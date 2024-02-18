using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject m_killsCounter_Text;
    public GameObject m_missedCounter_Text;
    public GameObject m_startGame_Button;
    public GameObject m_stopGame_Button;

    public void SetStartUIState()
    {
        m_startGame_Button.SetActive(false);
        m_stopGame_Button.SetActive(true);
        m_killsCounter_Text.SetActive(true);
        m_missedCounter_Text.SetActive(true);
    }

    public void SetStopUIState()
    {
        m_stopGame_Button.SetActive(false);
        m_startGame_Button.SetActive(true);
        m_killsCounter_Text.SetActive(false);
        m_missedCounter_Text.SetActive(false);
    }
    
    public void SetKilledScore(int killedScore)
    {
        m_killsCounter_Text.GetComponent<Text>().text = $"Количество убитых: {killedScore}";
    }

    public void SetMissedScore(int missedScore)
    {
        m_missedCounter_Text.GetComponent<Text>().text = $"Количество пропущенных: {missedScore}";
    }
}
