using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MainAnimationView : MonoBehaviour
{
    [SerializeField] private RectTransform barObj;
    [SerializeField] private RectTransform posBarObj;
    [SerializeField] private RectTransform teamObj;
    [SerializeField] private RectTransform posTeamObj;
    [SerializeField] private RectTransform eventObj;
    [SerializeField] private RectTransform posEventObj;
    [SerializeField] private RectTransform inventoryObj;
    [SerializeField] private RectTransform posInventoryObj;
    [SerializeField] private RectTransform groupAccObj;
    [SerializeField] private RectTransform posGroupAccObj;
    [SerializeField] private RectTransform posBtnStart;
    [SerializeField] private RectTransform btnStart;
    // Start is called before the first frame update
    public void Init()
    {
        barObj.DOLocalMoveY(posBarObj.localPosition.y, 0.5f);
        teamObj.DOLocalMoveX(posTeamObj.localPosition.x, .5f);
        eventObj.DOLocalMoveX(posEventObj.localPosition.x, .5f);
        inventoryObj.DOLocalMoveY(posInventoryObj.localPosition.y, .5f);
        btnStart.DOLocalMoveY(posBtnStart.localPosition.y, .5f);
        groupAccObj.DOLocalMoveY(posGroupAccObj.localPosition.y, .5f);
    }
}
