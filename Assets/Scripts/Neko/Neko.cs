using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neko
{
    public string NekoName;
    public NekoClass NekoClass;
    public List<NekoSkill> NekoSkill;
    public Dictionary<string, int> traitsNeko = new Dictionary<string, int>();
    public int Level;
    public string UrlImage;
    public float Atk;
    public float Speed;
    public float HP;
    public float Magic;
    public float Resist;
    public float def;
}
