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
    [SerializeField] private List<Button> areasBtn;
    [SerializeField] private List<Button> lands;
    [SerializeField] private List<Button> enemyBtn;
    [SerializeField] private BattleView battleView;
    [Header("Anim")]
    [SerializeField] private RectTransform posBar;
    [SerializeField] private RectTransform barObj;
    [SerializeField] private RectTransform posInventory;
    [SerializeField] private RectTransform InventoryObj;

    private Vector2 sizeScene;
    private Vector2 initSize;
    private Vector2 sizeChild;
    private Vector2 CurrentSize => new Vector2(img.rectTransform.rect.width, img.rectTransform.rect.height);
    private float sizeMultiple = 3f;
    private bool drag;
    private bool isIn;

    //data map api fake
    private List<DataArea> listDataAreas;
    private List<DataAreaLevel> listDataAreaLevel;
    private void Awake()
    {
        listDataAreas = DataTest.GetDataAreas();
        listDataAreaLevel = DataTest.GetDataAreaLevels();
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
        SceneManager.LoadScene(DataConst.MAIN_SCENE);
    }
    public void OpenSceneBattle()
    {
        SceneManager.LoadScene(DataConst.BATTLE_SCENE);
    }
    void LoadArea(List<Button> btnAreas)
    {
        for (int i = 0; i < listDataAreas.Count; i++)
        {
            Button btn = btnAreas.Find(s => s.GetComponent<Area>().nameArea == listDataAreas[i].name);
            btn.gameObject.SetActive(true);
            Area area = btn.gameObject.GetComponent<Area>();
            area.data = listDataAreas[i];
        }
        btnAreas.ForEach(s => s.onClick.AddListener(() => OnBtnPointerClick(s)));
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
        if (!drag)
        {
            if (isIn)
            {
                var diff = (Vector2)img.rectTransform.position - eventData.position;
                var toCenter = sizeScene / 2 - eventData.position;
                var last = diff / sizeMultiple - diff + toCenter;
                Vector2 center = new Vector2(0f, 0f);
                img.rectTransform.DOSizeDelta(initSize, 1f);
                img.rectTransform.DOLocalMove(center, 1f);
                areasBtn.ForEach(i => i.gameObject.SetActive(true));
                lands.ForEach(i => i.gameObject.SetActive(false));
            }
            isIn = !isIn;
        }
        drag = false;
    }
    public void OnBtnPointerClick(Button eventData)
    {
        if (!drag)
        {
            if (!isIn)
            {
                var diff = (Vector2)img.rectTransform.position - (Vector2)eventData.transform.position;
                var toCenter = sizeScene / 2 - (Vector2)eventData.transform.position;
                var last = diff * sizeMultiple - diff + toCenter;
                img.rectTransform.DOSizeDelta(sizeMultiple * initSize, 1f);
                img.rectTransform.DOMove(last, 1f).SetRelative(true);
                areasBtn.ForEach(i => i.gameObject.SetActive(false));
                Area area = eventData.gameObject.GetComponent<Area>();
                area.landAreas.ForEach(s => s.gameObject.SetActive(true));
                for (int i = 0; i < listDataAreaLevel.Count; i++)
                {
                    if(listDataAreaLevel[i].area_id == area.data.id)
                    {
                        area.landAreas.ForEach(s => s.data = listDataAreaLevel[i]);
                    }
                }
                area.landAreas.ForEach(s => s.gameObject.GetComponent<Button>().onClick.AddListener(() => OpenTitle(s.gameObject.GetComponent<Button>())));
            }
            else
            {
                var diff = (Vector2)img.rectTransform.position - (Vector2)eventData.transform.position;
                var toCenter = sizeScene / 2 - (Vector2)eventData.transform.position;
                var last = diff / sizeMultiple - diff + toCenter;

                Vector2 center = new Vector2(0f, 0f);
                img.rectTransform.DOSizeDelta(initSize, 1f);
                img.rectTransform.DOLocalMove(center, 1f);
                areasBtn.ForEach(i => i.gameObject.SetActive(true));
                lands.ForEach(i => i.gameObject.SetActive(false));
            }
            isIn = !isIn;
        }
        drag = false;
    }
    void LoadEnemy(Button btn)
    {
        LandArea land = btn.GetComponent<LandArea>();
        for (int i = 0; i < enemyBtn.Count; i++)
        {
            if (i < land.data.enemies.Length)
            {
                Button b = enemyBtn[i];
                b.gameObject.SetActive(true);
                EnemyView l = b.GetComponent<EnemyView>();
                l.enemy = land.data.enemies[i];
                b.onClick.AddListener(() => OpenBatlle(l.enemy,l.icon));
            }
            else
            {
                enemyBtn[i].gameObject.SetActive(false);
            }
        }
    }
    private void OpenTitle(Button btn)
    {
        preBattle.gameObject.SetActive(true);
        preBattle.rectTransform.DOMoveX(sizeScene.x / 2, .5f);
        LoadEnemy(btn);
    }
    public void CloseTitle()
    {
        preBattle.rectTransform.DOMoveX(sizeScene.x * 2, .5f);
    }
    private void OpenBatlle(DataEnemy l,Image icon)
    {
        battleView.InitBattle(l,icon);
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
}
