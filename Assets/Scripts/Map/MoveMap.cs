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
    [SerializeField] private GameLoading levelLoader;
    [SerializeField] private Image img;
    [SerializeField] private Image preBattle;
    [SerializeField] private Image preBattle2;
    [SerializeField] private List<Button> areasBtn;
    [SerializeField] private List<Button> lands;
    [SerializeField] private List<Button> levels;
    [SerializeField] private BattleView battleView;
    [Header("Anim")]
    [SerializeField] private RectTransform posBar;
    [SerializeField] private RectTransform barObj;
    [SerializeField] private RectTransform posInventory;
    [SerializeField] private RectTransform InventoryObj;

    private List<Button> btnCacheLands = new List<Button>();
    private Dictionary<string, MapData[]> cacheMap;
    private Dictionary<string, MapData[]> Cache =>
        cacheMap ?? (cacheMap = new Dictionary<string, MapData[]>());

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
        LoadArea(areasBtn);
        barObj.DOLocalMoveY(posBar.localPosition.y, 0.5f);
        InventoryObj.DOLocalMoveY(posInventory.localPosition.y, 0.5f);
    }
    public void LoadHomeScene()
    {
        //levelLoader.LoadLevel(DataConst.MAIN_SCENE);
        SceneManager.LoadScene(DataConst.MAIN_SCENE);
    }
    public void OpenSceneBattle()
    {
        //levelLoader.LoadLevel(DataConst.BATTLE_SCENE);
        SceneManager.LoadScene(DataConst.BATTLE_SCENE);
    }
    void LoadArea(List<Button> btnAreas)
    {
        for (int i = 0; i < btnAreas.Count; i++)
        {
            if (i < cacheMap.Count)
            {
                btnAreas[i].gameObject.SetActive(true);
                int index = i;
                var area = Cache[btnAreas[i].name];
                btnAreas[index].onClick.AddListener(() => OnBtnPointerClick(btnAreas[index], area));
            }
            else
            {
                btnAreas[i].gameObject.SetActive(false);
            }
        }
    }
    void LoadLand(List<Button> btnLands, MapData[] lands)
    {
        for (int i = 0; i < btnLands.Count; i++)
        {
            if (i < lands.Length)
            {
                btnLands[i].gameObject.SetActive(true);
                int index = i;
                var area = lands[i];
                btnLands[index].onClick.AddListener(() => OpenTitle(area));
            }
            else
            {
                btnLands[i].gameObject.SetActive(false);
            }
        }
    }
    void LoadLevel(List<Button> btnLevels, MapData area)
    {
        for (int i = 0; i < btnLevels.Count; i++)
        {
            if (i < area.DataLevel.Count)
            {
                btnLevels[i].gameObject.SetActive(true);
                int index = i;
                var level = area.DataLevel[i];
                btnLevels[i].GetComponent<LevelView>().level = level;
                btnLevels[i].GetComponent<LevelView>().SetIconLevel();
                btnLevels[index].onClick.AddListener(() => OpenBatlle(level));
            }
            else
            {
                btnLevels[i].gameObject.SetActive(false);
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

        img.rectTransform.position = positionTarget;
        drag = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        drag = false;
        if (!drag)
        {
            if (isIn)
            {
                // var diff = (Vector2)img.rectTransform.position - eventData.position;
                // var toCenter = sizeScene / 2 - eventData.position;
                // var last = diff * sizeMultiple - diff + toCenter;

                // img.rectTransform.DOSizeDelta(sizeMultiple * initSize, 1f);
                // img.rectTransform.DOMove(last, 1f).SetRelative(true);
                //areas.ForEach(i => i.rectTransform.DOSizeDelta(sizeMultiple * sizeChild, 1f));
                var diff = (Vector2)img.rectTransform.position - eventData.position;
                var toCenter = sizeScene / 2 - eventData.position;
                var last = diff / sizeMultiple - diff + toCenter;
                Vector2 center = new Vector2(0f, 0f);
                img.rectTransform.DOSizeDelta(initSize, 1f);
                //img.rectTransform.DOMove(center, 1f).SetRelative(true);
                img.rectTransform.DOLocalMove(center, 1f);
                Debug.Log(last + " " + drag);

                //areas.ForEach(i => i.rectTransform.DOSizeDelta(sizeChild, 1f));
                areasBtn.ForEach(i => i.gameObject.SetActive(true));
                lands.ForEach(i => i.gameObject.SetActive(false));
            }
            // else
            // {
            //     var diff = (Vector2)img.rectTransform.position - eventData.position;
            //     var toCenter = sizeScene / 2 - eventData.position;
            //     var last = diff / sizeMultiple - diff + toCenter;
            //     Vector2 center = new Vector2(0f, 0f);
            //     img.rectTransform.DOSizeDelta(initSize, 1f);
            //     //img.rectTransform.DOMove(center, 1f).SetRelative(true);
            //     img.rectTransform.DOLocalMove(center, 1f);
            //     Debug.Log(last);

            //     //areas.ForEach(i => i.rectTransform.DOSizeDelta(sizeChild, 1f));
            //     areasBtn.ForEach(i => i.gameObject.SetActive(true));
            //     lands.ForEach(i => i.gameObject.SetActive(false));
            // }
            isIn = !isIn;
        }

    }
    public void OnBtnPointerClick(Button eventData, MapData[] l)
    {
        drag = false;
        if (!drag)
        {
            if (!isIn)
            {
                var diff = (Vector2)img.rectTransform.position - (Vector2)eventData.transform.position;
                var toCenter = sizeScene / 2 - (Vector2)eventData.transform.position;
                var last = diff * sizeMultiple - diff + toCenter;

                img.rectTransform.DOSizeDelta(sizeMultiple * initSize, 1f);
                img.rectTransform.DOMove(last, 1f).SetRelative(true);
                // areas.ForEach(i => i.rectTransform.DOSizeDelta(sizeMultiple * sizeChild, 1f));
                areasBtn.ForEach(i => i.gameObject.SetActive(false));
                btnCacheLands.Clear();
                for (int i = 0; i < lands.Count; i++)
                {
                    var landOfArea = lands[i].GetComponent<LandArea>().NameArea;
                    var areaName = eventData.gameObject.GetComponent<Area>().area;
                    if (landOfArea == areaName)
                    {
                        btnCacheLands.Add(lands[i]);
                    }
                }
                LoadLand(btnCacheLands, l);
            }
            else
            {
                var diff = (Vector2)img.rectTransform.position - (Vector2)eventData.transform.position;
                var toCenter = sizeScene / 2 - (Vector2)eventData.transform.position;
                var last = diff / sizeMultiple - diff + toCenter;

                Vector2 center = new Vector2(0f, 0f);
                img.rectTransform.DOSizeDelta(initSize, 1f);
                //img.rectTransform.DOMove(center, 1f).SetRelative(true);
                img.rectTransform.DOLocalMove(center, 1f);
                //areas.ForEach(i => i.rectTransform.DOSizeDelta(sizeChild, 1f));
                areasBtn.ForEach(i => i.gameObject.SetActive(true));
                lands.ForEach(i => i.gameObject.SetActive(false));
            }
            isIn = !isIn;
        }
        //drag = false;
    }

    private void OpenTitle(MapData a)
    {
        preBattle.gameObject.SetActive(true);
        preBattle.rectTransform.DOMoveX(sizeScene.x / 2, .5f);
        LoadLevel(levels, a);
    }
    public void CloseTitle()
    {
        preBattle.rectTransform.DOMoveX(sizeScene.x * 2, .5f);
    }
    private void OpenBatlle(LevelData l)
    {
        battleView.InitBattle(l);
        preBattle2.gameObject.SetActive(true);
        preBattle2.rectTransform.DOMoveX(sizeScene.x / 2, .5f);
    }
    public void CloseBatlle()
    {
        preBattle2.rectTransform.DOMoveX(sizeScene.x * 2, .5f);
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
        ReadDataScripableMap(DataConst.NAME_FOLDER_AREA + "1");
        ReadDataScripableMap(DataConst.NAME_FOLDER_AREA + "2");
        ReadDataScripableMap(DataConst.NAME_FOLDER_AREA + "3");
        ReadDataScripableMap(DataConst.NAME_FOLDER_AREA + "4");
        ReadDataScripableMap(DataConst.NAME_FOLDER_AREA + "5");
        ReadDataScripableMap(DataConst.NAME_FOLDER_AREA + "6");
        ReadDataScripableMap(DataConst.NAME_FOLDER_AREA + "7");
    }

    private void ReadDataScripableMap(string areaName)
    {
        var listItem = Resources.LoadAll<MapData>($"MapData/{areaName}");
        Cache.Add(areaName, listItem);
    }

}
