using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This code was aquired in this video https://youtube.com/shorts/x03mPWj3gFg?si=5IzPnDwf4jsr2os_

public class MouseClicked : MonoBehaviour
{
    public GameObject spawnObject;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))// This simple if the mouse has been pressed
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);// Finds the current position of the mouse
            Vector3 offset = new Vector3(0,0,10);
            Instantiate(spawnObject, pos + offset, Quaternion.identity);// then spawns this object at that position
        }
    }
}

