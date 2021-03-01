﻿using FRBC_Coding_Assignment.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FRBC_Coding_Assignment.Services
{
    public class WordOccurrenceService : IWordOccurrenceService
    {
        public Dictionary<string, int> GetWordOccurences(string[] wordArray)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (string word in wordArray)
            {
                if (!wordCount.ContainsKey(word))
                {
                    wordCount.Add(word, 1);
                }
                else
                {
                    wordCount[word] += 1;
                }                
            }

            return wordCount;
        }

        public Dictionary<string, int> SortWordOccurences(Dictionary<string, int> wordOccurences)
        {
            return wordOccurences.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);            
        }

        public void PrintTopWordOccurences(Dictionary<string, int> orderedWordOccurences)
        {
            var keyValuePair = orderedWordOccurences.Take(20);
            foreach (KeyValuePair<string, int> pair in keyValuePair)
            {                
                Console.WriteLine($"{pair.Key} - Number of Occurences: {pair.Value}");
            }
        }
    }
}