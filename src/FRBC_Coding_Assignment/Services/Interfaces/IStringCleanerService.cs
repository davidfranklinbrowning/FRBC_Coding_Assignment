﻿namespace FRBC_Coding_Assignment.Services.Interfaces
{
    public interface IStringCleanerService
    {
        string RemoveNonAlphaCharacters(string text);
        string RemoveUnicodeCharacters(string text);
        string RemovePunctuationAndSymbols(string text);
        string[] RemoveApostropheExceptConjunctions(string[] wordArray);
    }
}