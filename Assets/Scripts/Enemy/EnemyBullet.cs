using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�ɓ���������_���[�W�ǂɐG�ꂽ�����
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        var pl = other.gameObject.GetComponent<IPlayerDamage>();
        if (pl != null)
        {
            pl.ApplyDamage(200);
        }
        else if(other.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
