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

public class ModelControllerTest : MonoBehaviour
{
    [SerializeField] private NekoView nekoView;
    [SerializeField] private List<Sprite> classSpr;
    [SerializeField] private Button[] btnChangeSkill;
    private List<Sprite> nekoImageSpr;
    public List<Texture> listTextureNeko = new List<Texture>();
    private string[] listTraitNames;
    private Dictionary<string, List<TraitsDataModel>> traitsCache;


    private List<SkillData> skillsCache;


    private Dictionary<string, GameObject> traits;
    private Dictionary<string, GameObject> Traits => traits ?? (traits = new Dictionary<string, GameObject>());
    private Dictionary<string, List<TraitsDataModel>> Cache =>
        traitsCache ?? (traitsCache = new Dictionary<string, List<TraitsDataModel>>());
    private List<Neko> listNeko;
    private Neko neko;
    private int cacheIdNeko = 0;
    private void Awake()
    {
        InitTraitName();
        CacheFile();
        LoadSpriteImageNeko();
    }

    public void Start()
    {
        listNeko = DataTest.GetNeko();
        neko = listNeko[cacheIdNeko];
        InitNeko(neko);
    }
#if UNITY_EDITOR
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //RandomInit();
            ChangeClass(NekoClass.Fire);
            //InitNeko(neko);
        }
    }
#endif
    public void ChangeModel(int i)
    {
        int index = cacheIdNeko + i;
        if (cacheIdNeko == 0 && i < 0)
            return;
        if (index < listNeko.Count)
        {
            InitNeko(listNeko[index]);
            cacheIdNeko = index;
        }
        else
        {
            return;
        }

    }

    public void InitNeko(Neko neko)
    {
        ChangeClass(neko.NekoClass);
        foreach (KeyValuePair<string, int> kvp in neko.traitsNeko)
        {
            ChangeTraits(kvp.Key, kvp.Value);
        }
        nekoView.Init(neko);
        nekoView.ResetBtnSkill(btnChangeSkill);
        InitButtonSkill(btnChangeSkill, neko);
    }
    void InitTraitName()
    {
        listTraitNames = new[]
        {
            ModelConst.Body, ModelConst.Ear, ModelConst.Nose, ModelConst.Eye, ModelConst.Eyebrow, ModelConst.Medal,
            ModelConst.Necklaces, ModelConst.FrontFace, ModelConst.Arms, ModelConst.Accessories,
            ModelConst.Back, ModelConst.SideFace
        };
    }

    public void InitButtonYourNeko(Button[] btnYourNeko)
    {
        for (int i = 0; i < btnYourNeko.Length; i++)
        {
            if (i < listNeko.Count && listNeko.Count == listTextureNeko.Count)
            {
                btnYourNeko[i].gameObject.SetActive(true);
                int index = i;
                var img = btnYourNeko[index].transform.GetChild(0).GetChild(0).GetComponent<RawImage>();
                img.texture = listTextureNeko[index];
                btnYourNeko[index].onClick.AddListener(() =>
                {
                    neko = listNeko[index];
                    cacheIdNeko = index;
                    InitNeko(neko);
                });
            }
            else
            {
                btnYourNeko[i].gameObject.SetActive(false);
            }
        }
    }

    public void InitButtonSkill(Button[] btnSkill, Neko neko)
    {
        nekoView.ShowDesceptionSkill(btnSkill);
        for (int i = 0; i < btnSkill.Length; i++)
        {

            if (i < neko.NekoSkill.Count)
            {
                var btn = btnSkill[i];
                btnSkill[i].gameObject.SetActive(true);

                NekoSkill n = btnSkill[i].GetComponent<NekoSkill>();
                n.NameSkill = neko.NekoSkill[i].NameSkill;
                n.IsLockSkill = neko.NekoSkill[i].IsLockSkill;

                var s = skillsCache.Find(s => String.Compare(s.NameSkill, n.NameSkill.ToString(), StringComparison.OrdinalIgnoreCase) == 0);
                n.Icon.sprite = s.Icon;

                btn.onClick.AddListener(() =>
                {
                    nekoView.SetDesceptionSkill(s.NameSkill, s.Desception);
                    n.StateSkill = StateSkill.SELECTED;
                    nekoView.SetDesceptionSkillActive(true);
                    nekoView.ChangeSkillState(btnSkill, s.NameSkill);
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
                var n = listTraitNames[i];
                var btn = btnTraits[i];
                btn.GetComponentInChildren<TextMeshProUGUI>().text = n;
                btn.onClick.AddListener(() =>
                {
                    UpdateInforTraits(n, btnTraitsInfor);
                    btnTraits.ForEach(s => s.transform.GetChild(1).gameObject.SetActive(false));
                    btn.transform.GetChild(1).gameObject.SetActive(true);

                    var indexModel = Random.Range(0, Cache[n].Count);
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
        var l = (NekoClass[])Enum.GetValues(typeof(NekoClass));

        for (int i = 0; i < btnClasses.Length; i++)
        {
            if (i < l.Length && i != 0)
            {
                var c = l[i];
                var btn = btnClasses[i];
                btn.GetComponentInChildren<TextMeshProUGUI>().text = c.ToString();
                var img = btnClasses[i].GetComponentsInChildren<Image>()[1];
                img.sprite = classSpr.Find(s => String.Compare(s.name, c.ToString(), StringComparison.OrdinalIgnoreCase) == 0);

                btn.onClick.AddListener(() =>
                {
                    ChangeClass(c);
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

    #region Change model

    void RandomInit()
    {
        foreach (var traitName in listTraitNames)
        {
            ChangeTraits(traitName);
        }
    }

    public void UpdateInforTraits(string traitName, Button[] inforTraits)
    {
        for (int i = 0; i < inforTraits.Length; i++)
        {
            var btn = inforTraits[i];

            if (i < Cache[traitName].Count)
            {
                var n = Cache[traitName];

                var indexModel = i;
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

    public void ChangeClass(NekoClass newClass)
    {
        Cache.Clear();
        skillsCache.Clear();
        CacheFile(newClass.ToString());
        RandomInit();
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

        ReadDataScripableSkill(currentClass);
    }



    private void ReadDataScripable(string className, string pathName)
    {
        var listItem = Resources.LoadAll<TraitsDataModel>($"ModelData/{className}/{pathName}").ToList();
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

    public void LoadSpriteImageNeko()
    {
        var pathSpr = $"Texture/Image";
        List<Sprite> spr = Resources.LoadAll<Sprite>(pathSpr).ToList();
        nekoImageSpr = spr;
    }
    #endregion
}
