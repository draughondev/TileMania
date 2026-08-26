using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    int coinCounter;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            coinCounter++;
            Destroy(gameObject, 0.07f);
        }
    }
}
