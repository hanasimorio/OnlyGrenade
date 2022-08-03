using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour,IDamage
{
    // Start is called before the first frame update

    [SerializeField] private float hp;
    public bool isdead = false;

    /// <summary>
    /// インターフェイスによってダメージが与えられる
    /// </summary>
    /// <param name="damage"></param>
    public void ApplyDamage(float damage)
    {
        hp -= damage;
        if(hp < 0)
        {
            isdead = true;
            Invoke("brea", 5);
            
        }
    }

    private void brea()
    {
        Destroy(this.gameObject);
    }
}
