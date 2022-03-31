using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NekoSkillData : MonoBehaviour
{
    public string NameSkill;
    public Image Icon;
    public bool IsLockSkill;
    public StateSkill StateSkill;
    [SerializeField] private GameObject lockSkill;
    [SerializeField] private GameObject selectSkill;

    private void Start()
    {
        lockSkill.SetActive(IsLockSkill);
    }

    private void Update()
    {
        ChangeStateSkill();
    }
    void ChangeStateSkill()
    {
        if (StateSkill == StateSkill.SELECTED)
        {
            selectSkill.SetActive(true);
        }
        else if (StateSkill == StateSkill.NONE)
        {
            selectSkill.SetActive(false);
        }
    }
}
public enum StateSkill
{
    NONE,
    SELECTED
}
