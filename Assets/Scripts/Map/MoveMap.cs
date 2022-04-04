using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class MoveMap : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    [SerializeField] private Image img;
    [SerializeField] private Image preBattle;
    [SerializeField] private Image preBattle2;
    [SerializeField] private List<Button> areasBtn;
    [SerializeField] private List<Button> lands;
    [SerializeField] private List<Button> enemyBtn;
    [SerializeField] private BattleView battleView;
    [SerializeField] private GameObject loadingPrefab;
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

    //data map api
    private AreaResponse areaResponse;
    private List<SArea> listAreas;
    private List<MapLevelIdResponse> mapLevelIdResponse;

    private void Awake()
    {
        areaResponse = DataApi.GetInstance().GetAreaResponse();
        mapLevelIdResponse = DataApi.GetInstance().GetMapLevelIdResponse();
        listAreas = areaResponse.data.ToList();
    }
    private void Start()
    {
        initSize = new Vector2(img.rectTransform.rect.width, img.rectTransform.rect.height);
        sizeScene = new Vector2(Screen.width, Screen.height);
        sizeChild = new Vector2(64, 64);
        LoadArea();
        barObj.DOLocalMoveY(posBar.localPosition.y, 0.5f);
        InventoryObj.DOLocalMoveY(posInventory.localPosition.y, 0.5f);
    }
    public void LoadHomeScene()
    {
        GameUtilities.LoadingScene(DataConst.MAIN_SCENE, transform, loadingPrefab, this);
    }
    public void OpenSceneBattle()
    {
        GameUtilities.LoadingScene(DataConst.BATTLE_SCENE, transform, loadingPrefab, this);
    }
    void LoadArea()
    {
        for (int i = 0; i < listAreas.Count; i++)
        {
            Button btn = areasBtn.Find(s => s.GetComponent<Area>().nameArea == listAreas[i].name);
            btn.gameObject.SetActive(true);
            Area area = btn.gameObject.GetComponent<Area>();
            area.data = listAreas[i];
        }
        areasBtn.ForEach(s => s.onClick.AddListener(() => OnBtnPointerClick(s)));
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
                SetActiveBtnArea(true);
                lands.ForEach(i => i.gameObject.SetActive(false));
            }
            isIn = !isIn;
        }
        drag = false;
    }
    public void OnBtnPointerClick(Button eventBtn)
    {
        if (!drag)
        {
            if (!isIn)
            {
                var diff = (Vector2)img.rectTransform.position - (Vector2)eventBtn.transform.position;
                var toCenter = sizeScene / 2 - (Vector2)eventBtn.transform.position;
                var last = diff * sizeMultiple - diff + toCenter;
                img.rectTransform.DOSizeDelta(sizeMultiple * initSize, 1f);
                img.rectTransform.DOMove(last, 1f).SetRelative(true);
                SetActiveBtnArea(false);
                Area area = eventBtn.gameObject.GetComponent<Area>();
                List<MapLevelId> l = new List<MapLevelId>();
                for (int i = 0; i < mapLevelIdResponse.Count; i++)
                {
                    if(mapLevelIdResponse[i].data.area_id == area.data.id)
                    {
                        l.Add(mapLevelIdResponse[i].data);
                    }
                }
                for (int i = 0; i < l.Count; i++)
                {
                    LandArea land = area.landAreas.Find(s => s.level == l[i].level);
                    land.gameObject.SetActive(true);
                    land.data = l[i];
                }
                area.landAreas.ForEach(s => s.gameObject.GetComponent<Button>().onClick.AddListener(() => OpenTitle(s.gameObject.GetComponent<Button>())));
            }
            else
            {
                var diff = (Vector2)img.rectTransform.position - (Vector2)eventBtn.transform.position;
                var toCenter = sizeScene / 2 - (Vector2)eventBtn.transform.position;
                var last = diff / sizeMultiple - diff + toCenter;

                Vector2 center = new Vector2(0f, 0f);
                img.rectTransform.DOSizeDelta(initSize, 1f);
                img.rectTransform.DOLocalMove(center, 1f);
                SetActiveBtnArea(true);
                lands.ForEach(i => i.gameObject.SetActive(false));
            }
            isIn = !isIn;
        }
        drag = false;
    }
    void SetActiveBtnArea(bool isActive)
    {
        for (int i = 0; i < listAreas.Count; i++)
        {
            Button btn = areasBtn.Find(s => s.GetComponent<Area>().nameArea == listAreas[i].name);
            btn.gameObject.SetActive(isActive);
        }
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
                EnemyView e = b.GetComponent<EnemyView>();
                e.enemy = land.data.enemies[i];
                b.onClick.AddListener(() => OpenBatlle(e.enemy,e.icon));
            }
            else
            {
                enemyBtn[i].gameObject.SetActive(false);
            }
        }
        //Check current level
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
    private void OpenBatlle(Enemy e,Image icon)
    {
        battleView.InitBattle(e,icon);
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
