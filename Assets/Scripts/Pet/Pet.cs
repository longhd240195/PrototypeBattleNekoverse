using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pet : MonoBehaviour
{
    public PetData pet;
    [SerializeField] private Image Icon;
    [SerializeField] private List<Image> star;
    [SerializeField] private GameObject lockObj;
    public bool isLockPet;
    public void InitPet()
    {
        if (pet.RateNumber == 0)
        {
            star[0].transform.parent.gameObject.SetActive(false);
        }
        else
        {
            for (int i = 0; i < star.Count; i++)
            {
                if (i < pet.RateNumber)
                {
                    star[i].gameObject.SetActive(true);
                }
                else
                {
                    star[i].gameObject.SetActive(false);
                }
            }
        }
        SetIconPet();
        SetLockPet(isLockPet);
    }
    void SetIconPet()
    {
        Icon.sprite = pet.Icon;
    }
    void SetLockPet(bool b)
    {
        lockObj.SetActive(b);
    }
}
