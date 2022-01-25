using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class SkillInformation : MonoBehaviour
{
    [SerializeField] private BattleController controller;

    [SerializeField] private Button btnClick;
    [SerializeField] private TextMeshProUGUI txt;

    CharacterSkilled cache;

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
        cache = new CharacterSkilled(skill, character);

        txt.text = $"Name: {cache.NameSkill}\nDamage: {cache.EndValue: 0.00}";
    }

    public void SetController(BattleController controller)
    {
        this.controller = controller;
    }

    private void MakeAction()
    {
        controller.AssignSkill(cache);
    }
}
