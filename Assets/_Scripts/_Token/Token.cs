using UnityEngine;
using UnityEngine.EventSystems;
using cakeslice;
using System;

public class Token : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler , IBeginDragHandler, IEndDragHandler {
    public GameObject tokenMenu;
    public Outline outline;

    bool disableClick;
    bool isShowMovement;

    public bool debug;

    void Start() {
        tokenMenu.SetActive(false);
        disableClick = false;
        outline.eraseRenderer = true;
    }

    void ShowView(bool state)
    {
        tokenMenu.SetActive(state);
    }

    void ToggleMovementSpeed()
    {
        isShowMovement = !isShowMovement;

        Collider[] hitColliders = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y - 5, transform.position.z), 6);

        foreach (Collider col in hitColliders)
        {
            if (col.GetComponent<GridCubeController>())
                col.GetComponent<GridCubeController>().OnCubeReached(isShowMovement);
        }
    }

    #region Pointer Handlers

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (debug)
            Debug.Log("Pointer entered");

        if (disableClick == false)
            ShowView(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (debug)
            Debug.Log("Pointer exited");

        if (disableClick == false)
            ShowView(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.dragging)
            return;

        if (debug)
            Debug.Log("Clicked");

        outline.eraseRenderer = !outline.eraseRenderer;
        disableClick = !disableClick;
        ToggleMovementSpeed();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (debug)
            Debug.Log("Drag start");

        if (isShowMovement)
            ToggleMovementSpeed();

        disableClick = true;
        outline.eraseRenderer = true;
        ShowView(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        GameObject hoveredGrid = eventData.pointerEnter;

        if (hoveredGrid == null)
            return;

        if (hoveredGrid.layer == 8)
            transform.position = new Vector3(hoveredGrid.transform.position.x, hoveredGrid.transform.position.y + GetComponent<Collider>().bounds.extents.y + hoveredGrid.GetComponent<Collider>().bounds.extents.y, hoveredGrid.transform.position.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (debug)
            Debug.Log("Drag end");

        disableClick = false;

        if (eventData.pointerEnter == gameObject)
            ShowView(true);
    }

    #endregion
}
