using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

public class RSAController
{

    public static string CheckData(string data)
    {
        return data.Replace("\\\"", "");
    }


    public static string Encrypt(string textToEncrypt, string publicKeyString)
    {
        var publicKey = RSAController.PemToXml("-----BEGIN PUBLIC KEY-----\r\n" + publicKeyString + "\r\n-----END PUBLIC KEY-----");
        var bytesToEncrypt = Encoding.UTF8.GetBytes(textToEncrypt);

        using (var rsa = new RSACryptoServiceProvider(1024))
        {
            try
            {
                rsa.FromXmlString(publicKey.ToString());
                var encryptedData = rsa.Encrypt(bytesToEncrypt, true);
                var base64Encrypted = Convert.ToBase64String(encryptedData);
                return base64Encrypted;
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }
        }
    }

    public static string Decrypt(string textToDecrypt, string privateKeyString)
    {
        var bytesToDescrypt = Encoding.UTF8.GetBytes(textToDecrypt);

        using (var rsa = new RSACryptoServiceProvider(1024))
        {
            try
            {

                // server decrypting data with private key                    
                rsa.FromXmlString(privateKeyString);

                var resultBytes = Convert.FromBase64String(textToDecrypt);
                var decryptedBytes = rsa.Decrypt(resultBytes, true);
                var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                return decryptedData.ToString();
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }
        }
    }


    //Convert public key to xml;
    public static string PemToXml(string pem)
    {
        if (pem.StartsWith("-----BEGIN RSA PRIVATE KEY-----")
            || pem.StartsWith("-----BEGIN PRIVATE KEY-----"))
        {
            return GetXmlRsaKey(pem, obj =>
            {
                if ((obj as RsaPrivateCrtKeyParameters) != null)
                    return DotNetUtilities.ToRSA((RsaPrivateCrtKeyParameters)obj);
                var keyPair = (AsymmetricCipherKeyPair)obj;
                return DotNetUtilities.ToRSA((RsaPrivateCrtKeyParameters)keyPair.Private);
            }, rsa => rsa.ToXmlString(true));
        }

        if (pem.StartsWith("-----BEGIN PUBLIC KEY-----"))
        {
            return GetXmlRsaKey(pem, obj =>
            {
                Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters publicKey = (Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters)obj;
                return DotNetUtilities.ToRSA(publicKey);
            }, rsa => rsa.ToXmlString(false));
        }

        throw new InvalidKeyException("Unsupported PEM format...");
    }
    private static string GetXmlRsaKey(string pem, Func<object, RSA> getRsa, Func<RSA, string> getKey)
    {
        using (var ms = new MemoryStream())
        using (var sw = new StreamWriter(ms))
        using (var sr = new StreamReader(ms))
        {
            sw.Write(pem);
            sw.Flush();
            ms.Position = 0;
            var pr = new PemReader(sr);
            object keyPair = pr.ReadObject();
            using (RSA rsa = getRsa(keyPair))
            {
                var xml = getKey(rsa);
                return xml;
            }
        }
    }
}
