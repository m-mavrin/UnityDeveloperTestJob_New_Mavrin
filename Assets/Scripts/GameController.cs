using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject m_KillsCounter_Text;
    public GameObject m_LostsCounter_Text;
    public GameObject m_StartGame_Button;
    public GameObject m_StopGame_Button;

    private bool isGameStarted = false;

    public void StartGame()
    {
        isGameStarted = true;
        m_StartGame_Button.SetActive(false);
        m_StopGame_Button.SetActive(true);
        m_KillsCounter_Text.SetActive(true);
        m_LostsCounter_Text.SetActive(true);
    }

    public void StopGame()
    {
        isGameStarted = false;
        m_StopGame_Button.SetActive(false);
        m_StartGame_Button.SetActive(true);
        m_KillsCounter_Text.SetActive(false);
        m_LostsCounter_Text.SetActive(false);
    }
}
