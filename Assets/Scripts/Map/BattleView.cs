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
    [SerializeField] private LevelData level;
    public void InitBattle(LevelData l)
    {
        this.level = l;
        SetLayOut();
    }
    private void SetLayOut()
    {
        battleTitleText.text = level.LevelName;
        battleDesceptionText.text = level.LevelDesception;
        icon.sprite = level.Icon;
        atkText.text = level.Atk.ToString();
        speedText.text = level.Def.ToString();
        hpText.text = level.Hp.ToString();
        atkImg.fillAmount = (level.Atk * DataConst.DEFAULT_100 / DataConst.MAX_ATK_BOSS) / DataConst.DEFAULT_100;
        speedImg.fillAmount = (level.Def * DataConst.DEFAULT_100 / DataConst.MAX_SPEED_BOSS) / DataConst.DEFAULT_100;
        hpImg.fillAmount = (level.Hp * DataConst.DEFAULT_100 / DataConst.MAX_HP_BOSS) / DataConst.DEFAULT_100;
    }

}
