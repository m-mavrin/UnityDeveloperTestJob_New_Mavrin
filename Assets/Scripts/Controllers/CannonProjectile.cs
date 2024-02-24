using UnityEngine;

public class CannonProjectile : ProjectileBase
{
    private Rigidbody m_rigidbody;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        StartMove();
    }

    public void StartMove()
    {
        m_rigidbody.velocity = transform.forward * m_speed;
    }
}
