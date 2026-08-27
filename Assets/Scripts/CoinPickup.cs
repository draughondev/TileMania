using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    [SerializeField] AudioClip coinPickupSFX;
    int coinCounter;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            coinCounter++;
            AudioSource.PlayClipAtPoint(coinPickupSFX, transform.position);
            Destroy(gameObject, 0.07f);
        }
    }
}
