using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class StringToModel : MonoBehaviour
{
	[SerializeField] private string modelString;

	private List<TraitsDataModel> allTraits;

	[ContextMenu("Change Model")]
	private void LoadModel()
	{
		var itemCount = modelString.Split(',');
		foreach (var item in itemCount)
		{
			Instantiate(allTraits.Find(s => s.name == item).Model,transform);
		}
	}

	[ContextMenu("Test count")]
	private void LoadAllModelData()
	{
		if(allTraits == null || allTraits.Count <= 0)
		{
			allTraits = Resources.LoadAll<TraitsDataModel>("ModelData").ToList();
			Debug.Log(allTraits.Count);
		}else
		{
			Debug.Log("Nah");
		}
	}

}
