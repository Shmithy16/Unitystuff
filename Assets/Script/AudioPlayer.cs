using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    public AudioSource[] sounds; //this is to play the sound when the player jumps

     public void playSound(string soundName)
     {
        if(soundName == "Jump"){
            sounds[0].Play();
        }
     }
}
