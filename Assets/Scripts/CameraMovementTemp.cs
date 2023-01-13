using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementTemp : MonoBehaviour
{
    private Vector3 CameraPosition;

    [Header("Camera Settings")]
    public float Distance;


    void Start()
    {
        CameraPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            CameraPosition.y += Distance;
            Debug.Log("Press W");
        }

        if (Input.GetKey(KeyCode.A))
        {
            CameraPosition.y -= Distance;
        }

        if (Input.GetKey(KeyCode.S))
        {
            CameraPosition.x -= Distance;
        }

        if (Input.GetKey(KeyCode.D))
        {
            CameraPosition.x += Distance;
        }
        this.transform.position = CameraPosition;
    }
}
