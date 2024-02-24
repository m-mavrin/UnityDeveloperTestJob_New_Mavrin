using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    private GameObject m_target;
    [SerializeField] protected float m_speed;
    [SerializeField] protected int m_damage;

    public GameObject Target { get => m_target; set => m_target = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Monster>(out var monster))
        {
            monster.GetDamage(m_damage);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        return;
    }
}
