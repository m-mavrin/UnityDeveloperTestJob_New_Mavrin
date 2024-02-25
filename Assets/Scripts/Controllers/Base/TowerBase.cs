using UnityEngine;

public class TowerBase : MonoBehaviour
{
    [SerializeField] protected TowerData m_towerData;
    [SerializeField] protected GameController m_controller;
    [SerializeField] protected Transform m_shootPoint;
    [SerializeField] protected Transform m_projectileContainer;

    protected float m_lastShotTime = -0.5f;
    protected Monster m_target = null;
    protected Pool<ProjectileBase> m_projectilePool;

    private void Start()
    {
        m_projectilePool = new Pool<ProjectileBase>(m_towerData.ProjectilePrefab, m_projectileContainer);
    }

    protected Monster FindTarget()
    {
        foreach (var monster in FindObjectsOfType<Monster>(false))
        {
            if (Vector3.Distance(transform.position, monster.transform.position) > m_towerData.ShootRange)
                continue;

            return monster;
        }

        return null;
    }

    public void Shoot(bool isGuided)
    {
        if (m_lastShotTime + m_towerData.ShootInterval > Time.time)
            return;

        var newProjectile = m_projectilePool.GetFreeElement();
        newProjectile.transform.position = m_shootPoint.position;
        newProjectile.transform.rotation = m_shootPoint.rotation;
        newProjectile.Launch();

        if (isGuided)
        {
            newProjectile.Target = m_target.gameObject;
        }
        m_lastShotTime = Time.time;
    }

    protected bool IsTargetDead()
    {
        return m_target.CurrentHP <= 0;
    }
}
