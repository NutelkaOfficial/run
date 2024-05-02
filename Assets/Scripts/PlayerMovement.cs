using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public AudioClip[] audioClip;
    public AudioSource audioSource;
    public float runSpeed = 30f;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private Score _scoreScript;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Text _coinCountText;
    private string _coinsText = "x ";
    private int _coinCount = 0;
    private bool _isGameEnd = false;
    private int highScore;
    private void Move()
    {
        if (transform.position.z < 250)
        {
            runSpeed = Mathf.MoveTowards(runSpeed, 40, 1f * Time.deltaTime);
        }
        else
        {
            runSpeed = Mathf.MoveTowards(runSpeed, 120, 0.3f * Time.deltaTime);
        }

        transform.Translate(-transform.forward * runSpeed * Time.deltaTime);
    }
    private void Start()
    {
        highScore = PlayerPrefs.GetInt("score");
        audioSource.clip = audioClip[0];
        audioSource.loop = true;
        audioSource.Play();
        _losePanel.SetActive(false);
        _isGameEnd = false;
    }
    void Update()
    {
        if (Time.timeScale == 1)
        {
            Move();
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                    case TouchPhase.Moved:
                        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
                        if (touchPosition.x < 9.24f || touchPosition.y < 54.45)
                        {
                            transform.position = new Vector3(touchPosition.x, transform.position.y, transform.position.z);
                        }
                        break;
                }
            }
        }
        if (_isGameEnd)
        {
            _losePanel.SetActive(true);
            audioSource.clip = audioClip[1];
            audioSource.Play();
            audioSource.loop = false;
            int score = _scoreScript.score;
            if (score > highScore)
            {
                PlayerPrefs.SetInt("score", score);
            }
            for (int i = 0; i < 3; i++)
            {
                PlayerPrefs.SetInt($"Score {i}", PlayerPrefs.GetInt($"Score {i+1}"));
            }
            PlayerPrefs.SetInt("Score 3", score);
            _isGameEnd = false;
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "coin")
        {
            _coinCount++;
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 1);
            _coinCountText.text = _coinsText + _coinCount;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "obstacle")
        {
            Time.timeScale = 0;
            _isGameEnd = true;
        }
    }
}
