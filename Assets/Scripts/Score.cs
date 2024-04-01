using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _coinCountText;
    private string _scoretext = "SCORE ";
    private string _coinsText = "x ";
    private int _coinCount = 0;
    private void Update()
    {
        if (_player.transform.position.z > 0 )
        {
            _scoreText.text = _scoretext + ((int)(_player.position.z / 2)).ToString();
        }
        else
        {
            _scoreText.text = _scoretext + 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        _coinCount++;
        _coinCountText.text = _coinsText + _coinCount;

    }
}
