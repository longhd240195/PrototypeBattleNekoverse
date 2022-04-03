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

    public void InitNekoBar(NekoData neko)
    {
        currentDame = neko.metadata.atk;
        currentSpeed = neko.metadata.speed;
        currentHP = neko.metadata.health;
        ShowNekoBar();
    }
    public void InitPetBar(PetData pet)
    {
        currentDame = pet.Atk;
        currentSpeed = pet.Def;
        currentHP = pet.Hp;
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
    private void ShowPetBar()
    {
        sliderDame.fillAmount = (currentDame * DataConst.DEFAULT_100 / DataConst.MAX_DAME_PET) / DataConst.DEFAULT_100;
        sliderSpeed.fillAmount = (currentSpeed * DataConst.DEFAULT_100 / DataConst.MAX_SPEED_PET) / DataConst.DEFAULT_100;
        sliderHP.fillAmount = (currentHP * DataConst.DEFAULT_100 / DataConst.MAX_HP_PET) / DataConst.DEFAULT_100;
        dameText.text = currentDame.ToString();
        speedText.text = currentSpeed.ToString();
        hpText.text = currentHP.ToString();
    }
}
