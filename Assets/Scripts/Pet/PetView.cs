using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PetView : MonoBehaviour
{
    [SerializeField] private Text namePet;
    [SerializeField] private List<Image> stars;
    [SerializeField] private Image icon;
    [SerializeField] private NekoBar petBar;

    [SerializeField] private RectTransform posBar;
    [SerializeField] private RectTransform barObj;
    [SerializeField] private RectTransform posInventory;
    [SerializeField] private RectTransform inventoryObj;
    [SerializeField] private RectTransform posDetailPet;
    [SerializeField] private RectTransform detailPetObj;
    [SerializeField] private RectTransform posPet;
    [SerializeField] private RectTransform petObj;
    public void SetLayoutPet(PetData pet)
    {
        namePet.text = pet.PetName;
        if (pet.RateNumber == 0)
        {
            stars[0].transform.parent.gameObject.SetActive(false);
        }
        else
        {
            for (int i = 0; i < stars.Count; i++)
            {
                if (i < pet.RateNumber)
                {
                    stars[i].gameObject.SetActive(true);
                }
                else
                {
                    stars[i].gameObject.SetActive(false);
                }
            }
        }
        icon.sprite = pet.Icon;
        petBar.InitPetBar(pet);
        Init();
    }
    private void Init()
    {
        barObj.DOLocalMoveY(posBar.localPosition.y, 0.5f);
        inventoryObj.DOLocalMoveY(posInventory.localPosition.y, 0.5f);
        petObj.DOLocalMoveX(posPet.localPosition.x, 0.5f);
    }
    public void animDetailPet()
    {
        detailPetObj.localPosition = new Vector2(detailPetObj.localPosition.x + posDetailPet.localPosition.x, detailPetObj.localPosition.y);
        detailPetObj.DOLocalMoveX(posDetailPet.localPosition.x, 0.5f);
    }
}
