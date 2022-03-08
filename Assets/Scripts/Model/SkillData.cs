using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/SkillData")]
public class SkillData : ScriptableObject
{
    [SerializeField] private string nameSkill;
    [SerializeField] private Sprite icon;
    [SerializeField] private NekoClass className;
    [SerializeField] private string desception;

    public string NameSkill
    {
        get { return nameSkill; }
        set { nameSkill = value; }
    }
    public Sprite Icon
    {
        get { return icon; }
        set { icon = value; }
    }
    public NekoClass ClassName
    {
        get { return className; }
        set { className = value; }
    }
       public string Desception
    {
        get { return desception; }
        set { desception = value; }
    }
}
