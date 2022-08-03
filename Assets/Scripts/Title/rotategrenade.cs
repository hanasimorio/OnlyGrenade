using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotategrenade : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(new Vector3(0, 0.5f, 0));
    }
}
