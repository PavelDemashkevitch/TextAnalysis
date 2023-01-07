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
            var result = new Dictionary<string, string>(); // конечный результат
            var wordThereList = new List<int>(); // лист для проверки ключ значений


            foreach (var wordList in text) // перебераем листы в тексте
            {
                for (int words = 0; words < wordList.Count - 1; words++) // перебераем слова из листа для 2 разрядного слова
                {
                    var t = ByteMass(wordList[words]) + ByteMass(wordList[words + 1]);
                    if (!wordThereList.Contains(t))
                    {
                        result.Add(wordList[words], wordList[words + 1]);
                        wordThereList.Add(t);
                    }
                    else
                        continue;
                }
                for (int words = 0; words < wordList.Count - 2; words++)// перебераем слова из листа для 3 разрядного слова
                {
                    var t = ByteMass(wordList[words]) + ByteMass(wordList[words + 1]) + ByteMass(wordList[words + 2]);
                    if (!wordThereList.Contains(t))
                    {
                        result.Add(wordList[words] + " " + wordList[words + 1], wordList[words + 2]);
                        wordThereList.Add(t);
                    }
                    else
                        continue;
                }
            }

            return result;
        }
        private static int ByteMass(string oneWord) // расчет массы слова
        {
            int t = 0;
            foreach (var v in ASCIIEncoding.UTF8.GetBytes(oneWord))
                t += v;
            return t;
        }
    }
}