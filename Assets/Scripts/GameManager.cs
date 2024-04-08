using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    private void Awake()
    {
        Application.targetFrameRate = 600;
    }
    public void PauseButton()
    {
        if (pausePanel.activeSelf == false)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }
    public void ResetButton()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
