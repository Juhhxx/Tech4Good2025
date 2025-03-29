using System;
using System.Collections;

[Serializable]
public struct ResourceAmount
{
    private MissionResources _resource;
    private int _amount;

    public ResourceAmount( MissionResources resource, int amount)
    {
        _resource = resource;
        _amount = amount;
    }

    /// <summary>
    /// Write ["resource"] to get the Resource and ["amount] to ge the amount.
    /// </summary>
    /// <param name="str">What value you want to get.</param>
    /// <returns>The type or the amount of the collection.</returns>
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
