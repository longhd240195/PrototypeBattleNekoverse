using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitsDataModel : ScriptableObject
{
    [SerializeField] private GameObject model;
    [SerializeField] private Sprite icon;
    [SerializeField] private NekoClass className;
    [SerializeField] private string trait;

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

    public NekoClass ClassName
    {
        get { return className; }
        set { className = value; }
    }

    public string Trait
    {
        get { return trait; }
        set { trait = value; }
    }
}
