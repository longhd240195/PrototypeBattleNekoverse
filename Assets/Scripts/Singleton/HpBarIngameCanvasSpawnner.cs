using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarIngameCanvasSpawnner : MonoBehaviour
{
    public static HpBarIngameCanvasSpawnner Instance;
    [SerializeField] private HpBarIngameCanvas temp;

    private List<HpBarIngameCanvas> listSpawned;
    private List<HpBarIngameCanvas> ListSpawned => listSpawned ?? (listSpawned = new List<HpBarIngameCanvas>());

    public Vector3 PosTemp => temp.transform.localPosition;

    private void Awake()
    {
        temp.gameObject.SetActive(false);
        Instance = this;
    }

    public HpBarIngameCanvas GetTemp()
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
