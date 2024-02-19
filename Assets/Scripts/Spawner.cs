using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	public float m_interval = 3;
	public GameObject m_moveTarget;
	public GameObject m_monster;

	private float m_lastSpawn = -1;

	void Update () 
	{
		if (Time.time > m_lastSpawn + m_interval)
		{
            GameObject newMonster = Instantiate(m_monster);
            newMonster.transform.position = transform.position;
			newMonster.transform.rotation = Quaternion.Euler(0, 90, 0);
			newMonster.GetComponent<Monster>().m_moveTarget = m_moveTarget;

			m_lastSpawn = Time.time;
		}
	}
}
