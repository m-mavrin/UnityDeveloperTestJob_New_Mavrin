using UnityEngine;

public class CannonProjectile : MonoBehaviour
{
    public float speed;
    public int damage;

    private Rigidbody m_rigidbody;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.TryGetComponent<Monster>(out var monster))
            return;

        monster.HP -= damage;
        Destroy(gameObject);
    }
}
