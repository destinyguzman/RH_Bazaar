using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.InputSystem;


public class VoiceRecording : MonoBehaviour
{
    public GameObject tile;
    public GameObject xrRig;
    public AudioSource audioSource;
    private AudioClip recordedClip;

    private string device;
    private bool isRecording;

    void Start()
    {
        device = Microphone.devices[1];
    }

    void Update()
    {
        var devices = Microphone.devices;
    }

    //
    // Audio recording modules
    //

    public void StartRecording(InputAction.CallbackContext action)
    {
        if (!isRecording)
        {
            recordedClip = Microphone.Start(device, true, 60, 44100);
            audioSource.clip = recordedClip;
            isRecording = true;
        }
    }

    public void StopRecording(InputAction.CallbackContext action)
    {
        if (isRecording)
        {
            isRecording = false;
            Microphone.End(device);
            instantiateTile(recordedClip);
        }
    }

    public void playRecording(InputAction.CallbackContext action)
    {
        audioSource.Play();
    }


    //
    // Instantiate tile
    //
    public void instantiateTile(AudioClip clip)
    {
        GameObject newTile = Instantiate(tile) as GameObject;
        newTile.transform.position = this.transform.position;
        AudioSource audioSource = newTile.GetComponent<AudioSource>();
        audioSource.playOnAwake = false; 
        audioSource.clip = clip;
    }




    [ContextMenu("play")]
    public void playRecording()
    {
        audioSource.Play();
    }

    [ContextMenu("Start recordnig")]
    public void StartRecording()
    {
        if (!isRecording)
        {
            recordedClip = Microphone.Start(device, false, 10, 44100);
            audioSource.clip = recordedClip;
            //isRecording = true;
        }
    }

    [ContextMenu("Stop recordnig")]
    public void StopRecording()
    {
        if (isRecording)
        {
            isRecording = false;
            Microphone.End(device);
            audioSource.clip = recordedClip;
        }
    }
    
    
}