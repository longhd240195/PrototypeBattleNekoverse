using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyFiller : MonoBehaviour
{
	[SerializeField] private Transform L_Eye;
	[SerializeField] private Transform R_Eye;
	[SerializeField] private Transform ear;
	[SerializeField] private Transform arm;
	[SerializeField] private Transform eyebrow;
	[SerializeField] private Transform back;
	[SerializeField] private Transform front_face;

	[SerializeField] private Transform necklaces;
	[SerializeField] private Transform medal;
	[SerializeField] private Transform nose;
	[SerializeField] private Transform side_face;
	[SerializeField] private Transform top;

	[Header("Chi")]
	[SerializeField] private Transform L_Foot;
	[SerializeField] private Transform L_Hand;
	[SerializeField] private Transform R_Hand;
	[SerializeField] private Transform R_Foot;

	private void Reset()
	{
		
		var hip = transform.GetChild(0);

		R_Eye = hip.Find("R_Eye");
		L_Eye = hip.Find("L_Eye");
		ear = hip.Find("Ear_Root");
		eyebrow = hip.Find("Eyebrow");
		arm = hip.Find("Arm");
		back = hip.Find("Back_Root");
		front_face = hip.Find("Front_Face");
		necklaces = hip.Find("Necklaces");
		medal = hip.Find("Medal");
		nose = hip.Find("Nose");
		side_face = hip.Find("Side_Face");
		top = hip.Find("Top");

		L_Foot = hip.Find("L_Foot");
		L_Hand = hip.Find("L_Hand");
		R_Hand = hip.Find("R_Hand");
		R_Foot = hip.Find("R_Foot");
	}

	public void ChangeHand(Transform newPart)
	{
		ChangeModel(newPart, arm);
	}

	public void ChangeEar(Transform newPart)
	{
		ChangeModel(newPart, ear);

	}

	public void ChangeBack(Transform newPart)
	{
		ChangeModel(newPart, back);
	}

	public void ChangeLeftFoot(Transform newPart)
	{
		ChangeModel(newPart, L_Foot);
	}
	public void ChangeRightFoot(Transform newPart)
	{
		ChangeModel(newPart, R_Foot);
	}
	public void ChangeLeftHand(Transform newPart)
	{
		ChangeModel(newPart, L_Hand);
	}
	public void ChangeRightHand(Transform newPart)
	{
		ChangeModel(newPart, R_Hand);
	}


	public void ChangeModel(Transform newPart, Transform parent)
	{
		if (!newPart)
			return;

		newPart.SetParent(parent);
		newPart.localPosition = Vector3.zero;
		newPart.localRotation = Quaternion.identity;
	}
}
