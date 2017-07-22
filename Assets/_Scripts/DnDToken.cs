using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Interfaces;
using UnityEngine.EventSystems;
using System;
using cakeslice;

public class DnDToken : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler {

    public GameObject View;
    public Outline outliner;
    bool clickedActive;

    // Use this for initialiszation
    void Start() {
        //Disable View on start
        View.SetActive(false);
        clickedActive = false;
        outliner.eraseRenderer = true;
    }

    // Update is called once per frame
    void Update() {

    }

    #region Model

    //Character Interface

    #endregion

    #region Controller Methods

    /// <summary>
    /// Controller
    /// </summary>
    public void MoveCharacter()
    {
        Debug.Log("Characterd moved...");

    }

    public void TakeDamage(int dmgVal)
    {
        //Decrease Character Health Property
        Debug.Log("Characterd takes " + dmgVal + "dmg");
    }

    #endregion

    #region View Methods
    //View Methods
    void ShowView(bool state)
    {
        View.SetActive(state);
    }

    #endregion

    #region ButtonEvents
    public void OnAttackButton()
    {
        Debug.Log("Check Attack Radius Code");
        //??
    }

    public void OnMoveButton()
    {
        //Show permitted movement 
        //Call MaxMovement Code
        Debug.Log("Call Move Code");
    }

    public void OnLineOfSightButton()
    {
        Debug.Log("Call Line of Sight Code");
        bool isInSight = false;

        Transform target1 = this.transform;
        Transform target2;



        // Track click 1, 
        // Track click 2,
        //Call LineOfSight( transform1, transform2)
        // isInSight;
    }


    #endregion

    #region MouseInteractionEvents

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked");
        outliner.eraseRenderer = !outliner.eraseRenderer;
        ShowView(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("HoverEnter");
        ShowView(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("HoverExit");
        ShowView(false);
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("ClickedDown");
        clickedActive = !clickedActive;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("ClickedUp");
    }
    #endregion  
}
