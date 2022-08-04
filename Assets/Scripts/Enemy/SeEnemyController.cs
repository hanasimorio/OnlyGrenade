using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeEnemyController : MonoBehaviour
{
    [SerializeField, Tooltip("‘–‚é‚Æ‚«‚Ì‘«‰¹")] AudioClip[] Dashclips;
    [SerializeField, Tooltip("Ž€‚ñ‚¾‚Æ‚«‚Ì‰¹")] AudioClip deadclip;
    [SerializeField, Tooltip("“|‚ê‚é‰¹")] AudioClip taoreruclip;
    [SerializeField, Tooltip("”­Œ©‚µ‚½‰¹")] AudioClip findclip;
    [SerializeField] float pitchRange = 0.1f;
    private AudioSource AS;
  
    void Start()
    {
        AS = gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// Œ©‚Â‚¯‚½Žž‚Ì‰¹
    /// </summary>
    public void findeye()
    {
        AS.PlayOneShot(findclip);
    }

    /// <summary>
    /// Ž€‚ñ‚¾‚Æ‚«‚É‰¹‚ð‚¾‚·
    /// </summary>
    public void deadSe()
    {
        StartCoroutine(deathSE());
    }

    /// <summary>
    /// ’Ç‚¢‚©‚¯‚Ä‚¢‚é‚Æ‚«‚Ì‰¹
    /// </summary>
    public void DashFootstepSE()
    {
        AS.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);
        AS.PlayOneShot(Dashclips[Random.Range(0, Dashclips.Length)]);
    }

    /// <summary>
    /// Ž€‚ñ‚¾‚Æ‚«‚Ì‰¹
    /// </summary>
    /// <returns></returns>
    IEnumerator deathSE()
    {
        AS.PlayOneShot(deadclip);
        yield return new WaitForSeconds(1.7f);
        AS.PlayOneShot(taoreruclip);
    }
}
