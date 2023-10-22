using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This code was aquired in this video https://youtu.be/odStG_LfPMQ?si=tjy2Jln5pc3XCgUW

public class GameController : MonoBehaviour
{
    Vector2 startPos;
    Rigidbody2D playerRb;

    private void Awake()
    {
       playerRb = GetComponent<Rigidbody2D>(); 
    }

    private void Start() //this sets the respawn position
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision) //this checks if the player touches anything with the "obstacle" tag 
                                                        //the video uses it for a spike but i apply it to box colliders that o0verlayed on the ground so you die if you touch the ground
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }

    }

    void Die() // this function is what kills the player
    {
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration) //this respawns the player
    {
        playerRb.simulated = false;
        playerRb.velocity = new Vector2(0,0); //stopping the players movment
        transform.localScale = new Vector3(0,0,0); //making the player invisible
        yield return new WaitForSeconds(duration); //wait a second
        transform.position = startPos; //move the player to the start
        transform.localScale = new Vector3(1,1,1); //make player visible
        playerRb.simulated = true;
        
    }

}
