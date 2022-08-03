using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chagecolor : MonoBehaviour
{
    // Start is called before the first frame update

    private float a;
    private bool flag = true;

    private Text text;
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        a = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            a -= Time.deltaTime;
            text.color = new Color(0, 0, 0, a);
            if (a < 0)
                flag = false;
        }
        else
        {
            a += Time.deltaTime;
            text.color = new Color(0, 0, 0, a);
            if (a > 1)
                flag = true;
        }
        
    }
}
