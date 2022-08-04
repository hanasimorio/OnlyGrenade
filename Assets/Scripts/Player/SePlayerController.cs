using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SePlayerController : MonoBehaviour
{
    [SerializeField,Tooltip("•à‚­Žž‚Ì‘«‰¹")] AudioClip[] walkclips;
    [SerializeField,Tooltip("‘–‚é‚Æ‚«‚Ì‘«‰¹")] AudioClip[] Dashclips;
    [SerializeField, Tooltip("“Š‚°‚éŽž‚Ì‰¹")] AudioClip throwclip;
    [SerializeField, Tooltip("Ž€‚ñ‚¾‚Æ‚«‚Ì‰¹")] AudioClip deadclip;
    [SerializeField, Tooltip("“|‚ê‚é‰¹")] AudioClip taoreruclip;
    [SerializeField] float pitchRange = 0.1f;
    private AudioSource AS;

    private void Awake()
    {
        AS = gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// “Š‚°‚éŽž‚Ì‰¹
    /// </summary>
    public void ThrowSe()
    {
        AS.PlayOneShot(throwclip);
    }

    /// <summary>
    /// Ž€‚ñ‚¾‚Æ‚«‚Ì‰¹
    /// </summary>
    public void deadSe()
    {
        StartCoroutine(deathSE());
    }

    /// <summary>
    /// •à‚­Žž‚Ì‰¹
    /// </summary>
    public void WalkFootstepSE()
    {
        AS.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);
        AS.PlayOneShot(walkclips[Random.Range(0, walkclips.Length)]);
    }

    /// <summary>
    /// ‘–‚é‚Æ‚«‚Ì‰¹
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
