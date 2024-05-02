using System;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text coinsText;
    [SerializeField] private GameObject[] _carSkins;
    [SerializeField] private GameObject _shopPanel;
    private int _totalCoins;

    private void Start()
    {
        foreach (GameObject carSkin in _carSkins)
        {
            int bought = PlayerPrefs.GetInt(carSkin.name + "buy");
            int equiped = PlayerPrefs.GetInt(carSkin.name + "equip");
            if (bought == 1)
            {
                carSkin.GetComponentInChildren<Text>().text = equiped == 1 ? "SELECTED" : "PURSHARED";
            }
        }

        _totalCoins = PlayerPrefs.GetInt("coins");
        coinsText.text = _totalCoins.ToString();
        _shopPanel.SetActive(false);
    }
    public void BuySkin(Button buyButton)
    {
        string skinName = buyButton.transform.parent.name;
        string price = buyButton.GetComponentInChildren<Text>().text;

        bool isSkinBought = PlayerPrefs.GetInt(skinName + "buy") == 1;
        if (!isSkinBought && _totalCoins >= Convert.ToInt32(price))
        {
            _totalCoins -= Convert.ToInt32(price);
            coinsText.text = _totalCoins.ToString();
            PlayerPrefs.SetInt("coins", _totalCoins);
            PlayerPrefs.SetInt(skinName + "buy", 1);
            BuySkin(buyButton);
        }
        else if (isSkinBought)
        {
            if (PlayerPrefs.GetInt(skinName + "equip") == 0)
            {
                setBuyButtonText(buyButton);
            }
        }
    }

    private void setBuyButtonText(Button buyButton)
    {
        foreach (GameObject skin in _carSkins)
        {
            if (skin.name == buyButton.transform.parent.name)
            {
                PlayerPrefs.SetInt(skin.name + "equip", 1);
                buyButton.GetComponentInChildren<Text>().text = "SELECTED";
            }
            else if (PlayerPrefs.GetInt(skin.name + "buy") == 1)
            {
                PlayerPrefs.SetInt(skin.name + "equip", 0);
                skin.GetComponentInChildren<Text>().text = "PURSHARED";
            }
        }
    }
}

