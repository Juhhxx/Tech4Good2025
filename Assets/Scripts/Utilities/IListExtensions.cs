using System;
using System.Collections.Generic;
using System.Linq;

public static class IListExtensions
{
    public static T RandomElement<T>(this IList<T> ts)
    {
        if (ts.Count > 0)
        {
            Random rand = new Random();
            return ts[rand.Next(ts.Count)];
        }
        else
            return default;
    }
}
