using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModelCanvas : MonoBehaviour
{
    [SerializeField] private ModelControllerTest controller;
    [SerializeField] private GameLoading loadingLoader;
    [SerializeField] private Button[] btnChangeClass;
    [SerializeField] private Button[] btnChangeTraits;
    [SerializeField] private Button[] btnChangeTraitsInfor;
    [SerializeField] private Button[] btnChangeSkill;
    [SerializeField] private Button[] btnYourNeko;
    [SerializeField] private Button btnChangeModel;

    private void Start()
    {
        controller.InitButtonClass(btnChangeClass);
        controller.InitButtonYourNeko(btnYourNeko);
        controller.InitButtonTraits(btnChangeTraits,btnChangeTraitsInfor);
        btnChangeTraitsInfor.ForEach(s => s.gameObject.SetActive(false));
    }        
    public void LoadMap()
    {
        loadingLoader.LoadLevel(DataConst.MAP_SCENE);
    }
}
