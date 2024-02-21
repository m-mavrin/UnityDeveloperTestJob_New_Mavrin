using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public UIController UI;
    public Spawner spawner;
    public float spawnInterval = 3;
    public bool isGameStarted = false;

    private float m_lastSpawn = -1;
    private int m_killsScore = 0;
    private int m_missedScore = 0;
    public List<GameObject> m_monsters = new List<GameObject>(16);

    private void Update()
    {
        if (isGameStarted)
        {
            if (Time.time > m_lastSpawn + spawnInterval)
            {
                var newMonster = spawner.SpawnMonster();
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
        UI.SetStartUIState();
    }

    public void StopGame()
    {
        isGameStarted = false;
        ClearMonsters();
        UI.SetStopUIState();
    }

    public void AddKilled()
    {
        m_killsScore++;
        UI.SetKilledScore(m_killsScore);
    }

    public void AddMissed()
    {
        m_missedScore++;
        UI.SetMissedScore(m_missedScore);
    }
}
