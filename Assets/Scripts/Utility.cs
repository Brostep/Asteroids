using System;
using System.Collections.Generic;

public class Utility
{
    static Random _random = new Random();

    public static void Shuffle<T>(IList<T> collection)
    {
        for (var i = 0; i < collection.Count; i++)
        {
            var j = _random.Next(i, collection.Count);

            Swap(collection, i, j);
        }
    }

    public static void Swap<T>(IList<T> collection, int i, int j)
    {
        var aux = collection[i];
        collection[i] = collection[j];
        collection[j] = aux;
    }
}
