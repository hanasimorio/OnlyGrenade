using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFind : MonoBehaviour
{

    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))//ƒvƒŒƒCƒ„[‚ğŒ©‚Â‚¯‚½‚ç
        {
            //Debug.Log("hit");
            if (player == null)
            {
                player = other.gameObject;
            }
        }
    }
}
