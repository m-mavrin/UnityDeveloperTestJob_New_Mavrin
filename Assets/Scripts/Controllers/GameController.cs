using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController m_UI;
    [SerializeField] private Spawner m_spawner;
    public bool isGameStarted = false;

    private float m_lastSpawn = -1;
    private int m_killsScore = 0;
    private int m_missedScore = 0;

    private void Update()
    {
        if (isGameStarted)
        {
            if (Time.time > m_lastSpawn + m_spawner.RespawnTime)
            {
                var newMonster = m_spawner.SpawnMonster();
                newMonster.GetComponent<Monster>().onKilled += AddKilled;
                newMonster.GetComponent<Monster>().onDestroy += AddMissed;

                m_lastSpawn = Time.time;
            }
        }
    }

    public void StartGame()
    {
        isGameStarted = true;
        m_lastSpawn = Time.time;
        m_UI.SetStartUIState();
    }

    public void StopGame()
    {
        isGameStarted = false;
        m_spawner.DisableAllMonsters();
        m_UI.SetStopUIState();
    }

    public void AddKilled()
    {
        m_killsScore++;
        m_UI.SetKilledScore(m_killsScore);
    }

    public void AddMissed()
    {
        m_missedScore++;
        m_UI.SetMissedScore(m_missedScore);
    }
}
