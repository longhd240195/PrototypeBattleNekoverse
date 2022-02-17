using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] List<CharacterInformation> blues;
    [SerializeField] List<CharacterInformation> reds;
    [SerializeField] List<SkillInformation> skills;
    [SerializeField] TextMeshProUGUI txtTimer;
    [SerializeField] TextMeshProUGUI txtTimerRound;
    [SerializeField] TextMeshProUGUI txtLog;

    [Header("Config")]
    [SerializeField] private float timePerRound = 10;


    private float timer;
    private float timeRoundCD;

    List<QueueBattle> queue;
    public BattleStep Step;
    private QueueBattle cache;
    private bool lockSelect = false;

    private int NumberAction()
    {
        var count = 0;
        blues.ForEach(s => { if (s.Alive) count++; });
        reds.ForEach(s => { if (s.Alive) count++; });
        return count;
    }

    private void Start()
    {
        StartBattle();
        queue = new List<QueueBattle>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        txtTimer.text = $"{timer:0.00}";

        if (Step == BattleStep.PreSkill)
        {
            timeRoundCD -= Time.deltaTime;
            txtTimerRound.text = $"{timeRoundCD:0.00}";
        }
    }

    public void StartBattle()
    {
        timer = 0;
        ChangeStateBattle(BattleStep.PreSkill, true);
        blues.ForEach(s =>
        {
            s.Initialize();
            s.Controller = this;
        });
        reds.ForEach(s =>
        {
            s.Initialize();
            s.Controller = this;
        });
        skills.ForEach(s =>
        {
            s.SetController(this);
        });
    }

    public void UpdateSign()
    {
     //   ResetState();

        if (cache == null)
            return;

        blues.ForEach(s => s.CheckState(cache));
        reds.ForEach(s => s.CheckState(cache));
        skills.ForEach(s => s.CheckState(cache.skill));
    }

    private void ResetState()
    {
        blues.ForEach(s => s.CheckState(null));
        reds.ForEach(s => s.CheckState(null));
        skills.ForEach(s => s.CheckState(null));
    }

    private void UpdateLog()
    {
        var sb = new StringBuilder("--Log--\n");
        queue.ForEach(q =>
        {
            var isBlueFrom = blues.IndexOf(q.from) != -1;
            var isBlueTarget = blues.IndexOf(q.target) != -1;
            sb.
            Append(isBlueFrom ? "B" : "R").
            Append((isBlueFrom ? blues.IndexOf(q.from) : reds.IndexOf(q.from)) + 1).
            Append("-").
            Append($"{q.skill.NameSkill}").
            Append("-").
            Append(isBlueTarget ? "B" : "R").
            Append((isBlueTarget ? blues.IndexOf(q.target) : reds.IndexOf(q.target)) + 1).
            Append("\n");
        });
        txtLog.text = sb.ToString();
    }

    public void AssignSkill(SkillAttribute skill)
    {
        if (cache == null)
            cache = new QueueBattle();

        cache.skill = skill;
        UpdateSign();
    }

    public void UnassignSkill(SkillAttribute skill)
    {
        if (cache == null)
            return;

        if (cache.skill == skill)
            cache.skill = null;

        UpdateSign();
    }

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

    public void RemoveAssignTarget(CharacterInformation character)
    {
        if (cache == null) return;

        if (cache.target == character)
        {
            //Debug.Log("Remove assign:" + character.transform.name, this);
            cache.target = null;

            UpdateSign();
        }
    }

    public void EndSelection()
    {
        if(cache== null || cache.from == null || cache.target == null || cache.skill == null)
        {
            if(cache.target == null)
                Debug.Log("<color=red>Missing</color> target, queue not add battle infor");
            else
                Debug.LogError("Missing somethign here");
            return;
        }
        queue.Add(cache);

        UpdateLog();
        ResetState();
        ResetCacheBattle();
    }

    private void ResetCacheBattle()
    {
        queue = queue.OrderBy(s => s.from.Speed).ToList();

        if (queue.Count >= NumberAction())
        {
            DoQueue();
        }

        cache = new QueueBattle();
    }

    private void UpdateSkill(CharacterInformation character)
    {
        for (int i = 0; i < character.Skills.Count || i < skills.Count; i++)
        {
            skills[i].SetSkill(character.CurrentStat, i < character.Skills.Count ? character.Skills[i] : null);
        }
    }

    private void DoQueue()
    {
        UpdateLog();

        if (queue.Count <= 0)
        {
            ChangeStateBattle(BattleStep.PreSkill);
            return;
        }

        ChangeStateBattle(BattleStep.CastSkill);

        var q = queue[0];
        var target = q.target;
        var from = q.from;

        if (target.Alive && from.Alive)
        {
            from.transform.DOMove(-from.transform.forward * .3f, .2f).SetRelative(true).SetLoops(2, LoopType.Yoyo);
            target.transform.DOMove(-target.transform.forward * .3f, .2f).SetRelative(true).SetLoops(2, LoopType.Yoyo);
            target.ApplyEffects(q.skill.Effects);
        }
        else
        {
            target.transform.DOShakePosition(.2f, new Vector3(.1f, 0, 0), 20);
            from.transform.DOShakePosition(.2f, new Vector3(.1f, 0, 0), 45);
        }

        DOVirtual.DelayedCall(1f, () =>
        {
            queue.RemoveAt(0);
            DoQueue();
        });

    }

    private void ChangeStateBattle(BattleStep nextStep, bool mustBe = false)
    {
        if (nextStep != Step || mustBe)
        {
            Step = nextStep;

            switch (Step)
            {
                case BattleStep.PreSkill:
                    timeRoundCD = timePerRound;
                    lockSelect = false;
                    break;
                case BattleStep.CastSkill:
                    lockSelect = true;
                    break;
            }
        }
    }

}

public enum BattleStep
{
    None,
    PreSkill,
    CastSkill
}

public class QueueBattle
{
    public CharacterInformation from;
    public CharacterInformation target;

    public SkillAttribute skill;
}