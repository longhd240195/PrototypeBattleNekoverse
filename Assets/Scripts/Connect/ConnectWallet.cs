using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using crypto;
    public class ConnectWallet : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        private void Awake()
        {
            Application.deepLinkActivated += onDeepLinkActivated;
            if (!string.IsNullOrEmpty(Application.absoluteURL))
            {
                onDeepLinkActivated(Application.absoluteURL);
            }
        }


        public void onDeepLinkActivated(string url)
        {
            // Update DeepLink Manager global variable, so URL can be accessed from anywhere.
            text.text = "nopause " + url;
            // Decode the URL to determine action. 
            // In this example, the app expects a link formatted like this:
            // unitydl://mylink?scene1
            string sceneName = url.Split("?"[0])[1];
        }
        public void OnButtonConnectClick()
        {
            var data = new DataSign
            {
                message = "Test Message"
            };
            string dataSign = JsonUtility.ToJson(data);
            //string c1 = RSAController.Encrypt(RSAController.CheckData(dataSign), DataConst.PUBLIC_KEY);
            string c = "hdwEkkGCDE3gqcI6E104YbxNwDAb8BsZD8H+qa8WkNN+pr4b+FiVHabk8oGnHFVzHIMDEqxkGyJ28bI2/VIh3b+pWeqV0nZSStKK2Wq1dLq2y2hZ1cKEd48+83s11rgfNBFcVc06QcKvdFuU+oGTL3xyU7Ng7abBaNzKteLWrZmyMs/fUEf+lFSoVn4OibLjqjw5v9gncr6M+xdx1DYY0nzbKb/nVFZ5LRQ989ThkuvXjGT9ANH2A88mynrf1i4AGBBWP8J5Ke4IkaQUyneaG2bbaiGm2DFdZ+c97HSEwXRl4xH3HNx8dYcbMpNP6QHflJD9vWELheMmWedbPIUyIQ==";
            var obj = new DataLogin
            {
                id = DataConst.ID,
                data = c,
                responseUrl = DataConst.RESPONSE_URL
            };
            var s = JsonUtility.ToJson(obj);

            string url = DataConst.NEKOWALLET_URL + "?data=" + s;
            text.text = url;
            Application.OpenURL(url);
            Debug.Log(url);
        }
        public void OnButtonDecryptClick()
        {
            var data = new DataSign
            {
                message = "Test Message"
            };
            string dataSign = JsonUtility.ToJson(data);
            string prv = "MIICdQIBADANBgkqhkiG9w0BAQEFAASCAl8wggJbAgEAAoGBAIjZbA0qyo49QUvl0w6Mt+ccHhOZAeuYSeTnSrGgkeUoLDEOjvqzo/WfhGthwY0H9Wl2lQi1bApOrYJsrBDYVxJpixhjSe6LQzSbRYpTSAdkA52VCspAkkCv3pd1303mmdp/B58Z+KD9NL4d8V4id7SRzByQkzjogXox7ch/yXcvAgMBAAECgYBLp5+Dm/+FKTobAoBuz76vhqzd+r3ECFn5sSBrGLDvdgkQSdMjqAJhvQFQ+Ccvl5HF7yevO9Tx0dM8gmWRnnhrv3qVzTFLnl5Bdtjsvbz1jWRiPdEepEU0UdXCdHh2z2kek4hEjqtZDJSXtsvu7G3NJ0RoEIkFejnj1wnj2oV04QJBAPbmtKKeuKaTnqR5ZHyA5Lo9LCT84Dt5NTmWvbXPj1/a8wKKFHoN38zOB0od21dA2egviJUdGR1TmXNdZ4b3sPECQQCN5HlnWYRz886Ycgiqsla6dwiSuwlVKUN8e93jn8Vd7WA8WTHNIa3LRXe2lV6SdPVK/zpf4vq5kZbxYgcw+6ofAkAXnw7dGA5WcX0WAz8n4jT/1GZqy36wcfIzpkZUJJ108D+bmJZI7xbgQz3TS3P2rw+p9RI+IeCLO7pMnT0QXpYhAkBom5RVeU2JHqmlAg0Zqzj9Z1xOsM2El1NFpxxDADtFsAdO9oMctEOopKJJXX3Hg6qDi/7BSlmGDau2cYrTtfYJAkBelTMY2Ghj/i67AfUcGhSPBgOpM7ikk6vTObrKdw/kimfeo9owf3ntA8ldbEmcwEuH50sOHdPzy+XFyYrhG5p0";
        //string pem_prv = 
        Debug.Log(RSAController.PemToXml("-----BEGIN PRIVATE KEY-----\r\n" + prv + "\r\n-----END PRIVATE KEY-----"));
        string c = RSAController.Decrypt(text.text.Trim(), prv);
            //string c = "hdwEkkGCDE3gqcI6E104YbxNwDAb8BsZD8H+qa8WkNN+pr4b+FiVHabk8oGnHFVzHIMDEqxkGyJ28bI2/VIh3b+pWeqV0nZSStKK2Wq1dLq2y2hZ1cKEd48+83s11rgfNBFcVc06QcKvdFuU+oGTL3xyU7Ng7abBaNzKteLWrZmyMs/fUEf+lFSoVn4OibLjqjw5v9gncr6M+xdx1DYY0nzbKb/nVFZ5LRQ989ThkuvXjGT9ANH2A88mynrf1i4AGBBWP8J5Ke4IkaQUyneaG2bbaiGm2DFdZ+c97HSEwXRl4xH3HNx8dYcbMpNP6QHflJD9vWELheMmWedbPIUyIQ==";

            text.text = c;
            //Application.OpenURL(url);
            Debug.Log(c);
        }
        public void OnButtonEncryptClick()
        {
        var data = new DataSign
        {
            message = "Test Message"
        };
        string dataSign = JsonUtility.ToJson(data);
        string pub = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCI2WwNKsqOPUFL5dMOjLfnHB4TmQHrmEnk50qxoJHlKCwxDo76s6P1n4RrYcGNB/VpdpUItWwKTq2CbKwQ2FcSaYsYY0nui0M0m0WKU0gHZAOdlQrKQJJAr96Xdd9N5pnafwefGfig/TS+HfFeIne0kcwckJM46IF6Me3If8l3LwIDAQAB";
        string c = RSAController.Encrypt(RSAController.CheckData(dataSign), pub);
        Debug.Log( RSAController.PemToXml("-----BEGIN PUBLIC KEY-----\r\n" + pub + "\r\n-----END PUBLIC KEY-----"));


        text.text = c;
        //Application.OpenURL(url);
        Debug.Log(c);
    }
    }
