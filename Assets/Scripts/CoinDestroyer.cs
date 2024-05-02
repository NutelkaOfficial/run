using UnityEngine;

public class CoinDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" || collider.tag == "obstacle")
        {
            Destroy(gameObject);
        }
    }
}
