using System;
using System.Collections;

public struct ResourceAmount
{
    private MissionResources _resource;
    private int _amount;

    public ResourceAmount( MissionResources resource, int amount)
    {
        _resource = resource;
        _amount = amount;
    }

    public object this [string str]
    {
        get
        {
            if (str == "resource")      return _resource;
            else if (str == "amount")   return _amount;
            else return                 null;
        }
    }
}
