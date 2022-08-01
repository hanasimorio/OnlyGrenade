using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAngle : MonoBehaviour
{
    /// <summary>
    /// 感度
    /// </summary>
    [SerializeField, Range(0.01F, 50.0F), Tooltip("感度")]
    private float sensitivity = 1.0F;

    /// <summary>
    /// 砲身のオブジェクト
    /// </summary>
    [SerializeField, Tooltip("ShotPosのオブジェクト")]
    private GameObject barrelObject;

    private bool ShotPre = false;


    void Update()
    {
        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(new Vector3(0F, -1.0F * sensitivity, 0F));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(new Vector3(0F, 1.0F * sensitivity, 0F));
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            barrelObject.transform.Rotate(new Vector3(-1.0F * sensitivity, 0F, 0F));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            barrelObject.transform.Rotate(new Vector3(1.0F * sensitivity, 0F, 0F));
        }*/

        if (Input.GetMouseButtonDown(0))
            ShotPre = true;

        if (Input.GetMouseButtonUp(0))
        {
            ShotPre = false;
        }

        
        if(ShotPre)
        {
            var mx = Input.GetAxis("Mouse Y");
            var xrotate =  -1 * mx * sensitivity;
            var currentangle = barrelObject.transform.eulerAngles.x;
            var a = currentangle + xrotate;
            //Debug.Log(a);
            if (a > 10 && a < 88)
            {
                barrelObject.transform.Rotate(new Vector3(xrotate, 0F, 0F));
            }
            

        }
        

    }
}

