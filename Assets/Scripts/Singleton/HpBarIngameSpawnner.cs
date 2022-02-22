using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarIngameSpawnner : MonoBehaviour
{
    public static HpBarIngameSpawnner Instance;
    [SerializeField] private IngameHealthBar temp;

    private List<IngameHealthBar> listSpawned;
    private List<IngameHealthBar> ListSpawned => listSpawned ?? (listSpawned = new List<IngameHealthBar>());

    public Vector3 PosTemp => temp.transform.localPosition;
    
    private void Awake()
    {
        temp.gameObject.SetActive(false);
        Instance = this;
    }

    public IngameHealthBar GetTemp()
    {
        var ob = ListSpawned.Find(s => !s.gameObject.activeInHierarchy);
        if (!ob)
        {
            ob = Instantiate(temp, transform);
            ListSpawned.Add(ob);
        }
        ob.gameObject.SetActive(true);
        return ob;
    }
}
