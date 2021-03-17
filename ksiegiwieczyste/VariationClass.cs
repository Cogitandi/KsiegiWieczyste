using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ksiegiwieczyste
{
    class VariationClass
    {
        public static IEnumerable<IEnumerable<T>> GetVariationsWithoutDuplicates<T>(IList<T> items, int length)
        {
            if (length == 0 || !items.Any()) return new List<List<T>> { new List<T>() };
            return from item in items.Distinct()
                   from permutation in GetVariationsWithoutDuplicates(items.Where(i => !EqualityComparer<T>.Default.Equals(i, item)).ToList(), length - 1)
                   select Prepend(item, permutation);
        }

        public static IEnumerable<IEnumerable<T>> GetVariations<T>(IList<T> items, int length)
        {
            if (length == 0 || !items.Any()) return new List<List<T>> { new List<T>() };
            return from item in items
                   from permutation in GetVariations(Remove(item, items).ToList(), length - 1)
                   select Prepend(item, permutation);
        }

        public static IEnumerable<T> Prepend<T>(T first, IEnumerable<T> rest)
        {
            yield return first;
            foreach (var item in rest) yield return item;
        }

        public static IEnumerable<T> Remove<T>(T item, IEnumerable<T> from)
        {
            var isRemoved = false;
            foreach (var i in from)
            {
                if (!EqualityComparer<T>.Default.Equals(item, i) || isRemoved) yield return i;
                else isRemoved = true;
            }
        }
    }
}
