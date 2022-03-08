using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Level data", order = 1)]
public class MapData : ScriptableObject
{
	[SerializeField] List<LevelData> dataLevel;

	public List<LevelData> DataLevel { get => dataLevel; set => dataLevel = value; }
}

[Serializable]
public class LevelData
{
	[SerializeField] float hp;
	[SerializeField] float atk;
	[SerializeField] float def;

	public float Hp { get => hp; set => hp = value; }
	public float Atk { get => atk; set => atk = value; }
	public float Def { get => def; set => def = value; }
}
