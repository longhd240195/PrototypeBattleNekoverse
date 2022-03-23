using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using System;

public class ConnectWallet : MonoBehaviour
{
    string str = "{ \"message\": \"Test Message\"}";
    private void Start()
    {
        JObject data = JObject.Parse(str);
        Debug.Log(data);
        // var publicKey = RSAController.ConvertPublicKeyToXml(DataConst.PUBLIC_KEY);
        // var rsa = new RSACryptoServiceProvider();
        // string pubKeyString = RSAController.GetKeyString(publicKey);
        // //Debug.Log(pubKeyString);
        // string encryptedText = RSAController.Encrypt("Thao", pubKeyString);
        // Debug.Log(encryptedText);

    }

}
