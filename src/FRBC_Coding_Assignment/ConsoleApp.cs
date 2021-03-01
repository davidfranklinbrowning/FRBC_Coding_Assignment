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
            var semiSanitizedArray = noPunctuationOrSymbols.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var sanitizedList = stringCleanerService.RemoveApostropheExceptConjunctions(semiSanitizedArray);
            var stopWordRemovedList = stopWordService.RemoveStopWords(sanitizedList);

            // Remove all non alpha characters
            var alphaOnlyText = stringCleanerService.RemoveNonAlphaCharacters(string.Join(" ", stopWordRemovedList));

            // Stemming Algorithm
            var alphaOnlyArray = alphaOnlyText.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var stemmingArray = porterStemmingService.RunStemmingAlgorithm(alphaOnlyArray);

            // Computes the frequency of each term
            var wordOccurrenceCount = wordOccurrenceService.GetWordOccurences(stemmingArray);
            var sortedOccurrenceCount = wordOccurrenceService.SortWordOccurences(wordOccurrenceCount);

            // Prints out the most commonly occurring terms (not including stop words) in descending order of frequency
            wordOccurrenceService.PrintTopWordOccurences(sortedOccurrenceCount);
        }
    }
}