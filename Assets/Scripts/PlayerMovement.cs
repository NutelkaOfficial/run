using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public AudioClip[] audioClip;
    public AudioSource audioSource;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private Score _scoreScript;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Text _coinCountText;
    private string _coinsText = "x ";
    private int _coinCount = 0;
    public float runSpeed = 30f;
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
        Time.timeScale = 1;
    }
    void Update()
    {
        if (runSpeed > 4.99)
        {
            if (_gameManager.pausePanel.activeSelf == false)
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
                            if (touchPosition.x < 7.41f || touchPosition.y > 14.13)
                            {
                                transform.position = new Vector3(touchPosition.x, transform.position.y, transform.position.z);
                            }
                            break;
                    }

                }
            }

        }
    }
        void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag == "coin")
            {
                _coinCount++;
                PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 1);
                _coinCountText.text = _coinsText + _coinCount;
            }
            if (collision.collider.tag == "obstacle")
            {
                runSpeed = 0;
                Time.timeScale = 0;
                _losePanel.SetActive(true);
                audioSource.loop = false;
                audioSource.clip = audioClip[1];
                audioSource.Play();
                int score = _scoreScript.score;
                if (score > highScore)
                {
                    PlayerPrefs.SetInt("score", score);
                }
            }
        }
}
