using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeEnemyController : MonoBehaviour
{
    [SerializeField, Tooltip("弾を打つ音")] AudioClip Shotclip;
    [SerializeField, Tooltip("走るときの足音")] AudioClip[] Dashclips;
    [SerializeField, Tooltip("死んだときの音")] AudioClip deadclip;
    [SerializeField, Tooltip("倒れる音")] AudioClip taoreruclip;
    [SerializeField, Tooltip("発見した音")] AudioClip findclip;
    [SerializeField] float pitchRange = 0.1f;
    private AudioSource AS;
  
    void Start()
    {
        AS = gameObject.GetComponent<AudioSource>();
    }

    public void shotse()
    {
        AS.PlayOneShot(Shotclip);
    }

    /// <summary>
    /// 見つけた時の音
    /// </summary>
    public void findeye()
    {
        AS.PlayOneShot(findclip);
    }

    /// <summary>
    /// 死んだときに音をだす
    /// </summary>
    public void deadSe()
    {
        StartCoroutine(deathSE());
    }

    /// <summary>
    /// 追いかけているときの音
    /// </summary>
    public void DashFootstepSE()
    {
        AS.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);
        AS.PlayOneShot(Dashclips[Random.Range(0, Dashclips.Length)]);
    }

    /// <summary>
    /// 死んだときの音
    /// </summary>
    /// <returns></returns>
    IEnumerator deathSE()
    {
        AS.PlayOneShot(deadclip);
        yield return new WaitForSeconds(1.7f);
        AS.PlayOneShot(taoreruclip);
    }
}
