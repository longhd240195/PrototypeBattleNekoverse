using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.UI;

public class ModelCanvas : MonoBehaviour
{
    [SerializeField] private ModelController controller;
    
    [SerializeField] private Button[] btnChangeClass;
    [SerializeField] private Button[] btnChangeTraits;
    [SerializeField] private Button[] btnChangeTraitsInfor;
    [SerializeField] private Button btnChangeModel;

    private void Start()
    {
        controller.InitButtonClass(btnChangeClass);
        controller.InitButtonTraits(btnChangeTraits,btnChangeTraitsInfor);
        btnChangeTraitsInfor.ForEach(s => s.gameObject.SetActive(false));
    }        

}
