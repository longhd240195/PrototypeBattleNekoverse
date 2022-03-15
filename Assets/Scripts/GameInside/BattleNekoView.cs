using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleNekoView : MonoBehaviour
{
    [SerializeField] private RawImage imgNeko;
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
    public void LoadNekoBar(Neko neko,Texture mainTexture)
    {
        imgNeko.texture = mainTexture;
        txtNekoName.text = neko.NekoName;
        txtHp.text = neko.HP.ToString();
        txtMagic.text = neko.Magic.ToString();
        txtSpeed.text = neko.Speed.ToString();
        txtResist.text = neko.Resist.ToString();
        txtAtk.text = neko.Atk.ToString();
        txtDef.text = neko.def.ToString();
        sliderHP.fillAmount = (neko.HP * DataConst.DEFAULT_100 / DataConst.MAX_HP_NEKO) / DataConst.DEFAULT_100;
        sliderMagic.fillAmount = (neko.Magic * DataConst.DEFAULT_100 / DataConst.MAX_MAGIC_NEKO) / DataConst.DEFAULT_100;
        sliderSpeed.fillAmount = (neko.Speed * DataConst.DEFAULT_100 / DataConst.MAX_SPEED_NEKO) / DataConst.DEFAULT_100;
        sliderResist.fillAmount = (neko.Resist * DataConst.DEFAULT_100 / DataConst.MAX_RESIST_NEKO) / DataConst.DEFAULT_100;
        sliderAtk.fillAmount = (neko.Atk * DataConst.DEFAULT_100 / DataConst.MAX_DAME_NEKO) / DataConst.DEFAULT_100;
        sliderDef.fillAmount = (neko.def * DataConst.DEFAULT_100 / DataConst.MAX_DEF_NEKO) / DataConst.DEFAULT_100;
        imgClassNeko.sprite = listClassSpr.Find(s => String.Compare(s.name, neko.NekoClass.ToString().ToLower()) == 0);
    }

}
