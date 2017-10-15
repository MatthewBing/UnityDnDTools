using UnityEngine;

public class YAxisBillboarder: MonoBehaviour {

    //Rotates objects on the Y axis only
    void LateUpdate()
    {
        Vector3 camPos = Camera.main.transform.position;
        camPos.y = transform.position.y;
        transform.LookAt(camPos);
        transform.localRotation *= Quaternion.Euler(0f, 180f, 0f);
    }
}