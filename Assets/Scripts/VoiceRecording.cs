using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.InputSystem;


public class VoiceRecording : MonoBehaviour
{
    public GameObject tile;
    public GameObject xrRig;
    public AudioSource audioSource;
    public Material[] materials;

    private AudioClip recordedClip;
    private string device;
    private bool isRecording;
    private GameObject newTile;
    private GameObject newTileCore;
    private Animator tileAnimation;
    private AudioClip storedClip;

    


    void Start()
    {
        device = Microphone.devices[0];
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
            instantiateTile(recordedClip);
        }
    }

    public void StopRecording(InputAction.CallbackContext action)
    {
        if (isRecording)
        {
            isRecording = false;
            Microphone.End(device);
            tileAnimation.SetInteger("state", 1);
            newTileCore.GetComponent<PlayAudioInteraction>().shouldTrigget = true;
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
        // instantiate material, position on start recording
        // fill in clip after recording

        newTile = Instantiate(tile) as GameObject;
        newTileCore = newTile.transform.GetChild(0).gameObject;

        newTileCore.GetComponent<PlayAudioInteraction>().shouldTrigget = false;

        // Set render material
        int index = Random.Range(0, materials.Length - 1);
        MeshRenderer renderer = newTileCore.GetComponent<MeshRenderer>();
        Material[] renderMaterials = renderer.materials;
        renderMaterials[0] = materials[index];
        renderer.materials = renderMaterials;

        // Set initial position and audio clip
        var tilePosition = new Vector3(this.transform.position.x, this.transform.position.y - 1.5f, this.transform.position.z);
        newTile.transform.position = tilePosition;

        storedClip = clip;
        setAudioClip();

        // Set animator
        tileAnimation = newTileCore.GetComponent<Animator>();
    }

    public void setAudioClip(){
        AudioSource audioSource = newTileCore.GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = storedClip;
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