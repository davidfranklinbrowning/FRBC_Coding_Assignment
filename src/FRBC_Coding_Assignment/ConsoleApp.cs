using FRBC_Coding_Assignment.Services.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;

namespace FRBC_Coding_Assignment
{
    [ExcludeFromCodeCoverage]
    public class ConsoleApp
    {
        private readonly IFileService fileService;
        private readonly IStringCleanerService stringCleanerService;
        private readonly IPorterStemmingService porterStemmingService;
        private readonly IWordOccurrenceService wordOccurrenceService;
        private readonly IStopWordService stopWordService;

        public ConsoleApp(
            IFileService fileService,
            IStringCleanerService stringCleanerService,
            IPorterStemmingService porterStemmingService,
            IWordOccurrenceService wordOccurrenceService,
            IStopWordService stopWordService
        )
        {
            this.fileService = fileService;
            this.stringCleanerService = stringCleanerService;
            this.porterStemmingService = porterStemmingService;
            this.wordOccurrenceService = wordOccurrenceService;
            this.stopWordService = stopWordService;
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

            var results = stopWordService.RemoveStopWords(secondWordArray, stopwords);

            // Remove all non alpha characters
            var alphaOnlyText = stringCleanerService.RemoveNonAlphaCharacters(string.Join(" ", results));

            // Stemming Algorithm
            var thirdWordArray = alphaOnlyText.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var stemmingArray = porterStemmingService.RunStemmingAlgorithm(thirdWordArray);

            // Computes the frequency of each term
            var wordOccurrenceCount = wordOccurrenceService.GetWordOccurences(stemmingArray);
            var sortedOccurrenceCount = wordOccurrenceService.SortWordOccurences(wordOccurrenceCount);

            //prints out the 20 most commonly occurring terms (not including stop words) in descending order of frequency
            wordOccurrenceService.PrintTopWordOccurences(sortedOccurrenceCount);
        }
    }
}