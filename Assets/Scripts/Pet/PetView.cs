using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetView : MonoBehaviour
{
    [SerializeField] private Text namePet;
    [SerializeField] private List<Image> stars;
    [SerializeField] private Image icon;
    [SerializeField] private NekoBar petBar;
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
    }
}
