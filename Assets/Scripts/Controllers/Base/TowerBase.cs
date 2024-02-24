using UnityEngine;

public class TowerBase : MonoBehaviour
{
    [SerializeField] protected TowerData m_towerData;
    [SerializeField] protected GameController m_controller;
    [SerializeField] protected Transform m_shootPoint;

    protected float m_lastShotTime = -0.5f;
    protected Monster m_target = null;

    protected Monster FindTarget()
    {
        foreach (var monster in FindObjectsOfType<Monster>())
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

        var newProjectile = Instantiate(m_towerData.ProjectilePrefab, m_shootPoint.position, m_shootPoint.rotation);

        if (isGuided)
        {
            newProjectile.GetComponent<GuidedProjectile>().Target = m_target.gameObject;
        }
        m_lastShotTime = Time.time;
    }
}
