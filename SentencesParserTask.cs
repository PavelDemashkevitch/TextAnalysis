using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            return GetListSentences(text);
        }

        private static List<List<string>> GetListSentences(string text)
        {
            var separator = new char[] { '.', '!', '?', ';', ':', '(', ')' };
            var sentencesList = new List<List<string>>();

            foreach (var sentence in text.Split(separator, StringSplitOptions.RemoveEmptyEntries))
            {
                sentencesList.Add(new List<string>(GetListWord(sentence)));

                if (sentencesList.Last<List<string>>().Count == 0)
                {
                    sentencesList.Remove(sentencesList.Last<List<string>>());
                }
            }

            return sentencesList;
        }

        private static List<string> GetListWord(string sentence)
        {
            var separator = new char[] {' '};
            var wordList = new List<string>();

            sentence = Regex.Replace(sentence,@"[^a-zA-Z']" , " ");
            foreach (var word in sentence.Split(separator, StringSplitOptions.RemoveEmptyEntries))
            {
                wordList.Add(word.ToString().ToLower().Trim());
            }

            return wordList;
        }
    }
}