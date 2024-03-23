using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void resetButton()
    {
        SceneManager.LoadScene(0);
    }
}
