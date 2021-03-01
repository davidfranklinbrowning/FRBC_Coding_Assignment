using FRBC_Coding_Assignment.Services.Interfaces;
using System.Collections.Generic;

namespace FRBC_Coding_Assignment.Services
{
    public class PorterStemmingService : IPorterStemmingService
    {
        public string[] RunStemmingAlgorithm(string[] wordArray)
        {
            var porterStemmer = new PorterStemmer();
            var stringList = new List<string>();
            foreach (var word in wordArray)
            {
                stringList.Add(porterStemmer.StemWord(word));                
            }

            return stringList.ToArray();
        }
    }
}