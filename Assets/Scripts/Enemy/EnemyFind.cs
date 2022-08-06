using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFind : MonoBehaviour
{

    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))//プレイヤーを見つけたら
        {
            //Debug.Log("hit");
            if (player == null)
            {
                player = other.gameObject;
            }
        }
    }
}
