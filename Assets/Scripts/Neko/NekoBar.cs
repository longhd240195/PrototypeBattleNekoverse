using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NekoBar : MonoBehaviour
{
    public const int MAX_DAME = 200;
    public const int MAX_SPEED = 200;
    public const int MAX_HP = 200;
    private const int DEFAULT = 100;
    private float currentDame;
    private float currentSpeed;
    private float currentHP;

    [SerializeField] private Image sliderDame;
    [SerializeField] private Image sliderSpeed;
    [SerializeField] private Image sliderHP;
    [SerializeField] private Text dameText;
    [SerializeField] private Text speedText;
    [SerializeField] private Text hpText;

    public void InitNekoBar(Neko neko)
    {
        currentDame = neko.Atk;
        currentSpeed = neko.Speed;
        currentHP = neko.HP;
        ShowNekoBar();
    }
    private void ShowNekoBar()
    {
        sliderDame.fillAmount = (currentDame * DEFAULT / MAX_DAME)/100;
        sliderSpeed.fillAmount = (currentSpeed * DEFAULT / MAX_SPEED)/100;
        sliderHP.fillAmount = (currentHP * DEFAULT / MAX_HP)/100;
        dameText.text = currentDame.ToString();
        speedText.text = currentSpeed.ToString();
        hpText.text = currentHP.ToString();
    }
}
