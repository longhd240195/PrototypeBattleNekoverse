using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ModelController controller;
    private Neko neko;
    void Start()
    {
        neko = DataTest.GetNeko();
        controller.InitNeko(neko);
    }
}
