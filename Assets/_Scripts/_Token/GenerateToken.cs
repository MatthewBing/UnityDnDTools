using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateToken : MonoBehaviour {
    public Transform spawnPoint;
    public GameObject prefab;

    public void OnButtonClicked()
    {
        Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }
}
