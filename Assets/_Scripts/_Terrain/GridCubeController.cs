using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridCubeController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {
    Color previousColor;

    public void OnCubeReached(bool toggle)
    {
        if (toggle == true)
            GetComponent<Renderer>().material.color = Color.green;
        else
            GetComponent<Renderer>().material.color = Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Entering tile edit mode.");
    }

    public void OnPointerEnter(PointerEventData data)
    {
        previousColor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData data)
    {
        GetComponent<Renderer>().material.color = previousColor;
    }
}
