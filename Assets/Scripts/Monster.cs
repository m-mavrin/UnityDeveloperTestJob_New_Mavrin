using UnityEngine;

public class Monster : MonoBehaviour
{
    const float reachDistance = 0.3f;
    public float speed = 5f;
    public int maxHP;
    public int HP;
    public GameObject moveTarget;

    private Rigidbody m_rigidbody;

    void Start()
    {
        HP = maxHP;
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.velocity = (moveTarget.transform.position - transform.position).normalized * speed;
    }

    void Update()
    {
        if (moveTarget == null)
            return;

        if ((moveTarget.transform.position - transform.position).sqrMagnitude < reachDistance)
        {
            Destroy(gameObject);
        }

        if (HP <= 0)
        {
            GetComponent<Animator>().SetTrigger("Death");
            m_rigidbody.velocity = Vector3.zero;
            Destroy(gameObject, 1.2f);
        }
    }
}
