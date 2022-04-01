using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleView : MonoBehaviour
{
    [SerializeField] private Text battleTitleText;
    [SerializeField] private TextMeshProUGUI battleDesceptionText;
    [SerializeField] private Text atkText;
    [SerializeField] private Text speedText;
    [SerializeField] private Text hpText;
    [SerializeField] private Image icon;
    [SerializeField] private Image atkImg;
    [SerializeField] private Image speedImg;
    [SerializeField] private Image hpImg;
    [SerializeField] private Button battleBtn;
    public void InitBattle(DataEnemy l,Image i)
    {
        battleTitleText.text = l.name;
        //battleDesceptionText.text = level.LevelDesception;
        icon.sprite = i.sprite;
        atkText.text = l.metadata.atk.ToString();
        speedText.text = l.metadata.def.ToString();
        hpText.text = l.metadata.health.ToString();
        atkImg.fillAmount = (l.metadata.atk * DataConst.DEFAULT_100 / DataConst.MAX_ATK_BOSS) / DataConst.DEFAULT_100;
        speedImg.fillAmount = (l.metadata.def * DataConst.DEFAULT_100 / DataConst.MAX_DEF_BOSS) / DataConst.DEFAULT_100;
        hpImg.fillAmount = (l.metadata.health * DataConst.DEFAULT_100 / DataConst.MAX_HP_BOSS) / DataConst.DEFAULT_100;

    }
}
