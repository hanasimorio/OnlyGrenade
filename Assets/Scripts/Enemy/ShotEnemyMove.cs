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

    private EnemyStatus status;

    private EnemyFind find;

    private SeEnemyController se;

    private Animator ani;


    // Start is called before the first frame update
    void Start()
    {
        player = null;
        status = gameObject.GetComponent<EnemyStatus>();
        ani = gameObject.GetComponent<Animator>();
        find = gameObject.transform.GetChild(3).gameObject.GetComponent<EnemyFind>();
        se = gameObject.GetComponent<SeEnemyController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!status.isdead)//Ž€‚ñ‚Å‚¢‚é‚©”»’è
        {
            player = find.player;
            if (player != null)
            {
                target = player.transform.GetChild(3).gameObject;
                transform.LookAt(target.transform);
                shotpos.transform.LookAt(target.transform);
                if (!ontime)
                {
                    StartCoroutine(BulletShot());
                    ontime = true;
                    se.findeye();
                    ani.SetBool("Shot", true);
                }

            }
        }
        else
        {
            ani.SetBool("Death", true);
        }
        
    }

    /// <summary>
    /// ’e‚ð‘Å‚Â
    /// </summary>
    /// <returns></returns>
    IEnumerator BulletShot()
    {
        while(!status.isdead)
        {
            var bl = Instantiate(bullet, shotpos.position, Quaternion.identity);
            bl.GetComponent<Rigidbody>().AddForce(shotpos.forward * shotpower);
            se.shotse();
            Destroy(bl, 10.0f);
            yield return new WaitForSeconds(2.0f);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        var pl = collision.gameObject.GetComponent<IPlayerDamage>();
        if (pl != null)
        {
            pl.ApplyDamage(200);
        }
    }
}
