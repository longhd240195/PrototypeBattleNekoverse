using Sirenix.Serialization.Utilities;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class SkillInformation : MonoBehaviour
{
    [SerializeField] private BattleController controller;

    [SerializeField] private Button btnClick;
    [SerializeField] private Image signSelected;
    [SerializeField] private TextMeshProUGUI txt;

    SkillAttribute cache;

    private void Reset()
    {
        btnClick = GetComponent<Button>();
        txt = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        btnClick.onClick.AddListener(MakeAction);
    }

    public void SetSkill(CharacterAttribute character, SkillAttribute skill)
    {
        btnClick.interactable = skill != null;
        if (skill == null || character == null)
        {
            txt.text = string.Empty;
            return;
        }

        cache = skill.Clone() as SkillAttribute;
        cache.Apply(character);
        txt.text = cache.ToString() ;
    }

    public void SetController(BattleController controller)
    {
        this.controller = controller;
    }

    private void MakeAction()
    {
        controller.AssignSkill(cache);
    }

    public void CheckState(SkillAttribute skillAtb)
    {
        signSelected.gameObject.SetActive(cache == skillAtb);
    }
}
