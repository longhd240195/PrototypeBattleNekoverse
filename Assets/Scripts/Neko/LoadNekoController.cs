using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNekoController : MonoBehaviour
{
    [SerializeField] private ModelControllerTest modelController;
    [SerializeField] private List<GameObject> listObjNeko;
    private List<Neko> listNeko;
    void Start()
    {
        listNeko = DataTest.GetNeko();
        for (int i = 0; i < listObjNeko.Count; i++)
        {
            if (i < listNeko.Count)
            {
                int index = i;
                listObjNeko[i].SetActive(true);
                var loadNeko = listObjNeko[index].GetComponent<LoadNeko>();
                var texture = listObjNeko[index].GetComponent<LoadNeko>().cam.targetTexture;
                loadNeko.neko = listNeko[index];
                loadNeko.Init();
                modelController.listTextureNeko.Add(texture);
            }
            else
            {
                listObjNeko[i].SetActive(false);
            }
        }
    }
}
