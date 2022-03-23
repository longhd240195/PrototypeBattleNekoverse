using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

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
    [Header("Animation")]
    [SerializeField] private RectTransform posListNeko;
    [SerializeField] private RectTransform listNekoObj;
    [SerializeField] private RectTransform posInventory;
    [SerializeField] private RectTransform inventoryObj;
    [SerializeField] private RectTransform posBar;
    [SerializeField] private RectTransform barObj;
    [SerializeField] private RectTransform posListSkill;
    [SerializeField] private RectTransform listSkillObj;
    [SerializeField] private RectTransform posDesSkill;
    [SerializeField] private RectTransform desObj;
    [SerializeField] private RectTransform posNekoBar;
    [SerializeField] private RectTransform nekoBar;

    private void Start()
    {
        controller.InitButtonClass(btnChangeClass);
        controller.InitButtonYourNeko(btnYourNeko);
        controller.InitButtonTraits(btnChangeTraits, btnChangeTraitsInfor);
        btnChangeTraitsInfor.ForEach(s => s.gameObject.SetActive(false));
        InitAnimation();
    }


    #region UI anim
    private void InitAnimation()
    {
        listNekoObj.DOLocalMoveX(posListNeko.localPosition.x, 0.5f);
        inventoryObj.DOLocalMoveY(posInventory.localPosition.y, 0.5f);
        barObj.DOLocalMoveY(posBar.localPosition.y, 0.5f);
        nekoBar.DOLocalMoveY(posNekoBar.localPosition.y, 0.5f);
    }
    public void AnimNekoBar()
    {
        nekoBar.localPosition = new Vector2(nekoBar.localPosition.x, nekoBar.localPosition.y + posNekoBar.localPosition.y);
        nekoBar.DOLocalMoveY(posNekoBar.localPosition.y, 0.5f);
    }
    public void AnimListSkill()
    {
        listSkillObj.localPosition = new Vector2(listSkillObj.localPosition.x + posListSkill.localPosition.x, listSkillObj.localPosition.y);
        listSkillObj.DOLocalMoveX(posListSkill.localPosition.x, 0.5f);
    }
    public void AnimDesSkill()
    {
        desObj.localPosition = new Vector2(desObj.localPosition.x, (desObj.localPosition.y + posDesSkill.localPosition.y) * 2);
        desObj.DOLocalMoveY(posDesSkill.localPosition.y, 0.5f);
    }
    #endregion


    public void LoadMap()
    {
        SceneManager.LoadScene(DataConst.MAP_SCENE);
    }
    public void LoadHome()
    {
        SceneManager.LoadScene(DataConst.MAIN_SCENE);
    }
}
