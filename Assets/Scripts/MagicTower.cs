using UnityEngine;

public class MagicTower : MonoBehaviour
{
    public float m_shootInterval = 0.5f;
    public float m_range = 50f;
    public GameObject m_projectile;
    public GameController m_controller;

    private float m_lastShotTime = -0.5f;
    private Monster m_target = null;

    void Update()
    {
        if (m_projectile == null || m_controller == null)
            return;

        if (m_controller.isGameStarted)
        {
            if (m_target == null)
            {
                m_target = FindTarget();
            }
            else
            {
                if (Time.time < m_lastShotTime + m_shootInterval)
                    return;

                var projectile = Instantiate(m_projectile, transform.position + Vector3.up * 1.5f, Quaternion.identity);
                var projectileBeh = projectile.GetComponent<GuidedProjectile>();
                projectileBeh.m_target = m_target.gameObject;

                m_lastShotTime = Time.time;
            }
        }
    }

    private Monster FindTarget()
    {
        foreach (var monster in FindObjectsOfType<Monster>())
        {
            if (Vector3.Distance(transform.position, monster.transform.position) < m_range)
                continue;

            return monster;
        }

        return null;
    }
}
