using DG.Tweening;

using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class TextSingleton : MonoBehaviour
{
    public static TextSingleton Instance;

    [SerializeField] private TextMeshProUGUI temp;
    private List<TextMeshProUGUI> temps;

    private List<TextMeshProUGUI> Temps => temps ?? (temps = new List<TextMeshProUGUI>());

    private void Awake()
    {
        Instance = this;
    }

    private TextMeshProUGUI GetFree()
    {
        TextMeshProUGUI result = Temps.Find(s => s.gameObject.activeInHierarchy);

        if (!result)
        {
            result = Instantiate(temp, transform);
            Temps.Add(result);
        }

        return result;
    }

    public void CreateText(Vector3 position, string information)
    {
        var txt = GetFree();
        txt.text = information;
        txt.transform.position = position;
        txt.gameObject.SetActive(true);
        txt.transform.DOLocalMoveY(5f, .5f).SetRelative(true).OnComplete(()=>txt.gameObject.SetActive(false));
    }
}
