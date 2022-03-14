using System;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using Sirenix.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] List<CharacterInformation> blues;
    [SerializeField] List<CharacterInformation> reds;
    [SerializeField] List<SkillInformation> skills;
    [SerializeField] List<QueueTurn> queueTurns;
    [SerializeField] TextMeshProUGUI txtTimer;
    [SerializeField] TextMeshProUGUI txtTimerRound;
    [SerializeField] TextMeshProUGUI txtLog;
    [SerializeField] TextMeshProUGUI txtLogTurn;
    [SerializeField] LineRenderer line;
    [SerializeField] Image imgClock;
    [SerializeField] private Button btnChangeSkin;
    [SerializeField] private ModelController[] clr;

    [Header("Config")]
    [SerializeField] private float timePerRound = 10;

    private float timer;
    private float timeRoundCD;
    private int turnCount;

    public BattleStep CurrentStep;
    private QueueBattle cache;
    private bool lockSelect = false;

    private List<CharacterInformation> orderCharacters;
    private List<CharacterInformation> currentOrderCharacters;

    private List<Neko> listNeko;

    private void Start()
    {
        listNeko = DataTest.GetNekoBattle();

        for (int i = 0; i < 6; i++)
        {
            if (clr.Length == listNeko.Count)
            {
                clr[i].InitNeko(listNeko[i]);
            }
        }
        InitBattleOderSelect();
    }

    private void Update()
    {
        if (CurrentStep == BattleStep.PreBattle)
            return;

        timer += Time.deltaTime;
        txtTimer.text = $"Game time: {timer:0}";

        if (CurrentStep == BattleStep.PreSkill)
        {
            timeRoundCD -= Time.deltaTime;
            txtTimerRound.text = $"{timeRoundCD:0}";
            imgClock.fillAmount = timeRoundCD / timePerRound;
        }
    }

    #region Queue character turn

    private void UpdateStack()
    {
        orderCharacters = new List<CharacterInformation>();
        blues.ForEach(s => orderCharacters.Add(s));
        reds.ForEach(s => orderCharacters.Add(s));

        RefreshCurrentTurn();
        ReorderQueue();
        InitUIQueue();
    }

    private void RefreshCurrentTurn()
    {
        if (currentOrderCharacters == null)
            currentOrderCharacters = new List<CharacterInformation>();
        currentOrderCharacters.Clear();

        ClearCone();

        orderCharacters.ForEach(s => currentOrderCharacters.Add(s));
    }

    private CharacterInformation Pop()
    {
        var result = currentOrderCharacters[0];
        currentOrderCharacters.RemoveAt(0);
        return result;
    }

    private void ReorderQueue()
    {
        orderCharacters = orderCharacters.OrderBy(s => s.Speed).ToList();
        currentOrderCharacters.RemoveAll(s => !s.Alive);
        currentOrderCharacters = currentOrderCharacters.OrderBy(s => s.Speed).ToList();

        UpdateUIQueue();
    }
    private void InitBattleOderSelect()
    {
        for (int i = 0; i < queueTurns.Count; i++)
        {
            //queueTurns[i].gameObject.transform.Find("Select").gameObject.SetActive(false);
            Debug.Log(queueTurns[i].gameObject.transform.Find("Select").name);
        }
    }
    private void UpdateUIQueue()
    {
        for (int i = 0; i < queueTurns.Count; i++)
        {
            if (i < orderCharacters.Count)
            {
                var c = orderCharacters[i];

                var color = Color.white;//reds.Contains(c) ? Color.red : Color.blue;

                if (reds.Contains(c))
                {
                    color = Color.red;
                }
                else
                {
                    color = Color.green;
                }
                //color.a = .1f;
                queueTurns[i].Init(c.MainTexture, color);
                queueTurns[i].SetCurrent(currentOrderCharacters.Contains(c));
            }
        }
    }

    private void InitUIQueue()
    {
        for (int i = 0; i < queueTurns.Count; i++)
        {
            if (i < orderCharacters.Count)
            {
                var c = orderCharacters[i];
                queueTurns[i].Init(c.MainTexture, reds.Contains(c) ? Color.red : Color.green);
            }
        }
    }


    #endregion


    #region Ultilities

    private int NumberAction()
    {
        var count = 0;
        blues.ForEach(s => { if (s.Alive) count++; });
        reds.ForEach(s => { if (s.Alive) count++; });
        return count;
    }

    #endregion


    #region Start + init funtion
    public void StartBattle()
    {
        timer = 0;
        turnCount = 0;
        ChangeStateBattle(BattleStep.PreSkill, true);

        blues.ForEach(s =>
        {
            s.Initialize();
            s.Controller = this;
        });
        reds.ForEach(s =>
        {
            s.InitializeRed();
            s.Controller = this;
        });
        skills.ForEach(s =>
        {
            s.SetController(this);
        });

        UpdateStack();

        NextOnQueue();
    }

    public void UpdateSignSkill()
    {
        if (cache == null)
            return;

        skills.ForEach(s => s.CheckState(cache.skill));
    }

    public void UpdateSignSelected(CharacterInformation infor)
    {
        orderCharacters.ForEach(s => s.SelectedTarget(false));
        infor.SelectedTarget(true);
    }

    private void ResetState()
    {
        skills.ForEach(s => s.CheckState(null));
    }
    #endregion


    #region Assign neko attack, skill use
    //Fix this into: Turn follow queue, if blue, select target, select skill, select target

    private void NextOnQueue()
    {
        if (currentOrderCharacters.Count <= 0)
            RefreshCurrentTurn();

        ReorderQueue();
        ClearCone();

        currentOrderCharacters.RemoveAll(s => !s.Alive);
        var turnCharacter = Pop();

        if (turnCharacter == null)
            Debug.Log("out of character");

        //if(turnCharacter.Alive)
        if (blues.Contains(turnCharacter))
        {
            ShowUISkill(true);

            AssignCharacterAttack(turnCharacter);

        }
        else
        {
            //TODO: Add AI for red team here
            ShowUISkill(false);

            AIAction(turnCharacter);
        }

        AnnounceNewTurn();
    }

    public void AssignSkill(SkillAttribute skill)
    {
        if (cache == null)
            cache = new QueueBattle();

        cache.skill = skill;
        Announce("Drag skill to Opponent's Neko");
        UpdateSignSkill();
        AssignTargetableForSkill();
    }

    private void ShowUISkill(bool active)
    {
        skills.ForEach(s => s.gameObject.SetActive(active));
    }


    public void UnassignSkill(SkillAttribute skill)
    {
        if (cache == null)
            return;

        if (cache.skill == skill)
            cache.skill = null;

        UpdateSignSkill();
    }

    public void AssignCharacterAttack(CharacterInformation character)
    {
        if (cache == null)
            cache = new QueueBattle();
        cache.from = character;

        UpdateSkill(character);
        UpdateSignSkill();
        UpdateSignSelected(character);
    }

    public void AssignCharacterTarget(CharacterInformation character)
    {
        cache.target = character;
    }

    /* Assign Both Character for from and attack target
	public bool AssignCharacter(CharacterInformation character, bool needSkill = false)
	{
		if (cache == null)
			cache = new QueueBattle();

		if (needSkill && cache.skill == null)
			return false;

		if (cache.skill == null)
		{
			Debug.Log("assign from: " + character.transform.name, this);
			cache.from = character;
			UpdateSkill(character);
		}
		else
		{
			Debug.Log("assign target: " + character.transform.name, this);
			cache.target = character;
		}

		UpdateSign();

		return true;
	}
	*/

    public void RemoveAssignTarget(CharacterInformation character)
    {
        if (cache == null) return;

        if (cache.target != character) return;

        //Debug.Log("Remove assign:" + character.transform.name, this);
        cache.target = null;

        UpdateSignSkill();
    }

    public void AssignTargetableForSkill()
    {
        if (cache.skill != null)
        {
            ClearCone();

            var skillAttribute = cache.skill.Effects[0];
            //TODO: Assign target for each character
            switch (skillAttribute.TargetType)
            {
                case SkillTargetType.Self:
                    cache.from.MoveCone(true);
                    break;
                case SkillTargetType.Ally:
                    blues.ForEach(s => s.MoveCone(true));
                    break;
                case SkillTargetType.Allies:
                    blues.ForEach(s => s.MoveCone(true));
                    break;
                case SkillTargetType.Enemy:
                    reds.ForEach(s => s.MoveCone(true));
                    break;
                case SkillTargetType.Enemies:
                    reds.ForEach(s => s.MoveCone(true));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        else
        {

        }
    }
    #endregion


    #region Time-life and status of battle

    /// <summary>
    /// official end select skill and target, need to call action here
    /// </summary>
    public void EndSelection()
    {
        if (cache == null || cache.from == null || cache.target == null || cache.skill == null)
        {
            if (cache?.target == null)
                Debug.Log("<color=red>Missing</color> target, queue not add battle infor");
            else
                Debug.LogError("Missing something here");
            return;
        }

        //UpdateLog();
        ResetState();
        DoAction();

        ResetCacheBattle();
    }

    private void ResetCacheBattle()
    {
        cache = new QueueBattle();
    }

    /// <summary>
    /// In side action, need to split step to step
    /// </summary>
    private void DoAction()
    {
        ChangeStateBattle(BattleStep.CastSkill);
        ClearCone();

        var q = cache;
        var target = q.target;
        var from = q.from;

        //TODO: Polish here later

        line.SetPosition(0, from.transform.position);
        line.SetPosition(1, target.transform.position);

        imgClock.fillAmount = 0;
        txtTimerRound.text = string.Empty;

        Debug.Log($"Make attack: from {from.name} to {target.name}");
        UpdateLog($"{from.name} {q.skill.NameSkill} {target.name}");

        if (target.Alive && from.Alive)
        {
            //TODO: Get all information about skill here to apply to character 
            //HM... A lot's logic in here will need to fix
            //Don't not check list target and enemy here, that job server will help you.

            //TODO: Here is pre-skill
            //			from.transform.DOMove(-from.transform.forward * .3f, .2f).SetRelative(true).SetLoops(2, LoopType.Yoyo);
            //			target.transform.DOMove(-target.transform.forward * .3f, .2f).SetRelative(true).SetLoops(2, LoopType.Yoyo);

            //TODO: Here is in-skill. Add more skill effect inside skill apply
            from.PlayAnimation(q.skill.SkillAnimation, () =>
            {
                foreach (var ef in q.skill.Effects)
                {
                    switch (ef.TargetType)
                    {
                        case SkillTargetType.Self:
                            from.ApplyEffects(ef);
                            from.MoveCone(true);
                            break;
                        case SkillTargetType.Ally:
                            target.ApplyEffects(ef);
                            target.MoveCone(true);
                            break;
                        case SkillTargetType.Allies:
                            var listAllies = reds.Contains(from) ? reds : blues;
                            listAllies.ForEach(s =>
                            {
                                s.ApplyEffects(ef);
                                s.MoveCone(true);
                            });
                            break;
                        case SkillTargetType.Enemy:
                            target.ApplyEffects(ef);
                            target.PlayAnimation("TakeDamage");
                            target.MoveCone(true);
                            break;
                        case SkillTargetType.Enemies:
                            var listEnemies = !reds.Contains(from) ? reds : blues;
                            listEnemies.ForEach(s =>
                            {
                                s.ApplyEffects(ef);
                                s.PlayAnimation("TakeDamage");
                                s.MoveCone(true);
                            });
                            break;
                    }
                }
            });

            //TODO: End of action, change state to pre skill
            //need to split all action, prepare for command pattern? 
        }
        else
        {
            target.transform.DOShakePosition(.2f, new Vector3(.1f, 0, 0), 20);
            from.transform.DOShakePosition(.2f, new Vector3(.1f, 0, 0), 45);
        }

        DOVirtual.DelayedCall(2, () =>
        {
            ClearCone();
            ChangeToSelectSkillAction();
            NextOnQueue();
        });
    }

    private void AnnounceNewTurn()
    {
        var isPlayerTurn = blues.Contains(cache.from);

        Announce($"Your {(isPlayerTurn ? "" : "Opponent")} Turn");
    }

    private void ClearCone()
    {
        orderCharacters.ForEach(s => s.MoveCone(false));

        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, Vector3.zero);
    }


    private void AIAction(CharacterInformation characterAttack)
    {
        var firstAlive = blues.OrderBy(s => s.CurrentStat.Hp).First(s => s.Alive);
        AssignCharacterAttack(characterAttack);
        AssignSkill(characterAttack.Skills[0]);

        DOVirtual.DelayedCall(2, () =>
         {
             AssignCharacterTarget(firstAlive);
             DoAction();
         });
        //DoAction();
    }

    private void ChangeToSelectSkillAction()
    {
        ChangeStateBattle(BattleStep.PreSkill);
    }

    private void ChangeStateBattle(BattleStep nextStep, bool mustBe = false)
    {
        if (nextStep != CurrentStep || mustBe)
        {
            CurrentStep = nextStep;

            switch (CurrentStep)
            {
                case BattleStep.PreSkill:
                    turnCount++;
                    timeRoundCD = timePerRound;
                    lockSelect = false;
                    break;
                case BattleStep.CastSkill:
                    lockSelect = true;
                    break;
            }
        }
    }

    #endregion


    #region Update ui shower

    /// <summary>
    /// Show all skill of character on ui
    /// </summary>
    /// <param name="character">Character info</param>
    private void UpdateSkill(CharacterInformation character)
    {
        for (int i = 0; i < character.Skills.Count || i < skills.Count; i++)
        {
            skills[i].SetSkill(character.CurrentStat, i < character.Skills.Count ? character.Skills[i] : null);
        }
    }

    private void Announce(string announceInfor)
    {
        txtLogTurn.text = announceInfor;
        txtLogTurn.color = Color.white;
        txtLogTurn.DOFade(0, .3f).SetDelay(1f);
    }

    private void UpdateLog(string newTurn)
    {
        txtLog.text += newTurn + "\n";
    }

    #endregion
}

public enum BattleStep
{
    None,
    PreBattle,
    PreSkill,
    CastSkill
}

public class QueueBattle
{
    public CharacterInformation from;
    public CharacterInformation target;

    public SkillAttribute skill;
}