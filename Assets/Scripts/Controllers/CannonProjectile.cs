using UnityEngine;

public class CannonProjectile : ProjectileBase
{
    [SerializeField] protected Rigidbody m_rigidbody;

    public void StartMove()
    {
        m_rigidbody.velocity = transform.forward * m_speed;
    }

    public override void Launch()
    {
        base.Launch();
        StartMove();
    }
}
