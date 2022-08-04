using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum state
    {
        Title,
        playing,
        clear,
    }

    private state currentstate;

    public static GameManager instance = null;

    public int stagenum = 1;
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
                SceneManager.LoadScene("TutorialScene");
                SetState(state.playing);

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

                break;
        }
    }



}
