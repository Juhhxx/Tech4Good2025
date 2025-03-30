using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Missions
{
    public Missions(string name, int manpwrReq, ResourceAmount cost, ResourceAmount reward, int turnCost, int turnDuration, string text, GameObject minigame)
    {
        _name           = name;
        _manpowerReq    = manpwrReq;
        _cost           = cost;
        _reward         = reward;
        _turnCost       = turnCost;
        _turnDuration   = turnDuration;
        _text           = text;
        Minigame        = minigame;
    }
    private string _name;
    public string Name => _name;
    private int _manpowerReq;
    public int ManpowerReq => _manpowerReq;
    public int ManpowerReturn => (int)(_manpowerReq * _missionSuccess);
    private ResourceAmount _cost;
    public ResourceAmount Cost => _cost;
    private ResourceAmount _reward;
    public ResourceAmount Reward => new ResourceAmount((Resources)_reward["resource"], 
                                                        (int)((int)_reward["amount"] * _missionSuccess));
    private int _turnCost;
    public int TurnCost => _turnCost;
    private int _turnDuration;
    public int TurnDuration => _turnDuration;
    private float _missionSuccess;
    public float MissionSuccess 
    {
        get => _missionSuccess;
        set => _missionSuccess = value;
    }
    private int _turnsPassedWaiting;
    public int TurnsPassedW => _turnsPassedWaiting;
    private int _turnsPassedActive;
    public int TurnsPassedA => _turnsPassedActive;
    // private UnityEvent _startMinigame;
    public void PassTurnWaiting() => _turnsPassedWaiting++;
    public void PassTurnActive() => _turnsPassedActive++;
    private string _text;
    public string Text => _text;
    public GameObject Minigame;
    
    public override string ToString()
    {
        return string.Format(
        "{0}\nManpower: {1}\nCost: {2} {3}/s\nRewards: {4} {5}/s\nDuration: {6} days\nTime Available: {7} days",
        _name, _manpowerReq, 
        _cost["amount"], _cost["resource"].ToString(),
        _reward["amount"], _reward["resource"].ToString(),
        _turnCost, _turnDuration - _turnsPassedWaiting
        );
    }
}
