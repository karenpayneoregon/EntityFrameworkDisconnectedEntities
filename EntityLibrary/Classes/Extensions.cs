using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityLibrary.Classes
{
    public static class Extensions
    {
        /// <summary>
        /// Return distinct collection by a specific property e.g. country.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="sender"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> sender, Func<TSource, TKey> keySelector)
        {

            var hashSet = new HashSet<TKey>();
            return sender.Where((element) => hashSet.Add(keySelector(element)));

        }
    }
}