using UnityEngine;

[CreateAssetMenu(fileName = "New TowerData", menuName = "Tower Data")]
public class TowerData : ScriptableObject
{
    [SerializeField] private float m_projectileSpeed;
    [SerializeField] private int m_damage;
    [SerializeField] private float m_shootInterval;
    [SerializeField] private float m_shootRange;
    [SerializeField] private float m_rotationSpeed;
    [SerializeField] private ProjectileBase m_projectilePrefab;

    public float ProjectileSpeed { get => m_projectileSpeed; }
    public int Damage { get => m_damage; }
    public float ShootInterval { get => m_shootInterval; }
    public float ShootRange { get => m_shootRange; }
    public float RotationSpeed { get => m_rotationSpeed; }
    public ProjectileBase ProjectilePrefab { get => m_projectilePrefab; }
}
