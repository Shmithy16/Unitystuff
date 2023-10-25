
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
    public SpriteRenderer sprite;
    public Animator animator;



    public MouseClicked mouseClicked;
    private AudioPlayer audioPlayer;

    private float horizontal; //Sets the values for speed, jumping power and if the player is facing right
    private float speed = 8f;
    private float jumpingPower = 16f;

    void Start()
    {
        audioPlayer = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioPlayer>();
    }


    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); //our movement speed is the direction we are holding times the speed

        animator.SetFloat("Speed", Mathf.Abs(horizontal)); // i learned how to do the animation from this video https://youtu.be/hkaysu1Z-N8

        if (horizontal > 0f) //if we are facing left and we are moving left then flip the player 
        { 
            sprite.flipX = false;
        }
        else if (horizontal < 0f)
        {
            sprite.flipX = true;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded()) //if we are on the ground then we can jump
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            audioPlayer.playSound("Jump");
        }

        if (context.canceled && rb.velocity.y >0f) //this will make it so the longer you hold jump the higher you jump
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y  * 0.5f);
        }
    }

    private bool IsGrounded(){ //this checks if we are on the ground
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, gridLayer);
    }

    // private void Flip()//this flips the character    this use to be the way i fliped the character but i found a better way thanks to ruby
    // {
    //     isFaceingRight = !isFaceingRight;
    //     Vector3 localScale = transform.localScale;
    //     localScale.x *= -1f;
    //     transform.localScale = localScale;
    // }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void OnTriggerEnter2D(Collider2D collision) { //when you touch the chest you gain 6 blocks and it destroys the chest
        if (collision.CompareTag ("Chest"))
        {
           mouseClicked.addToCounter();
           Destroy(collision.gameObject);
        }
    
    }
}

