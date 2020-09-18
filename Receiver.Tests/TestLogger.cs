using Xunit;
using receiver.Utils;
namespace Receiver.Tests
{
    public class TestLogger
    {
        private readonly Logger _logger = new Logger();
        [Fact]
        public void WhenStatusCodeIs0ThenPrintOkMessage()
        {
            var message = "Temperature: ";
            const int statusCode = 0;
            _logger.LoggingToConsole(statusCode,ref message);
            var isFalse=message.Equals("Temperature: Warning");
            Assert.False(isFalse);
            
            var isTrue= message.Equals("Temperature: OK");
            Assert.True(isTrue);

            message = "Humidity: ";
            _logger.LoggingToConsole(statusCode, ref message);
            isTrue = message.Equals("Humidity: OK");
            Assert.True(isTrue);
        }
        [Fact]
        public void WhenStatusCodeIs1ThenPrintWarningMessage()
        {
            var message = "Temperature: ";
            var statusCode = 1;
            _logger.LoggingToConsole(statusCode, ref message);
            
            var isFalse = message.Equals("Temperature: Error");
            Assert.False(isFalse);

             isFalse = message.Equals("Temperature: OK");
            Assert.False(isFalse);

            var isTrue = message.Equals("Temperature: Warning");
            Assert.True(isTrue);

            statusCode = 2;
            _logger.LoggingToConsole(statusCode, ref message);
            isFalse = message.Equals("Temperature: Warning");
            Assert.False(isFalse);

            statusCode = 1;
            message = "Humidity: ";
            _logger.LoggingToConsole(statusCode, ref message);
            isTrue = message.Equals("Humidity: Warning");
            Assert.True(isTrue);
        }

        [Fact]
        public void WhenStatusCodeIs2ThenPrintErrorMessage()
        {
            var message = "Temperature: ";
            var statusCode = 2;
            _logger.LoggingToConsole(statusCode, ref message);

            var isTrue = message.Equals("Temperature: Error");
            Assert.True(isTrue);

            var isFalse = message.Equals("Temperature: OK");
            Assert.False(isFalse);

            statusCode = 1;
            _logger.LoggingToConsole(statusCode, ref message);
            isFalse = message.Equals("Temperature: Error");
            Assert.False(isFalse);

            statusCode = 2;
            message = "Humidity: ";
            _logger.LoggingToConsole(statusCode, ref message);
            isTrue = message.Equals("Humidity: Error");
            Assert.True(isTrue);
        }

        [Fact]
        public void WhenStatusCodeIsInvalidThenPrintExceptionMessage()
        {
            var message = "Temperature: ";
            var statusCode = 3;
            _logger.LoggingToConsole(statusCode, ref message);

            var isTrue = message.Equals("Temperature: Not A valid Status Code");
            Assert.True(isTrue);

            statusCode = -1;
            message = "Temperature: ";
            _logger.LoggingToConsole(statusCode, ref message);
            isTrue = message.Equals("Temperature: Not A valid Status Code");
            Assert.True(isTrue);

            message = "Humidity: ";
            _logger.LoggingToConsole(statusCode, ref message);
            isTrue = message.Equals("Humidity: Not A valid Status Code");
            Assert.True(isTrue);
        }
    }
}