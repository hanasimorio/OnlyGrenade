using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject operate;
    [SerializeField] private GameObject death;
    [SerializeField] private GameObject clear;
    [SerializeField] private GameObject playerui;

    private bool opeflag = false;
    private Text grenum;
    private Image im;
    // Start is called before the first frame update
    void Start()
    {
        grenum = playerui.transform.Find("num").gameObject.transform.gameObject.GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (opeflag == false)//������@��������
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                operateUI();
                opeflag = true;
            }    
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.T))//������@������
            {
                opeflag = false;
                deleteope();
            }
        }
    }
    /// <summary>
    /// ������@��\������
    /// </summary>
    public void operateUI()
    {
        operate.SetActive(true);
    }
    /// <summary>
    /// ������@���\���ɂ���
    /// </summary>
    private void deleteope()
    {
        operate.SetActive(false);
    }
    /// <summary>
    /// ���񂾂Ƃ���ui��\������
    /// </summary>
    public void deathUI()
    {
        death.SetActive(true);
    }
    /// <summary>
    /// �N���A�����Ƃ���ui��\������
    /// </summary>
    public void clearUI()
    {
        clear.SetActive(true);
    }

    /// <summary>
    /// ui�����ׂĔ�\���ɂ���
    /// </summary>
    public void resetUI()
    {
        operate.SetActive(false);
        death.SetActive(false);
        clear.SetActive(false);
    }
    /// <summary>
    /// �O���l�[�h�̐���ύX����
    /// </summary>
    /// <param name="num"></param>
    public void changegrenade(int num)
    {
        if(grenum != null)
        {
            grenum.text = num.ToString("00");
        }
    }
    
}

    /*public void feedout()
    {
        float a  = 1.0f;
        a -= Time.deltaTime;
        while (a < 0)
        {
            im.color = new Color(0, 0, 0, a);
        }
    }*/

