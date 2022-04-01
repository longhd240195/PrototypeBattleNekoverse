using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colyseus;

public class BattleDataManager : PersistantAndSingletonBehavior<BattleDataManager>
{
    public NekoManager nekoColyseusManager;

    public readonly static string START_TURN_MSG_TO_SEND = "StartTurn";
    public readonly static string ACTION_MSG_TO_SEND = "Action";
    public readonly static string DONE_ANIMATION_MSG_TO_SEND = "Done Animation";

    // ready msg
    public RoomData roomData = null;
    // calculate queue msg
    public Turn[] queue;
    public int entityTurnIndex;
    // result msg
    public Action actionToPerform;
    public EffectOnEntity[] effectOnNekos;
    public EffectOnEntity[] effectOnEnemies;

    public ActionToSend actionToSend;

    private void OnEnable()
    {
        NekoManager.onReadyMsgReturn += ReadyMsgReturn;
        NekoManager.onStartRoundMsgReturn += StartRoundMsgReturn;
        NekoManager.onCalculateQueueMsgReturn += CalculateQueueMsgReturn;
        NekoManager.onResultMsgReturn += ResultMsgReturn;
        NekoManager.onEndTurnMsgReturn += EndTurnMsgReturn;
        NekoManager.onEndRoundMsgReturn += EndRoundMsgReturn;
        NekoManager.onEndGameMsgReturn += EndGameMsgReturn;
    }

    private void OnDisable()
    {
        NekoManager.onReadyMsgReturn -= ReadyMsgReturn;
        NekoManager.onStartRoundMsgReturn -= StartRoundMsgReturn;
        NekoManager.onCalculateQueueMsgReturn -= CalculateQueueMsgReturn;
        NekoManager.onResultMsgReturn -= ResultMsgReturn;
        NekoManager.onEndTurnMsgReturn -= EndTurnMsgReturn;
        NekoManager.onEndRoundMsgReturn -= EndRoundMsgReturn;
        NekoManager.onEndGameMsgReturn -= EndGameMsgReturn;
    }

    private void Start()
    {
        // debug purpose
        //nekoColyseusManager.JoinPvERoom();
    }

    public void StartPvEEvent()
    {
        nekoColyseusManager.JoinPvERoom();
    }

    private void ReadyMsgReturn(ReadyRespondMessages msg)
    {
        roomData = msg.data;
    }

    private void StartRoundMsgReturn(StartRoundRespondMessage msg)
    {
        // do start round functions 
    }

    private void CalculateQueueMsgReturn(CalculateQueueRespondMessage msg)
    {
        entityTurnIndex = msg.data.index;
        queue = msg.data.turns;
    }

    private void ResultMsgReturn(ResultRespondMessage msg)
    {
        actionToPerform = msg.data.action;
        effectOnNekos = msg.data.effect.nekos;
        effectOnEnemies = msg.data.effect.enemies;
    }

    private void EndTurnMsgReturn(EndTurnRespondMessage msg)
    {
        // do end turn functions 
    }

    private void EndRoundMsgReturn(EndRoundRespondMessage msg)
    {
        // do end round function
    }

    private void EndGameMsgReturn(EndGameRespondMessage msg)
    {
        // do end game function
    }

    // assume this function only get called in neko turn / player turn
    public void SetActionToSend(ActionType actionType, Target[] targets, string actionId = "")
    {
        actionToSend.nekoId = queue[entityTurnIndex].id;
        actionToSend.actionType = actionType;
        actionToSend.targets = targets;
        actionToSend.actionId = actionId;
    }

    public void Send(string action, object msg = null)
    {
        if (msg == null)
        {
            nekoColyseusManager.SendMessage(action);
        }
        else
        {
            nekoColyseusManager.SendMessage(action, msg);
        }
    }

    public void ClearData()
    {
        roomData = null;
    }
}
