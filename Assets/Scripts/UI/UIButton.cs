using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UIButton : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IPointerUpHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        //TODO: Asign skill+ for player
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
        //TODO: Click, assign skill for player
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("pointer up");
        //TODO: End assign action
    }

}
