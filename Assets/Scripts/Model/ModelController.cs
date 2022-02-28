using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Directory = UnityEngine.Windows.Directory;

public class ModelController : MonoBehaviour
{
    private Dictionary<string, List<GameObject>> traitsCache;
    
    private Dictionary<string, GameObject> traits;
    private Dictionary<string, GameObject> Traits => traits ?? (traits = new Dictionary<string, GameObject>());
    
    private void Start()
    {
        ReadALotFile();
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

    [ContextMenu("Read file")]
    public void ReadALotFile()
    {
        ReadData(ModelConst.Body);
        ReadData(ModelConst.Ear);
        ReadData(ModelConst.Nose);
        ReadData(ModelConst.Eye);
        ReadData(ModelConst.Eyebrow);
        ReadData(ModelConst.Medal);
        ReadData(ModelConst.Necklaces);
        ReadData(ModelConst.FrontFace);
        ReadData(ModelConst.Arms);
        ReadData(ModelConst.Accessories);
        ReadData(ModelConst.Back);
        ReadData(ModelConst.SideFace);
    }
    
    [ContextMenu("Create")]
    public void CreateALotFile()
    {
        InitScripableObjectFile(ModelConst.Body);
        InitScripableObjectFile(ModelConst.Ear);
        InitScripableObjectFile(ModelConst.Nose);
        InitScripableObjectFile(ModelConst.Eye);
        InitScripableObjectFile(ModelConst.Eyebrow);
        InitScripableObjectFile(ModelConst.Medal);
        InitScripableObjectFile(ModelConst.Necklaces);
        InitScripableObjectFile(ModelConst.FrontFace);
        InitScripableObjectFile(ModelConst.Arms);
        InitScripableObjectFile(ModelConst.Accessories);
        InitScripableObjectFile(ModelConst.Back);
        InitScripableObjectFile(ModelConst.SideFace);
        
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private void ReadData(string pathName)
    {
        var listItem = Resources.LoadAll<GameObject>("Model/Water/"+pathName).ToList();
        traitsCache.Add(pathName, listItem);
    }

    public void InitScripableObjectFile(string pathName)
    {
        var path = "Model/Water/" + pathName;
        var pathSave = "Assets/Resources/ModelData/Water/" + pathName;
        var objs = Resources.LoadAll<GameObject>(path).ToList();

        try
        {
            if (!Directory.Exists(pathSave))
            {
                Directory.CreateDirectory(pathSave);
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        foreach (var ob in objs)
        {
            var model = ScriptableObject.CreateInstance<TraitsDataModel>();
            model.Model = ob;
            model.name = ob.name;
            AssetDatabase.CreateAsset(model,pathSave+"/"+model.name+".asset");
            EditorUtility.SetDirty(model);
        }
    }
}
