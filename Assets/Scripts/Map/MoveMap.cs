using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveMap : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    [SerializeField] private Image img;

    private Vector2 sizeScene;
    
    private Vector2 initSize;
    private Vector2 CurrentSize => new Vector2(img.rectTransform.rect.width,img.rectTransform.rect.height);
    private float sizeMultiple = 3f;
    private bool drag;
    
    private void Start()
    {
        initSize = new Vector2(img.rectTransform.rect.width,img.rectTransform.rect.height);
        sizeScene = new Vector2(Screen.width,Screen.height);
        
        Debug.Log(initSize);
        Debug.Log(sizeScene);
    }

    public void OnDrag(PointerEventData eventData)
    {
        var positionTarget = img.rectTransform.position;
        positionTarget += (Vector3) eventData.delta;

        var topRight = TopRight();
        var bottomLeft = BottomLeft();

        if (positionTarget.x < topRight.x)
            positionTarget.x = topRight.x;
        else if (positionTarget.x > bottomLeft.x)
            positionTarget.x = bottomLeft.x;
        
        if (positionTarget.y < topRight.y)
            positionTarget.y = topRight.y;
        else if (positionTarget.y > bottomLeft.y)
            positionTarget.y = bottomLeft.y;

        drag = true;
        img.rectTransform.position = positionTarget;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var diff = (Vector2) img.rectTransform.position - eventData.position ;

        if (!drag)
        {
            Debug.Log(diff);
            img.rectTransform.DOSizeDelta(sizeMultiple * initSize,1f);
            var last = diff * sizeMultiple - diff;
            img.rectTransform.DOMove(last, 1f).SetRelative(true);

        }
        
        drag = false;
    }
    
    private Vector2 BottomLeft()
    {
        Vector2 result = Vector2.zero;

        result =  CurrentSize / 2;

        return result;
    }

    private Vector2 TopRight()
    {
        Vector2 result = Vector2.zero;

        result = - CurrentSize / 2 + sizeScene;

        return result;
    }

    
}
