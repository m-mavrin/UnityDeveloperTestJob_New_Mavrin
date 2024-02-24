using UnityEngine;

public class CannonTower : TowerBase
{
    void Update()
    {
        if (m_towerData.ProjectilePrefab == null || m_controller == null)
            return;

        if (m_controller.isGameStarted)
        {
            if (m_target == null)
            {
                m_target = FindTarget();
            }
            else
            {
                var targetPosition = CalculateLeadPoint(m_target.transform.position, m_target.GetComponent<Rigidbody>().velocity, m_towerData.ProjectileSpeed);
                var angle = Quaternion.LookRotation(targetPosition - m_shootPoint.position);

                transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * m_towerData.RotationSpeed);

                Shoot(false);
            }
        }
    }

    private Vector3 CalculateLeadPoint(Vector3 targetPosition, Vector3 targetVelocity, float projectileSpeed)
    {
        Vector3 relativePosition = targetPosition - transform.position;
        float distance = relativePosition.magnitude;
        float timeToImpact = distance / projectileSpeed;
        Vector3 leadPoint = targetPosition + targetVelocity * timeToImpact;
        leadPoint.y += m_target.gameObject.transform.localScale.y;

        return leadPoint;
    }
}