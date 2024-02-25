using System.Collections;
using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    protected const float m_reachDistance = 0.3f;

    [SerializeField] protected float m_timeToDeath;
    [SerializeField] protected MonsterData m_monsterData;
    [SerializeField] protected GameObject m_target;
    [SerializeField] protected Rigidbody m_rigidbody;
    protected int m_currentHP;

    public Vector3 Velocity { get => m_rigidbody.velocity; }
    public GameObject Target { get => m_target; set => m_target = value; }
    public int CurrentHP { get => m_currentHP; }

    public void GetDamage(int damage)
    {
        m_currentHP -= damage;
    }

    public void Death()
    {
        //GetComponent<Animator>().SetTrigger("Death");
        m_rigidbody.velocity = Vector3.zero;
        gameObject.SetActive(false);
        //StartCoroutine(WaitForDeath());
    }
    public IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(m_timeToDeath);

        gameObject.SetActive(false);
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }

    public void Launch()
    {
        m_currentHP = m_monsterData.MaxHP;
        m_rigidbody.velocity = (Target.transform.position - transform.position).normalized * m_monsterData.Speed;
    }
}
