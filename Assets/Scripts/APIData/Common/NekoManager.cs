using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colyseus;
using Colyseus.Schema;
using System;
using UnityEngine.Networking;
using System.IO;
using System.Linq;

public partial class NekoManager : ColyseusManager<NekoManager>
{
    private ColyseusClient client;

    private ColyseusRoom<PvERoomState> room;

    private readonly static string DEFAULT_PvE_ROOM_ID = "pve_room";
    private readonly static string DEFAULT_API_ADDRESS = "http://54.169.40.19:8000";

    private readonly static string API_AREA = "/v1/pve/areas/";
    private readonly static string API_LOGIN = "/v1/login/";
    private readonly static string API_MAP_LEVELS = "/v1/pve/map-levels/";  // can add ID to this API in order to get a specific map level, else return all map levels
    private readonly static string API_PROFILE = "/v1/my/profile/";
    private readonly static string API_CURRENT_LEVEL = "/v1/my/pve/current-level/";
    private readonly static string API_USER_NEKOS = "/v1/my/nekos/";
    private readonly static string API_CONSUMPTION_ITEMS = "/v1/my/consumption-items/";
    private readonly static string API_EXCLUSIVE_ITEMS = "/v1/my/exclusive-items/";
    private readonly static string API_NEKOS_INFO = "/v1/nekos/";  // this api always require neko's ID
    private readonly static string API_NEKOS_SKILL_TO_ADD = "/skills";  // append this api to API_NEKOS_INFO in order to get skill info
    private readonly static string API_USERS = "/v1/users/";  // can add ID to this API in order to get a specific user, else return all users

    public delegate void OnReadyMsgReturn(ReadyRespondMessages msg);
    public delegate void OnStartRoundMsgReturn(StartRoundRespondMessage msg);
    public delegate void OnCalculateQueueMsgReturn(CalculateQueueRespondMessage msg);
    public delegate void OnResultMsgReturn(ResultRespondMessage msg);
    public delegate void OnEndTurnMsgReturn(EndTurnRespondMessage msg);
    public delegate void OnEndRoundMsgReturn(EndRoundRespondMessage msg);
    public delegate void OnEndGameMsgReturn(EndGameRespondMessage msg);


    public static event OnReadyMsgReturn onReadyMsgReturn;
    public static event OnStartRoundMsgReturn onStartRoundMsgReturn;
    public static event OnCalculateQueueMsgReturn onCalculateQueueMsgReturn;
    public static event OnResultMsgReturn onResultMsgReturn;
    public static event OnEndTurnMsgReturn onEndTurnMsgReturn;
    public static event OnEndRoundMsgReturn onEndRoundMsgReturn;
    public static event OnEndGameMsgReturn onEndGameMsgReturn;

    public AreaResponse areaResponse = new AreaResponse();
    public CurrentUserProfileResponse currentUserProfileResponse = new CurrentUserProfileResponse();
    public LoginResponse loginResponse = new LoginResponse();
    public MapLevelResponse mapLevelResponse = new MapLevelResponse();
    public MapLevelIdResponse mapLevelIdResponse = new MapLevelIdResponse();
    public CurrentLevelResponse currLevelResponse = new CurrentLevelResponse();
    public UserNekosResponse userNekoResponse = new UserNekosResponse();
    public ConsumptionItemsResponse consumptionItemsResponse = new ConsumptionItemsResponse();
    public ExclusiveItemsResponse exclusiveItemsResponse = new ExclusiveItemsResponse();
    public NekoResponse nekoResponse = new NekoResponse();
    public NekoSkillResponse nekoSkillResponse = new NekoSkillResponse();
    public AllUsersResponse allUsersResponse = new AllUsersResponse();
    public UserProfileResponse userProfileResponse = new UserProfileResponse();

    public string signKey = "QkkqwQFXLgPP0zkeVS2ONYdXDkI16ynrG+VdJGipuY1ocE0Ypp9U49AhyJKtnimbnXHglPDlSFuymYA1AX1hBQ==";
    public string walletAddress = "D5sGL6rCYzWKfZj6eP4SwyV8xQ2PozLY5J76ovnwVw4y";

    
    //protected override void Awake()
    //{
    //    InitClient();
    //}

    public void LogIn()
    {
        var d = new Dictionary<string, string>();
        d.Add("signature", signKey);
        d.Add("wallet_address", walletAddress);

        Post(API_LOGIN, d, return_value =>
        {
            loginResponse = JsonUtility.FromJson<LoginResponse>(return_value);
            Debug.Log("Logged in");
        });
    }

    public void GetDataAPI()
    {

        GetData(API_USER_NEKOS);
        GetData(API_AREA);
        GetData(API_MAP_LEVELS);
    }

    public UserNekosResponse GetUserNekoResponse() { return userNekoResponse; }

    public void GetData(string API, string id = "", bool getSkill = false) // check API string to see if an API require ID
    {
        string current_api = API + id;
        switch (API){
            case "/v1/pve/areas/": // API_AREA
                Get(current_api, return_value => {
                    areaResponse = JsonUtility.FromJson<AreaResponse>(return_value);
                    //Debug.Log(areaResponse.data[0].max_map_level);
                    DataApi.GetInstance().SetAreaResponse(areaResponse);
                });
                break;

            case "/v1/pve/map-levels/": // API_MAP_LEVELS
                if (id.Equals("") == false) // with ID
                {
                    Get(current_api, return_value => {
                        mapLevelIdResponse = JsonUtility.FromJson<MapLevelIdResponse>(return_value);
                        //Debug.Log(mapLevelIdResponse.data.enemies[0].metadata.atk);
                        Debug.Log(mapLevelIdResponse.data.id);
                    },
                    loginResponse.data.access_token);
                }
                else // without ID
                {
                    Get(current_api, return_value => {
                        mapLevelResponse = JsonUtility.FromJson<MapLevelResponse>(return_value);
                        DataApi.GetInstance().SetMapLevelResponse(mapLevelResponse);
                        
                    },
                    loginResponse.data.access_token);
                }
                break;

            case "/v1/my/profile/": // API_PROFILE
                Get(current_api, return_value => {
                    currentUserProfileResponse = JsonUtility.FromJson<CurrentUserProfileResponse>(return_value);
                    //Debug.Log(currentUserProfileResponse.data.id);
                },
                loginResponse.data.access_token);
                break;

            case "/v1/my/pve/current-level/": // API_CURRENT_LEVEL
                Get(current_api, return_value => {
                    currLevelResponse = JsonUtility.FromJson<CurrentLevelResponse>(return_value);
                    //Debug.Log(currLevelResponse.data[0].level);
                    DataApi.GetInstance().SetCurrentLevelResponse(currLevelResponse);
                },
                loginResponse.data.access_token);
                break;

            case "/v1/my/nekos/": // API_USER_NEKOS
                Get(current_api, return_value => {
                    userNekoResponse = JsonUtility.FromJson<UserNekosResponse>(return_value);
                    //Debug.Log(userNekoResponse.data[1].name);
                    DataApi.GetInstance().SetUserNekoResponse(userNekoResponse);
                },
                loginResponse.data.access_token);
                break;
                
            case "/v1/my/consumption-items/": // API_CONSUMPTION_ITEMS
                Get(current_api, return_value => {
                    consumptionItemsResponse = JsonUtility.FromJson<ConsumptionItemsResponse>(return_value);
                    //Debug.Log(consumptionItemsResponse.data[1].metadata.damage);
                },
                loginResponse.data.access_token);
                break;

            case "/v1/my/exclusive-items/": // API_EXCLUSIVE_ITEMS
                Get(current_api, return_value => {
                    exclusiveItemsResponse = JsonUtility.FromJson<ExclusiveItemsResponse>(return_value);
                    //Debug.Log(exclusiveItemsResponse.data[2].exclusive_item_type_id);
                },
                loginResponse.data.access_token);
                break;

            case "/v1/nekos/": // API_NEKOS_INFO, this api always require ID
                if (getSkill == false)
                {
                    Get(current_api, return_value => {
                        nekoResponse = JsonUtility.FromJson<NekoResponse>(return_value);
                        //Debug.Log(nekoResponse.data.traits[3].trait_type.id);
                        DataApi.GetInstance().SetNekoResponse(nekoResponse);
                    });
                }
                else
                {
                    current_api += API_NEKOS_SKILL_TO_ADD; // add api to get skill of a specific neko
                    Get(current_api, return_value => {
                        nekoSkillResponse = JsonUtility.FromJson<NekoSkillResponse>(return_value);
                        //Debug.Log(nekoSkillResponse.data.skills[0].metadata.mana);
                        DataApi.GetInstance().SetNekoSkillResponse(nekoSkillResponse);
                    });
                }
                break;

            case "/v1/users/": // API_USERS
                if (id.Equals("") == false)
                {
                    Get(current_api, return_value => {
                        userProfileResponse = JsonUtility.FromJson<UserProfileResponse>(return_value);
                        //Debug.Log(userProfileResponse.user.address);
                    },
                    loginResponse.data.access_token);
                }
                else
                {
                    Get(current_api, return_value => {
                        allUsersResponse = JsonUtility.FromJson<AllUsersResponse>(return_value);
                        //Debug.Log(allUsersResponse.users[0].address);
                    },
                    loginResponse.data.access_token);
                }
                break;
        }
    }

    public void Get(string API, Action<string> callback = null, string authorization_token = "")
    {
        StartCoroutine(GetRequest(API, return_value => {
            callback.Invoke(return_value);
        },
        authorization_token
        ));
    }

    IEnumerator GetRequest(string API, Action<string> callback = null, string authorization_token = "")
    {
        UnityWebRequest getRequest = UnityWebRequest.Get(DEFAULT_API_ADDRESS + API);
        getRequest.SetRequestHeader("accept", "application/json");

        if (authorization_token.Equals("") == false)
        {
            getRequest.SetRequestHeader("Authorization", "Bearer " + authorization_token);
        }

        yield return getRequest.SendWebRequest();

        if (getRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(getRequest.error);
        }
        else
        {
            Debug.Log(getRequest.downloadHandler.text);

            if (callback != null)
                callback.Invoke(getRequest.downloadHandler.text);
        }


    }
    public void Post(string API, Dictionary<string, string> data, Action<string> callback = null, string authorization_token = "")
    {
        StartCoroutine(PostRequest(API, data, return_value => {
            callback.Invoke(return_value);
        },
        authorization_token
        ));
    }

    IEnumerator PostRequest(string API, Dictionary<string,string> data, Action<string> callback = null, string authorization_token = "")
    {
        UnityWebRequest postRequest = UnityWebRequest.Post(DEFAULT_API_ADDRESS + API, data);

        postRequest.SetRequestHeader("accept", "application/json");

        if (authorization_token.Equals("") == false)
        {
            postRequest.SetRequestHeader("Authorization", "Bearer " + authorization_token);
        }

        yield return postRequest.SendWebRequest();

        if (postRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(postRequest.error);
        }
        else
        {
            Debug.Log(postRequest.downloadHandler.text);

            if (callback != null)
                callback.Invoke(postRequest.downloadHandler.text);
        }
    }

    // Initialize colyseus client
    void InitClient()
    {
        client = new ColyseusClient("ws://" + _colyseusSettings.colyseusServerAddress + ":" + _colyseusSettings.colyseusServerPort);
    }

    public void JoinPvERoom()
    {
        JoinExistingRoom(DEFAULT_PvE_ROOM_ID, true);
    }

    private async void JoinExistingRoom(string roomID, bool isNewJoin)
    {
        room = await client.JoinOrCreate<PvERoomState>(roomID/* , Dictionary of options */);
        Debug.Log("joined successfully");

        room.OnStateChange += (state, isFirstState) =>
        {
            if (isFirstState)
            {
                Debug.Log("this is the first room state!");
            }

            Debug.Log("the room state has been updated");

            Debug.Log("Game status: " + state.phase);
            //state.enemies.ForEach((key, value) => { Debug.Log(key + JsonUtility.ToJson(value)); });
            //Debug.Log(state.enemies[1]);

        };

        MessagesReceiveHandler();
    }

    public void MessagesReceiveHandler()
    {
        #region Battle Scene
        room.OnMessage<ReadyRespondMessages>("Ready", (message) => {
            //Debug.Log("message received from server: Ready");
            onReadyMsgReturn?.Invoke(message);

            Debug.Log("Ready:" + JsonUtility.ToJson(message));

            //signal ready event
            //CustomEventSystem.GetInstance().BattleDataReady();
        });

        room.OnMessage<StartRoundRespondMessage>("StartRound", message => {
            //Debug.Log("message received from server: StartRound");
            Debug.Log("Start round:" + JsonUtility.ToJson(message));

            onStartRoundMsgReturn?.Invoke(message);
        });

        room.OnMessage<CalculateQueueRespondMessage>("CalculateQueue", (message) => {
            //Debug.Log("message received from server: CalculateQueue");
            Debug.Log("Calculate queue:" + JsonUtility.ToJson(message));

            onCalculateQueueMsgReturn?.Invoke(message);

            //signal queue event
            //CustomEventSystem.GetInstance().BattleQueueReady();
        });

        room.OnMessage<ResultRespondMessage>("Result", (message) => {
            //Debug.Log("message received from server: Result");
            Debug.Log("Result:" + JsonUtility.ToJson(message));

            onResultMsgReturn?.Invoke(message);

            //signal result received event
            //CustomEventSystem.GetInstance().TurnResultReceived();
        });

        room.OnMessage<EndTurnRespondMessage>("EndTurn", (message) => {
            //Debug.Log("message received from server: EndTurn");
            Debug.Log("End turn:" + JsonUtility.ToJson(message));

            onEndTurnMsgReturn?.Invoke(message);

            //signal end turn event
            //CustomEventSystem.GetInstance().EndTurnSignalReceived();
        });

        room.OnMessage<EndRoundRespondMessage>("EndRound", (message) =>
        {
            //Debug.Log("message received from server: EndRound");
            Debug.Log("End round:" + JsonUtility.ToJson(message));

            onEndRoundMsgReturn?.Invoke(message);

            //signal end round event
            //CustomEventSystem.GetInstance().EndRoundSignalReceived();
        });

        room.OnMessage<EndGameRespondMessage>("EndGame", (message) =>
        {
            //Debug.Log("message received from server: EndGame");
            Debug.Log("End game:" + JsonUtility.ToJson(message));

            onEndGameMsgReturn?.Invoke(message);

            //signal end game event
            //CustomEventSystem.GetInstance().EndGameSignal();
        });
        #endregion
    }

    public new async void SendMessage(string action, object msg = null)
    {
        if (msg == null)
        {
            await room.Send(action);
        }
        else
        {
            await room.Send(action, msg);
        }
    }

    public string AppendAPI(string api, params string[] parameterAdd)
    {
        var result = api;
       
        if (parameterAdd.Length > 0)
            result += $"?{parameterAdd[0]}";
       
        for(int i = 1; i < parameterAdd.Length;i++)
            result += $"&{parameterAdd[i]}";


        return result;
    }
}

// classes to specify Send and Receive data
#region Battle Scene info (Colyseus framework)
[Serializable]
public class Data
{

}

[Serializable]
public enum ActionType
{
    Skill = 0,
    Item = 1,
    None = 2
}

// Receive messages

#region Ready Respond
public class ReadyRespondMessages
{
    public string type;
    public bool status;
    public long timestamp;
    public RoomData data;
}

[Serializable]
public class RoomData
{
    public RoomConsumptionItems[] roomConsumptionItems;
    public RoomEnemy[] roomEnemies;
    public RoomNeko[] roomNekos;
}

[Serializable]
public class RoomConsumptionItems
{

}

[Serializable]
public class RoomEnemy
{
    public string id;
    public string map_level_id;
    public string name;
    public int element_id;
    public int class_id;
    public string strategy;
    public SkillInGame[] skills;
    public CharacterStat metadata;
}

[Serializable]
public class RoomNeko
{
    public string id;
    public string mint_address;
    public string name;
    public SkillInGame[] skills;
    public CharacterStat metadata;
}

[Serializable]
public class CharacterStat
{
    public int atk;
    public int def;
    public int health;
    public int speed;
    public int mana;
}

[Serializable]
public class SkillInGame
{

}
#endregion

#region Start Round Respond
public class StartRoundRespondMessage
{
    public string type;
    public bool status;
    public long timestamp;
    public Data data;
}

#endregion

#region Calculate Queue Respond

public class CalculateQueueRespondMessage
{
    public string type;
    public bool status;
    public long timestamp;
    public Queue data;
}

[Serializable]
public class Queue
{
    public int index;
    public Turn[] turns;
}

[Serializable]
public class Turn
{
    public int type;
    public string id;
}
#endregion

#region Result Respond

public class ResultRespondMessage
{
    public string type;
    public bool status;
    public long timestamp;
    public Result data;
}

[Serializable]
public class Result
{
    public Action action;
    public Effect effect;
}

[Serializable]
public class Action
{
    public ActionType actionType;
    public string actionId;
    public Data metadata;
}

[Serializable]
public class Effect
{
    public EffectOnEntity[] nekos;
    public EffectOnEntity[] enemies;
}

[Serializable]
public class EffectOnEntity
{
    public string id;
    public int health;
    public int atk;
    public int def;
    public int mana;
}

#endregion

#region End Turn Respond
public class EndTurnRespondMessage
{
    public string type;
    public bool status;
    public long timestamp;
    public Data data;
}

#endregion

#region End Round Respond

public class EndRoundRespondMessage
{
    public string type;
    public bool status;
    public long timestamp;
    public Data data;
}

#endregion

#region End Game Respond

public class EndGameRespondMessage
{
    public string type;
    public bool status;
    public long timestamp;
    public Data data;
}

#endregion

// Send messages

#region Send Messages
[Serializable]
public class ActionToSend
{
    public string nekoId;
    public ActionType actionType;
    public Target[] targets;
    public string actionId;

    public ActionToSend()
    {
        nekoId = "";
        actionType = ActionType.None;
        targets = null;
        actionId = "";
    }
}

[Serializable]
public class Target
{
    public int type;
    public string id;

    public Target(int _type, string _id)
    {
        type = _type;
        id = _id;
    }
}
#endregion

#endregion

#region InGame data (Restful API)
#region Login
[Serializable]
public class LoginRequestBody
{
    public string signature;
    public string wallet_address;
}
[Serializable]
public class LoginResponse
{
    public LoginData data;
    public int status;
}

[Serializable]
public class LoginData
{
    public User user;
    public double expired_time;
    public string refresh_token;
    public string access_token;
}
#endregion

#region Area
[Serializable]
public class AreaResponse
{
    public int status;
    public SArea[] data;
}

[Serializable]
public class SArea{
    public double max_map_level;
    public BackgroundColor metadata;
    public double area_type;
    public string description = null;
    public string name;
    public string id;
}
#endregion

#region Current User Profiles
[Serializable]
public class CurrentUserProfileResponse
{
    public User data;
    public int status;
}

[Serializable]
public class User
{
    public string id;
    public string username;
    public string address;
    public double level;
    public double experience;
    public string avatar_url = null;
}
#endregion

#region Map Levels
[Serializable]
public class MapLevelResponse
{
    public MapLevel[] data;
    public int status;
}

[Serializable]
public class MapLevel
{
    public string id;
    public double level;
    public BackgroundColor metadata;
    public string area_id;
}

[Serializable]
public class BackgroundColor
{
    public string background;
}
#endregion

#region Map Levels ID
[Serializable]
public class MapLevelIdResponse
{
    public MapLevelId data;
    public int status;
}

[Serializable]
public class MapLevelId
{
    public string id;
    public int level;
    public BackgroundColor metadata;
    public string area_id;
    public Enemy[] enemies;
}

[Serializable]
public class Enemy
{
    public string id;
    public string name;
    public string element_id;
    public string class_id;
    public EnemyStat metadata;
    public string strategy;
    public string map_level_id;
}

[Serializable]
public class EnemyStat
{
    public int atk;
    public int def;
    public int speed;
    public int health;
}
#endregion

#region My Account
[Serializable]
public class CurrentLevelResponse
{
    public CurrentLevel[] data;
    public int status;
}

[Serializable]
public class CurrentLevel
{
    public string area_id;
    public int level;
    public string map_level_id;
}
#endregion

#region User nekos
[Serializable]
public class UserNekosResponse
{
    public UserNeko[] data;
    public int status;
}

[Serializable]
public class UserNeko
{
    public string id;
    public string mint_address;
    public string nft_id;
    public string name;
}
#endregion

#region Consumption items
[Serializable]
public class ConsumptionItemsResponse
{
    public ConsumptionItemInfo[] data;
    public int status;
}

[Serializable]
public class ConsumptionItemInfo
{
    public string id;
    public string name;
    public string consumption_item_type_id;
    public ItemData metadata;
    public string consumption_item_type_name;
    public int consumption_item_type_category;
    public string user_id;
    public int total;
}

[Serializable]
public class ItemData
{
    public string background;
    public int damage;
    public string function;
}
#endregion

#region Exclusive items
[Serializable]
public class ExclusiveItemsResponse
{
    public ExclusiveItemInfo[] data;
    public int status;
}

[Serializable]
public class ExclusiveItemInfo
{
    public string id;
    public string name;
    public string exclusive_item_type_id;
    public ItemData metadata;
    public string exclusive_item_type_name;
    public int exclusive_item_type_category;
}
#endregion

#region Nekos infor
[Serializable]
public class NekoResponse
{
    public NekoInfo data;
    public int status;
}

[Serializable]
public class NekoInfo
{
    public string id;
    public string mint_address;
    public string nft_id;
    public string name;
    public NekoStat metadata;
    public int level;
    public int experience;
    public NekoTrait[] traits;
}

[Serializable]
public class NekoStat
{
    public int atk;
    public int m_atk;
    public int def;
    public int m_def;
    public int speed;
    public int health;
    public int mana;
}

[Serializable]
public class NekoTrait
{
    public string id;
    public string name;
    public TraitType trait_type; 
}

[Serializable]
public class TraitType
{
    public string id;
    public string name;
    public string description = null;
}
#endregion

#region Neko Skill Response
[Serializable]
public class NekoSkillResponse
{
    public NekoSkillList data;
    public int status;
}

[Serializable]
public class NekoSkillList
{
    public NekoSkill[] skills;
}

[Serializable]
public class NekoSkill
{
    public string id;
    public string name;
    public NekoSkillInfo metadata;
}

[Serializable]
public class NekoSkillInfo
{
    public string function;
    public int atk;
    public int def;
    public int speed;
    public int mana;
}
#endregion

#region Users response
[Serializable]
public class AllUsersResponse
{
    public User[] users;
    public int status;
}
#endregion

#region Any User profile
[Serializable]
public class UserProfileResponse
{
    public User user;
    public int status;
}
#endregion
#endregion