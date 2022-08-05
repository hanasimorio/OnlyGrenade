using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    private GameObject fadecanvas;

    private void Start()
    {
        fadecanvas = GameObject.Find("Fade");
        if(fadecanvas != null)
        fadecanvas.GetComponent<FadeController>().fadeIn();
    }
    /// <summary>
    /// �^�C�g���ɑJ��
    /// </summary>
    public async void Title()
    {
        GameManager.instance.SetState(GameManager.state.Title);
        GameManager.instance.stagenum = 0;
        if (fadecanvas != null)
            fadecanvas.GetComponent<FadeController>().fadeOut();
        await Task.Delay(4000);
        SceneManager.LoadScene(GameManager.instance.stagenum);
    }

    /// <summary>
    /// ������x�v���C
    /// </summary>
    public async void replay()
    {
        GameManager.instance.SetState(GameManager.state.playing);
        if (fadecanvas != null)
            fadecanvas.GetComponent<FadeController>().fadeOut();
        await Task.Delay(4000);
        SceneManager.LoadScene(GameManager.instance.stagenum);
    }
    /// <summary>
    /// ���̃X�e�[�W��
    /// </summary>
    public async void nextstage()
    {
        GameManager.instance.stagenum += 1;
        GameManager.instance.SetState(GameManager.state.playing);
        if (fadecanvas != null)
            fadecanvas.GetComponent<FadeController>().fadeOut();
        await Task.Delay(4000);
        SceneManager.LoadScene(GameManager.instance.stagenum);
    }

}
