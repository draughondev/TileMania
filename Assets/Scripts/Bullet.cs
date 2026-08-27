using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] float bulletSpeed = 20f;
    float xSpeed;

    PlayerMovement player;
    Rigidbody2D myRigidbody;
    CircleCollider2D myCircleCollider;

    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myCircleCollider = GetComponent<CircleCollider2D>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        myRigidbody.linearVelocity = new Vector2 (xSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {
            Destroy(collision.gameObject, 0.05f);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 0.05f);
    }
}
