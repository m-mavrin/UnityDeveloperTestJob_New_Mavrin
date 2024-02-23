using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject m_target;
    [SerializeField] private GameObject m_monster;
    [SerializeField] private float m_respawnTime;

    public GameObject SpawnMonster()
    {
        GameObject newMonster = Instantiate(m_monster);
        newMonster.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 90, 0));
        newMonster.GetComponent<Monster>().moveTarget = m_target;

        return newMonster;
    }
}
