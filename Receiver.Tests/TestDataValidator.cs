using Xunit;
using receiver.Utils;
using receiver.Data;
namespace Receiver.Tests
{
    public class TestDataValidator
    {

        private EnvironmentData _environmentData = new EnvironmentData();
        private readonly DataValidator _dataValidator = new DataValidator();

        [Fact]

        public void WhenDataIsValidThenReturnTrue()
        {
            
            const string receivedData = "25.4,70";
            var isValid = _dataValidator.ValidateReceivedData(receivedData, ref _environmentData);
            Assert.True(isValid);
        }

        [Fact]

        public void WhenDataIsInvalidThenReturnFalse()
        {
            var receivedData = "25.4,";
            var isValid = _dataValidator.ValidateReceivedData(receivedData, ref _environmentData);
            Assert.False(isValid);

            receivedData = ",70";
            isValid = _dataValidator.ValidateReceivedData(receivedData, ref _environmentData);
            Assert.False(isValid);

            receivedData = ",";
            isValid = _dataValidator.ValidateReceivedData(receivedData, ref _environmentData);
            Assert.False(isValid);

            receivedData = "File Does not exist";
            isValid = _dataValidator.ValidateReceivedData(receivedData, ref _environmentData);
            Assert.False(isValid);
        }
    }
}
