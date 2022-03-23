using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    [SerializeField] private List<RectTransform> listNeko;
    [SerializeField] private GameLoading loadingLoader;
    [SerializeField] private MainAnimationView view;
    private const int MAX_SIZE = 300;
    void Start()
    {
        LoadNeko();
        view.Init();
        // btnStart.onClick.AddListener(() => LoadMapSence());
    }

    void LoadNeko()
    {
        int maxNeko = 4;
        float minSize = MAX_SIZE - (maxNeko - 1) * 20;
        for (int i = 0; i < listNeko.Count; i++)
        {
            if (i < maxNeko)
            {
                float width = minSize + i * 20;
                float height = minSize + i * 20;
                float posX = width / 2 - 350 + i * 50;
                listNeko[i].sizeDelta = new Vector2(width, height);
                listNeko[i].localPosition = new Vector2(posX, listNeko[i].localPosition.y);
                var btn = listNeko[i].gameObject.GetComponent<Button>();
                btn.onClick.AddListener(() => OnLoadYourNeko());
            }
            else
            {
                listNeko[i].gameObject.SetActive(false);
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
}
