using UnityEngine;

public class CoinDestroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "obstacle")
        {
            Destroy(gameObject);
        }
    }
}
