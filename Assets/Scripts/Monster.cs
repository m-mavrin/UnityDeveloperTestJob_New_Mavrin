using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour 
{
	public GameObject m_moveTarget;
	private float m_speed = 5f;
    private int m_maxHP = 30;
	private Animator m_animator;
	const float m_reachDistance = 0.3f;

	public int m_hp;

	void Start() 
	{
		m_hp = m_maxHP;
		m_animator = GetComponent<Animator>();
	}

	void Update() 
	{
        if (m_moveTarget == null)
			return;
        
        if ((m_moveTarget.transform.position - transform.position).sqrMagnitude < m_reachDistance)
		{
			m_animator.SetTrigger("Death");
			Destroy(gameObject, 1.2f);
        }

        transform.position += (m_moveTarget.transform.position - transform.position).normalized * m_speed * Time.deltaTime;
    }
}
