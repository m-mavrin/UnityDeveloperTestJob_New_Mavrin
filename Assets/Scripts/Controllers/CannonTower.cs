using UnityEngine;

public class CannonTower : TowerBase
{
    [SerializeField] protected Transform m_verticalCannonPart;
    [SerializeField] protected Transform m_horizontalCannonPart;

    private Quaternion m_defaultVerticalRotation;
    private Quaternion m_defaultHorizontalRotation;

    protected override void Start()
    {
        base.Start();

        m_defaultVerticalRotation = m_verticalCannonPart.rotation;
        m_defaultHorizontalRotation = m_horizontalCannonPart.rotation;
    }

    void Update()
    {
        if (m_towerData.ProjectilePrefab == null || m_controller == null)
            return;

        if (m_controller.isGameStarted)
        {
            if (m_target == null || !m_target.IsAlive())
            {
                m_target = FindTarget();
            }
            else
            {
                Rotate();
                Shoot(false);
            }
        }
        else
        {
            SetDefaultRotate();
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

    private void SetDefaultRotate()
    {
        m_horizontalCannonPart.rotation = m_defaultHorizontalRotation;
        m_verticalCannonPart.rotation = m_defaultVerticalRotation;
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