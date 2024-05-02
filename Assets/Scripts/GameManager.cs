using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Sprite[] _carSkins;
    [SerializeField] private GameObject[] _gameCarSkins;
    public GameObject pausePanel;
    private void Awake()
    {
        Application.targetFrameRate = 600;
        foreach (Sprite skin in _carSkins)
        {
            string[] skinNameWords = skin.name.Split(' ');
            int skinID = Convert.ToInt32(skinNameWords[2]);
            if (PlayerPrefs.GetInt(skin.name + "equip") == 1)
            {
                _gameCarSkins[skinID - 1].SetActive(true);
            }
            else
            {
                _gameCarSkins[skinID - 1].SetActive(false);
            }
        }
    }
}
