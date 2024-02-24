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

        Vector3 direction = targetPosition - transform.position;
        Quaternion horizontalRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        Quaternion verticalRotation = Quaternion.LookRotation(direction);

        m_horizontalCannonPart.rotation = Quaternion.Lerp(m_horizontalCannonPart.rotation, horizontalRotation, m_towerData.RotationSpeed * Time.deltaTime);
        m_verticalCannonPart.rotation = Quaternion.Lerp(m_verticalCannonPart.rotation, verticalRotation, m_towerData.RotationSpeed * Time.deltaTime);
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