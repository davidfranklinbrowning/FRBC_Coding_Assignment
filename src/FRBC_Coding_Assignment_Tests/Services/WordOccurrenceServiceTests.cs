using FluentAssertions;
using FRBC_Coding_Assignment.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FRBC_Coding_Assignment_Tests.Services
{
    public class WordOccurrenceServiceTests
    {
        [Theory]
        [AutoMoqData]
        public void GivenWordArrayWithNoDuplicates_WhenGetWordOccurences_ThenReturnsDictionaryOfCountedWords(
            string[] wordArray,
            WordOccurrenceService service
        )
        {
            // ARRANGE

            // ACT
            var results = service.GetWordOccurences(wordArray);

            // ASSERT
            results.Should().NotBeEmpty().And.NotBeNull();
            results.TryGetValue(wordArray[0], out int value);
            value.Should().Be(1);
        }

        [Theory]
        [AutoMoqData]
        public void GivenWordArrayWithDuplicates_WhenGetWordOccurences_ThenReturnsDictionaryOfCountedWords(
            string word,
            WordOccurrenceService service
        )
        {
            // ARRANGE
            var wordArray = new string[] { word, word, word, "something" };

            // ACT
            var results = service.GetWordOccurences(wordArray);

            // ASSERT
            results.Should().NotBeEmpty().And.NotBeNull();
            results.TryGetValue(word, out int value);
            value.Should().Be(3);
            results.TryGetValue("something", out int singleValue);
            singleValue.Should().Be(1);
        }

        [Theory]
        [AutoMoqData]
        public void GivenOutOfOrderDictionary_WhenSortWordOccurences_ThenReturnsDictionaryOfCountedWordsInDescendingOrder(
            Dictionary<string, int> wordDictionary,
            WordOccurrenceService service
        )
        {
            // ARRANGE
            var expected = wordDictionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            // ACT
            var results = service.SortWordOccurences(wordDictionary);

            // ASSERT
            results.Should().NotBeEmpty().And.NotBeNull();
            results.Should().BeEquivalentTo(expected);
        }
    }
}
