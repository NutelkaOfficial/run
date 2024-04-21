using System;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text coinsText;
    public GameObject shopPanel;
    public GameObject[] shops;
    [SerializeField] private GameObject[] _carSkins;
    [SerializeField] private GameObject[] _obstacleSkins;
    [SerializeField] private GameObject[] _platformSkins;
    [SerializeField] private GameObject[] _buyButtons;
    private int j = 0;
    private float i = -2163;
    private int _activeTabIndex = 0;
    private int _totalCoins;

    private void Start()
    {
        foreach (GameObject buyButton in _buyButtons)
        {
            int bought = PlayerPrefs.GetInt(buyButton.transform.parent.name + "buy");
            int equiped = PlayerPrefs.GetInt(buyButton.transform.parent.name + "equip");
            if (bought == 1)
            {
                buyButton.GetComponentInChildren<Text>().text = equiped == 1 ? "SELECTED" : "PURSHARED";
            }
        }

        _totalCoins = PlayerPrefs.GetInt("coins");
        coinsText.text = _totalCoins.ToString();
        shopPanel.SetActive(false);
    }

    private void Update()
    {
        if (j == 1)
        {
            i = Mathf.MoveTowards(i, 0, 1600f * Time.deltaTime);
            shopPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, i);
            if (i == 0) { j = 0; }
        }
        else if (j == -1)
        {
            i = Mathf.MoveTowards(i, -2163, 1600f * Time.deltaTime);
            shopPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, i);
            if (i == -2163)
            {
                j = 0;
                shopPanel.SetActive(false);
            }
        }
    }

    public void BuySkin(Button buyButton)
    {
        string skinName = buyButton.transform.parent.name;
        string[] skinWords = skinName.Split(' ');
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
                setBuyButtonText(skinWords[0], buyButton);
            }
        }
    }

    private void setBuyButtonText(string skinsName, Button buyButton)
    {
        foreach (GameObject skin in GetSkinArray(skinsName))
        {
            if (skin.name == buyButton.transform.parent.name)
            {
                PlayerPrefs.SetInt(skin.name + "equip", 1);
                buyButton.GetComponentInChildren<Text>().text = "SELECTED";
            }
            else if (PlayerPrefs.GetInt(skin.name + "buy") == 1)
            {
                PlayerPrefs.SetInt(skin.name + "equip", 0);
                skin.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = "PURSHARED";
            }
        }
    }

    private GameObject[] GetSkinArray(string skinsName)
    {
        switch (skinsName)
        {
            case "Car":
                return _carSkins;
            case "Obstacle":
                return _obstacleSkins;
            case "Platform":
                return _platformSkins;
            default:
                Debug.LogError("Invalid skin type");
                return null;
        }
    }
    #region shop tabs buttons

    public void ShopButton()
    {
        shopPanel.SetActive(true);
        shops[_activeTabIndex].SetActive(true);
        j = 1;
    }

    public void CloseShop()
    {
        j = -1;
    }

    public void CarShopButton()
    {
        SwitchShopTab(0);
    }

    public void ObstacleShopButton()
    {
        SwitchShopTab(1);
    }

    public void PlatformShopButton()
    {
        SwitchShopTab(2);
    }

    private void SwitchShopTab(int tabIndex)
    {
        shops[_activeTabIndex].SetActive(false);
        _activeTabIndex = tabIndex;
        shops[_activeTabIndex].SetActive(true);
    }

    #endregion
}

