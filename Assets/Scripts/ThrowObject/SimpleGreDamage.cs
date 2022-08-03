using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGreDamage : MonoBehaviour
{
    [SerializeField] float m_force = 20;
    [SerializeField] float m_radius = 5;
    [SerializeField] float m_upwards = 0;
    private Vector3 m_position;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<IDamage>();//インターフェイス
        if (enemy != null)
        {
            enemy.ApplyDamage(200);
        }
    }

    public void Explosion()
    {
        m_position = gameObject.transform.position;

        // 範囲内のRigidbodyにAddExplosionForce
        Collider[] hitColliders = Physics.OverlapSphere(m_position, m_radius);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            var rb = hitColliders[i].GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddExplosionForce(m_force, m_position, m_radius, m_upwards, ForceMode.Impulse);
            }
        }
    }
}
