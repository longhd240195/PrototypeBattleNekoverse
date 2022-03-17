using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleNekoView : MonoBehaviour
{
    [SerializeField] private RawImage imgNeko;
    [SerializeField] private Image img;
    [SerializeField] private Image imgClassNeko;
    [SerializeField] private Image sliderHP;
    [SerializeField] private Image sliderMagic;
    [SerializeField] private Image sliderSpeed;
    [SerializeField] private Image sliderResist;
    [SerializeField] private Image sliderAtk;
    [SerializeField] private Image sliderDef;
    [SerializeField] private Text txtNekoName;
    [SerializeField] private Text txtHp;
    [SerializeField] private Text txtMagic;
    [SerializeField] private Text txtSpeed;
    [SerializeField] private Text txtResist;
    [SerializeField] private Text txtAtk;
    [SerializeField] private Text txtDef;
    [SerializeField] private List<Sprite> listClassSpr;
    public void LoadNekoBar(CharacterInformation character)
    {
        imgNeko.texture = character.MainTexture;
        character.NekoController.LoadImage(character.Neko.UrlImage, img);
        txtNekoName.text = character.Neko.NekoName;
        txtHp.text = character.Neko.HP.ToString();
        txtMagic.text = character.Neko.Magic.ToString();
        txtSpeed.text = character.Neko.Speed.ToString();
        txtResist.text = character.Neko.Resist.ToString();
        txtAtk.text = character.Neko.Atk.ToString();
        txtDef.text = character.Neko.def.ToString();
        sliderHP.fillAmount = (character.Neko.HP * DataConst.DEFAULT_100 / DataConst.MAX_HP_NEKO) / DataConst.DEFAULT_100;
        sliderMagic.fillAmount = (character.Neko.Magic * DataConst.DEFAULT_100 / DataConst.MAX_MAGIC_NEKO) / DataConst.DEFAULT_100;
        sliderSpeed.fillAmount = (character.Neko.Speed * DataConst.DEFAULT_100 / DataConst.MAX_SPEED_NEKO) / DataConst.DEFAULT_100;
        sliderResist.fillAmount = (character.Neko.Resist * DataConst.DEFAULT_100 / DataConst.MAX_RESIST_NEKO) / DataConst.DEFAULT_100;
        sliderAtk.fillAmount = (character.Neko.Atk * DataConst.DEFAULT_100 / DataConst.MAX_DAME_NEKO) / DataConst.DEFAULT_100;
        sliderDef.fillAmount = (character.Neko.def * DataConst.DEFAULT_100 / DataConst.MAX_DEF_NEKO) / DataConst.DEFAULT_100;
        imgClassNeko.sprite = listClassSpr.Find(s => String.Compare(s.name, character.Neko.NekoClass.ToString().ToLower()) == 0);
    }

}
