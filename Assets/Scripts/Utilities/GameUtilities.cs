using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUtilities : MonoBehaviour
{
    #region load scene
    public static void LoadingScene(string sceneName, Transform parent, GameObject loadingPrefab,MonoBehaviour behaviour)
    {
        behaviour.StartCoroutine(LoadScene(sceneName, parent, loadingPrefab));
    }
    private static IEnumerator LoadScene(string sceneName, Transform parent, GameObject loadingPrefab)
    {
        GameObject loading = Instantiate(loadingPrefab);
        loading.transform.SetParent(parent);
        loading.transform.localPosition = new Vector2(0, 0);
        yield return new WaitForSeconds(2f);
        Destroy(loading);
        SceneManager.LoadScene(sceneName);
    }
    #endregion

    #region Download image from url
    public static void LoadImage(string url, Image profileImage,MonoBehaviour behaviour)
    {
        behaviour.StartCoroutine(DownloadImage(url, profileImage));
    }

    private static IEnumerator DownloadImage(string url, Image img)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
        {
            Texture2D webTexture = ((DownloadHandlerTexture)request.downloadHandler).texture as Texture2D;
            Sprite webSprite = SpriteFromTexture2D(webTexture);
            img.sprite = webSprite;
        }
    }

    private static Sprite SpriteFromTexture2D(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
    #endregion
}
