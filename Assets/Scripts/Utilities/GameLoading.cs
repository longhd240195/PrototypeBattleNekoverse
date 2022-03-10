using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoading : MonoBehaviour
{
    public GameObject LoaddingPanel;
    public GameObject ObjectCurrent;
    public Slider loadSlider;
    public Text loadText;
    private int numberLoad = 0;
    private const float DEAULFT_100 = 100;
    private void Update()
    {
        loadText.text = numberLoad + "%";
    }

    public void LoadLevel(string sceneIndex)
    {
        ObjectCurrent.SetActive(false);
        LoaddingPanel.SetActive(true);
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(string sceneIndex)
    {
        yield return new WaitForSeconds(3f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            numberLoad = (int)(progress * DEAULFT_100);
            loadSlider.value = progress;
            yield return null;
        }
    }
}
