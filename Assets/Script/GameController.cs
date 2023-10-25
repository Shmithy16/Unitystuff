using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This code was aquired in this video https://youtu.be/odStG_LfPMQ?si=tjy2Jln5pc3XCgUW

public class GameController : MonoBehaviour
{
    Vector2 startPos;
    Rigidbody2D playerRb;

    public Scene_Manager sceneManager;

    private void Awake()
    {
       playerRb = GetComponent<Rigidbody2D>(); 
    }

    private void Start() //this sets the respawn position
    {
        startPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Obstacle")//this checks if the player touches anything with the "obstacle" tag 
                                                        //the video uses it for a spike but i apply it to all of the tiles except for a few near the middle as it was quite hard since just 
                                                        //touching the walls would kill you
        {
            Die();
        }

        if (collision.gameObject.tag == "End") //this checks if the player has reached the end and will switch to the end scene
        {
            sceneManager.EndGame();
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
    public void Update() 
    {
        if(Input.GetKeyDown(KeyCode.R)) //this is what resets the scene when you hit the key R
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
