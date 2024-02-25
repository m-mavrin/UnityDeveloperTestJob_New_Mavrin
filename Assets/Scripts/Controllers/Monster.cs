using System;
using UnityEngine;

public class Monster : MonsterBase
{
    public event Action onKilled;
    public event Action onDestroy;

    void Start()
    {
        onKilled += Death;
        onDestroy += Destroy;

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
            onDestroy?.Invoke();
        }

        if (m_currentHP <= 0)
        {
            onKilled?.Invoke();
            m_target = null;
        }
    }
}
