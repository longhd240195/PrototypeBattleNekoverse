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
    [SerializeField] private Image preBattle;
    [SerializeField] private List<Image> childs;

    private Vector2 sizeScene;
    private Vector2 initSize;
    private Vector2 sizeChild;
    private Vector2 CurrentSize => new Vector2(img.rectTransform.rect.width, img.rectTransform.rect.height);
    private float sizeMultiple = 3f;
    private bool drag;
    private bool isIn;

    private void Start()
    {
        initSize = new Vector2(img.rectTransform.rect.width, img.rectTransform.rect.height);
        sizeScene = new Vector2(Screen.width, Screen.height);
        sizeChild = new Vector2(64, 64);

        childs.ForEach(i => i.GetComponent<Button>().onClick.AddListener(OpenTitle));
    }

    public void OnDrag(PointerEventData eventData)
    {
        var positionTarget = img.rectTransform.position;
        positionTarget += (Vector3)eventData.delta;

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
        if (!drag)
        {
            if (!isIn)
            {
                var diff = (Vector2)img.rectTransform.position - eventData.position;
                var toCenter = sizeScene / 2 - eventData.position;
                var last = diff * sizeMultiple - diff + toCenter;

                img.rectTransform.DOSizeDelta(sizeMultiple * initSize, 1f);
                img.rectTransform.DOMove(last, 1f).SetRelative(true);
                //childs.ForEach(i => i.rectTransform.DOSizeDelta(sizeMultiple * sizeChild, 1f));
            }
            else
            {
                var diff = (Vector2)img.rectTransform.position - eventData.position;
                var toCenter = sizeScene / 2 - eventData.position;
                var last = diff / sizeMultiple - diff + toCenter;

                img.rectTransform.DOSizeDelta(initSize, 1f);
                img.rectTransform.DOMove(last, 1f).SetRelative(true);
                //childs.ForEach(i => i.rectTransform.DOSizeDelta( sizeChild, 1f));
            }
            isIn = !isIn;
        }

        drag = false;
    }

    private void OpenTitle()
    {
        preBattle.gameObject.SetActive(true);
        preBattle.rectTransform.DOMoveX(sizeScene.x / 2, .5f);
        childs.ForEach(i => i.gameObject.SetActive(false));
    }
    public void CloseTitle()
    {

        preBattle.rectTransform.DOMoveX(sizeScene.x*2, .5f);
        //preBattle.gameObject.SetActive(false);
        childs.ForEach(i => i.gameObject.SetActive(true));
    }
    private Vector2 BottomLeft()
    {
        Vector2 result = Vector2.zero;

        result = CurrentSize / 2;

        return result;
    }

    private Vector2 TopRight()
    {
        Vector2 result = Vector2.zero;

        result = -CurrentSize / 2 + sizeScene;

        return result;
    }


}
