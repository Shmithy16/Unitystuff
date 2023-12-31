using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

//This code was aquired in this video https://youtube.com/shorts/x03mPWj3gFg?si=5IzPnDwf4jsr2os_

public class MouseClicked : MonoBehaviour
{
    public GameObject spawnObject;
    public int counter = 6;

    public TMP_Text blockText;

 
    void Update()
    {
        if(Input.GetMouseButtonDown(0))// This simple if the mouse has been pressed
        {   
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);// Finds the current position of the mouse
            Vector3 offset = new Vector3(0,0,10);
            if(counter > 0){
                Instantiate(spawnObject, pos + offset, Quaternion.identity);// then spawns this object at that position
                counter -= 1;
                updateText();
            }
        }
    }
    public void updateText() //this updates the text for how many blocks you have
    {
        blockText.text = "Blocks: " + counter;
    }

    public void addToCounter() //this increses the counter
    {
        counter += 6;
        updateText();
    }
}

