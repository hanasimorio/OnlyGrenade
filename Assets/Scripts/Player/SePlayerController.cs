using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SePlayerController : MonoBehaviour
{
    [SerializeField,Tooltip("�������̑���")] AudioClip[] walkclips;
    [SerializeField,Tooltip("����Ƃ��̑���")] AudioClip[] Dashclips;
    [SerializeField, Tooltip("�����鎞�̉�")] AudioClip throwclip;
    [SerializeField, Tooltip("���񂾂Ƃ��̉�")] AudioClip deadclip;
    [SerializeField, Tooltip("�|��鉹")] AudioClip taoreruclip;
    [SerializeField] float pitchRange = 0.1f;
    private AudioSource AS;

    private void Awake()
    {
        AS = gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// �����鎞�̉�
    /// </summary>
    public void ThrowSe()
    {
        AS.PlayOneShot(throwclip);
    }

    /// <summary>
    /// ���񂾂Ƃ��̉�
    /// </summary>
    public void deadSe()
    {
        StartCoroutine(deathSE());
    }

    /// <summary>
    /// �������̉�
    /// </summary>
    public void WalkFootstepSE()
    {
        AS.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);
        AS.PlayOneShot(walkclips[Random.Range(0, walkclips.Length)]);
    }

    /// <summary>
    /// ����Ƃ��̉�
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
