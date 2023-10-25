using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName = "SampleScene"; //this is what switches from the start screen to the main game

   
    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
      
}
