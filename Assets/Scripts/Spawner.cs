using UnityEngine;

public class Spawner : MonoBehaviour 
{
	public GameObject m_moveTarget;
	public GameObject m_monster;

	public GameObject SpawnMonster()
	{
        GameObject newMonster = Instantiate(m_monster);
        newMonster.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 90, 0));
        newMonster.GetComponent<Monster>().m_moveTarget = m_moveTarget;

        return newMonster;
    }
}
