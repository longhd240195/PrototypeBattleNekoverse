using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillInformation : MonoBehaviour
{
    private static GameObject SkillInfo;

    [SerializeField] private BattleController controller;
    [SerializeField] private Image imgFaded;

    [SerializeField] private UIButton btnClick;
    [SerializeField] private Image signSelected;
    [SerializeField] private TextMeshProUGUI txt;

    SkillAttribute cache;

    private void Reset()
    {
        btnClick = GetComponent<UIButton>();
        txt = GetComponentInChildren<TextMeshProUGUI>();
    }

    [ContextMenu("Update ui button")]
    private void GetUIButton()
    {
        btnClick = GetComponent<UIButton>();
    }

    private void Start()
    {
        btnClick.onDrag.AddListener(Drag);
        btnClick.onClick.AddListener(MakeAction);
        btnClick.onStartDrag.AddListener(() =>
        {
            StartDrag();
            MakeAction();
        });
        btnClick.onPointerUp.AddListener(PointerUp);
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

    private void StartDrag()
    {
        SkillInfo = Instantiate(imgFaded, transform.parent.parent).gameObject;
        var txt = SkillInfo.GetComponentInChildren<TextMeshProUGUI>();
        txt.text = cache.ToString();
    }

    private void Drag(PointerEventData eventData)
    {
        SkillInfo.transform.position = eventData.position;
    }

    private void PointerUp()
    {
        Destroy(SkillInfo);

        controller.EndSelection();
        controller.UnassignSkill(cache);
    }

    public void CheckState(SkillAttribute skillAtb)
    {
        signSelected.gameObject.SetActive(cache == skillAtb);
    }
}
