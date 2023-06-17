using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {


            IEnumerable<(string key, string value)> bigrams = text.Where(t => t.Count > 1)
            .SelectMany(sentence => sentence
            .Zip(sentence.Skip(1), (key, value) => (key, value)));

            IEnumerable<(string key,string value)> trigrams = text.Where(t => t.Count > 2)
            .SelectMany(sentence => sentence
            .Zip(sentence.Skip(1), (first, second) => first + " " + second)
            .Zip(sentence.Skip(2), (key, value) => (key, value)));

            var res1 = bigrams
                .Concat(trigrams)
                .ToLookup(x => x.key, x => x.value)
                .ToDictionary(x => x.Key, x => x.GetMaxValue());
            return res1;
        }


        private static string GetMaxValue(this IGrouping<string, string> values)
        {
            return values
                .ToLookup(x => values.Count(y => y == x))
                .OrderBy(x => x.Key)
                .Last()
                .Aggregate((first, second) => string.CompareOrdinal(first, second) < 0 ? first : second);
        }
    }
}