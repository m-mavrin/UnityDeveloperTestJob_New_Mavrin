using UnityEngine;

[CreateAssetMenu(fileName = "New SpawnerData", menuName = "Spawner Data")]
public class SpawnerData : ScriptableObject
{
    [SerializeField] private GameObject m_monsterPrefab;
    [SerializeField] private float m_respawnTime;

    public GameObject MonsterPrefab { get => m_monsterPrefab; }
    public float RespawnTime { get => m_respawnTime; }
}
