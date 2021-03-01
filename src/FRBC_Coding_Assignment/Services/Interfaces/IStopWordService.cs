using System.Collections.Generic;

namespace FRBC_Coding_Assignment.Services.Interfaces
{
    public interface IStopWordService
    {
        List<string> RemoveStopWords(List<string> wordList);
    }
}