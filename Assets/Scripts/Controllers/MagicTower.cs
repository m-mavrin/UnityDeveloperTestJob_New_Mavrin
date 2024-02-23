using UnityEngine;

public class MagicTower : MonoBehaviour
{
    public float shootInterval;
    public float range;
    public GameObject projectile;
    public GameController controller;

    private float m_lastShotTime = -0.5f;
    private Monster m_target = null;

    void Update()
    {
        if (projectile == null || controller == null)
            return;

        if (controller.isGameStarted)
        {
            if (m_target == null || m_target.HP <= 0)
            {
                m_target = FindTarget();
            }
            else
            {
                if (Time.time < m_lastShotTime + shootInterval)
                    return;

                var newProjectile = Instantiate(projectile, transform.position + Vector3.up * 1.5f, Quaternion.identity);
                var projectileBeh = newProjectile.GetComponent<GuidedProjectile>();
                projectileBeh.target = m_target.gameObject;

                m_lastShotTime = Time.time;
            }
        }
    }

    private Monster FindTarget()
    {
        foreach (var monster in FindObjectsOfType<Monster>())
        {
            if (Vector3.Distance(transform.position, monster.transform.position) > range)
                continue;

            return monster;
        }

        return null;
    }
}
