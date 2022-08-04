using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGrenadeController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject exp;
    [SerializeField] private AudioClip expclip;

    private AudioSource AS;
    void Start()
    {
        StartCoroutine(createexp());
        AS = gameObject.GetComponent<AudioSource>();
    }

    IEnumerator createexp()
    {
        yield return new WaitForSeconds(5f);
        AS.PlayOneShot(expclip);
        Instantiate(exp, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }

}
