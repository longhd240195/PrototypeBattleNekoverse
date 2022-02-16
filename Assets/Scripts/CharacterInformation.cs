using DG.Tweening;

using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInformation : MonoBehaviour
{
    [Header("Reference")]
//    [SerializeField] TextMeshProUGUI txtHP;
   // [SerializeField] Image imgSelectMe;
    //[SerializeField] Button btnMain;
    [SerializeField] GetTouch btnMain;
    [SerializeField] Transform imgSelectMe;
    [SerializeField] private BattleController controller;
    [Header("Stat")]
    [SerializeField] private CharacterAttribute initStat;
    [SerializeField, ReadOnly] private CharacterAttribute currentStat;
    [SerializeField] private List<SkillAttribute> skills;

    private Vector3 localCone;

    public BattleController Controller { get => controller; set => controller = value; }

    public float Damage => CurrentStat.Damage;
    public float Speed => CurrentStat.Speed;
    public bool Alive => CurrentStat.Hp > 0;

    public List<SkillAttribute> Skills { get => skills; set => skills = value; }

    public CharacterAttribute CurrentStat { get => currentStat; }

    [ContextMenu("Update ref")]
    private void UpdateReference()
    {
        btnMain = GetComponentInChildren<GetTouch>();
    }

    [ContextMenu("Update Cone")]
    private void UpdateCone()
    {
        imgSelectMe = transform.Find("Cone");
    }

    private void Start()
    {
        localCone = imgSelectMe.localPosition;
        btnMain.onClick.AddListener(AssignAction);
    }

    public void Initialize()
    {
        currentStat = (CharacterAttribute)initStat.Clone();
        UpdateStat();
    }

    public void UpdateStat()
    {
        var sb = new StringBuilder();
        sb.Append($"HP: {CurrentStat.Hp} / {initStat.Hp}\n");
        sb.Append($"DAM: {CurrentStat.Damage} / {initStat.Damage}\n");
        sb.Append($"Speed: {CurrentStat.Speed}");
     //   txtHP.text = sb.ToString();
        if(btnMain)
        btnMain.interactable = Alive;
    }


    public void CheckState(CharacterInformation attributeCheck)
    {
        imgSelectMe.DOKill();
        imgSelectMe.localPosition = localCone;
        imgSelectMe.gameObject.SetActive(this == attributeCheck);

        if(imgSelectMe.gameObject.activeInHierarchy)
            imgSelectMe.DOMoveY(.5f, .3f).SetLoops(-1, LoopType.Yoyo).SetRelative(true);
    }

    #region Logic change character attribute in-game
    public void ApplyEffects(SkillEffect[] effects)
    {
        foreach (var ef in effects)
            switch (ef.Type)
            {
                case TypeSkill.Damage:
                    TakeDamage(ef.EndValue);
                    break;
                case TypeSkill.Heal:
                    HealCharacter(ef.EndValue);
                    break;
                case TypeSkill.Buff_atk:
                    BuffPower(ef.EndValue);
                    break;
                case TypeSkill.Bonus_atk:
                    BonusPower(ef.EndValue); 
                    break;
            }

        UpdateStat();
    }

    private void BuffPower(float numberEffect)
    {
        var old = CurrentStat.Damage;
        CurrentStat.Damage *= (numberEffect + 1);
        var diff = old - CurrentStat.Damage;
        LogChangePower(diff);
    }

    private void BonusPower(float numberEffect)
    {
        CurrentStat.Damage *= (numberEffect + 1);
        LogChangePower(numberEffect);
    }

    public void HealCharacter(float numberEffect)
    {
        CurrentStat.Hp += numberEffect;

        if (CurrentStat.Hp > initStat.Hp)
            CurrentStat.Hp = initStat.Hp;

        LogChangeHeal(-numberEffect);
    }

    public void TakeDamage(float numberEffect)
    {
        CurrentStat.Hp -= numberEffect;
        LogChangeHeal(numberEffect);

        if (CurrentStat.Hp <= 0)
        {
            Debug.Log("Dead");
        }
    }

    #endregion

    #region Log visual
    public void LogChangeHeal(float damage)
    {
        var infor = new StringBuilder();
        infor.Append($"{(damage > 0 ? "<color=red>-" : "<color=green>+")}{Mathf.Abs(damage)}");
        TextSingleton.Instance.CreateText(transform.position, infor.ToString());
    }

    public void LogChangePower(float power)
    {
        var infor = new StringBuilder();
        infor.Append($"Damage add {(power > 0 ? "<color=red>-" : "<color=green>+")}{Mathf.Abs(power)}");
        TextSingleton.Instance.CreateText(transform.position, infor.ToString());
    }

    #endregion



    public void AssignAction()
    {
        Debug.Log("assign:" + transform.name, this);
        Controller.AssignCharacter(this);
    }
}


[System.Serializable]
public class CharacterAttribute
{
    [SerializeField] float hp;
    [SerializeField] float damage;
    [SerializeField] float speed;
    [SerializeField] float evasion;

    public float Damage { get => damage; set => damage = value; }
    public float Hp { get => hp; set => hp = value; }
    public float Speed { get => speed; set => speed = value; }

    public object Clone()
    {
        return this.MemberwiseClone() as CharacterAttribute;
    }
}

public enum SkillType
{
    Damage,
    Heal,
    Buff_Attack,
}


[System.Serializable]
public class SkillAttribute
{
    [SerializeField] string nameSkill;
    [SerializeField] SkillEffect[] effects;

    public string NameSkill { get => nameSkill; set => nameSkill = value; }
    public SkillEffect[] Effects { get => effects; set => effects = value; }

    public SkillAttribute(string nameSkill, SkillEffect[] effects)
    {
        NameSkill = nameSkill;
        Effects = effects;
    }

    public SkillAttribute(CharacterAttribute attribute)
    {
        NameSkill = "Punch";
        Effects = new SkillEffect[1];
        Effects[0] = new SkillEffect(TypeSkill.Damage, 1, attribute.Damage);
    }

    public void Apply(CharacterAttribute attribute)
    {
        foreach (var ef in Effects)
        {
            ef.SetEndValue(attribute.Damage); 
        }
    }

    internal object Clone()
    {
        return this.MemberwiseClone();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"<b>{NameSkill}</b>");

        foreach (var ef in Effects)
        {
            sb.Append("\n")
                .Append(ef.Type.ToString())
                .Append(":")
                .Append(ef.EndValue);
        }

        return sb.ToString();
    }
}

public enum TypeSkill
{
    Damage,
    Heal,
    Buff_atk,
    Bonus_atk
}

[System.Serializable]
public class SkillEffect
{
    [SerializeField] TypeSkill type;
    [SerializeField] float attribute;
    [SerializeField, ReadOnly] float endValue;

    public SkillEffect(TypeSkill type, float attribute, float endValue)
    {
        Type = type;
        Attribute = attribute;
        EndValue = endValue;
    }

    public TypeSkill Type { get => type; set => type = value; }
    public float Attribute { get => attribute; set => attribute = value; }
    public float EndValue { get => endValue; set => endValue = value; }

    public void SetEndValue(float multiple)
    {
        switch (type)
        {
            case TypeSkill.Damage:
                endValue = multiple * attribute;
                break;
            case TypeSkill.Heal:
                endValue = multiple * attribute;
                break;
            case TypeSkill.Buff_atk:
                endValue = attribute;
                break;
            case TypeSkill.Bonus_atk:
                endValue = attribute;
                break;
        }
    }
}
