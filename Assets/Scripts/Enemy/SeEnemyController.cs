using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeEnemyController : MonoBehaviour
{
    [SerializeField, Tooltip("����Ƃ��̑���")] AudioClip[] Dashclips;
    [SerializeField, Tooltip("���񂾂Ƃ��̉�")] AudioClip deadclip;
    [SerializeField, Tooltip("�|��鉹")] AudioClip taoreruclip;
    [SerializeField, Tooltip("����������")] AudioClip findclip;
    [SerializeField] float pitchRange = 0.1f;
    private AudioSource AS;
  
    void Start()
    {
        AS = gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// ���������̉�
    /// </summary>
    public void findeye()
    {
        AS.PlayOneShot(findclip);
    }

    /// <summary>
    /// ���񂾂Ƃ��ɉ�������
    /// </summary>
    public void deadSe()
    {
        StartCoroutine(deathSE());
    }

    /// <summary>
    /// �ǂ������Ă���Ƃ��̉�
    /// </summary>
    public void DashFootstepSE()
    {
        AS.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);
        AS.PlayOneShot(Dashclips[Random.Range(0, Dashclips.Length)]);
    }

    /// <summary>
    /// ���񂾂Ƃ��̉�
    /// </summary>
    /// <returns></returns>
    IEnumerator deathSE()
    {
        AS.PlayOneShot(deadclip);
        yield return new WaitForSeconds(1.7f);
        AS.PlayOneShot(taoreruclip);
    }
}
