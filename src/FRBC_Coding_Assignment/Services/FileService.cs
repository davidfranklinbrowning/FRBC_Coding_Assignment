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
        public string ReadAllTextFromFile(string fileName)
        {
            try
            {
                return File.ReadAllText($@"../../../{fileName}.txt");
            }
            catch
            {
                return string.Empty;
            }
            
        }

        public string[] GetStopWords(string fileName)
        {
            try
            {
                var text = File.ReadAllText($@"../../../{fileName}.txt");
                var cleanWords = stringCleanerService.RemoveUnicodeCharacters(text);
                return cleanWords.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            catch
            {
                return new string[0];
            }
        }
    }
}