using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitsDataModel : ScriptableObject
{
    [SerializeField] private GameObject model;
    [SerializeField] private Sprite icon;

    public GameObject Model
    {
        get { return model; }
        set { model = value; }
    }

    public Sprite Icon
    {
        get { return icon; }
        set { icon = value; }
    }
}
