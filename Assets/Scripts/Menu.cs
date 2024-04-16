using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text scoreText;
    public GameObject fadeImage;
    public GameObject background;
    private float i = 0;
    private void Start()
    {
        Time.timeScale = 1;
        int highScore = PlayerPrefs.GetInt("score");
        scoreText.text = $"{highScore}";
        i = 0;
    }
    private void Update()
    {
        i = Mathf.MoveTowards(i, 10000, 0.1f * Time.deltaTime);
        background.GetComponent<RawImage>().uvRect = new Rect(0, i, 1.69f, 3.36f);
    }
    public void PlayButton()
    { fadeImage.SetActive(true); }
}
