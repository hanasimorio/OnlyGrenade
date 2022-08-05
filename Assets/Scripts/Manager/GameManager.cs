using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum state
    {
        Title,
        playing,
        dead,
        clear,
    }

    private state currentstate;

    public static GameManager instance = null;
    private ChangeScene cs;

    public int stagenum = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        SetState(state.Title);
        cs = GameObject.Find("SceneManager").gameObject.GetComponent<ChangeScene>() ;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(currentstate == state.Title)
        {
            if(Input.anyKey)
            {
                if (cs != null)
                    cs.nextstage();

            }
        }
    }

    // Update is called once per frame
    public void SetState(state st)
    {
        currentstate = st;
        changestate(currentstate);
    }

    private void changestate(state st)
    {
        switch (st)
        {
            case state.Title:
                Cursor.visible = true;
                break;

            case state.playing:
                Cursor.visible = false;
                break;

            case state.dead:
                Cursor.visible = true;
                break;

            case state.clear:
                Cursor.visible = true;
                break;
        }
    }



}
