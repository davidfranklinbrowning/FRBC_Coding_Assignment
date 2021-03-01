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
        private readonly IPorterStemmingService porterStemmingService;

        public ConsoleApp(
            IFileService fileService,
            IStringCleanerService stringCleanerService,
            IPorterStemmingService porterStemmingService
        )
        {
            this.fileService = fileService;
            this.stringCleanerService = stringCleanerService;
            this.porterStemmingService = porterStemmingService;
        }

        public void Run()
        {
            // Read a file
            var dirtyText = fileService.ReadAllTextFromFile("Text2");

            var nonUnicodeText = stringCleanerService.RemoveUnicodeCharacters(dirtyText);

            // Remove Stop Words
            var noPunctuationOrSymbols = stringCleanerService.RemovePunctuationAndSymbols(nonUnicodeText);

            var firstWordArray = noPunctuationOrSymbols.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var secondWordArray = stringCleanerService.RemoveApostropheExceptConjunctions(firstWordArray);

            var stopwords = fileService.GetStopWords("stopwords");

            var results = secondWordArray.Except(stopwords).ToArray(); //2850

            // Remove all non alpha characters
            var alphaOnlyText = stringCleanerService.RemoveNonAlphaCharacters(string.Join(" ", results));

            // Stemming Algorithm
            var thirdWordArray = alphaOnlyText.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var stemmingArray = porterStemmingService.RunStemmingAlgorithm(thirdWordArray);

            // Computes the frequency of each term


            //prints out the 20 most commonly occurring terms (not including stop words) in descending order of frequency

        }
    }
}