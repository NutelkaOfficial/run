using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 600;
    }
    public void resetButton()
    {
        SceneManager.LoadScene(1);
    }
}
