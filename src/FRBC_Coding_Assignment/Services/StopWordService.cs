﻿using FRBC_Coding_Assignment.Services.Interfaces;
using System.Collections.Generic;

namespace FRBC_Coding_Assignment.Services
{
    public class StopWordService : IStopWordService
    {
        private readonly IFileService fileService;

        public StopWordService(
            IFileService fileService    
        )
        {
            this.fileService = fileService;
        }

        public List<string> RemoveStopWords(List<string> wordList)
        {
            var stopWords = fileService.GetStopWords("stopwords");
            
            foreach (var stopWord in stopWords)
            {
                wordList.RemoveAll(word => word.ToLower().Equals(stopWord.ToLower()));
            }
            return wordList;
        }
    }
}