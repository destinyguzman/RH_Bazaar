using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInteraction : MonoBehaviour
{
    public InputActionReference leftTrigger;
    public InputActionReference rightTrigger;
    public InputActionReference leftPrimary;
    public VoiceRecording voiceRecorder;

    // Start is called before the first frame update
    void Start()
    {
        leftTrigger.action.performed += voiceRecorder.StartRecording;
        rightTrigger.action.performed += voiceRecorder.StopRecording;
        leftPrimary.action.performed += voiceRecorder.playRecording;
    }

    

    void printHello(InputAction.CallbackContext action)
    {
        Debug.Log("hello");
    }
}
