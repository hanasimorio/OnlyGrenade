using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour,IPlayerDamage
{
    // Start is called before the first frame update
    [SerializeField] private float hp;
    public bool isdead = false;
    private UIManager UI;
    private SePlayerController se;

    public int grenadenum;//グレネードの数

    private void Start()
    {
        UI = GameObject.Find("UIManager").transform.gameObject.GetComponent<UIManager>();
        UI.changegrenade(grenadenum);
        se = gameObject.GetComponent<SePlayerController>();
    }

    public void changegre()
    {
        UI.changegrenade(grenadenum);
    }

    /// <summary>
    /// インターフェイスによってダメージが与えられたら
    /// </summary>
    /// <param name="damage"></param>
    public void ApplyDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0 && !isdead)
        {
            isdead = true;
            se.deadSe();
            if(UI !=null)
            UI.deathUI();
        }
    }
}
