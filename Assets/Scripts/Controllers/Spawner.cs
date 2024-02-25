using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject m_target;
    [SerializeField] private SpawnerData m_spawnerData;
    [SerializeField] private Pool<MonsterBase> m_monsterPool;

    public float RespawnTime;

    public Pool<MonsterBase> MonsterPool { get => m_monsterPool; }

    private void Start()
    {
        RespawnTime = m_spawnerData.RespawnTime;
        m_monsterPool = new Pool<MonsterBase>(m_spawnerData.MonsterPrefab, transform);
    }

    public MonsterBase SpawnMonster()
    {
        var newMonster = m_monsterPool.GetFreeElement();
        newMonster.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 90, 0));
        newMonster.GetComponent<Monster>().Target = m_target;
        newMonster.Launch();

        return newMonster;
    }
}
