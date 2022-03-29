using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Networking;

public class MainController : MonoBehaviour
{
    [SerializeField] private List<RectTransform> listNekoBtn;
    [SerializeField] private List<Image> listNekoTeamImg;
    [SerializeField] private MainAnimationView view;
    private List<NekoData> listMyNeko;
    private const int MAX_SIZE = 300;
    void Start()
    {
        listMyNeko = DataTest.GetMyNekoDatas();
        LoadNeko();
        view.Init();
    }

    void LoadNeko()
    {
        int maxNeko = listMyNeko.Count;
        Debug.Log(maxNeko);
        float minSize = MAX_SIZE - (maxNeko - 1) * 20;
        for (int i = 0; i < listNekoBtn.Count; i++)
        {
            if (i < maxNeko)
            {
                float width = minSize + i * 20;
                float height = minSize + i * 20;
                float posX = width / 2 - 350 + i * 50;
                listNekoBtn[i].sizeDelta = new Vector2(width, height);
                listNekoBtn[i].localPosition = new Vector2(posX, listNekoBtn[i].localPosition.y);
                Button btn = listNekoBtn[i].gameObject.GetComponent<Button>();
                string url = DataConst.NEKO_IMAGE_URL + listMyNeko[i].nft_id + DataConst.NEKO_IMAGE_PNG;
                LoadImage(url, btn.transform.GetChild(0).GetChild(0).GetComponent<Image>());
                btn.onClick.AddListener(() => OnLoadYourNeko());
            }
            else
            {
                listNekoBtn[i].gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < listNekoTeamImg.Count; i++)
        {
            if (i < listMyNeko.Count)
            {
                Image btn = listNekoTeamImg[i].GetComponent<Image>();
                string url = DataConst.NEKO_IMAGE_URL + listMyNeko[i].nft_id + DataConst.NEKO_IMAGE_PNG;
                LoadImage(url, btn);
            }
            else
            {
                listNekoTeamImg[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnLoadYourNeko()
    {
        SceneManager.LoadScene(DataConst.YOUR_NEKO_SCENE);
    }
    public void LoadMapSence()
    {
        SceneManager.LoadScene(DataConst.MAP_SCENE);
    }

    #region Download image from url
    public void LoadImage(string url, Image profileImage)
    {
        StartCoroutine(DownloadImage(url, profileImage));
    }

    IEnumerator DownloadImage(string MediaUrl, Image profileImage)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
        {
            Texture2D webTexture = ((DownloadHandlerTexture)request.downloadHandler).texture as Texture2D;
            Sprite webSprite = SpriteFromTexture2D(webTexture);
            profileImage.sprite = webSprite;
        }
    }

    Sprite SpriteFromTexture2D(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
    #endregion
}
