using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlanking : MonoBehaviour {

    //check if near enemy using boxcasting
    //if near enemy send raycast from center of character through center of enemy
    //if raycast hits another player give both players advantage for flanking

    //layer 9 is player
    //layer 10 is npc

    Transform characterTrans;
    RaycastHit enemyInfo;
    RaycastHit playerInfo;

    Transform flankingPlayerTrans;
    Transform targetMonsterTrans;

    Vector3 flankDirection;

    float boxRayDistance = 20f;
    float flankDistance = 1f;

    Vector3 boxDimensions = new Vector3(1,1,1);

	void Start () {
        characterTrans = GetComponent<Transform>();
	}
	
	void Update ()
    {
        Physics.BoxCast(characterTrans.position + new Vector3(0,5,0), boxDimensions, transform.up * -1.0f, out enemyInfo);


        if(enemyInfo.transform.gameObject.layer == LayerMask.NameToLayer("NPC"))
        {
            //use raycast to check for a flanking player
            Debug.Log(enemyInfo.transform.gameObject.layer);

            flankDirection = enemyInfo.transform.position - transform.position;

            Physics.Raycast(enemyInfo.transform.position, flankDirection, out playerInfo, flankDistance);

            if(Physics.Raycast(enemyInfo.transform.position, flankDirection, flankDistance) &&playerInfo.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Debug.Log("Flanking" + enemyInfo.transform.gameObject.name);
                // put up ui element to show the player is flanking
            }
        }

	}
}
