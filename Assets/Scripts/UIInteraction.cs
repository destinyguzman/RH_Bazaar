using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInteraction : MonoBehaviour
{
    public InputActionReference leftTrigger;
    public InputActionReference rightTrigger;
    public VoiceRecording voiceRecorder;


    // Start is called before the first frame update
    void Start()
    {
        //leftTrigger.action.performed += voiceRecorder.StartRecording;
        //rightTrigger.action.performed += voiceRecorder.StopRecording;
    }

    void printHello(InputAction.CallbackContext action)
    {
        Debug.Log("hello");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
