using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectWallet : MonoBehaviour
{
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
        string sceneName = url.Split("?"[0])[1];
        SceneManager.LoadScene(DataConst.MAIN_SCENE);
        Debug.Log(sceneName);
    }
    public void OnButtonConnectClick()
    {
        DataSign data = new DataSign
        {
            message = "Test Message"
        };
        string dataSign = JsonUtility.ToJson(data);
        string rsaDataSign = RSAController.RSAEncryptPublicKey(DataConst.PUBLIC_KEY, RSAController.CheckData(dataSign));
        DataLogin obj = new DataLogin
        {
            id = DataConst.ID,
            data = rsaDataSign,
            responseUrl = DataConst.RESPONSE_URL
        };
        string s = JsonUtility.ToJson(obj);
        string url = DataConst.NEKOWALLET_URL + "?data=" + s;
        Application.OpenURL(url);
    }
}
