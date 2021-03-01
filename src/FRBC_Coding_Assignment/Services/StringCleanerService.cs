using FRBC_Coding_Assignment.Services.Interfaces;
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

        // Need to account for apostrophy
        public string RemovePunctuation(string text)
        {
            var stringBuilder = new StringBuilder();

            var test = Regex.Replace(text, @"[^\w\d'\s]+", " "); ;

            foreach (char character in text)
            {
                if (character == '\'' || !char.IsPunctuation(character))
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
    }
}