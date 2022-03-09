using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelView : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private GameObject objOnLevel;
    public LevelData level;
    public bool isOnLevel;
    private void Start()
    {
        objOnLevel.SetActive(isOnLevel);
    }
    public void SetIconLevel()
    {
        icon.sprite = level.Icon;
    }
}
