using System;
using System.Collections;
using UnityEngine;

[Serializable]
public struct ResourceAmount
{
    [SerializeField] private Resources _resource;
    [SerializeField] private int _amount;

    public ResourceAmount( Resources resource, int amount)
    {
        _resource = resource;
        _amount = amount;
    }

    /// <summary>
    /// Write ["resource"] to get the Resource and ["amount"] to ge the amount.
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
