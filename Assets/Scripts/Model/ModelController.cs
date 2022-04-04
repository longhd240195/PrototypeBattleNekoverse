using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Sirenix.Utilities;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ModelController : MonoBehaviour
{
    [SerializeField] private NekoView nekoView;
    [SerializeField] private ModelCanvas modelCanvas;
    [SerializeField] private TextMeshProUGUI txtLog;
    [SerializeField] private List<Sprite> classSpr;
    [SerializeField] private Button[] btnChangeSkill;
    private string[] listTraitNames;
    public NekoData neko;
    private List<SkillData> skillsCache;
    private Dictionary<string, List<TraitsDataModel>> traitsCache;

    private Dictionary<string, GameObject> traits;
    private Dictionary<string, GameObject> Traits => traits ?? (traits = new Dictionary<string, GameObject>());
    private Dictionary<string, List<TraitsDataModel>> Cache =>
        traitsCache ?? (traitsCache = new Dictionary<string, List<TraitsDataModel>>());
    private int cacheIdNeko = 0;
    private List<NekoData> listNekoData;
    private void Awake()
    {
        InitTraitName();
        CacheFile();
    }
    public void LoadNeko(List<NekoData> nekoDatas)
    {
        listNekoData = nekoDatas;
        neko = listNekoData[cacheIdNeko];
        InitNekoData(neko);
    }
    public void ChangeModel(int i)
    {
        int index = cacheIdNeko + i;
        if (cacheIdNeko == 0 && i < 0)
            return;
        if (index < listNekoData.Count)
        {
            InitNekoData(listNekoData[index]);
            cacheIdNeko = index;
        }
        else
        {
            return;
        }
    }
    public void InitNekoData(NekoData neko, bool isBattle = false)
    {
        this.neko = neko;
        ChangeClass(neko.className);
        for (int i = 0; i < neko.traits.Length; i++)
        {
            if (listTraitNames.Contains(neko.traits[i].trait_type.name))
            {
                ChangeTraits(neko.traits[i].trait_type.name, Convert.ToInt32(neko.traits[i].id));
            }
        }
        if (!isBattle)
        {
            nekoView.Init(neko);
            nekoView.ResetBtnSkill(btnChangeSkill);
            InitButtonSkill(btnChangeSkill, neko);
            modelCanvas.AnimListSkill();
            modelCanvas.AnimNekoBar();
            txtLog.text = "";
        }
    }

    void InitTraitName()
    {
        listTraitNames = new[]
        {
            ModelConst.Body, ModelConst.Ear, ModelConst.Nose, ModelConst.Eye, ModelConst.Eyebrow, ModelConst.Medal,
            ModelConst.Necklaces, ModelConst.Necklaces, ModelConst.FrontFace, ModelConst.Arms, ModelConst.Accessories,
            ModelConst.Back, ModelConst.SideFace, ModelConst.Top
        };
    }
    public void InitButtonYourNeko(Button[] btnYourNeko)
    {
        for (int i = 0; i < btnYourNeko.Length; i++)
        {
            if (i < listNekoData.Count)
            {
                btnYourNeko[i].gameObject.SetActive(true);
                int index = i;
                Image img = btnYourNeko[index].transform.GetChild(1).GetChild(0).GetComponent<Image>();
                string url = DataConst.NEKO_IMAGE_URL + listNekoData[index].nft_id + DataConst.NEKO_IMAGE_PNG;
                GameUtilities.LoadImage(url, img, this);
                btnYourNeko[index].onClick.AddListener(() =>
                {
                    neko = listNekoData[index];
                    cacheIdNeko = index;
                    InitNekoData(neko);
                });
            }
            else
            {
                btnYourNeko[i].gameObject.SetActive(false);
            }
        }
    }
    public void InitButtonSkill(Button[] btnSkill, NekoData neko)
    {
        nekoView.ShowDesceptionSkill(btnSkill);
        for (int i = 0; i < btnSkill.Length; i++)
        {

            if (i < neko.skills.Length)
            {
                Button btn = btnSkill[i];
                btnSkill[i].gameObject.SetActive(true);

                NekoSkillData n = btnSkill[i].GetComponent<NekoSkillData>();
                n.NameSkill = neko.skills[i].name;
                n.IsLockSkill = false;

                SkillData s = skillsCache.Find(t => String.Compare(t.NameSkill, n.NameSkill, StringComparison.OrdinalIgnoreCase) == 0);
                n.Icon.sprite = s.Icon;

                btn.onClick.AddListener(() =>
                {
                    nekoView.SetDesceptionSkill(s.NameSkill, s.Desception);
                    n.StateSkill = StateSkill.SELECTED;
                    nekoView.SetDesceptionSkillActive(true);
                    nekoView.ChangeSkillState(btnSkill, s.NameSkill);
                    modelCanvas.AnimDesSkill();
                });
            }
            else
            {
                btnSkill[i].gameObject.SetActive(false);
            }
        }
    }
    public void InitButtonTraits(Button[] btnTraits, Button[] btnTraitsInfor)
    {
        for (int i = 0; i < btnTraits.Length; i++)
        {
            if (i < listTraitNames.Length)
            {
                string n = listTraitNames[i];
                Button btn = btnTraits[i];
                btn.GetComponentInChildren<TextMeshProUGUI>().text = n;
                btn.onClick.AddListener(() =>
                {
                    UpdateInforTraits(n, btnTraitsInfor);
                    btnTraits.ForEach(s => s.transform.GetChild(1).gameObject.SetActive(false));
                    btn.transform.GetChild(1).gameObject.SetActive(true);

                    int indexModel = Random.Range(0, Cache[n].Count);
                    ChangeTraits(n, indexModel);
                    btnTraitsInfor.ForEach(s => s.transform.GetChild(2).gameObject.SetActive(false));
                    btnTraitsInfor[indexModel].transform.GetChild(2).gameObject.SetActive(true);
                });
            }
            else
            {
                btnTraits[i].gameObject.SetActive(false);
            }
        }
    }
    public void InitButtonClass(Button[] btnClasses)
    {
        NekoClass[] l = (NekoClass[])Enum.GetValues(typeof(NekoClass));

        for (int i = 0; i < btnClasses.Length; i++)
        {
            if (i < l.Length && i != 0)
            {
                NekoClass c = l[i];
                Button btn = btnClasses[i];
                btn.GetComponentInChildren<TextMeshProUGUI>().text = c.ToString();
                Image img = btnClasses[i].GetComponentsInChildren<Image>()[1];
                img.sprite = classSpr.Find(s => String.Compare(s.name, c.ToString(), StringComparison.OrdinalIgnoreCase) == 0);

                btn.onClick.AddListener(() =>
                {
                    ChangeClass(c.ToString());
                    RandomInit();
                    btnClasses.ForEach(s => s.transform.GetChild(2).gameObject.SetActive(false));
                    btn.transform.GetChild(2).gameObject.SetActive(true);
                });
            }
            else
            {
                btnClasses[i].gameObject.SetActive(false);
            }
        }
    }
    public void UpdateInforTraits(string traitName, Button[] inforTraits)
    {
        for (int i = 0; i < inforTraits.Length; i++)
        {
            Button btn = inforTraits[i];

            if (i < Cache[traitName].Count)
            {
                List<TraitsDataModel> n = Cache[traitName];

                int indexModel = i;
                btn.GetComponentInChildren<TextMeshProUGUI>().text = n[i].name;
                btn.GetComponentsInChildren<Image>()[1].sprite = n[i].Icon;
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(() =>
                {
                    ChangeTraits(traitName, indexModel);
                    inforTraits.ForEach(s => s.transform.GetChild(2).gameObject.SetActive(false));
                    btn.transform.GetChild(2).gameObject.SetActive(true);
                });
                btn.gameObject.SetActive(true);
            }
            else
            {
                btn.gameObject.SetActive(false);
            }
        }
    }

    #region Log Model
    [ContextMenu("Context")]
    public void LogModel()
    {
        var sb = new StringBuilder();
        foreach (var item in Traits)
        {
            sb.Append(item.Value.name.Replace("(Clone)", "")).Append(",");
        }
        Debug.Log(sb.ToString());
    }
    #endregion

    #region Change model

    void RandomInit()
    {
        txtLog.text = "";
        foreach (var traitName in listTraitNames)
        {
            ChangeTraits(traitName);
        }
    }
    void ChangeTraits(string traitName, int indexNextModel = -1)
    {
        List<TraitsDataModel> modelRandom = Cache[traitName];
        if (indexNextModel == -1)
        {
            indexNextModel = Random.Range(0, modelRandom.Count);
            GameObject randomModel = Instantiate(modelRandom[indexNextModel].Model, transform);
            txtLog.text += traitName + " " + randomModel.name.Replace("(Clone)", "") + "\n";
            ChangeModel(randomModel);
            randomModel.layer = 6;
            ChangeModel(traitName, randomModel);
        }
        else
        {
            TraitsDataModel model = modelRandom.Find(s => s.Model.name == indexNextModel.ToString());
            GameObject randomModel = Instantiate(model.Model, transform);
            ChangeModel(randomModel);
            randomModel.layer = 6;
            ChangeModel(traitName, randomModel);
        }
    }


    private void ChangeModel(GameObject parent)
    {
        int childCount = parent.transform.childCount;
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

    public void ChangeClass(string newClass)
    {
        Cache.Clear();
        skillsCache.Clear();
        CacheFile(newClass);
        //RandomInit();
    }

    #endregion

    #region Load data
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
        ReadDataScripable(currentClass, ModelConst.Top);
        ReadDataScripableSkill(currentClass);
    }
    private void ReadDataScripable(string className, string pathName)
    {
        List<TraitsDataModel> listItem = Resources.LoadAll<TraitsDataModel>($"ModelData/{className}/{pathName}").ToList();
        Cache.Add(pathName, listItem);
    }
    private void ReadDataScripableSkill(string className)
    {
        skillsCache = Resources.LoadAll<SkillData>($"SkillData/{className}").ToList();
    }

    #endregion

    #region Modifier

    [ContextMenu("Create")]
    public void CreateAll()
    {
        var l = (NekoClass[])Enum.GetValues(typeof(NekoClass));
        foreach (var c in l)
        {
            InitScripableObjectFile(c, ModelConst.Body);
            InitScripableObjectFile(c, ModelConst.Ear);
            InitScripableObjectFile(c, ModelConst.Nose);
            InitScripableObjectFile(c, ModelConst.Eye);
            InitScripableObjectFile(c, ModelConst.Eyebrow);
            InitScripableObjectFile(c, ModelConst.Medal);
            InitScripableObjectFile(c, ModelConst.Necklaces);
            InitScripableObjectFile(c, ModelConst.FrontFace);
            InitScripableObjectFile(c, ModelConst.Arms);
            InitScripableObjectFile(c, ModelConst.Accessories);
            InitScripableObjectFile(c, ModelConst.Back);
            InitScripableObjectFile(c, ModelConst.SideFace);
        }
#if UNITY_EDITOR
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
#endif
    }


    public void InitScripableObjectFile(NekoClass className, string pathName)
    {
        var path = $"Model/{className}/{pathName}";
        var pathSave = $"Assets/Resources/ModelData/{className}/{pathName}";
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
            model.ClassName = className;
            model.Trait = pathName;
#if UNITY_EDITOR
            AssetDatabase.CreateAsset(model, pathSave + "/" + model.name + ".asset");
            EditorUtility.SetDirty(model);
#endif
        }
    }

    [ContextMenu("Load sprite")]
    public void LoadSprite()
    {
#if UNITY_EDITOR
        var pathModel = $"ModelData";
        var pathSpr = $"Texture/Traits";
        var models = Resources.LoadAll<TraitsDataModel>(pathModel).ToList();
        var spr = Resources.LoadAll<Sprite>(pathSpr).ToList();

        foreach (var ob in models)
        {
            ob.Icon = spr.Find(s => s.name == ob.name);

            EditorUtility.SetDirty(ob);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
#endif
    }
    #endregion
}