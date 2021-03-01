using FRBC_Coding_Assignment.Services.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FRBC_Coding_Assignment.Services
{
    public class StringCleanerService : IStringCleanerService
    {
        public string RemoveNonAlphaCharacters(string text)
        {
            return Regex.Replace(text, @"[^a-zA-Z0-9\s]", string.Empty);
        }

        public string RemoveUnicodeCharacters(string text)
        {
            return Regex.Replace(text, @"\t|\n|\r|\e", " "); ;
        }
        
        public string RemovePunctuationAndSymbols(string text)
        {
            var stringBuilder = new StringBuilder();

            foreach (char character in text)
            {
                if (IsCharacterApostropheOrNonPunctuationOrNonSymbol(character))
                {
                    stringBuilder.Append(character);
                }
                else
                {
                    stringBuilder.Append(" ");
                }
            }

           return stringBuilder.ToString();
        }

        public string[] RemoveApostropheExceptConjunctions(string[] wordArray)
        {
            var stringList = new List<string>();
            foreach(var word in wordArray)
            {
                if (word.Length > 0 && !word.Equals("\'"))
                {
                    stringList.Add(word.Trim('\''));
                }                
            }

            return stringList.ToArray();
        }

        private bool IsCharacterApostropheOrNonPunctuationOrNonSymbol(char character)
        {
            return character == '\'' || (!char.IsPunctuation(character) && !char.IsSymbol(character));
        }
    }
}