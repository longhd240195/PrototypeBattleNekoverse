using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NekoView : MonoBehaviour
{
    [SerializeField] private NekoBar nekoBar;
    [SerializeField] private Text nekoNameText;
    [SerializeField] private GameObject DesceptionSkill;
    public void Init(Neko neko)
    {
        nekoBar.InitNekoBar(neko);
        SetName(neko.NekoName);
    }

    private void SetName(string name)
    {
        nekoNameText.text = name;
    }

    public void ChangeSkillState(Button[] btnSkill, string nameSkill)
    {
        for (int i = 0; i < btnSkill.Length; i++)
        {
            NekoSkill nekoSkill = btnSkill[i].GetComponent<NekoSkill>();
            if (nekoSkill.StateSkill == StateSkill.SELECTED && nekoSkill.NameSkill != nameSkill)
            {
                nekoSkill.StateSkill = StateSkill.NONE;
            }
        }
    }
    public void SetDesceptionSkill(string nameSkill, string desception)
    {
        DesceptionSkill.transform.GetChild(0).GetComponent<Text>().text = nameSkill;
        DesceptionSkill.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = desception;
    }
    public void ShowDesceptionSkill(Button[] btnSkill)
    {
        bool isSelect = false;
        for (int i = 0; i < btnSkill.Length; i++)
        {
            NekoSkill nekoSkill = btnSkill[i].GetComponent<NekoSkill>();
            if (nekoSkill.StateSkill == StateSkill.SELECTED)
            {
                isSelect = true;
            }
        }
        if (!isSelect)
        {
            DesceptionSkill.SetActive(false);
        }
    }
    public void SetDesceptionSkillActive(bool b)
    {
        DesceptionSkill.SetActive(b);
    }
    public void ResetBtnSkill(Button[] btnSkill)
    {
        for (int i = 0; i < btnSkill.Length; i++)
        {
            NekoSkill nekoSkill = btnSkill[i].GetComponent<NekoSkill>();
            if (nekoSkill.StateSkill == StateSkill.SELECTED)
            {
                nekoSkill.StateSkill = StateSkill.NONE;
            }
        }
        DesceptionSkill.SetActive(false);
    }
}
