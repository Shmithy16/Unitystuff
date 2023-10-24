
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//This code was aquired in this video https://youtu.be/K1xZ-rycYY8?si=tyeDiy5znbKcHPwl

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask gridLayer;

    private float horizontal; //Sets the values for speed, jumping power and if the player is facing right
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFaceingRight = true;


    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); //our movement speed is the direction we are holding times the speed

        if (!isFaceingRight && horizontal > 0f) //if we are facing left and we are moving left then flip the player 
        { 
            Flip();
        }
        else if (isFaceingRight && horizontal < 0f)
        {
            Flip();
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded()) //if we are on the ground then we can jump
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (context.canceled && rb.velocity.y >0f) //this will make it so the longer you hold jump the higher you jump
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y  * 0.5f);
        }
    }

    private bool IsGrounded(){ //this checks if we are on the ground
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, gridLayer);
    }

    private void Flip()//this flips the character
    {
        isFaceingRight = !isFaceingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}

