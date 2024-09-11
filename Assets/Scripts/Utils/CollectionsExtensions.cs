using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utils
{
    public static class CollectionsExtensions
    {
        public static T GetRandom<T>(this IEnumerable<T> source)
        {
            List<T> sourceAsList = source.ToList();
            return sourceAsList[Random.Range(0, sourceAsList.Count)];
        }
    }
}