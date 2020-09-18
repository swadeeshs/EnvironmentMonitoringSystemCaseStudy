using Xunit;
using receiver.Utils;
namespace Receiver.Tests
{
    public class TestRangeChecker
    {
        private readonly RangeChecker _rangeChecker = new RangeChecker();
        [Fact]
        public void WhenTemperatureIsInNormalRangeThenReturnOkStatusCode()
        {
            
            var temperature = 20;
            Assert.True(_rangeChecker.CheckTemperatureAndReturnStatusCode(temperature) == 0);
            temperature = 37;
            Assert.False(_rangeChecker.CheckTemperatureAndReturnStatusCode(temperature) == 0);
            temperature = 42;
            Assert.False(_rangeChecker.CheckTemperatureAndReturnStatusCode(temperature) == 0);
            temperature = -2;
            Assert.False(_rangeChecker.CheckTemperatureAndReturnStatusCode(temperature) == 0);
        }
        [Fact]
        public void WhenTemperatureIsInWarningRangeThenReturnWarningStatusCode()
        {
            var temperature = 4;
            Assert.True(_rangeChecker.CheckTemperatureAndReturnStatusCode(temperature) == 1);
            temperature = 2;
            Assert.True(_rangeChecker.CheckTemperatureAndReturnStatusCode(temperature) == 1);
            temperature = 0;
            Assert.False(_rangeChecker.CheckTemperatureAndReturnStatusCode(temperature) == 1);
            temperature = 30;
            Assert.False(_rangeChecker.CheckTemperatureAndReturnStatusCode(temperature) == 1);
            temperature = 37;
            Assert.True(_rangeChecker.CheckTemperatureAndReturnStatusCode(temperature) == 1);
            temperature = 40;
            Assert.False(_rangeChecker.CheckTemperatureAndReturnStatusCode(temperature) == 1);
        }
        [Fact]
        public void WhenTemperatureIsInErrorRangeThenReturnErrorStatusCode()
        {
            var temperature = 0;
            Assert.True(_rangeChecker.CheckTemperatureAndReturnStatusCode(temperature) == 2);
            temperature = 2;
            Assert.False(_rangeChecker.CheckTemperatureAndReturnStatusCode(temperature) == 2);
            temperature = 40;
            Assert.True(_rangeChecker.CheckTemperatureAndReturnStatusCode(temperature) == 2);
            temperature = 30;
            Assert.False(_rangeChecker.CheckTemperatureAndReturnStatusCode(temperature) == 2);
            temperature = 37;
            Assert.False(_rangeChecker.CheckTemperatureAndReturnStatusCode(temperature) == 2);
        }

        [Fact]
        public void WhenHumidityIsInNormalRangeThenReturnOkStatusCode()
        {
            var humidity = 50;
            Assert.True(_rangeChecker.CheckHumidityAndReturnStatusCode(humidity) == 0);
            humidity = 70;
            Assert.False(_rangeChecker.CheckHumidityAndReturnStatusCode(humidity) == 0);
            humidity = 90;
            Assert.False(_rangeChecker.CheckHumidityAndReturnStatusCode(humidity) == 0);
        }

        [Fact]
        public void WhenHumidityIsInWarningRangeThenReturnOkStatusCode()
        {
            var humidity = 50;
            Assert.False(_rangeChecker.CheckHumidityAndReturnStatusCode(humidity) == 1);
            humidity = 70;
            Assert.True(_rangeChecker.CheckHumidityAndReturnStatusCode(humidity) == 1);
            humidity = 90;
            Assert.False(_rangeChecker.CheckHumidityAndReturnStatusCode(humidity) == 1);
        }

        [Fact]
        public void WhenHumidityIsInErrorRangeThenReturnOkStatusCode()
        {
            var humidity = 50;
            Assert.False(_rangeChecker.CheckHumidityAndReturnStatusCode(humidity) == 2);
            humidity = 70;
            Assert.False(_rangeChecker.CheckHumidityAndReturnStatusCode(humidity) == 2);
            humidity = 90;
            Assert.True(_rangeChecker.CheckHumidityAndReturnStatusCode(humidity) == 2);
        }
    }
}
