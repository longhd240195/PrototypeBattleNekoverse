using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataConst
{
    public const string YOUR_NEKO_SCENE = "Your_Neko";
    public const string MAP_SCENE = "Map";
    public const string BATTLE_SCENE = "Battle_Scene";
    public const string MAIN_SCENE = "Main";
    public const float MAX_ATK_BOSS = 200;
    public const float MAX_SPEED_BOSS = 200;
    public const float MAX_HP_BOSS = 200;
    public const float DEFAULT_100 = 100;

    public const int MAX_MANA_NEKO = 5;
    public const int MAX_DAME_NEKO = 300;
    public const int MAX_SPEED_NEKO = 300;
    public const int MAX_HP_NEKO = 300;
    public const int MAX_MAGIC_NEKO = 300;
    public const int MAX_DEF_NEKO = 300;
    public const int MAX_RESIST_NEKO = 300;

    public const int MAX_DAME_PET = 500;
    public const int MAX_SPEED_PET = 500;
    public const int MAX_HP_PET = 500;
    public const string NAME_FOLDER_AREA = "Area";

    //Connect
    public const string ID = "fea8dc14-cf13-4360-bb79-60d4bbfdc8de";
    public const string PUBLIC_KEY = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAlduwiCc1ByxBoQA7CPvPF0s5jrX6bJRHzo5oPpRqay4XISFSOY0JDLFL2UZZycAIa09sk6tC/4GUMJcAdwHL0VGX6R+x7sh2EZHv3GTLj0LChF+onFAzyW1W28MjDcZDRQrys1A/HJLecmmpZdW0Egw3ziD3duK6H8M3vxu6eT3jzMFfns5DBABPH7CxRPQxkmVEXQpooXkDILytWdtdkgDJnql4iVORk3bF5cUDWlW/XGd7mzfWEt/rMEvmwamHDu+YYE8V810+OjhdC05Hv0UZ1i6C5mTahuNf0vnxUBNV0cqo8+IvsnSPH+0KHgp3bUGCvODqCo3lTg76WRLtiQIDAQAB";
    public const string RESPONSE_URL = "nekoverse://login";
    public const string NEKOWALLET_URL = "nekowallet://sign";

    //Load image neko in url
    public const string NEKO_IMAGE_URL = "https://d1j8r0kxyu9tj8.cloudfront.net/neko/neko/origin/100x100/";
    public const string NEKO_IMAGE_PNG = ".png";
}
public class DataLogin
{
    public string id;
    public string data;
    public string responseUrl;
}
public class DataSign
{
    public string message;
}
public class NekoData
{
    public string id;
    public string mint_address;
    public string nft_id;
    public string name;
    public string className;
    public MetaDataNeko metadata;
    public int level;
    public int experience;
    public TraitsData[] traits;
    public SkillNekoData[] skills;
}
public class MetaDataNeko
{
    public int atk;
    public int m_atk;
    public int def;
    public int m_def;
    public int speed;
    public int health;
    public int mana;
}
public class SkillNekoData
{
    public string id;
    public string name;
    public MetaDataSkill metadata;
}
public class MetaDataSkill
{
    public string function;
    public int atk;
    public int def;
    public int speed;
    public int mana;
}
public class TraitsNeko
{
    public TraitsData body;
}
public class TraitsData
{
    public string id;
    public string name;
    public TraitsType trait_type;
}
public class TraitsType
{
    public string id;
    public string name;
    public string description;
}
