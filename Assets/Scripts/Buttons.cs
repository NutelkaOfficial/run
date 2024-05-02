using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private GameObject _fadeImage;
    [SerializeField] private GameObject _shopPanel;
    [Space(1)]
    [Header("Game")]
    [SerializeField] private PlayerMovement _playerMovementScript;
    public GameObject pausePanel;
    private int j = 0;
    private float i = -2163;
    #region Menu
    public void PlayButton() => _fadeImage.SetActive(true);

    public void ShopButton()
    {
        _shopPanel.SetActive(true);
        j = 1;
    }

    public void CloseShop() => j = -1;
    #endregion

    #region Game
    public void PauseButton()
    {
        if (pausePanel.activeSelf == false)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            _playerMovementScript.audioSource.Pause();
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            _playerMovementScript.audioSource.UnPause();
        }
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
    #endregion

    private void Update()
    {
        if (j == 1)
        {
            i = Mathf.MoveTowards(i, 0, 1600f * Time.deltaTime);
            _shopPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, i);
            if (i == 0) { j = 0; }
        }
        else if (j == -1)
        {
            i = Mathf.MoveTowards(i, -2163, 1600f * Time.deltaTime);
            _shopPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, i);
            if (i == -2163)
            {
                j = 0;
                _shopPanel.SetActive(false);
            }
        }
    }
}