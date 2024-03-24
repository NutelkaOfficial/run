using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public float zOffset;

    void LateUpdate()
    {
        Vector3 playerPosition = player.position;
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, playerPosition.z + zOffset);
        transform.position = newPosition;
    }
}
