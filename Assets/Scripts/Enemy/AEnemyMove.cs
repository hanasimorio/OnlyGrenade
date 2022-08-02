using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AEnemyMove : MonoBehaviour
{
    [SerializeField,Tooltip("í«Ç¢Ç©ÇØÇÈëŒè€")] private GameObject player;

    private NavMeshAgent nav;

    private EnemyStatus status;

    private Animator ani;

    private EnemyFind find;

    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
        status = gameObject.GetComponent<EnemyStatus>();
        ani = gameObject.GetComponent<Animator>();
        find = gameObject.transform.GetChild(2).gameObject.GetComponent<EnemyFind>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!status.isdead)
        {
            player = find.player;
            if (player != null)
            {
                nav.destination = player.transform.position;
                ani.SetBool("Chase", true);
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
