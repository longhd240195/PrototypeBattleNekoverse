using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class IngameHealthBar : MonoBehaviour
{
    [SerializeField] private SpriteRenderer border;
    [SerializeField] private SpriteRenderer main;
    [SerializeField] private SpriteRenderer hpLost;
    [SerializeField] private TextMeshPro txt;
    [SerializeField] private TextMeshPro txtName;

    private float currentPercent;
    
    
    public void Init(CharacterInformation infor)
    {
        main.transform.localScale = border.transform.localScale;
        txtName.text = infor.transform.name;
        txt.text = $"{infor.Health}/{infor.InitHealth}";
        currentPercent = 1;
    }

    public void ChangePercent(CharacterInformation infor)
    {
        var percent = infor.Health / infor.InitHealth;
        var cl=hpLost.transform.localScale;
        hpLost.transform.localScale = new Vector3(currentPercent,cl.y,cl.z);

        currentPercent = percent;
        
        main.transform.localScale = new Vector3(currentPercent,cl.y,cl.z);
        hpLost.transform.DOScaleX(currentPercent, .5f).SetEase(Ease.Linear);  
        txt.text = $"{infor.Health}/{infor.InitHealth}";
    }
}
