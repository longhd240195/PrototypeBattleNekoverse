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

    public CharacterAttribute CurrentStat { get => currentStat;}

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

    public void TakeDamage(float damage)
    {
        CurrentStat.Hp -= damage;
        UpdateStat();

        if (CurrentStat.Hp <= 0)
        {
            Debug.Log("Dead");
        }
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

    public float Damage { get => damage; set => damage = value; }
    public float Hp { get => hp; set => hp = value; }
    public float Speed { get => speed; set => speed = value; }

    public object Clone()
    {
        return this.MemberwiseClone() as CharacterAttribute;
    }
}

public enum SkillType {
    Damage,
    Heal,
    Buff_Attack,
}   


[System.Serializable]
public class SkillAttribute
{
    [SerializeField] string nameSkill;
    [SerializeField] float attribute;

    [SerializeField] private int timeEffect = 1;

    public float Attribute { get => attribute; set => attribute = value; }
    public string NameSkill { get => nameSkill; set => nameSkill = value; }
    public int TimeEffect { get => timeEffect; set => timeEffect = value; }

    internal object Clone()
    {
        return this.MemberwiseClone();
    }
}

[System.Serializable]
public class CharacterSkilled: SkillAttribute
{
    [SerializeField] float endValue;

    public CharacterSkilled(SkillAttribute oldSkill, CharacterAttribute attribute)
    {
        Attribute = oldSkill == null ? 1 : oldSkill.Attribute;
        NameSkill = oldSkill == null ? "Punch" : oldSkill.NameSkill;
        NameSkill = oldSkill == null ? "Punch" : oldSkill.NameSkill;
        EndValue = Attribute * attribute.Damage;
    }


    public float EndValue { get => endValue; set => endValue = value; }

    internal SkillAttribute Clone()
    {
        return this.MemberwiseClone() as SkillAttribute;
    }
}