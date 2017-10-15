using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMover : MonoBehaviour {
    public float rotateSpeed = 30;

    float vertical;
    float horizontal;

    //Unfortunately, Unity's event system is stupid and we're forced to use the input manager for moving and scrolling
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        //Rotation
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(0, Time.deltaTime * rotateSpeed, 0, Space.World);
        else if (Input.GetKey(KeyCode.Q))
            transform.Rotate(0, -Time.deltaTime * rotateSpeed, 0, Space.World);

        Vector3 globalForward = transform.forward;
        globalForward.y = 0;
        
        //Moving
        transform.position += transform.right * horizontal;
        transform.position += globalForward * vertical;


        //Scrolling
        GetComponent<Camera>().fieldOfView += Input.mouseScrollDelta.y * 1.5f;
    }
}
