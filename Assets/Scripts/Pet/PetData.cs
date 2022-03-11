using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "DataPet", menuName = "ScriptableObjects/Pet data")]
public class PetData : ScriptableObject
{
    [SerializeField] string petName;
    [SerializeField] int rateNumber;
    [SerializeField] Sprite icon;
    [SerializeField] float hp;
    [SerializeField] float atk;
    [SerializeField] float def;

    public string PetName { get => petName; set => petName = value; }
    public int RateNumber { get => rateNumber; set => rateNumber = value; }
    public Sprite Icon { get => icon; set => icon = value; }
    public float Hp { get => hp; set => hp = value; }
    public float Atk { get => atk; set => atk = value; }
    public float Def { get => def; set => def = value; }
}
