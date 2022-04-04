using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataApi : PersistantAndSingletonBehavior<DataApi>
{
    public NekoManager manager;
    private AreaResponse areaResponse = new AreaResponse();
    //private CurrentUserProfileResponse currentUserProfileResponse = new CurrentUserProfileResponse();
    //private LoginResponse loginResponse = new LoginResponse();
    private MapLevelResponse mapLevelResponse = new MapLevelResponse();
    private List<MapLevelIdResponse> mapLevelIdResponse = new List<MapLevelIdResponse>();
    private CurrentLevelResponse currLevelResponse = new CurrentLevelResponse();
    private UserNekosResponse userNekoResponse = new UserNekosResponse();
    //private ConsumptionItemsResponse consumptionItemsResponse = new ConsumptionItemsResponse();
    //private ExclusiveItemsResponse exclusiveItemsResponse = new ExclusiveItemsResponse();
    //private NekoResponse nekoResponse = new NekoResponse();
    //private NekoSkillResponse nekoSkillResponse = new NekoSkillResponse();
    ////map
    public AreaResponse GetAreaResponse() { return areaResponse; }
    public void SetAreaResponse(AreaResponse value) { areaResponse = value; }
    public MapLevelResponse GetMapLevelResponse() { return mapLevelResponse; }
    public void SetMapLevelResponse(MapLevelResponse value) { mapLevelResponse = value; }
    public List<MapLevelIdResponse> GetMapLevelIdResponse()
    {
        return mapLevelIdResponse;
    }
    public void AddListMapLevelIdResponse(MapLevelIdResponse value)
    {
        mapLevelIdResponse.Add(value);
    }
    public CurrentLevelResponse GetCurrentLevelResponse() { return currLevelResponse; }
    public void SetCurrentLevelResponse(CurrentLevelResponse value) { currLevelResponse = value; }
    ////nekodata
    public UserNekosResponse GetUserNekoResponse() { return userNekoResponse; }
    public void SetUserNekoResponse(UserNekosResponse value) { userNekoResponse = value; }
    //public NekoResponse GetNekoResponse() { return nekoResponse; }
    //public void SetNekoResponse(NekoResponse value) { nekoResponse = value; }
    //public NekoSkillResponse GetNekoSkillResponse() { return nekoSkillResponse; }
    //public void SetNekoSkillResponse(NekoSkillResponse value) { nekoSkillResponse = value; }
    ////user
    //public CurrentUserProfileResponse GetCurrentUserProfileResponse() { return currentUserProfileResponse; }
    //public void SetCurrentUserProfileResponse(CurrentUserProfileResponse value) { currentUserProfileResponse = value; }
}
