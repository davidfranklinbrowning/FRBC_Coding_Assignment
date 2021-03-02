using AutoFixture.Xunit2;
using FluentAssertions;
using FRBC_Coding_Assignment.Services;
using FRBC_Coding_Assignment.Services.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace FRBC_Coding_Assignment_Tests.Services
{
    [ExcludeFromCodeCoverage]
    public class StopWordServiceTests
    {
        [Theory]
        [AutoMoqData]
        public void GivenWordList_WhenRemoveStopWords_ThenReturnListWithoutStopWords(
            [Frozen] Mock<IFileService> fileServiceMock,
            List<string> wordList,
            string stopWordPath,
            StopWordService service
        )
        {
            // ARRANGE
            string[] stopWords = new string[] { "test" };
            wordList.Add("test");
            fileServiceMock.Setup(g => g.GetStopWords(It.IsAny<string>())).Returns(stopWords);

            // ACT
            var results = service.RemoveStopWords(wordList, stopWordPath);

            // ASSERT
            results.Should().NotBeNullOrEmpty();
            results.Should().HaveCount(wordList.Count);
            results.Should().NotContain("test");
        }

        [Theory]
        [AutoMoqData]
        public void GivenEmptyWordList_WhenRemoveStopWords_ThenReturnListWithoutStopWords(
            [Frozen] Mock<IFileService> fileServiceMock,
            List<string> wordList,
            string stopWordPath,
            StopWordService service
        )
        {
            // ARRANGE
            string[] stopWords = new string[] { "test" };
            wordList.Clear();
            fileServiceMock.Setup(g => g.GetStopWords(It.IsAny<string>())).Returns(stopWords);

            // ACT
            var results = service.RemoveStopWords(wordList, stopWordPath);

            // ASSERT
            results.Should().BeNullOrEmpty();
            results.Should().HaveCount(wordList.Count);
            results.Should().NotContain("test");
        }

        [Theory]
        [AutoMoqData]
        public void GivenEmptyStopWordList_WhenRemoveStopWords_ThenReturnListWithoutStopWords(
            [Frozen] Mock<IFileService> fileServiceMock,
            List<string> wordList,
            string stopWordPath,
            StopWordService service
        )
        {
            // ARRANGE
            string[] stopWords = new string[0];
            wordList.Add("test");
            fileServiceMock.Setup(g => g.GetStopWords(It.IsAny<string>())).Returns(stopWords);

            // ACT
            var results = service.RemoveStopWords(wordList, stopWordPath);

            // ASSERT
            results.Should().NotBeNullOrEmpty();
            results.Should().HaveCount(wordList.Count);
            results.Should().Contain("test");
        }
    }
}