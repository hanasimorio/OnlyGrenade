using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
   
    [SerializeField, Tooltip("���e��Prefab")]
    private GameObject bulletPrefab;

   
    [SerializeField, Tooltip("shot��Position")]
    private GameObject barrelObject;

    
    private Vector3 instantiatePosition;

    private float cooldown = 2.0f;
    
    public Vector3 InstantiatePosition
    {
        get { return instantiatePosition; }
    }

   
    [SerializeField, Range(1.0F, 30.0F), Tooltip("�e�̑���")]
    private float speed = 1.0F;


    
    private Vector3 shootVelocity;
    
    public Vector3 ShootVelocity
    {
        get { return shootVelocity; }
    }

    void Update()
    {
        var wh = Input.GetAxis("Mouse ScrollWheel") * 5;//�}�E�X�z�C�[���ŋ�����ύX

        if (speed > 1) speed += wh;
        else speed = 1;

        if (speed < 30) speed += wh;
        else speed = 30;

        //Debug.Log(speed);
        cooldown += Time.deltaTime;
        
        
        // �e�̏����x���X�V
        shootVelocity = barrelObject.transform.up * speed;

        // �e�̐������W���X�V
        instantiatePosition = barrelObject.transform.position;

        if (cooldown > 2.0f)
        {
            // ����
            if (Input.GetMouseButtonUp(0))
            {

                // �e�𐶐����Ĕ�΂�
                GameObject obj = Instantiate(bulletPrefab, instantiatePosition, Quaternion.identity);
                Rigidbody rid = obj.GetComponent<Rigidbody>();
                rid.AddForce(shootVelocity * rid.mass, ForceMode.Impulse);
                cooldown = 0.0f;

            }
        }
    }
}

