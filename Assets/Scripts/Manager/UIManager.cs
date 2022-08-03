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
    // Start is called before the first frame update
    void Start()
    {
        grenum = playerui.transform.Find("num").gameObject.transform.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (opeflag == false)
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                operateUI();
                opeflag = true;
            }    
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                opeflag = false;
                deleteope();
            }
        }
    }
    public void operateUI()
    {
        operate.SetActive(true);
    }

    private void deleteope()
    {
        operate.SetActive(false);
    }

    public void deathUI()
    {
        death.SetActive(true);
    }

    public void clearUI()
    {
        clear.SetActive(true);
    }


    public void resetUI()
    {
        operate.SetActive(false);
        death.SetActive(false);
        clear.SetActive(false);
    }

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

