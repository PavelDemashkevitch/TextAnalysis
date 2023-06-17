using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(Dictionary<string, string> nextWords,
            string phraseBeginning, int wordsCount) => Answer(nextWords, phraseBeginning, wordsCount);

        private static string Answer(Dictionary<string, string> frequency, string startWords, int wordsCount)
        {
            StringBuilder sb = new StringBuilder(startWords + ' ');

            for (int i = 0; i < wordsCount; i++)
            {
                sb.Append(GetNextWord(sb.ToString().TrimEnd().Split(' '), frequency) + ' ');
            }
            return sb.ToString().TrimEnd();
        }

        private static string GetNextWord(string[] startWords, Dictionary<string, string> frequency)
        {
            if (startWords.Length > 1 && frequency.ContainsKey(string.Concat(startWords[startWords.Length - 2], ' ', startWords[startWords.Length - 1])))
            {
                return frequency[string.Concat(startWords[startWords.Length - 2], ' ', startWords[startWords.Length - 1])];
            }
            else if (frequency.ContainsKey(startWords[startWords.Length - 1]))
            {
                return frequency[startWords[startWords.Length - 1]];
            }
            else return "";
        }
        //private static string GetNextWord(string total,
        //    Dictionary<string, string> nextWords)
        //{
        //    var start = total.Split(' ').Skip(total.Split(' ').Count() - 2);
        //    var startBigram = start.LastOrDefault();
        //    var startTrigram = start.Count() > 1 ? start.FirstOrDefault() + " " + startBigram : "";
        //    return nextWords.ContainsKey(startTrigram) ? total + " " + nextWords[startTrigram] :
        //        nextWords.ContainsKey(startBigram) ? total + " " + nextWords[startBigram] : total;
        //}

        //public static string ContinuePhrase(Dictionary<string, string> nextWords,
        //    string phraseBeginning, int wordsCount) =>
        //    Enumerable.Repeat("", wordsCount)
        //        .Aggregate(string
        //        .Join(" ", phraseBeginning
        //        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)),
        //        (total, next) => GetNextWord(total, nextWords));
    }
}