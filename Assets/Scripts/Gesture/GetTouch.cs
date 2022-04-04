﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GetTouch : MonoBehaviour
{
    public bool interactable;

    public UnityEvent onClick;
    public UnityEvent onMouseEnter;
    public UnityEvent onMouseExit;
    private CharacterInformation character;
    [SerializeField] private BattleNekoView nekoHover;

	private void Start()
	{
        character = gameObject.GetComponent<CharacterInformation>();
    }

	private void OnMouseUpAsButton()
    {
        if (!interactable)
            return;
        onClick?.Invoke();
    }

    private void OnMouseEnter()
    {
        if (!interactable)
            return;
        onMouseEnter?.Invoke();
    }

    private void OnMouseExit()
    {
        if (!interactable)
            return;

        onMouseExit?.Invoke();
        nekoHover?.gameObject.SetActive(false);
    }
    void OnMouseOver()
    {
        nekoHover?.gameObject.SetActive(true);
        nekoHover?.LoadNekoBar(character);
    }
}
