using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour {

    public List<GameObject> dicePrefab = new List<GameObject>();
    public GameObject dicePanel;
    public GameObject lastDieRoll;
    

    private void Start()
    {
        
    }

    public void RollDice(int die)
    {
        Vector3 force = new Vector3(Random.Range(-3f, 3f), 0f, Random.Range(-3f, 3f));
        Vector3 torque = new Vector3(Random.Range(10, 20), Random.Range(10, 20), 0f);
        GameObject currentDie = Instantiate(dicePrefab[die], new Vector3(0, .5f, 0), Quaternion.identity);
        lastDieRoll = currentDie;
        currentDie.GetComponent<Rigidbody>().maxAngularVelocity = 40f;
        currentDie.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        currentDie.GetComponent<Rigidbody>().AddTorque(torque, ForceMode.Impulse);
    }
    public void OpenPanel()
    {
        dicePanel.SetActive(true);
    }
    public void ClosePanel()
    {
        dicePanel.SetActive(false);
    }

    public void DiceKiller()
    {
        foreach (var dice in GameObject.FindGameObjectsWithTag("Dice"))
        {
            Destroy(dice);
        }
    }
    public void D4()
    {
        RollDice(0);
    }
    public void D6()
    {
        RollDice(1);
    }
    public void D8()
    {
        RollDice(2);
    }
    public void D10()
    {
        RollDice(3);
    }
    public void D10Percentile()
    {
        RollDice(4);
    }
    public void D12()
    {
        RollDice(5);
    }
    public void D20()
    {
        RollDice(6);
    }
}
