using System;

public class Monster : MonsterBase
{
    public event Action onKilled;
    public event Action onDestroy;

    void Update()
    {
        if (m_target == null)
            return;

        if ((m_target.transform.position - transform.position).sqrMagnitude < m_reachDistance)
        {
            m_target = null;
            onDestroy?.Invoke();
        }

        if (m_currentHP <= 0)
        {
            m_target = null;
            onKilled?.Invoke();
        }
    }

    private void OnEnable()
    {
        onKilled = Death;
        onDestroy = Destroy;
    }
}
