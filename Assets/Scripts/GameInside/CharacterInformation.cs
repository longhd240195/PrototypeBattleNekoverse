using System;
using System.Collections;
using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CharacterInformation : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] GetTouch btnOnCharacter;
    [SerializeField] ModelController nekoController;
    [SerializeField] Transform targetSelected;
    [SerializeField] Animator animator;
    [SerializeField] private BattleController controller;
    [SerializeField] private IngameHealthBar healthBar;
    [SerializeField] private Texture mainTexture;

    [Header("Stat")]
    [SerializeField] private CharacterAttribute initStat;
    [SerializeField, ReadOnly] private CharacterAttribute currentStat;
    [SerializeField] private List<SkillAttribute> skills;
    private Vector3 localCone;

    public BattleController Controller { get => controller; set => controller = value; }
    public NekoData Neko { get => nekoController.neko; set => nekoController.neko = value; }
    public ModelController NekoController { get => nekoController; }
    public float Health => CurrentStat.Hp;
    public int Mana => CurrentStat.Mana;
    public float InitHealth => initStat.Hp;
    public float Damage => CurrentStat.Damage;
    public float Speed => CurrentStat.Speed;
    public bool Alive => CurrentStat.Hp > 0;
    public List<SkillAttribute> Skills { get => skills; set => skills = value; }

    public CharacterAttribute CurrentStat { get => currentStat; }

    public Texture MainTexture => mainTexture;

    private Action callbackDelay;

    private Coroutine loop;

    #region Get reference on scene
    [ContextMenu("Init skill")]
    private void InitSkill()
    {
        if (Skills.Count <= 0)
        {
            Skills.Add(new SkillAttribute(currentStat));
        }
    }

    [ContextMenu("Update ref")]
    private void UpdateReference()
    {
        btnOnCharacter = GetComponentInChildren<GetTouch>();
    }

    [ContextMenu("Update Cone")]
    private void UpdateCone()
    {
        //targetCanSelect = transform.Find("Cone");
    }

    [ContextMenu("Update Selected")]
    private void UpdateSelected()
    {
        targetSelected = transform.Find("Cylinder");
    }

    [ContextMenu("Update Animator")]
    private void UpdateAnimator()
    {
        animator = transform.GetComponent<Animator>();
    }
    #endregion 

    private void Start()
    {
        // localCone = targetCanSelect.localPosition;

        btnOnCharacter.onClick.AddListener(AssignAction);
        btnOnCharacter.onMouseEnter.AddListener(SetTargetPlayer);
        btnOnCharacter.onMouseExit.AddListener(RemoveTargetPlayer);
    }

    public void Initialize(bool isEnemy = false)
    {
        SetNekoStat(Neko);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.localPosition);
        currentStat = (CharacterAttribute)initStat.Clone();
        healthBar = HpBarIngameSpawnner.Instance.GetTemp();
        healthBar.Init(this);
        if (isEnemy)
        {
            screenPos.y += 100;
            screenPos.x += 50;
            healthBar.SetColorHealBar(this);
        }
        else
        {
            screenPos.y += 200;
            screenPos.x -= 30;
        }
        LoadManaBar();
        healthBar.transform.position = screenPos + HpBarIngameSpawnner.Instance.PosTemp;
        UpdateStat();
    }

    private void SetNekoStat(NekoData neko)
    {
        initStat.Level = neko.level;
        initStat.Hp = neko.metadata.health;
    }

    public void LoadManaBar()
    {
        healthBar.SetManaBar(this);
    }

    public void UpdateStat()
    {
        var sb = new StringBuilder();
        sb.Append($"HP: {CurrentStat.Hp} / {initStat.Hp}\n");
        sb.Append($"DAM: {CurrentStat.Damage} / {initStat.Damage}\n");
        sb.Append($"Speed: {CurrentStat.Speed}");
        //   txtHP.text = sb.ToString();
        if (btnOnCharacter)
            btnOnCharacter.interactable = Alive;
    }


    public void CheckState(QueueBattle attributeCheck)
    {
        var track = attributeCheck != null &&
            (attributeCheck.from != null && attributeCheck.from == this ||
            attributeCheck.target != null && attributeCheck.target == this);
        MoveCone(track);
        // if (targetCanSelect.gameObject.activeInHierarchy)
        //     targetCanSelect.DOMoveY(.5f, .3f).SetLoops(-1, LoopType.Yoyo).SetRelative(true);
        if (healthBar.Cone.gameObject.activeInHierarchy)
            healthBar.Cone.transform.DOMoveY(.5f, .3f).SetLoops(-1, LoopType.Yoyo).SetRelative(true);
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

    public void ApplyEffects(SkillEffect effects)
    {
        switch (effects.Type)
        {
            case TypeSkill.Damage:
                TakeDamage(effects.EndValue);
                break;
            case TypeSkill.Heal:
                HealCharacter(effects.EndValue);
                break;
            case TypeSkill.Buff_atk:
                BuffPower(effects.EndValue);
                break;
            case TypeSkill.Bonus_atk:
                BonusPower(effects.EndValue);
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
        healthBar.ChangePercent(this);
        LogChangeHeal(-numberEffect);
    }

    public void TakeDamage(float numberEffect)
    {
        CurrentStat.Hp -= numberEffect;

        if (CurrentStat.Hp <= 0)
        {
            CurrentStat.Hp = 0;
            healthBar.gameObject.SetActive(false);
            gameObject.SetActive(false);
            Debug.Log("Dead");
        }

        LogChangeHeal(numberEffect);
        healthBar.ChangePercent(this);
    }

    #endregion

    #region Log visual
    public void LogChangeHeal(float damage)
    {
        var infor = new StringBuilder();
        infor.Append($"{(damage > 0 ? "<color=red>-" : "<color=green>+")}{Mathf.Abs(damage)}");
        TextController.Singleton.ShowInfo(transform.position, infor.ToString());
        //TextSingleton.Instance.CreateText(transform.position, infor.ToString());
    }

    public void LogChangePower(float power)
    {
        var infor = new StringBuilder();
        infor.Append($"Damage add {(power > 0 ? "<color=red>-" : "<color=green>+")}{Mathf.Abs(power)}");
        TextController.Singleton.ShowInfo(transform.position, infor.ToString());
    }

    #endregion

    private void SetTargetPlayer()
    {
        Controller?.AssignCharacterTarget(this);
    }

    private void RemoveTargetPlayer()
    {
        Controller?.RemoveAssignTarget(this);
    }

    public void AssignAction()
    {
        Controller?.AssignCharacterTarget(this);
        Controller?.EndSelection();
    }

    public void MoveCone(bool active)
    {
        // targetCanSelect.DOKill();
        // targetCanSelect.localPosition = localCone;
        // targetCanSelect.gameObject.SetActive(active);
        
        healthBar.Cone.DOKill();
        healthBar.Cone.gameObject.SetActive(active);
    }

    public void SelectedTarget(bool active)
    {
        targetSelected.gameObject.SetActive(active);

        if (active)
        {
            loop = StartCoroutine(Loop());
        }
        else if (loop != null)
            StopCoroutine(loop);
    }

    private IEnumerator Loop()
    {
        while (true)
        {
            yield return new WaitForSeconds(.5f);
            targetSelected.gameObject.SetActive(!targetSelected.gameObject.activeInHierarchy);
        }
    }


    public void PlayAnimation(string anim, Action callback = null)
    {
        if (callback != null)
            callbackDelay = callback;
        animator.Play(anim);
    }

    /// <summary>
    /// This function call on unity animation
    /// </summary>
    public void PlayCallBack()
    {
        callbackDelay?.Invoke();
        callbackDelay = null;
    }
    public void AddMana(int i)
    {
        if (currentStat.Mana >= DataConst.MAX_MANA_NEKO)
        {
            currentStat.Mana = DataConst.MAX_MANA_NEKO;
        }
        else
            currentStat.Mana += i;
    }
    public void SubMana(int i)
    {
        if (currentStat.Mana <= 0)
            currentStat.Mana = 0;
        else
            currentStat.Mana -= i;
    }
}


[System.Serializable]
public class CharacterAttribute
{
    [SerializeField] float hp;
    [SerializeField] float damage;
    [SerializeField] float speed;
    [SerializeField] float evasion;
    [SerializeField] int level;
    [SerializeField] int mana;

    public float Damage { get => damage; set => damage = value; }
    public float Hp { get => hp; set => hp = value; }
    public float Speed { get => speed; set => speed = value; }
    public int Mana { get => mana; set => mana = value; }

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

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
    [SerializeField] private string skillAnimation = "CastSkill";
    [SerializeField] private int mana;
    public string NameSkill { get => nameSkill; set => nameSkill = value; }
    public SkillEffect[] Effects { get => effects; set => effects = value; }
    public string SkillAnimation => skillAnimation;
    public int Mana { get => mana; set => mana = value; }

    public SkillAttribute(string nameSkill, SkillEffect[] effects, int mana)
    {
        NameSkill = nameSkill;
        Effects = effects;
        Mana = mana;
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
            ef.SetEndValue(attribute);
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

public enum SkillTargetType
{
    Self,
    Ally,
    Allies,
    Enemy,
    Enemies
}


[System.Serializable]
public class SkillEffect
{
    [SerializeField] TypeSkill type;
    [SerializeField] SkillTargetType targetType;
    [SerializeField] float attribute;
    [SerializeField] float endValue;

    public SkillEffect(TypeSkill type, float attribute, float endValue)
    {
        Type = type;
        Attribute = attribute;
        EndValue = endValue;
    }

    public TypeSkill Type { get => type; set => type = value; }
    public float Attribute { get => attribute; set => attribute = value; }
    public float EndValue { get => endValue; set => endValue = value; }
    public SkillTargetType TargetType { get => targetType; set => targetType = value; }

    public void SetEndValue(CharacterAttribute multiple)
    {
        //        switch (type)
        //        {
        //            case TypeSkill.Damage:
        //                endValue = multiple * attribute;
        //                break;
        //            case TypeSkill.Heal:
        //                endValue = multiple * attribute;
        //                break;
        //            case TypeSkill.Buff_atk:
        //                endValue = attribute;
        //                break;
        //            case TypeSkill.Bonus_atk:
        //                endValue = attribute;
        //                break;
        //        }

    }
}
