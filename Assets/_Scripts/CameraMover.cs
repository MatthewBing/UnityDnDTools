using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {
    float vertical;
    float horizontal;

    private void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        transform.position = new Vector3(transform.position.x + horizontal, transform.position.y, transform.position.z + vertical);
    }
}
