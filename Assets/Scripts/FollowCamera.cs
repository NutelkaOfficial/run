using UnityEngine;
using UnityEngine.UI;

public class FollowCamera : MonoBehaviour
{
    public Slider offsetSlider;
    public Transform player;
    public float zOffset;

    private void Start()
    {
        offsetSlider.value = PlayerPrefs.GetFloat("offset");
        zOffset = -offsetSlider.value * 65;
    }
    void LateUpdate()
    {
        zOffset = -offsetSlider.value * 65;
        PlayerPrefs.SetFloat("offset", offsetSlider.value);
        Vector3 playerPosition = player.position;
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, playerPosition.z + zOffset);
        transform.position = newPosition;
    }
}
