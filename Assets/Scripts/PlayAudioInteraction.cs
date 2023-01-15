using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioInteraction : MonoBehaviour
{
    public AudioSource playSound;       // Gameobject where they will be teleported to
    public bool shouldTrigget = false;
    public bool playing = false;

    public void OnTriggerEnter(Collider other)
    {
        if (shouldTrigget)
        {
            playSound.Play();
        }
        
    }

    //public void OnTriggerExit(Collider other)
    //{
        
    //    playSound.Stop();
       
    //}
}
