using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearGate : MonoBehaviour
{
    // Start is called before the first frame update

    private UIManager UI;

    private bool ontime = true;
    void Start()
    {
        UI = GameObject.Find("UIManager").transform.gameObject.GetComponent<UIManager>();
    }

    /// <summary>
    /// ÉSÅ[ÉãÇµÇΩèàóù
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (UI != null)
                UI.clearUI();
            if (ontime)
            {
                GameManager.instance.SetState(GameManager.state.clear);
                ontime = false;
            }
        }
    }
}
