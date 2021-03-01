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
            return File.ReadAllText($@"../../../{fileName}.txt");
        }

        public string[] GetStopWords(string fileName)
        {
            var text = File.ReadAllText($@"../../../{fileName}.txt");
            var cleanWords = stringCleanerService.RemoveUnicodeCharacters(text);
            return cleanWords.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
    }
}