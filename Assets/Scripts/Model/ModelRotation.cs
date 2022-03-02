using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelRotation : MonoBehaviour
{
    private Vector2 oldPosition;

    private void OnMouseDown()
    {
        oldPosition = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        var diff = oldPosition - (Vector2)Input.mousePosition;
        oldPosition = Input.mousePosition;
      
        if (Mathf.Abs(oldPosition.x) > 0)
        {
            transform.Rotate(0,diff.x,0);
        }
    }
}
