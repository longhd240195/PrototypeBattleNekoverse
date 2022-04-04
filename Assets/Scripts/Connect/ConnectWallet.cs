using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ConnectWallet : MonoBehaviour
{
    [SerializeField] private NekoManager nekoManager;
    private void Awake()
    {
        Application.deepLinkActivated += onDeepLinkActivated;
        if (!string.IsNullOrEmpty(Application.absoluteURL))
        {
            onDeepLinkActivated(Application.absoluteURL);
        }
        #if UNITY_EDITOR
        nekoManager.LogIn();
        #endif
    }
    public void onDeepLinkActivated(string url)
    {
        string responseUrl = url.Split("?"[0])[1];
        responseUrl = responseUrl.Replace("response=", "");
        ConnectWalletResponse res = JsonUtility.FromJson<ConnectWalletResponse>(responseUrl);
        //nekoManager.LogIn(res.signKey,res.walletAddesss);
        SceneManager.LoadScene(DataConst.LOADING_SCENE);
    }
    public void OnButtonConnectClick()
    {
        DataSign data = new DataSign
        {
            message = "Test Message"
        };
        string encryptData = RSAController.RSAEncryptPublicKey(DataConst.PUBLIC_KEY, RSAController.CheckData(JsonUtility.ToJson(data)));
        ConnectWalletRequest request = new ConnectWalletRequest
        {
            id = DataConst.ID,
            data = encryptData,
            responseUrl = DataConst.RESPONSE_URL
        };
        string requestUrl = DataConst.NEKOWALLET_URL + "?data=" + JsonUtility.ToJson(request);
        //Application.OpenURL(requestUrl);
        SceneManager.LoadScene(DataConst.LOADING_SCENE);
    }
}
