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
    public string id { get; set; }
    public string mint_address { get; set; }
    public string nft_id { get; set; }
    public string name { get; set; }
    public string className { get; set; }
    public MetaDataNeko metadata { get; set; }
    public int level { get; set; }
    public int experience { get; set; }
    public TraitsData[] traits { get; set; }
    public SkillNekoData[] skills { get; set; }
}
public class MetaDataNeko
{
    public int atk { get; set; }
    public int m_atk { get; set; }
    public int def { get; set; }
    public int m_def { get; set; }
    public int speed { get; set; }
    public int health { get; set; }
    public int mana { get; set; }
}
public class SkillNekoData
{
    public string id { get; set; }
    public string name { get; set; }
    public MetaDataSkill metadata { get; set; }
}
public class MetaDataSkill
{
    public string function { get; set; }
    public int atk { get; set; }
    public int def { get; set; }
    public int speed { get; set; }
    public int mana { get; set; }
}
public class TraitsData
{
    public string id { get; set; }
    public string name { get; set; }
    public TraitsType trait_type { get; set; }
}

public class TraitsType
{
    public string id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
}

//map
public class MetaDataBackground
{
    public string background { get; set; }
}

public class DataArea
{
    public string id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int area_type { get; set; }
    public MetaDataBackground metadata { get; set; }
    public string created_at { get; set; }
    public string updated_at { get; set; }
    public object deleted_at { get; set; }
    public int max_map_level { get; set; }
}
public class DataAreaLevel
{
    public string id { get; set; }
    public int level { get; set; }
    public MetaDataBackground metadata { get; set; }
    public string created_at { get; set; }
    public string updated_at { get; set; }
    public object deleted_at { get; set; }
    public string area_id { get; set; }
    public DataEnemy[] enemies { get; set; }
}
public class DataEnemy
{
    public string id { get; set; }
    public string name { get; set; }
    public int element_id { get; set; }
    public int class_id { get; set; }
    public MetaDataEnemies metadata { get; set; }
    public string strategy { get; set; }
    public string map_level_id { get; set; }
    public string created_at { get; set; }
    public string updated_at { get; set; }
    public string deleted_at { get; set; }
}
public class MetaDataEnemies
{
    public int atk { get; set; }
    public int def { get; set; }
    public int speed { get; set; }
    public int health { get; set; }
}

