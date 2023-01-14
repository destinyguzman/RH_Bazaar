using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.InputSystem;


public class VoiceRecording : MonoBehaviour
{
    public AudioSource audioSource;
    private AudioClip recordedClip;

    private string device;
    private bool isRecording;

    void Start()
    {
        device = Microphone.devices[0];
        //AudioSource audioSource = GetComponent<AudioSource>();
        //audioSource.clip = Microphone.Start(device, false, 10, 44100);
        //audioSource.Play();
    }

    void Update()
    {
    }

    [ContextMenu("Start recordnig")]
    public void StartRecording()
    {
        if (!isRecording)
        {
            recordedClip = Microphone.Start(device, true, 10, 44100);
            isRecording = true;
        }
    }

    [ContextMenu("Stop recordnig")]
    public void StopRecording( )
    {
        if (isRecording)
        {
            isRecording = false;
            Microphone.End(device);
            audioSource.clip = recordedClip;
        }
    }

    [ContextMenu("play")]
    public void playRecording()
    {
        audioSource.Play();
    }
}