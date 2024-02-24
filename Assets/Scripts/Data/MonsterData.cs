using UnityEngine;

[CreateAssetMenu(fileName = "New MonsterData", menuName = "Monster Data")]
public class MonsterData : ScriptableObject
{
    [SerializeField] private string m_name;
    [SerializeField] private float m_speed;
    [SerializeField] private int m_maxHP;

    public string Name { get { return m_name; } }
    public float Speed { get { return m_speed; } }
    public int MaxHP { get { return m_maxHP; } }
}
