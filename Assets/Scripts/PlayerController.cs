using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 startPos_cylinder;
    public Transform transform_cylinder;
    public float sensitivity = 3f;
    public Vector2 turn;

    // Start is called before the first frame update
    void Start()
    {
        startPos_cylinder = transform_cylinder.position;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        MoveLeftRight();
        MoveForwardBack();
        MouseControlRotation();
    }

    void MoveLeftRight()
    {
        Vector3 vec_left = Vector3.zero;
        vec_left.x = Input.GetAxis("Horizontal");
        Vector3 v = new Vector3(vec_left.x, 0.0f, 0.0f) * Time.deltaTime * 8.0f;
        transform_cylinder.Translate(v, Space.Self);
    }

    void MoveForwardBack()
    {
        Vector3 vec_forward = Vector3.zero;
        vec_forward.z = Input.GetAxis("Vertical");
        Vector3 v = new Vector3(0.0f, 0.0f, vec_forward.z) * Time.deltaTime * 8.0f;
        transform_cylinder.Translate(v, Space.Self);
    }


    void MouseControlRotation()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);


    }
}
