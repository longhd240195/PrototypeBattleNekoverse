using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelFiller : MonoBehaviour
{
	[SerializeField] private Transform[] arms;
	[SerializeField] private Transform[] ears;
	[SerializeField] private Transform[] backs;
	[SerializeField] private AccessoryData[] accessories;

	[SerializeField] private BodyFiller body;

	Dictionary<string, GameObject> traits;

	private void Start()
	{
		traits = new Dictionary<string, GameObject>() {
			{ ModelConst.Body, null },
			{ ModelConst.Ear, null },
			{ ModelConst.Nose, null },
			{ ModelConst.Eye, null },
			{ ModelConst.Eyebrow, null },
			{ ModelConst.Medal,null },
			{ ModelConst.Necklaces,null },
			{ ModelConst.FrontFace, null },
			{ ModelConst.Arms,null },
			{ "LF",null },
			{ "RF",null },
			{ "LH",null },
			{ "RH",null },
			{ ModelConst.Back,null },
			{ ModelConst.SideFace,null },
		};
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.A)) {
			ChangeModel(0);
			ChangeModel(1);
			ChangeModel(2);
			ChangeModel(3);
		}
	}

	public void ChangeModel(int index)
	{
		var r = 3;// Random.Range(0, 3);
		Transform newObj;
		switch (index)
		{
			case 0:
				newObj = CreateInstance(arms);
				RemoveTrait(ModelConst.Arms, newObj);
				body.ChangeHand(newObj);
				break;
			case 1:
				newObj = CreateInstance(ears);
				RemoveTrait(ModelConst.Ear, newObj);
				body.ChangeEar(newObj);
				break;
			case 2:
				newObj = CreateInstance(backs);
				RemoveTrait(ModelConst.Back, newObj);
				body.ChangeBack(newObj);
				break;
			case 3:
				var acc = accessories[Random.Range(0, accessories.Length)];

				newObj = CreateInstance(acc.LF);
				RemoveTrait("LF", newObj);
				body.ChangeLeftFoot(newObj);

				newObj = CreateInstance(acc.RF);
				RemoveTrait("RF", newObj);
				body.ChangeRightFoot(newObj);

				newObj = CreateInstance(acc.LH);
				RemoveTrait("LH", newObj);
				body.ChangeLeftHand(newObj);

				newObj = CreateInstance(acc.RH);
				RemoveTrait("RH", newObj);
				body.ChangeRightHand(newObj);
				break;
		}
	}

	public void RemoveTrait(string trait, Transform newObject)
	{
		if(traits[trait] != null)
			Destroy(traits[trait].gameObject);

		if(newObject)
			traits[trait] = newObject.gameObject;
	}

	private Transform CreateInstance(Transform[] list)
	{
		return Instantiate(list[Random.Range(0,list.Length)]);
	}

	private Transform CreateInstance(Transform newObj)
	{
		if (newObj)
			return Instantiate(newObj);
		else return null;
	}
}

[System.Serializable]
public class AccessoryData
{
	public Transform LH;
	public Transform LF;
	public Transform RH;
	public Transform RF;
}