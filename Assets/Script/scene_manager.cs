using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName = "SampleScene";
   
    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    
   
}
