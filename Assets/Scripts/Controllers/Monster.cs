using System;

public class Monster : MonsterBase
{
    public event Action onKilled;
    public event Action onDestroy;

    void Start()
    {
        onKilled += Death;
        onDestroy += Destroy;
    }

    void Update()
    {
        if (m_target == null)
            return;

        if ((m_target.transform.position - transform.position).sqrMagnitude < m_reachDistance)
        {
            onDestroy?.Invoke();
            m_target = null;
        }

        if (m_currentHP <= 0)
        {
            onKilled?.Invoke();
            m_target = null;
        }
    }
}
