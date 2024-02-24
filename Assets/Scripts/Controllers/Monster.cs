using UnityEngine;

public class Monster : MonsterBase
{
    void Start()
    {
        m_currentHP = m_monsterData.MaxHP;
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.velocity = (Target.transform.position - transform.position).normalized * m_monsterData.Speed;
    }

    void Update()
    {
        if (m_target == null)
            return;

        if ((m_target.transform.position - transform.position).sqrMagnitude < m_reachDistance)
        {
            Destroy(gameObject);
        }

        if (m_currentHP <= 0)
        {
            Death();
        }
    }
}
