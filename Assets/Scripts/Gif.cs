using UnityEngine.UI;
using UnityEngine;

public class Gif : MonoBehaviour
{
    public Sprite[] sprites;
    public float framesPerSecond;
    private Image img;
    private void Awake()
    {
        img = GetComponent<Image>(); 
    }
    private void Update()
    {
        float index = Time.time * framesPerSecond;
        index = index % sprites.Length;
        img.sprite = sprites[(int)index];
    }
}
