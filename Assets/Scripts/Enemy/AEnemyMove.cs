using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AEnemyMove : MonoBehaviour
{
    [SerializeField,Tooltip("í«Ç¢Ç©ÇØÇÈëŒè€")] private GameObject player;

    private NavMeshAgent nav;
    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            nav.destination = player.transform.position;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("hit");
            if(player == null)
            {
                player = other.gameObject;
            }
        }
    }
}
