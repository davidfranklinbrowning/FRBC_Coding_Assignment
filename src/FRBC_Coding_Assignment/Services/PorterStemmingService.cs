using FRBC_Coding_Assignment.PorterStemmer.Interfaces;
using FRBC_Coding_Assignment.Services.Interfaces;
using System.Collections.Generic;

namespace FRBC_Coding_Assignment.Services
{
    public class PorterStemmingService : IPorterStemmingService
    {
        private readonly IPorterStemmer porterStemmer;
        public PorterStemmingService(
            IPorterStemmer porterStemmer    
        )
        {
            this.porterStemmer = porterStemmer;
        }
        public string[] RunStemmingAlgorithm(string[] wordArray)
        {
            var stringList = new List<string>();
            foreach (var word in wordArray)
            {
                stringList.Add(porterStemmer.StemWord(word));                
            }

            return stringList.ToArray();
        }
    }
}