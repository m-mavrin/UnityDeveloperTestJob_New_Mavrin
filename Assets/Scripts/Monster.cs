using UnityEngine;

public class Monster : MonoBehaviour
{
    const float m_reachDistance = 0.3f;
    public float m_speed = 5f;
    public int m_maxHP = 30;
    public int m_hp;
    public GameObject m_moveTarget;

    void Start()
    {
        m_hp = m_maxHP;
    }

    void Update()
    {
        if (m_moveTarget == null)
            return;

        if ((m_moveTarget.transform.position - transform.position).sqrMagnitude < m_reachDistance)
        {
            Destroy(gameObject);
        }

        if (m_hp <= 0)
        {
            GetComponent<Animator>().SetTrigger("Death");
            Destroy(gameObject, 1.2f);
        }

        transform.position += (m_moveTarget.transform.position - transform.position).normalized * m_speed * Time.deltaTime;
    }
}
