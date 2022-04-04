using System;
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
        string url = DataConst.NEKO_IMAGE_URL + character.Neko.nft_id + DataConst.NEKO_IMAGE_PNG;
        GameUtilities.LoadImage(url, img, this);
        //character.NekoController.LoadImage(url, img);
        txtNekoName.text = character.Neko.name;
        txtHp.text = character.Neko.metadata.health.ToString();
        txtMagic.text = character.Neko.metadata.m_atk.ToString();
        txtSpeed.text = character.Neko.metadata.speed.ToString();
        txtResist.text = character.Neko.metadata.m_def.ToString();
        txtAtk.text = character.Neko.metadata.atk.ToString();
        txtDef.text = character.Neko.metadata.def.ToString();
        sliderHP.fillAmount = (character.Neko.metadata.health * DataConst.DEFAULT_100 / DataConst.MAX_HP_NEKO) / DataConst.DEFAULT_100;
        sliderMagic.fillAmount = (character.Neko.metadata.m_atk * DataConst.DEFAULT_100 / DataConst.MAX_MAGIC_NEKO) / DataConst.DEFAULT_100;
        sliderSpeed.fillAmount = (character.Neko.metadata.speed * DataConst.DEFAULT_100 / DataConst.MAX_SPEED_NEKO) / DataConst.DEFAULT_100;
        sliderResist.fillAmount = (character.Neko.metadata.m_def * DataConst.DEFAULT_100 / DataConst.MAX_RESIST_NEKO) / DataConst.DEFAULT_100;
        sliderAtk.fillAmount = (character.Neko.metadata.atk * DataConst.DEFAULT_100 / DataConst.MAX_DAME_NEKO) / DataConst.DEFAULT_100;
        sliderDef.fillAmount = (character.Neko.metadata.def * DataConst.DEFAULT_100 / DataConst.MAX_DEF_NEKO) / DataConst.DEFAULT_100;
        imgClassNeko.sprite = listClassSpr.Find(s => String.Compare(s.name, character.Neko.className.ToString().ToLower()) == 0);
    }

}
