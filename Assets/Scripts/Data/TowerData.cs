using UnityEngine;

[CreateAssetMenu(fileName = "New TowerData", menuName = "Tower Data")]
public class TowerData : ScriptableObject
{
    [SerializeField] private float m_projectileSpeed;
    [SerializeField] private int m_damage;
    [SerializeField] private float m_shootInterval;
    [SerializeField] private float m_shootRange;
    [SerializeField] private float m_rotationSpeed;
    [SerializeField] private GameObject m_projectilePrefab;

    public float ProjectileSpeed { get => m_projectileSpeed; }
    public int Damage { get => m_damage; }
    public float ShootInterval { get => m_shootInterval; }
    public float ShootRange { get => m_shootRange; }
    public float RotationSpeed { get => m_rotationSpeed; set => m_rotationSpeed = value; }
    public GameObject ProjectilePrefab { get => m_projectilePrefab; set => m_projectilePrefab = value; }
}
