using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearGate : MonoBehaviour
{
    // Start is called before the first frame update

    private UIManager UI;
    void Start()
    {
        UI = GameObject.Find("UIManager").transform.gameObject.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(UI != null)
        UI.clearUI();
        GameManager.instance.SetState(GameManager.state.clear);
    }
}
