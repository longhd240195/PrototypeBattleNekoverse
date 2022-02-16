using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GetTouch : MonoBehaviour
{
    public bool interactable;

    public UnityEvent onClick;
    public UnityEvent onMouseEnter;
    public UnityEvent onMouseExit;

    private void OnMouseUpAsButton()
    {
        if (!interactable)
            return;
        Debug.Log("On mouse up button");
        onClick?.Invoke();
    }

    private void OnMouseEnter()
    {
        if (!interactable)
            return;
        Debug.Log("MOuse enter");
        onMouseEnter?.Invoke();
    }

    private void OnMouseExit()
    {
        if (!interactable)
            return;

        onMouseExit?.Invoke();
    }
}
