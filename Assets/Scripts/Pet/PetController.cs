using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PetController : MonoBehaviour
{
    [SerializeField] private PetView petView;
    [SerializeField] private Transform content;
    [SerializeField] private GameObject petPrefab;
    private List<Button> listPetBtns = new List<Button>();
    private List<PetData> CachePet;

    private void Awake()
    {
        ReadDataPetScripable();
    }
    private void Start()
    {
        InitObjPet(CachePet, content.gameObject);
        InitButtonPet(listPetBtns);
        petView.SetLayoutPet(CachePet[0]);
    }

    void InitObjPet(List<PetData> list, GameObject parent)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var obj = Instantiate(petPrefab, parent.transform);
            int index = i;
            obj.GetComponent<Pet>().pet = list[index];
            obj.GetComponent<Pet>().InitPet();
            listPetBtns.Add(obj.GetComponent<Button>());
        }
    }
    void InitButtonPet(List<Button> btnPets)
    {
        for (int i = 0; i < btnPets.Count; i++)
        {
            var btn = btnPets[i].GetComponent<Button>();
            var petData = btnPets[i].GetComponent<Pet>().pet;
            btn.onClick.AddListener(() =>
            {
                petView.SetLayoutPet(petData);
            });
        }
    }

    private void ReadDataPetScripable()
    {
        CachePet = Resources.LoadAll<PetData>($"PetData").ToList();
    }
}
