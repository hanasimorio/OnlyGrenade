using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SePlayerController : MonoBehaviour
{
    [SerializeField,Tooltip("歩く時の足音")] AudioClip[] walkclips;
    [SerializeField,Tooltip("走るときの足音")] AudioClip[] Dashclips;
    [SerializeField, Tooltip("投げる時の音")] AudioClip throwclip;
    [SerializeField, Tooltip("死んだときの音")] AudioClip deadclip;
    [SerializeField, Tooltip("倒れる音")] AudioClip taoreruclip;
    [SerializeField] float pitchRange = 0.1f;
    private AudioSource AS;

    private void Awake()
    {
        AS = gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// 投げる時の音
    /// </summary>
    public void ThrowSe()
    {
        AS.PlayOneShot(throwclip);
    }

    /// <summary>
    /// 死んだときの音
    /// </summary>
    public void deadSe()
    {
        StartCoroutine(deathSE());
    }

    /// <summary>
    /// 歩く時の音
    /// </summary>
    public void WalkFootstepSE()
    {
        AS.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);
        AS.PlayOneShot(walkclips[Random.Range(0, walkclips.Length)]);
    }

    /// <summary>
    /// 走るときの音
    /// </summary>
    public void DashFootstepSE()
    {
        AS.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);
        AS.PlayOneShot(Dashclips[Random.Range(0, Dashclips.Length)]);
    }

    IEnumerator deathSE()
    {
        AS.PlayOneShot(deadclip);
        yield return new WaitForSeconds(1.7f);
        AS.PlayOneShot(taoreruclip);
    }

}
