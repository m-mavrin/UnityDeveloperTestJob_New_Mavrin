using UnityEngine;

public class CannonTower : MonoBehaviour
{
    public float shootInterval;
    public float range;
    public float rotationSpeed;
    public GameObject projectile;
    public Transform shootPoint;
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
                var targetPosition = CalculateLeadPoint(m_target.transform.position, m_target.GetComponent<Rigidbody>().velocity, projectile.GetComponent<CannonProjectile>().speed);
                targetPosition.y += m_target.gameObject.transform.localScale.y;

                var angle = Quaternion.LookRotation(targetPosition - shootPoint.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * rotationSpeed);
                Shoot();
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

    public void Shoot()
    {
        if (m_lastShotTime + shootInterval > Time.time)
            return;

        Instantiate(projectile, shootPoint.position, shootPoint.rotation);
        m_lastShotTime = Time.time;
    }

    private Vector3 CalculateLeadPoint(Vector3 targetPosition, Vector3 targetVelocity, float projectileSpeed)
    {
        Vector3 relativePosition = targetPosition - transform.position;
        float distance = relativePosition.magnitude;
        float timeToImpact = distance / projectileSpeed;
        Vector3 leadPoint = targetPosition + targetVelocity * timeToImpact;

        return leadPoint;
    }
}