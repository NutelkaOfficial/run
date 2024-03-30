using UnityEngine;
using UnityEngine.UI;

public class MenuButtonsClick : MonoBehaviour
{
    public GameObject fadeImage;
    public GameObject background;
    float i = 0;
    private void Update()
    {
        i = Mathf.MoveTowards(i, 10000, 0.1f * Time.deltaTime);
        background.GetComponent<RawImage>().uvRect = new Rect(0, i, 5, 5);
    }
    public void PlayButton()
    { fadeImage.SetActive(true); }
}
