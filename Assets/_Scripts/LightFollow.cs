using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour {

    GameObject lastRolledDie;
    GameObject DiceManager;

    private void Start()
    {
        DiceManager = GameObject.Find("DiceManager");
    }
    private void Update()
    {
        if(DiceManager.GetComponent<DiceRoller>().lastDieRoll == null)
        {
            return;
        }
        else
            lastRolledDie = DiceManager.GetComponent<DiceRoller>().lastDieRoll;

        transform.LookAt(lastRolledDie.transform);
    }

}
