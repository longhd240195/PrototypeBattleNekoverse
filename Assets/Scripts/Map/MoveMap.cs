using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveMap : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    [SerializeField] private Image img;
    [SerializeField] private Image preBattle;
    [SerializeField] private Image preBattle2;
    [SerializeField] private List<Button> areas;
    [SerializeField] private List<Button> levels;
    [SerializeField] private BattleView battleView;
    private MapData[] cacheMap;
    private Vector2 sizeScene;
    private Vector2 initSize;
    private Vector2 sizeChild;
    private Vector2 CurrentSize => new Vector2(img.rectTransform.rect.width, img.rectTransform.rect.height);
    private float sizeMultiple = 3f;
    private bool drag;
    private bool isIn;
    private void Awake()
    {
        LoadDataMap();
    }
    private void Start()
    {
        initSize = new Vector2(img.rectTransform.rect.width, img.rectTransform.rect.height);
        sizeScene = new Vector2(Screen.width, Screen.height);
        sizeChild = new Vector2(64, 64);
        LoadArea(areas);
    }

    void LoadArea(List<Button> btnAreas)
    {
        for (int i = 0; i < btnAreas.Count; i++)
        {
            if (i < cacheMap.Length)
            {
                btnAreas[i].gameObject.SetActive(true);
                int index = i;
                var area = cacheMap[i];
                btnAreas[index].onClick.AddListener(() => OpenTitle(area));
            }
            else
            {
                btnAreas[i].gameObject.SetActive(false);
            }
        }
    }
    void LoadLevel(List<Button> btnLevel, MapData area)
    {
        for (int i = 0; i < btnLevel.Count; i++)
        {
            if (i < area.DataLevel.Count)
            {
                btnLevel[i].gameObject.SetActive(true);
                int index = i;
                var level = area.DataLevel[i];
                btnLevel[i].GetComponent<LevelView>().level = level;
                btnLevel[i].GetComponent<LevelView>().SetIconLevel();
                btnLevel[index].onClick.AddListener(() => OpenBatlle(level));
            }
            else
            {
                btnLevel[i].gameObject.SetActive(false);
            }
        }
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
                //areas.ForEach(i => i.rectTransform.DOSizeDelta(sizeMultiple * sizeChild, 1f));
            }
            else
            {
                var diff = (Vector2)img.rectTransform.position - eventData.position;
                var toCenter = sizeScene / 2 - eventData.position;
                var last = diff / sizeMultiple - diff + toCenter;

                img.rectTransform.DOSizeDelta(initSize, 1f);
                img.rectTransform.DOMove(last, 1f).SetRelative(true);
                //areas.ForEach(i => i.rectTransform.DOSizeDelta(sizeChild, 1f));
            }
            isIn = !isIn;
        }

        drag = false;
    }

    private void OpenTitle(MapData a)
    {
        preBattle.gameObject.SetActive(true);
        preBattle.rectTransform.DOMoveX(sizeScene.x / 2, .5f);
        areas.ForEach(i => i.gameObject.SetActive(false));
        LoadLevel(levels, a);
    }
    public void CloseTitle()
    {
        preBattle.rectTransform.DOMoveX(sizeScene.x * 2, .5f);
        areas.ForEach(i => i.gameObject.SetActive(true));
    }
    private void OpenBatlle(LevelData l)
    {
        battleView.InitBattle(l);
        preBattle2.gameObject.SetActive(true);
        preBattle2.rectTransform.DOMoveX(sizeScene.x / 2, .5f);
    }
    public void CloseBatlle()
    {
        //preBattle2.gameObject.SetActive(false);
        preBattle2.rectTransform.DOMoveX(sizeScene.x * 2, .5f);
    }
    public void OpenSceneYourNeko()
    {
        SceneManager.LoadScene(DataConst.YOUR_NEKO_SCENE);
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

    private void LoadDataMap()
    {
        cacheMap = Resources.LoadAll<MapData>($"MapData");
    }

}
