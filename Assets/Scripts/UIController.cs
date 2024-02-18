using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public TMP_Text m_killsCounter_Text;
    public TMP_Text m_missedCounter_Text;
    public GameObject m_startGame_Button;
    public GameObject m_stopGame_Button;

    public void SetStartUIState()
    {
        m_startGame_Button.SetActive(false);
        m_stopGame_Button.SetActive(true);
        m_killsCounter_Text.gameObject.SetActive(true);
        m_missedCounter_Text.gameObject.SetActive(true);
    }

    public void SetStopUIState()
    {
        m_stopGame_Button.SetActive(false);
        m_startGame_Button.SetActive(true);
        m_killsCounter_Text.gameObject.SetActive(false);
        m_missedCounter_Text.gameObject.SetActive(false);
    }
    
    public void SetKilledScore(int killedScore)
    {
        m_killsCounter_Text.text = $"Убито монстров: {killedScore}";
    }

    public void SetMissedScore(int missedScore)
    {
        m_missedCounter_Text.text = $"Пропущено монстров: {missedScore}";
    }
}
