using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NekoView : MonoBehaviour
{
    public void ChangeSkillState(Button[] btnSkill, string nameSkill)
    {
        for (int i = 0; i < btnSkill.Length; i++)
        {
            NekoSkill nekoSkill = btnSkill[i].GetComponent<NekoSkill>();
            if (nekoSkill.StateSkill == StateSkill.SELECTED && nekoSkill.skill.NameSkill != nameSkill)
            {
                nekoSkill.StateSkill = StateSkill.NONE;
            }
        }
    }
}
