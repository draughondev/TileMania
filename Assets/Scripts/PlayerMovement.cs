using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpSpeed = 23f;
    [SerializeField] float climbSpeed = 9f;
    float startingGravityScale;

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myCollider;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<CapsuleCollider2D>();
        startingGravityScale = 8f;
    }

    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!myCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {return;}

        if (value.isPressed)
        {
            myRigidbody.linearVelocity += new Vector2(0f, jumpSpeed);
        }
    }


    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * moveSpeed, myRigidbody.linearVelocity.y);
        myRigidbody.linearVelocity = playerVelocity;

        bool hasHorizontalSpeed = Mathf.Abs(myRigidbody.linearVelocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", hasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool hasHorizontalSpeed = Mathf.Abs(myRigidbody.linearVelocity.x) > Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.linearVelocity.x), 1f);   
        }
    }

     void ClimbLadder()
    {
        if (!myCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) 
        {
            myRigidbody.gravityScale = startingGravityScale;
            myAnimator.SetBool("isClimbing", false);
            return;
        }

        myRigidbody.gravityScale = 0f;
        Vector2 climbingVelocity = new Vector2 (myRigidbody.linearVelocity.x, moveInput.y * climbSpeed);
        myRigidbody.linearVelocity = climbingVelocity;

        bool hasVerticalSpeed = Mathf.Abs(myRigidbody.linearVelocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", hasVerticalSpeed);

    }
}
