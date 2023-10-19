using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClicked : MonoBehaviour
{
    public GameObject spawnObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 offset = new Vector3(0,0,10);
            Instantiate(spawnObject, pos + offset, Quaternion.identity);
        }
    }
}
