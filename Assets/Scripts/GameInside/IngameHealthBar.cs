using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngameHealthBar : MonoBehaviour
{
    [SerializeField] private Image border;
    [SerializeField] private Image main;
    [SerializeField] private Image hpLost;
    [SerializeField] private Image classSpr;
    [SerializeField] private TextMeshPro txt;
    [SerializeField] private TextMeshPro txtLevel;
    [SerializeField] private TextMeshPro txtName;
    [SerializeField] private List<Image> listMana;
    [SerializeField] private List<Sprite> listClassSprs;
    private float currentPercent;
    private float health = 1;

    public void Init(CharacterInformation infor)
    {
        main.transform.localScale = border.transform.localScale;
        txtName.text = infor.Neko.NekoName;
        txt.text = $"{infor.Health}/{infor.InitHealth}";
        txtLevel.text = infor.CurrentStat.Level.ToString();
        currentPercent = 1;
    }
    void Update()
    {
        if (health < currentPercent)
        {
            currentPercent -= Time.deltaTime * 0.25f;
            main.fillAmount = currentPercent;
        }
    }
    public void ChangePercent(CharacterInformation infor)
    {
        var percent = infor.Health / infor.InitHealth;
        this.health = percent;
        var cl = hpLost.transform.localScale;
        //hpLost.transform.localScale = new Vector3(currentPercent, cl.y, cl.z);
        //main.transform.localScale = new Vector3(currentPercent, cl.y, cl.z);
        //hpLost.transform.DOScaleX(currentPercent, .5f).SetEase(Ease.Linear);
        txt.text = $"{infor.Health}/{infor.InitHealth}";
    }
    private IEnumerator FillHeal(float a, float b)
    {
        yield return new WaitForSeconds(.01f);


    }

    public void SetColorHealBar(CharacterInformation infor)
    {
        Color color = Color.red;
        main.color = color;
        hpLost.color = new Color(color.r, color.g, color.b, 0.2f);
    }
    public void SetImageClassNeko(CharacterInformation infor)
    {
        classSpr.sprite = listClassSprs.Find(s => String.Compare(s.name, infor.Neko.NekoClass.ToString().ToLower(), StringComparison.OrdinalIgnoreCase) == 0);
    }
}

