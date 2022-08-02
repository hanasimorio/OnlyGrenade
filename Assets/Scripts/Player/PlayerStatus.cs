using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour,IPlayerDamage
{
    // Start is called before the first frame update
    [SerializeField] private float hp;
    public bool isdead = false;
    
    public void ApplyDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            isdead = true;
        }
    }
}
