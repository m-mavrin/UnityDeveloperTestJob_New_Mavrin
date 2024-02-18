using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject m_UI;
    public bool isGameStarted = false;

    private int m_killsScore = 0;
    private int m_missedScore = 0;

    public bool IsGameStarted
    {
        get { return isGameStarted; }
    }

    public void StartGame()
    {
        isGameStarted = true;
        m_UI.GetComponent<UIController>().SetStartUIState();
    }

    public void StopGame()
    {
        isGameStarted = false;
        m_UI.GetComponent<UIController>().SetStopUIState();
    }

    public void AddKilled()
    {
        m_killsScore++;
        m_UI.GetComponent<UIController>().SetKilledScore(m_killsScore);
    }

    public void AddMissed()
    {
        m_missedScore++;
        m_UI.GetComponent<UIController>().SetMissedScore(m_missedScore);
    }
}
