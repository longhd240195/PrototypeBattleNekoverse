using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class StatHolder : MonoBehaviour
{
    [SerializeField] RawImage statHolder_nekoAvatar;
    [SerializeField] TextMeshProUGUI statHolder_nameText;
    [SerializeField] Image statHolder_nekoClass;
    [SerializeField] GameObject hpStat;
    [SerializeField] GameObject speedStat;
    [SerializeField] GameObject atkStat;
    [SerializeField] GameObject magicStat;
    [SerializeField] GameObject resistStat;
    [SerializeField] GameObject defStat;
    [SerializeField] private List<Sprite> listClassSprs;

    private float defaultStatInit = 250;

    public void UpdateStatHolder(CharacterInformation c)
    {
        statHolder_nekoAvatar.texture = c.MainTexture;
        statHolder_nameText.SetText(c.Neko.NekoName);
        statHolder_nekoClass.sprite = listClassSprs.Find(t => String.Compare(t.name, c.Neko.NekoClass.ToString().ToLower(), StringComparison.OrdinalIgnoreCase) == 0);

        UpdateStat(c);
    }

    private void UpdateStat(CharacterInformation c)
    {
        hpStat.transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText(c.Health.ToString());
        hpStat.transform.GetChild(2).GetComponent<Slider>().value = c.Health / c.InitHealth;

        speedStat.transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText(c.Speed.ToString());
        speedStat.transform.GetChild(2).GetComponent<Slider>().value = c.Speed / defaultStatInit;

        atkStat.transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText(c.Damage.ToString());
        atkStat.transform.GetChild(2).GetComponent<Slider>().value = c.Damage / defaultStatInit;
    }

}
