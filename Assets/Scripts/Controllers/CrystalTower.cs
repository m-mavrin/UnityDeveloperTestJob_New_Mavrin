public class CrystalTower : TowerBase
{
    void Update()
    {
        if (m_towerData.ProjectilePrefab == null || m_controller == null)
            return;

        if (m_controller.isGameStarted)
        {
            if (m_target == null || m_target.CurrentHP <= 0)
            {
                m_target = FindTarget();
            }
            else
            {
                Shoot(true);
            }
        }
    }
}
