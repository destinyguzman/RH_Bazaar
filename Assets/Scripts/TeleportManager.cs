using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public Transform Destination;       // Gameobject where they will be teleported to
    public GameObject Player;

    public void OnTriggerEnter(Collider other)
    {
        // Update other objects position and rotation
        Player.transform.position = Destination.transform.position;
        Player.transform.rotation = Destination.transform.rotation;

        Debug.Log("Collide");
    }

}
