using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingController : MonoBehaviour
{
    [SerializeField] private GameLoading loadingLoader;
    // Start is called before the first frame update
    void Start()
    {
        loadingLoader.LoadLevel(DataConst.MAIN_SCENE);
    }
}
