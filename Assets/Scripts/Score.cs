using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Text _scoreText;
    private string _scoretext = "SCORE ";
    public int score = 0;
    private void Update()
    {
        if (_player.transform.position.z > 0 )
        {
            score = (int)(_player.position.z / 2);
            _scoreText.text = _scoretext + score;
        }
        else
        {
            _scoreText.text = _scoretext + 0;
        }
    }
}
