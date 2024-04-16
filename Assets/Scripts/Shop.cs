using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text coinsText;
    public GameObject shopPanel;
    public GameObject[] shops;
    private int j = 0;
    private float i = -2163;
    private int _activeTabIndex = 0;
    private int _totalCoins;
    private void Start()
    {
        _totalCoins = PlayerPrefs.GetInt("coins");
        coinsText.text = _totalCoins.ToString();
        shopPanel.SetActive(false);
        for (int k = 0; k < shops.Length; k++)
        {shops[k].SetActive(false);}
    }
    private void Update()
    {
        if (j == 1)
        {
            i = Mathf.MoveTowards(i, 0, 1600f * Time.deltaTime);
            shopPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, i);
            if (i == 0) { j = 0; }
        }
        if (j == -1)
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
        shops[_activeTabIndex].SetActive(false);
        _activeTabIndex = 0;
        shops[_activeTabIndex].SetActive(true);
    }
    public void ObstacleShopButton()
    {
        shops[_activeTabIndex].SetActive(false);
        _activeTabIndex = 1;
        shops[_activeTabIndex].SetActive(true);
    }
    public void PlatformShopButton()
    {
        shops[_activeTabIndex].SetActive(false);
        _activeTabIndex = 2;
        shops[_activeTabIndex].SetActive(true);
    }
}
