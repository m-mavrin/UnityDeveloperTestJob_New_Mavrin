using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject m_target;
    [SerializeField] private SpawnerData m_spawnerData;

    public float RespawnTime;

    private void Start()
    {
        RespawnTime = m_spawnerData.RespawnTime;
    }

    public GameObject SpawnMonster()
    {
        GameObject newMonster = Instantiate(m_spawnerData.MonsterPrefab);
        newMonster.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 90, 0));
        newMonster.GetComponent<Monster>().Target = m_target;

        return newMonster;
    }
}
