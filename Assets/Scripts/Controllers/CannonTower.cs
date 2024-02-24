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
                Rotate();
                Shoot(false);
            }
        }
    }

    private void Rotate()
    {
        var targetPosition = CalculateLeadPoint(m_target.transform.position, m_target.Velocity, m_towerData.ProjectileSpeed);
        var angle = Quaternion.LookRotation(targetPosition - m_shootPoint.position);

        transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * m_towerData.RotationSpeed);
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