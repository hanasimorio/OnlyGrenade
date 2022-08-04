using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour,IDamage
{
    // Start is called before the first frame update

    [SerializeField] private float hp;
    public bool isdead = false;

    private SeEnemyController se;

    private void Start()
    {
        se = gameObject.GetComponent<SeEnemyController>();
    }

    /// <summary>
    /// インターフェイスによってダメージが与えられる
    /// </summary>
    /// <param name="damage"></param>
    public void ApplyDamage(float damage)
    {
        hp -= damage;
        if(hp < 0 && !isdead)
        {
            isdead = true;
            Invoke("brea", 5);
            se.deadSe();
        }
    }

    private void brea()
    {
        Destroy(this.gameObject);
    }
}
