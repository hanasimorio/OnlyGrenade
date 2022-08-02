using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGrenadeController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject exp;
    void Start()
    {
        StartCoroutine(createexp());
    }

    IEnumerator createexp()
    {
        yield return new WaitForSeconds(5f);
        Instantiate(exp, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

}
