using FluentAssertions;
using FRBC_Coding_Assignment.Services;
using System.Collections.Generic;
using Xunit;

namespace FRBC_Coding_Assignment_Tests.Services
{
    public class StringCleanerServiceTests
    {
        [Theory]
        [AutoMoqData]
        public void GivenText_WhenRemoveNonAlphaCharacters_ReturnsNonAlphaCharactersString(
            StringCleanerService service,
            string sampleText
        )
        {
            // ARRANGE
            var badInput = new List<string> { "-", "*" };

            // ACT
            var results = service.RemoveNonAlphaCharacters(sampleText);

            //ASSERT
            results.Should().NotBeNullOrEmpty();
            results.Should().NotContainAny(badInput);
        }

        [Theory]
        [AutoMoqData]
        public void GivenText_WhenRemoveUnicodeCharacters_ReturnsNonUnicodeCharactersString(
            StringCleanerService service,
            string sampleText
        )
        {
            // ARRANGE
            sampleText += "\n" + "\t";
            var unicode = new List<string> { "\n", "\t" };

            // ACT
            var results = service.RemoveUnicodeCharacters(sampleText);

            //ASSERT
            results.Should().NotBeNullOrEmpty();
            results.Should().NotContainAny(unicode);
        }

        [Theory]
        [AutoMoqData]
        public void GivenText_WhenRemovePunctuationAndSymbols_ReturnsNonPunctuationAndSymbolsString(
            StringCleanerService service            
        )
        {
            // ARRANGE
            var sampleText = ".This is * sample that\'s it \' !";
            var puncuationOrSymbols = new List<string> { ".", "*", "!" };

            // ACT
            var results = service.RemovePunctuationAndSymbols(sampleText);

            //ASSERT
            results.Should().NotBeNullOrEmpty();
            results.Should().NotContainAny(puncuationOrSymbols);
            results.Should().Contain("that\'s");
        }

        [Theory]
        [AutoMoqData]
        public void GivenTextArray_WhenRemoveApostropheExceptConjunctions_ReturnsApostropheExceptConjunctionsList(
            StringCleanerService service
        )
        {
            // ARRANGE
            var sampleTextArray = new string[] { "This", "is", "sample", "that\'s", "it", "\'" };

            // ACT
            var results = service.RemoveApostropheExceptConjunctions(sampleTextArray);

            //ASSERT
            results.Should().NotBeNullOrEmpty();
            results.Should().Contain("that\'s");
            results.Should().NotContain("\'");
        }
    }
}
