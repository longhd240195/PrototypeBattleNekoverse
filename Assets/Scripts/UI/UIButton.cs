using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIButton : Button, IBeginDragHandler, IPointerUpHandler , IDragHandler
{
    public UnityEvent onStartDrag;
    public UnityEvent<PointerEventData> onDrag;
    public UnityEvent onPointerUp;

    private bool isDrag = false;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        onStartDrag?.Invoke();
        isDrag = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        onDrag?.Invoke(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);

        if(isDrag)
            onPointerUp?.Invoke();
        isDrag = false;
    }
}
