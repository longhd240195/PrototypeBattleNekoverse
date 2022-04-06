using UnityEngine;

public class LoadingController : MonoBehaviour
{
    [SerializeField] private GameLoading loadingLoader;
    void Start()
    {
        DataApi.GetInstance().manager.GetData("/v1/my/nekos/");
        DataApi.GetInstance().manager.GetData("/v1/pve/areas/");
        DataApi.GetInstance().manager.GetData("/v1/pve/map-levels/");
        loadingLoader.LoadLevel(DataConst.MAIN_SCENE);
    }
}
