using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController m_UI;
    [SerializeField] private Spawner m_spawner;
    public bool isGameStarted = false;

    private float m_lastSpawn = -1;
    private int m_killsScore = 0;
    private int m_missedScore = 0;
    public List<GameObject> m_monsters = new List<GameObject>(16);

    private void Update()
    {
        if (isGameStarted)
        {
            if (Time.time > m_lastSpawn + m_spawner.RespawnTime)
            {
                var newMonster = m_spawner.SpawnMonster();
                newMonster.GetComponent<Monster>().onKilled += AddKilled;
                newMonster.GetComponent<Monster>().onDestroy += AddMissed;
                m_monsters.Add(newMonster);

                m_lastSpawn = Time.time;
            }
        }
    }

    public void ClearMonsters()
    {
        foreach (var monster in m_monsters)
        {
            Destroy(monster);
        }
        m_monsters.Clear();
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
        ClearMonsters();
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
