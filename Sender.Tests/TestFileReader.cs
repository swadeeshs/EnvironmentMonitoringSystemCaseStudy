using System.IO;
using Xunit;
using sender.Utils;

namespace Sender.Tests
{
    public class TestFileReader
    {
        private readonly FileReader _fileReader = new FileReader();
        
        [Fact]
        public void WhenInputCsvFileIsNotFoundThenReturnNull()
        {
            var data = _fileReader.ReadCsv(@"dummy\path\file.csv");
            Assert.Null(data);
        }

        [Fact]

        public void WhenInputCsvFileIsEmptyThenReturnEmptyList()
        {
            var data = _fileReader.ReadCsv($@"{Directory.GetCurrentDirectory()}\empty-environment-data.csv");
            Assert.Null(data);
        }
        
        [Fact]
        public void WhenInputCsvFileIsPresentThenReturnDataList()
        {
            var data = _fileReader.ReadCsv($@"{Directory.GetCurrentDirectory()}\test-environment-data.csv");
            Assert.True(data.Count > 0);
        }
    }

    

}
