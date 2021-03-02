using System.Collections.Generic;

namespace FRBC_Coding_Assignment.Services.Interfaces
{
    public interface IWordOccurrenceService
    {
        Dictionary<string, int> GetWordOccurences(string[] wordArray);
        Dictionary<string, int> SortWordOccurences(Dictionary<string, int> wordOccurences);
        void PrintTopWordOccurences(Dictionary<string, int> orderedWordOccurences);
    }
}