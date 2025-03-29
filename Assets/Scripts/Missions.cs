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
    private int _manpowerReq;
    private ResourceAmount _cost;
    private ResourceAmount _reward;
    private int _turnCost;
    private int _turnDuration;
    // public Event 
}
