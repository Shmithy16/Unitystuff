using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    public AudioSource[] sounds;

     public void playSound(string soundName)
     {
        if(soundName == "Jump"){
            sounds[0].Play();
        }
     }
}
