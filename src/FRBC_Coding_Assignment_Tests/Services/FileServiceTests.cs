using AutoFixture.Xunit2;
using FluentAssertions;
using FRBC_Coding_Assignment.Services;
using FRBC_Coding_Assignment.Services.Interfaces;
using Moq;
using System.IO;
using Xunit;

namespace FRBC_Coding_Assignment_Tests.Services
{
    public class FileServiceTests
    {
        [Theory]
        [AutoMoqData]
        public void GivenFileName_WhenReadAllTextFromFile_ThenReturnFileAsString(
            FileService service
        )
        {
            // ARRANGE
            var fileName = "../../../TestFile.txt";
            var expected = File.ReadAllText($@"{fileName}");

            // ACT
            var results = service.ReadAllTextFromFile(fileName);

            // ASSERT
            results.Should().NotBeNullOrEmpty();
            results.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [AutoMoqData]
        public void GivenEmptyFileName_WhenReadAllTextFromFile_ThenReturnFileAsString(
            FileService service
        )
        {
            // ARRANGE
            var fileName = string.Empty;

            // ACT
            var results = service.ReadAllTextFromFile(fileName);

            // ASSERT
            results.Should().BeEmpty();
        }

        [Theory]
        [AutoMoqData]
        public void GivenStopWordList_WhenGetStopWords_ThenReturnStopWordsAsArray(
            [Frozen] Mock<IStringCleanerService> stringCleanerServiceMock,
            FileService service
        )
        {
            // ARRANGE
            var fileName = "../../../StopTestFile.txt";
            var expectedString = "test file " +
                "here     more";
            stringCleanerServiceMock.Setup(g => g.RemoveUnicodeCharacters(It.IsAny<string>())).Returns(expectedString);

            // ACT
            var results = service.GetStopWords(fileName);

            // ASSERT
            results.Should().NotBeNullOrEmpty();
            results.Should().NotContain("\n");
            results.Should().NotContain("\t");
        }

        [Theory]
        [AutoMoqData]
        public void GivenEmptyFileName_WhenGetStopWords_ThenReturnEmptyString(
            FileService service
        )
        {
            // ARRANGE
            var fileName = string.Empty;

            // ACT
            var results = service.GetStopWords(fileName);

            // ASSERT
            results.Should().BeEmpty();
        }
    }
}