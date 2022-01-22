using DG.Tweening;

using System.Collections;
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

    private int NumberAction (){
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
        Chagne(BattleStep.PreSkill);
        blues.ForEach(s => { 
            s.Initialize();
            s.Controller = this;
        });
        reds.ForEach(s => {
            s.Initialize();
            s.Controller = this;
        });
        skills.ForEach(s => {
            s.SetController(this);
        });
    }

    private void UpdateLog()
    {
        var sb = new StringBuilder("--Log--\n");
        queue.ForEach(q =>
        {
            var isBlue = blues.IndexOf(q.from) != -1;
            sb.Append(isBlue ? "Blue" : "Red").
            Append(":\t").
            Append((isBlue ? blues.IndexOf(q.from) : reds.IndexOf(q.from)) + 1).
            Append("-").
            Append((isBlue ? reds.IndexOf(q.target) : blues.IndexOf(q.target)) + 1).
            Append("\n");
        });
        txtLog.text = sb.ToString();
    }

    public void AssignSkill(CharacterSkilled skill)
    {
        if (cache == null)
            cache = new QueueBattle();

        cache.skill = skill;
    }

    public void AssignCharacter(CharacterInformation character)
    {
        if (cache == null)
            cache = new QueueBattle();
        
        if (!cache.from)
        {
            cache.from = character;
            UpdateSkill(character);
        }
        else
        {
            cache.target = character;
            queue.Add(cache);

            cache = new QueueBattle();
            queue = queue.OrderBy(s => s.from.Speed).ToList();

            if (queue.Count >= NumberAction())
            {
                DoQueue();
            }
        }


        UpdateLog();
    }

    private void UpdateSkill(CharacterInformation character)
    {
        for(int i = 0; i < character.Skills.Count|| i < skills.Count; i++)
        {
                skills[i].SetSkill(character.CurrentStat, i < character.Skills.Count? character.Skills[i]:null);
        }
    }

    private void DoQueue()
    {
        UpdateLog();

        if (queue.Count <= 0)
        {
            Chagne(BattleStep.PreSkill);
            return;
        }
        Chagne(BattleStep.CastSkill);

        var q = queue[0];
        var target = q.target;
        var from = q.from;

        if (target.Alive && from.Alive)
        {
            target.transform.DOJump(Vector2.zero, 20f, 1, .2f).SetRelative(true);
            from.transform.DOJump(Vector2.zero, 20f, 1, .2f).SetRelative(true);
            target.TakeDamage(q.skill.EndValue);
        }
        else
        {
            target.transform.DOShakePosition(.2f, new Vector3(10, 0, 0),20);
            from.transform.DOShakePosition(.2f, new Vector3(10, 0, 0),45);
        }

        DOVirtual.DelayedCall(1f, () =>
        {
            queue.RemoveAt(0);
            DoQueue();
        });

    }

    private void Chagne(BattleStep nextStep)
    {
        if (nextStep != Step)
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

    public CharacterSkilled skill;
}