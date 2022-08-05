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
        if (opeflag == false)//操作方法を見せる
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                operateUI();
                opeflag = true;
            }    
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.T))//操作方法を消す
            {
                opeflag = false;
                deleteope();
            }
        }
    }
    /// <summary>
    /// 操作方法を表示する
    /// </summary>
    public void operateUI()
    {
        operate.SetActive(true);
    }
    /// <summary>
    /// 操作方法を非表示にする
    /// </summary>
    private void deleteope()
    {
        operate.SetActive(false);
    }
    /// <summary>
    /// 死んだときのuiを表示する
    /// </summary>
    public void deathUI()
    {
        death.SetActive(true);
    }
    /// <summary>
    /// クリアしたときのuiを表示する
    /// </summary>
    public void clearUI()
    {
        clear.SetActive(true);
    }

    /// <summary>
    /// uiをすべて非表示にする
    /// </summary>
    public void resetUI()
    {
        operate.SetActive(false);
        death.SetActive(false);
        clear.SetActive(false);
    }
    /// <summary>
    /// グレネードの数を変更する
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

