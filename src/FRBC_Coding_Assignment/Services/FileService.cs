using FRBC_Coding_Assignment.Services.Interfaces;
using System;
using System.IO;

namespace FRBC_Coding_Assignment.Services
{
    public class FileService : IFileService
    {
        private readonly IStringCleanerService stringCleanerService;

        public FileService(
            IStringCleanerService stringCleanerService
        )
        {
            this.stringCleanerService = stringCleanerService;
        }
        public string ReadAllTextFromFile(string filePath)
        {
            try
            {
                return File.ReadAllText($@"{filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when reading text file: {ex}");
                return string.Empty;
            }
            
        }

        public string[] GetStopWords(string filePath)
        {
            try
            {
                var text = File.ReadAllText($@"{filePath}");
                var cleanWords = stringCleanerService.RemoveUnicodeCharacters(text);
                return cleanWords.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when reading StopWords text file: {ex}");
                return new string[0];
            }
        }
    }
}