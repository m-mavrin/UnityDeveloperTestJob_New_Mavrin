using UnityEngine;

public class Monster : MonoBehaviour
{
    const float reachDistance = 0.3f;

    [SerializeField] private MonsterData m_monsterData;
    public GameObject moveTarget;

    private Rigidbody m_rigidbody;
    private int m_HP;

    void Start()
    {
        m_HP = m_monsterData.MaxHP;
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.velocity = (moveTarget.transform.position - transform.position).normalized * m_monsterData.Speed;
    }

    void Update()
    {
        if (moveTarget == null)
            return;

        if ((moveTarget.transform.position - transform.position).sqrMagnitude < reachDistance)
        {
            Destroy(gameObject);
        }

        if (m_HP <= 0)
        {
            GetComponent<Animator>().SetTrigger("Death");
            m_rigidbody.velocity = Vector3.zero;
            Destroy(gameObject, 1.2f);
        }
    }

    public void GetDamage(int damage)
    {
        m_HP -= damage;
    }
}
