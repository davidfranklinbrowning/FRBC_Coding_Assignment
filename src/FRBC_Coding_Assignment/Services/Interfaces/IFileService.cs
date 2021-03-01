namespace FRBC_Coding_Assignment.Services.Interfaces
{
    public interface IFileService
    {
        string ReadAllTextFromFile(string filePath);
        string[] GetStopWords(string filePath);
    }
}