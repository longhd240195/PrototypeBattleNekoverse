using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueueTurn : MonoBehaviour
{
    [SerializeField] private RawImage rawImg;
    [SerializeField] private Image border;

    private Color mainColor;
    
    public void Init(Texture mainImg, Color colorTeam)
    {
        rawImg.texture = mainImg;
        mainColor = colorTeam;
        border.color = colorTeam;
    }
    
    public QueueTurn SetCurrent(bool onQueue)
    {
        border.color = onQueue ? mainColor : (mainColor + Color.gray) / 2;
        return this;
    }

    public QueueTurn SetDead(bool isDead)
    {

        return this;
    }
}
