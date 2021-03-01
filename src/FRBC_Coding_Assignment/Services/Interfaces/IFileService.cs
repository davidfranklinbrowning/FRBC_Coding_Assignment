namespace FRBC_Coding_Assignment.Services.Interfaces
{
    public interface IFileService
    {
        string ReadAllTextFromFile(string fileName);
        string[] GetStopWords(string fileName);
    }
}