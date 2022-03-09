using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NekoBar : MonoBehaviour
{
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
        sliderDame.fillAmount = (currentDame * DataConst.DEFAULT_100 / DataConst.MAX_DAME_NEKO) / DataConst.DEFAULT_100;
        sliderSpeed.fillAmount = (currentSpeed * DataConst.DEFAULT_100 / DataConst.MAX_SPEED_NEKO) / DataConst.DEFAULT_100;
        sliderHP.fillAmount = (currentHP * DataConst.DEFAULT_100 / DataConst.MAX_HP_NEKO) / DataConst.DEFAULT_100;
        dameText.text = currentDame.ToString();
        speedText.text = currentSpeed.ToString();
        hpText.text = currentHP.ToString();
    }
}
