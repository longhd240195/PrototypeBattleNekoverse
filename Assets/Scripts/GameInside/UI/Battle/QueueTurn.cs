using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueueTurn : MonoBehaviour
{
    [SerializeField] private RawImage rawImg;
    [SerializeField] private Image border;
    //[SerializeField] private Image pointImage;
    private Color mainColor;

    public CharacterInformation charInfo = null;
    
    public void Init(Texture mainImg, Color colorTeam)
    {
        rawImg.texture = mainImg;
        mainColor = colorTeam;
        border.color = colorTeam;
        //pointImage.color = colorPoint;
    }
    
    public QueueTurn SetCurrent(bool onQueue, CharacterInformation c)
    {
        //save current character info for later use
        charInfo = c;

        border.color = onQueue ? mainColor : (mainColor + Color.gray) / 2;
        gameObject.SetActive(onQueue);
   
        if(!onQueue)
        {
//            Color c = border.color;
//            Color rawColor = Color.white;
//            c.a = .25f;
//            rawColor.a = .25f;
//            border.color = c;
//            rawImg.color = rawColor;
        }
        return this;
    }
}
