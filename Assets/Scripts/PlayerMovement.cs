using System;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8.5f;
    [SerializeField] float jumpSpeed = 23f;
    [SerializeField] float climbSpeed = 7f;
    [SerializeField] float coyoteTime = 0.12f;
    [SerializeField] float jumpBufferTime = 0.12f;

    float coyoteTimeCounter;
    float jumpBufferCounter;
    float startingGravityScale;

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    SpriteRenderer mySpriteRenderer;

    bool isAlive = true;

    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        startingGravityScale = 7f;
    }

    void Update()
    {

        if (!isAlive) 
        {
            Shrink();
            return; 
        }

        HandleCoyoteTime();
        HandleBufferTime();
        Jump();
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }

    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            jumpBufferCounter = jumpBufferTime;
        }
    }

    void Jump()
    {
        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
        myRigidbody.linearVelocity += new Vector2(
            0,
            jumpSpeed
        );

        jumpBufferCounter = 0f;
        coyoteTimeCounter = 0f;
        }
    }


    void Run()
    {
        Vector2 playerVelocity = new Vector2 (
            moveInput.x * moveSpeed, 
            myRigidbody.linearVelocity.y
        );
        myRigidbody.linearVelocity = playerVelocity;

        bool hasHorizontalSpeed = Mathf.Abs(myRigidbody.linearVelocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", hasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool hasHorizontalSpeed = Mathf.Abs(myRigidbody.linearVelocity.x) > Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (
                Mathf.Sign(myRigidbody.linearVelocity.x), 1f
            );  
        }
    }

     void ClimbLadder()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) 
        {
            myRigidbody.gravityScale = startingGravityScale;
            myAnimator.SetBool("isClimbing", false);
            return;
        }

        myRigidbody.gravityScale = 0f;
        Vector2 climbingVelocity = new Vector2 (
            myRigidbody.linearVelocity.x, 
            moveInput.y * climbSpeed
        );
        myRigidbody.linearVelocity = climbingVelocity;

        bool hasVerticalSpeed = Mathf.Abs(myRigidbody.linearVelocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", hasVerticalSpeed);

    }

    void HandleCoyoteTime()
    {
        bool isOnGround = myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));

        if (isOnGround && myRigidbody.linearVelocity.y <= 0.01)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

    void HandleBufferTime()
    {
        if (jumpBufferCounter > 0f)
        {
            jumpBufferCounter -= Time.deltaTime;
        }
    }

    void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Dying");
        }
    }

    void Shrink()
    {
        transform.localScale *= 0.99f;

        if (transform.localScale.magnitude < 0.01f)
        {
            transform.localScale = Vector3.zero;
            // Destroy the Character or Reset the Game
        }
    }
}
