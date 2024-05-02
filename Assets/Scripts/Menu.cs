using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject background;
    [SerializeField] private AudioSource _soundManager;
    public TextMeshProUGUI[] lastScores;
    private float i = 0;
    private void Start()
    {
        _soundManager.Play();
        Time.timeScale = 1;

        int highScore = PlayerPrefs.GetInt("score");
        scoreText.text = $"{highScore}";
        i = 0;
        for (int i = 0; i < lastScores.Length; i++)
        {
            lastScores[i].text = $"{PlayerPrefs.GetInt($"Score {i}")}";
        }
    }
    private void Update()
    {
        i = Mathf.MoveTowards(i, 10000, 0.1f * Time.deltaTime);
        background.GetComponent<RawImage>().uvRect = new Rect(0, i, 1.69f, 3.36f);
    }
}
