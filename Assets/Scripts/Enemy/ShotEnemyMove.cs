using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemyMove : MonoBehaviour
{
    private GameObject player;

    [SerializeField, Tooltip("BulletObject")] private GameObject bullet;

    [SerializeField, Tooltip("’e‚ð‘Å‚ÂˆÊ’u")] private Transform shotpos;

    [SerializeField] private float shotpower;

    private GameObject target;

    private bool ontime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(player!=null)
        {
            transform.LookAt(target.transform);
            shotpos.transform.LookAt(target.transform);
            if (!ontime)
            {
                StartCoroutine(BulletShot());
                ontime = true;
            }

        }
        
    }

    IEnumerator BulletShot()
    {
        while(true)
        {
            var bl = Instantiate(bullet, shotpos.position, Quaternion.identity);
            bl.GetComponent<Rigidbody>().AddForce(shotpos.forward * shotpower);
            Destroy(bl, 10.0f);
            yield return new WaitForSeconds(2.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(player == null)
            {
                player = other.gameObject;
                target = player.transform.GetChild(3).gameObject;
            }
        }
    }
}
