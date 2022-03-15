using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public static TextController Singleton;

    [SerializeField] private TextMeshPro txtTemp;

    private Camera mainCam;
    private List<TextMeshPro> list;


    private List<TextMeshPro> List => list ?? (list = new List<TextMeshPro>());

    void Awake()
    {
        Singleton = this;
        mainCam = Camera.main;
    }

    public void ShowInfo(Vector3 position, string information)
    {
        var txt = GetText();
        Debug.Log(position);
        txt.transform.position = position + Vector3.up;
        Debug.Log(txt.transform.position);
        //        txt.transform.rotation = 
        //            Quaternion.LookRotation(txt.transform.position - mainCam.transform.position);
        //        txt.transform.LookAt(mainCam.transform,Vector3.up);
        txt.color = new Color(0, 0, 0, 0);
        txt.text = information;

        txt.gameObject.SetActive(true);

        txt.transform.localScale = Vector3.one * 0.5f;
        txt.transform.DOMoveY(.2f, 0.5f).SetRelative(true);
        txt.transform.DOScale(1, 0.2f);
        txt.DOColor(Color.white, .2f);
        txt.DOColor(new Color(0, 0, 0, 0), .2f)
            .SetDelay(.8f).OnComplete(() => txt.gameObject.SetActive(false));
    }

    private TextMeshPro GetText()
    {
        var result = List.Find(s => !s.gameObject.activeInHierarchy);
        if (!result)
        {
            result = Instantiate(txtTemp, transform);
            List.Add(result);
        }

        return result;
    }

}
