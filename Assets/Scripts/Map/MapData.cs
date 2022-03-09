using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Level data", order = 1)]
public class MapData : ScriptableObject
{
    [SerializeField] string mapName;
    [SerializeField] List<LevelData> dataLevel;

    public List<LevelData> DataLevel { get => dataLevel; set => dataLevel = value; }
    public string MapName { get => mapName; set => mapName = value; }
}

[Serializable]
public class LevelData
{
    [SerializeField] string levelName;
    [SerializeField] string levelDesception;
    [SerializeField] Sprite icon;
    [SerializeField] float hp;
    [SerializeField] float atk;
    [SerializeField] float def;
    public string LevelName { get => levelName; set => levelName = value; }
    public string LevelDesception { get => levelDesception; set => levelDesception = value; }
    public Sprite Icon { get => icon; set => icon = value; }
    public float Hp { get => hp; set => hp = value; }
    public float Atk { get => atk; set => atk = value; }
    public float Def { get => def; set => def = value; }
}
