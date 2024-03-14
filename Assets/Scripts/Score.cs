using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Text _scoreText;
    private string text = "SCORE ";
    void Update()
    {
        if (_player.transform.position.z > 0 )
        {
            _scoreText.text = text + ((int)(_player.position.z / 2)).ToString();
        }
        else
        {
            _scoreText.text = text + 0;
        }
    }
}
