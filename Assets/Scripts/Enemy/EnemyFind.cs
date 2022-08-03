using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFind : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))//ÉvÉåÉCÉÑÅ[Çå©Ç¬ÇØÇΩÇÁ
        {
            //Debug.Log("hit");
            if (player == null)
            {
                player = other.gameObject;
            }
        }
    }
}
