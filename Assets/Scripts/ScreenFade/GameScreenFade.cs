using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameScreenFade : MonoBehaviour
{
    public float fadeSpeed = -0.2f;
    IEnumerator Start()
    {
        Image fadeImage = GetComponent<Image>();
        Color color = fadeImage.color;
        while (color.a > 0f)
        {
            color.a += fadeSpeed * Time.deltaTime;
            fadeImage.color = color;
            yield return null;
        }
    }
}
