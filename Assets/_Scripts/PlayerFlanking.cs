using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlanking : MonoBehaviour {

    //check if near enemy using boxcasting
    //if near enemy send raycast from center of character through center of enemy
    //if raycast hits another player give both players advantage for flanking

    GameObject characterGO;
    RaycastHit enemyInfo;
    RaycastHit playerInfo;

    Vector3 boxDimensions = new Vector3(1,1,1);

	void Start () {
        characterGO = GetComponent<GameObject>();
	}
	
	void Update ()
    {
        Physics.BoxCast(characterGO.transform.position, boxDimensions, transform.up * -1.0f, Quaternion.identity);


	}
}
