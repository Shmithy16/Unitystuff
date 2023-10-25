using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    [SerializeField] 
    private string sceneEnd = "EndScene"; //this is what switches to the end screen
    
        public void EndGame()
    {
        SceneManager.LoadScene(sceneEnd);
    }
}
