using System;
using System.Collections.Generic;
using UnityEngine;

public class Missions
{
    public Missions(string name, int manpwrReq, ResourceAmount cost, ResourceAmount reward, int turnCost, int turnDuration)
    {
        _name           = name;
        _manpowerReq    = manpwrReq;
        _cost           = cost;
        _reward         = reward;
        _turnCost       = turnCost;
        _turnDuration   = turnDuration;
    }
    private string _name;
    public string Name => _name;
    private int _manpowerReq;
    public int ManpowerReq => _manpowerReq;
    private ResourceAmount _cost;
    public ResourceAmount Cost => _cost;
    private ResourceAmount _reward;
    private ResourceAmount Reward => new ResourceAmount((MissionResources)_reward["resource"], 
                                                        (int)((int)_reward["amount"] * _missionSuccess));
    private int _turnCost;
    public int TurnCost => _turnCost;
    private int _turnDuration;
    public int TurnDuration => _turnDuration;
    private float _missionSuccess;
    // public Event 

    public override string ToString()
    {
        return string.Format(
        "{0}\nManpower Required:\n{1}\nCost:\n{2} {3}/s\nRewards:\n{4} {5}/s\nDuration:\n{6} days\nTime Available:\n{7} days",
        _name, _manpowerReq, 
        _cost["amount"], _cost["resource"].ToString(),
        _reward["amount"], _reward["resource"].ToString(),
        _turnCost, _turnDuration
        );
    }
}
