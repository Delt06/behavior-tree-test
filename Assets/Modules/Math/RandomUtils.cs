using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Modules.Math
{
    public static class RandomUtils
    {
        public static bool TryGetRandom<T>(HashSet<T> set, [MaybeNullWhen(false)] out T selectedItem)
        {
            var selectedIndex = Random.Range(0, set.Count);

            var index = 0;

            foreach (var item in set)
            {
                if (index == selectedIndex)
                {
                    selectedItem = item;
                    return true;
                }

                index++;
            }

            selectedItem = default;
            return false;
        }
    }
}