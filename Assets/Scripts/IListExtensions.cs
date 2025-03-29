using System;
using System.Collections.Generic;
using System.Linq;

public static class IListExtensions
{
    public static T RandomElement<T>(this IList<T> ts)
    {
        Random rand = new Random();
        return ts[rand.Next(ts.Count)];
    }
}
