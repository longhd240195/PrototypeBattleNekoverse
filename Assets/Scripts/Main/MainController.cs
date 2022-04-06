using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class MainController : MonoBehaviour
{
    [SerializeField] private List<RectTransform> listNekoBtn;
    [SerializeField] private List<Image> listNekoTeamImg;
    [SerializeField] private MainAnimationView view;
    [SerializeField] private GameObject loadingPrefab;
    private const int MAX_SIZE = 300;
    private UserNekosResponse userNekosResponse;
    private MapLevelResponse mapLevelResponse;
    private void Awake()
    {
        mapLevelResponse = DataApi.GetInstance().GetMapLevelResponse();
        if (DataApi.GetInstance().GetMapLevelIdResponse().Count == 0)
        {
            for (int i = 0; i < mapLevelResponse.data.Length; i++)
            {
                DataApi.GetInstance().manager.GetData("/v1/pve/map-levels/", mapLevelResponse.data[i].id);
            }
        }
        userNekosResponse = DataApi.GetInstance().GetUserNekoResponse();
    }

    void Start()
    {
        LoadNeko();
        view.Init();
    }

    void LoadNeko()
    {
        int maxNeko = userNekosResponse.data.Length;
        if (userNekosResponse.data.Length >= 5)
        {
            maxNeko = 5;
        }
        else
        {
            maxNeko = userNekosResponse.data.Length;
        }
        float minSize = MAX_SIZE - (maxNeko - 1) * 40;
        for (int i = 0; i < listNekoBtn.Count; i++)
        {
            if (i < maxNeko)
            {
                float width = minSize + i * 40;
                float height = minSize + i * 40;
                float posX = width / 2 - 350 + i * 50;
                listNekoBtn[i].sizeDelta = new Vector2(width, height);
                listNekoBtn[i].localPosition = new Vector2(posX, listNekoBtn[i].localPosition.y);
                Button btn = listNekoBtn[i].gameObject.GetComponent<Button>();
                string url = DataConst.NEKO_IMAGE_URL + userNekosResponse.data[i].nft_id + DataConst.NEKO_IMAGE_PNG;
                Image img = btn.transform.GetChild(0).GetChild(0).GetComponent<Image>();
                GameUtilities.LoadImage(url, img, this);
                btn.onClick.AddListener(() => OnLoadYourNeko());
            }
            else
            {
                listNekoBtn[i].gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < listNekoTeamImg.Count; i++)
        {
            if (i < userNekosResponse.data.Length)
            {
                Image btn = listNekoTeamImg[i].GetComponent<Image>();
                string url = DataConst.NEKO_IMAGE_URL + userNekosResponse.data[i].nft_id + DataConst.NEKO_IMAGE_PNG;
                GameUtilities.LoadImage(url, btn, this);
            }
            else
            {
                listNekoTeamImg[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnLoadYourNeko()
    {
        GameUtilities.LoadingScene(DataConst.YOUR_NEKO_SCENE, transform, loadingPrefab, this);
    }
    public void LoadMapSence()
    {
        GameUtilities.LoadingScene(DataConst.MAP_SCENE, transform, loadingPrefab, this);
    }
}
