using FRBC_Coding_Assignment.Services.Interfaces;
using System.Linq;

namespace FRBC_Coding_Assignment.Services
{
    public class StopWordService : IStopWordService
    {
        public string[] RemoveStopWords(string[] wordArray, string[] stopWords)
        {
            var wordList = wordArray.ToList();
            foreach (var stopWord in stopWords)
            {
                wordList.RemoveAll(word => word.Equals(stopWord));
            }
            return wordList.ToArray();
        }
    }
}