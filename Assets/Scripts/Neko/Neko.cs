using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neko
{
    public string NekoName;
    public NekoClass NekoClass;
    public List<NekoSkill> NekoSkill;
    public Dictionary<string, int> traitsNeko = new Dictionary<string, int>();
    public string NameImage;
    public int Atk;
    public int Speed;
    public int HP;
}
