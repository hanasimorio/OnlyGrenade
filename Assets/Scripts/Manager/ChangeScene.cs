using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �^�C�g���ɑJ��
    /// </summary>
    public void Title()
    {
        GameManager.instance.SetState(GameManager.state.Title);
        GameManager.instance.stagenum = 1;
        SceneManager.LoadScene(0);
        
    }

    /// <summary>
    /// ������x�v���C
    /// </summary>
    public void replay()
    {
        GameManager.instance.SetState(GameManager.state.playing);
        SceneManager.LoadScene(GameManager.instance.stagenum);
    }
    /// <summary>
    /// ���̃X�e�[�W��
    /// </summary>
    public void nextstage()
    {
        GameManager.instance.stagenum += 1;
        GameManager.instance.SetState(GameManager.state.playing);
        SceneManager.LoadScene(GameManager.instance.stagenum);
    }
}
