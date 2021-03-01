using FRBC_Coding_Assignment.Services.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FRBC_Coding_Assignment
{
    [ExcludeFromCodeCoverage]
    public class ConsoleApp
    {
        private readonly IFileService fileService;
        private readonly IStringCleanerService stringCleanerService;

        public ConsoleApp(
            IFileService fileService,
            IStringCleanerService stringCleanerService
        )
        {
            this.fileService = fileService;
            this.stringCleanerService = stringCleanerService;
        }

        public void Run()
        {
            // Read a file
            var dirtyText = fileService.ReadAllTextFromFile("Text1");

            var nonUnicodeText = stringCleanerService.RemoveUnicodeCharacters(dirtyText);

            // Remove Stop Words
            var noPunctuation = stringCleanerService.RemovePunctuation(nonUnicodeText);
            var firstWordArray = noPunctuation.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            var stopwords = fileService.GetStopWords("stopwords");

            var results = firstWordArray.Except(stopwords).ToArray();

            // Remove all non alpha characters
            var alphaOnlyText = stringCleanerService.RemoveNonAlphaCharacters(string.Join(" ", results));


            // Stemming Algorithm


            // Computes the frequency of each term

            //prints out the 20 most commonly occurring terms (not including stop words) in descending order of frequency

        }

        private string[] Splitter(string input)
        {
            return Regex.Split(input, @"\W+");
        }
    }
}