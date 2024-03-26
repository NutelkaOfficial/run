using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScreenFade : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public float fadeSpeed = 1f;
    IEnumerator Start()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        Image fadeImage = GetComponent<Image>();
        Color color = fadeImage.color;
        while (color.a < 1f)
        {
            color.a += fadeSpeed * Time.deltaTime;
            fadeImage.color = color;
            yield return null;
        }
        SceneManager.LoadScene(1);
    }
}
