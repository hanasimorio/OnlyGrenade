using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AEnemyMove : MonoBehaviour
{
    [SerializeField,Tooltip("í«Ç¢Ç©ÇØÇÈëŒè€")] private GameObject player;

    private bool findplayer = false;

    private NavMeshAgent nav;

    private EnemyStatus status;

    private Animator ani;

    private EnemyFind find;

    private SeEnemyController se;


    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
        status = gameObject.GetComponent<EnemyStatus>();
        ani = gameObject.GetComponent<Animator>();
        find = gameObject.transform.GetChild(2).gameObject.GetComponent<EnemyFind>();
        se = gameObject.GetComponent<SeEnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!status.isdead)//éÄÇÒÇ≈Ç¢ÇÈÇ©îªíË
        {
            player = find.player;
            if (player != null)//ÉvÉåÉCÉÑÅ[Çå©Ç¬ÇØÇƒÇ¢ÇÈÇ©
            {
                nav.destination = player.transform.position;
                ani.SetBool("Chase", true);
                if (!findplayer)
                {
                    findplayer = true;
                    se.findeye();
                }
            }
        }
        else
        {
            ani.SetBool("Death", true);
        }
        
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("hit");
            if(player == null)
            {
                player = other.gameObject;
            }
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        var pl = collision.gameObject.GetComponent<IPlayerDamage>();
        if (pl != null)
        {
            pl.ApplyDamage(200);
        }
    }

}
