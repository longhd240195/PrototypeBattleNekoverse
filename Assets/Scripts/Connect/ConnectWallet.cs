using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConnectWallet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public void OnButtonConnectClick()
    {
        var data = new DataSign
        {
            message = "Test Message"
        };
        string dataSign = JsonUtility.ToJson(data);
        //string c = RSAController.Encrypt(RSAController.CheckData(dataSign), DataConst.PUBLIC_KEY);
        string c = "";
        var obj = new DataLogin
        {
            id = DataConst.ID,
            data = c,
            responseURL = DataConst.RESPONSE_URL
        };
        var s = JsonUtility.ToJson(obj);
            
        string url = DataConst.NEKOWALLET_URL + "?data=" + s;
        text.text = url;
        Application.OpenURL(url);
        Debug.Log(url);
    }
}
