using AutoFixture.Xunit2;
using FluentAssertions;
using FRBC_Coding_Assignment.Algorithms.Interfaces;
using FRBC_Coding_Assignment.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace FRBC_Coding_Assignment_Tests.Services
{
    [ExcludeFromCodeCoverage]
    public class PorterStemmingServiceTests
    {
        [Theory]
        [AutoMoqData]
        public void GivenWordArray_WhenRunStemmingAlgorithm_ThenReturnStringArray(
            [Frozen] Mock<IPorterStemmer> porterStemmerMock,
            string[] wordArray,
            string word,
            PorterStemmingService service
        )
        {
            // ARRANGE
            porterStemmerMock.Setup(g => g.StemWord(It.IsAny<string>())).Returns(word);

            // ACT
            var result = service.RunStemmingAlgorithm(wordArray);

            // ASSERT
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(wordArray.Length);
            result.Should().Contain(word);
        }

        [Theory]
        [AutoMoqData]
        public void GivenEmptyWordArray_WhenRunStemmingAlgorithm_ThenReturnStringArray(
            [Frozen] Mock<IPorterStemmer> porterStemmerMock,
            string[] wordArray,
            string word,
            PorterStemmingService service
        )
        {
            // ARRANGE
            wordArray = new string[0];
            porterStemmerMock.Setup(g => g.StemWord(It.IsAny<string>())).Returns(word);

            // ACT
            var result = service.RunStemmingAlgorithm(wordArray);

            // ASSERT
            result.Should().BeNullOrEmpty();
            result.Should().HaveCount(wordArray.Length);
            result.Should().NotContain(word);
        }
    }
}
