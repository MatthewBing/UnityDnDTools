using UnityEngine;

public class BillboardedObject : MonoBehaviour {

    void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
    }
}