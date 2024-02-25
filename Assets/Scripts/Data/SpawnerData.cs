using UnityEngine;

[CreateAssetMenu(fileName = "New SpawnerData", menuName = "Spawner Data")]
public class SpawnerData : ScriptableObject
{
    [SerializeField] private MonsterBase m_monsterPrefab;
    [SerializeField] private float m_respawnTime;

    public MonsterBase MonsterPrefab { get => m_monsterPrefab; }
    public float RespawnTime { get => m_respawnTime; }
}
