using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
   
    [SerializeField, Tooltip("爆弾のPrefab")]
    private GameObject bulletPrefab;

   
    [SerializeField, Tooltip("shotのPosition")]
    private GameObject barrelObject;

    
    private Vector3 instantiatePosition;

    private float cooldown = 2.0f;
    
    public Vector3 InstantiatePosition
    {
        get { return instantiatePosition; }
    }

   
    [SerializeField, Range(1.0F, 30.0F), Tooltip("弾の速さ")]
    private float speed = 1.0F;


    
    private Vector3 shootVelocity;
    
    public Vector3 ShootVelocity
    {
        get { return shootVelocity; }
    }

    void Update()
    {
        var wh = Input.GetAxis("Mouse ScrollWheel") * 5;//マウスホイールで強さを変更

        if (speed > 1) speed += wh;
        else speed = 1;

        if (speed < 30) speed += wh;
        else speed = 30;

        //Debug.Log(speed);
        cooldown += Time.deltaTime;
        
        
        // 弾の初速度を更新
        shootVelocity = barrelObject.transform.up * speed;

        // 弾の生成座標を更新
        instantiatePosition = barrelObject.transform.position;

        if (cooldown > 2.0f)
        {
            // 発射
            if (Input.GetMouseButtonUp(0))
            {

                // 弾を生成して飛ばす
                GameObject obj = Instantiate(bulletPrefab, instantiatePosition, Quaternion.identity);
                Rigidbody rid = obj.GetComponent<Rigidbody>();
                rid.AddForce(shootVelocity * rid.mass, ForceMode.Impulse);
                cooldown = 0.0f;

            }
        }
    }
}

