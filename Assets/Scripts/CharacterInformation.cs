using Sirenix.OdinInspector;

using System.Collections.Generic;
using System.Text;

using TMPro;

using UnityEditor.Experimental.GraphView;

using UnityEngine;
using UnityEngine.UI;

public class CharacterInformation : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] TextMeshProUGUI txtHP;
    [SerializeField] Image imgSelectMe;
    [SerializeField] Button btnMain;
    [SerializeField] private BattleController controller;
    [Header("Stat")]
    [SerializeField] private CharacterAttribute initStat;
    [SerializeField] private CharacterAttribute currentStat;
    [SerializeField] private List<SkillAttribute> skills;

    public BattleController Controller { get => controller; set => controller = value; }

    public float Damage => CurrentStat.Damage;
    public float Speed => CurrentStat.Speed;
    public bool Alive => CurrentStat.Hp > 0;

    public List<SkillAttribute> Skills { get => skills; set => skills = value; }

    public CharacterAttribute CurrentStat { get => currentStat; }

    private void Reset()
    {
        txtHP = GetComponentInChildren<TextMeshProUGUI>();
        btnMain = GetComponentInChildren<Button>();
    }

    private void Start()
    {
        btnMain.onClick.AddListener(AssignAction);
    }

    public void Initialize()
    {
        currentStat = (CharacterAttribute)initStat.Clone();
        UpdateStat();
    }

    public void ApplyEffects(SkillEffect[] effects)
    {
        foreach(var ef in effects)
            switch (ef.Type)
            {
                case TypeSkill.Damage:
                    TakeDamage(ef.EndValue);
                    break;
                case TypeSkill.Heal:
                    break;
                case TypeSkill.Buff_atk:
                    break;
                case TypeSkill.Bonus_atk:
                    break;
            }
    }

    public void TakeDamage(float damage)
    {
        CurrentStat.Hp -= damage;
        UpdateStat();
        LogInfor(damage);
        if (CurrentStat.Hp <= 0)
        {
            Debug.Log("Dead");
        }
    }

    public void LogInfor(float damage)
    {
        var infor = new StringBuilder();
        infor.Append($"{(damage > 0 ? "<color=red>-" : "<color=green>+")}{Mathf.Abs(damage)}");
        TextSingleton.Instance.CreateText(transform.position, infor.ToString());
    }

    public void UpdateStat()
    {
        var sb = new StringBuilder();
        sb.Append($"HP: {CurrentStat.Hp} / {initStat.Hp}\n");
        sb.Append($"DAM: {CurrentStat.Damage} / {initStat.Damage}\n");
        sb.Append($"Speed: {CurrentStat.Speed}");
        txtHP.text = sb.ToString();
        btnMain.interactable = Alive;
    }


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
        Effects[0] = new SkillEffect(TypeSkill.Damage,1,attribute.Damage);
    }

    internal object Clone()
    {
        return this.MemberwiseClone();
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
    [SerializeField,ReadOnly] float endValue;

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
