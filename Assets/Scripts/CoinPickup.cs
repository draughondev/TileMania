using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsForCoinPickup = 100;

    bool wasCollected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !wasCollected) {
            wasCollected = true;
            FindAnyObjectByType<GameSession>().AddToScore(pointsForCoinPickup);
            gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(coinPickupSFX, transform.position);

            Destroy(gameObject, 0.07f);
        }
    }
}
