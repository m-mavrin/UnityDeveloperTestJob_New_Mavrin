using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    protected const float m_reachDistance = 0.3f;

    [SerializeField] protected float m_timeToDeath;
    [SerializeField] protected MonsterData m_monsterData;
    [SerializeField] protected GameObject m_target;

    protected Rigidbody m_rigidbody;
    protected int m_currentHP;

    public Vector3 Velocity { get => m_rigidbody.velocity; }
    public GameObject Target { get => m_target; set => m_target = value; }

    public void GetDamage(int damage)
    {
        m_currentHP -= damage;
    }

    public void Death()
    {
        GetComponent<Animator>().SetTrigger("Death");
        m_rigidbody.velocity = Vector3.zero;
        Destroy(gameObject, m_timeToDeath);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
