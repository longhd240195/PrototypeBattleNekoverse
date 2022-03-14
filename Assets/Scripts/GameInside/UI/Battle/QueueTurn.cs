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
    
    public void Init(Texture mainImg, Color colorTeam)
    {
        rawImg.texture = mainImg;
        mainColor = colorTeam;
        border.color = colorTeam;
        //pointImage.color = colorPoint;
    }
    
    public QueueTurn SetCurrent(bool onQueue)
    {
        border.color = onQueue ? mainColor : (mainColor + Color.gray) / 2;
        //gameObject.SetActive(onQueue);
        
   
        if(!onQueue)
        {
            Debug.Log(gameObject.name);
            gameObject.transform.Find("Select").gameObject.SetActive(false);
//            Color c = border.color;
//            Color rawColor = Color.white;
//            c.a = .25f;
//            rawColor.a = .25f;
//            border.color = c;
//            rawImg.color = rawColor;
        }else{
            gameObject.transform.Find("Select").gameObject.SetActive(true);
        }
        return this;
    }
}
