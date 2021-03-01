namespace FRBC_Coding_Assignment.Services.Interfaces
{
    public interface IStopWordService
    {
        string[] RemoveStopWords(string[] wordArray, string[] stopWords);
    }
}