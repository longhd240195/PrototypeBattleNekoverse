using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DG.Tweening;
using Sirenix.Utilities;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class LoadNeko : MonoBehaviour
{
    private Dictionary<string, List<TraitsDataModel>> traitsCache;
    private Dictionary<string, GameObject> traits;
    private Dictionary<string, GameObject> Traits => traits ?? (traits = new Dictionary<string, GameObject>());
    private Dictionary<string, List<TraitsDataModel>> Cache =>
        traitsCache ?? (traitsCache = new Dictionary<string, List<TraitsDataModel>>());
    public Neko neko;
    [SerializeField] public Camera cam;
    private Texture mainTexture;
    public Texture MainTexture => mainTexture;
    public void Init()
    {
        CacheFile(neko.NekoClass.ToString());
        InitNeko(neko);
    }

    private void InitNeko(Neko neko)
    {

        foreach (KeyValuePair<string, int> kvp in neko.traitsNeko)
        {
            ChangeTraits(kvp.Key, kvp.Value);
        }
    }

    void ChangeTraits(string traitName, int indexNextModel = -1)
    {
        var modelRandom = Cache[traitName];
        if (indexNextModel == -1)
            indexNextModel = Random.Range(0, modelRandom.Count);
        var randomModel = Instantiate(modelRandom[indexNextModel].Model, transform);
        ChangeModel(randomModel);
        randomModel.layer = 6;
        ChangeModel(traitName, randomModel);
    }

    private void ChangeModel(GameObject parent)
    {
        var childCount = parent.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            parent.transform.GetChild(i).gameObject.layer = 6;
            ChangeModel(parent.transform.GetChild(i).gameObject);
        }
    }
    void ChangeModel(string traitName, GameObject newGameObject)
    {
        if (!Traits.TryGetValue(traitName, out var go))
        {
            Traits.Add(traitName, newGameObject);
        }
        else
        {
            Destroy(Traits[traitName]);
            Traits[traitName] = newGameObject;
        }
    }

    public void CacheFile(string currentClass = "Water")
    {
        ReadDataScripable(currentClass, ModelConst.Body);
        ReadDataScripable(currentClass, ModelConst.Ear);
        ReadDataScripable(currentClass, ModelConst.Nose);
        ReadDataScripable(currentClass, ModelConst.Eye);
        ReadDataScripable(currentClass, ModelConst.Eyebrow);
        ReadDataScripable(currentClass, ModelConst.Medal);
        ReadDataScripable(currentClass, ModelConst.Necklaces);
        ReadDataScripable(currentClass, ModelConst.FrontFace);
        ReadDataScripable(currentClass, ModelConst.Arms);
        ReadDataScripable(currentClass, ModelConst.Accessories);
        ReadDataScripable(currentClass, ModelConst.Back);
        ReadDataScripable(currentClass, ModelConst.SideFace);
    }

    private void ReadDataScripable(string className, string pathName)
    {
        var listItem = Resources.LoadAll<TraitsDataModel>($"ModelData/{className}/{pathName}").ToList();
        Cache.Add(pathName, listItem);
    }
}
