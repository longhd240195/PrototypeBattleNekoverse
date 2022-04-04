using System;
using System.Security.Cryptography;
using System.Text;
//using Org.BouncyCastle.Crypto.Parameters;
//using Org.BouncyCastle.Security;

public static class RSAController
{

    public static string CheckData(string data)
    {
        return data.Replace("\\\"", "");
    }
    public static string RSAEncryptPublicKey(string publicKey, string content)
    {
        //RsaKeyParameters publicKeyParam = (RsaKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(publicKey));
        //string XML = string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent></RSAKeyValue>",
        //    Convert.ToBase64String(publicKeyParam.Modulus.ToByteArrayUnsigned()),
        //    Convert.ToBase64String(publicKeyParam.Exponent.ToByteArrayUnsigned()));
        //RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        //byte[] cipherbytes;
        //rsa.FromXmlString(XML);
        //cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(content), false);
        //return Convert.ToBase64String(cipherbytes);

        return null;
    }
}
