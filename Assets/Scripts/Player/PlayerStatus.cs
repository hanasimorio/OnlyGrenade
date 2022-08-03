using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour,IPlayerDamage
{
    // Start is called before the first frame update
    [SerializeField] private float hp;
    public bool isdead = false;
    private UIManager UI;

    public int grenadenum;//�O���l�[�h�̐�

    private void Start()
    {
        UI = GameObject.Find("UIManager").transform.gameObject.GetComponent<UIManager>();
        UI.changegrenade(grenadenum);
    }

    public void changegre()
    {
        UI.changegrenade(grenadenum);
    }

    /// <summary>
    /// �C���^�[�t�F�C�X�ɂ���ă_���[�W���^����ꂽ��
    /// </summary>
    /// <param name="damage"></param>
    public void ApplyDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            isdead = true;
            if(UI !=null)
            UI.deathUI();
        }
    }
}
