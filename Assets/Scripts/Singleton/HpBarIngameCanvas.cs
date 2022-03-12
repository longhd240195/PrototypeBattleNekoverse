using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpBarIngameCanvas : MonoBehaviour
{
    [SerializeField] private Image border;
    [SerializeField] private Image main;
    [SerializeField] private Image hpLost;
    [SerializeField] private TextMeshPro txt;
    [SerializeField] private TextMeshPro txtName;

    private float currentPercent;


    public void Init(CharacterInformation infor)
    {
        return;
        main.transform.localScale = border.transform.localScale;
        txtName.text = infor.transform.name;
        txt.text = $"{infor.Health}/{infor.InitHealth}";
        currentPercent = 1;
    }

    public void ChangePercent(CharacterInformation infor)
    {
        return;
        var percent = infor.Health / infor.InitHealth;
        var cl = hpLost.transform.localScale;
        hpLost.transform.localScale = new Vector3(currentPercent, cl.y, cl.z);

        currentPercent = percent;

        main.transform.localScale = new Vector3(currentPercent, cl.y, cl.z);
        hpLost.transform.DOScaleX(currentPercent, .5f).SetEase(Ease.Linear);
        txt.text = $"{infor.Health}/{infor.InitHealth}";
    }

    public void SetPosition(Vector3 positionTarget)
	{
        var pos = Camera.main.WorldToScreenPoint(positionTarget);
        transform.position = pos;
	}
}
