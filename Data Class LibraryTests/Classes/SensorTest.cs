using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data_Class_Library.Classes;

namespace Data_Class_Library.Managers.Tests
{
    [TestClass]
    public class SensorTest
    {

        readonly Sensor sensorCorrect = new() { Id = 1, MacAddress = "1234", Name = "1234" };

        readonly Sensor sensorIdInvalid = new() { Id = 0, MacAddress = "1234", Name = "1234" };

        readonly Sensor sensorMacNull = new() { Id = 1, MacAddress = null, Name = "1234" };
        readonly Sensor sensorMacTooShort = new() { Id = 1, MacAddress = "123", Name = "1234" };

        readonly Sensor sensorNameNull = new() { Id = 1, MacAddress = "1234", Name = null };
        readonly Sensor sensorNameTooShort = new() { Id = 1, MacAddress = "1234", Name = "123" };


        [TestMethod]
        public void ValidateIdTest()
        {
            sensorCorrect.Validate();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sensorIdInvalid.Validate());
        }

        [TestMethod]
        public void ValidateMacAddress()
        {
            sensorCorrect.Validate();
            Assert.ThrowsException<ArgumentNullException>(() => sensorMacNull.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sensorMacTooShort.Validate());
        }

        [TestMethod]
        public void ValidateName()
        {
            sensorCorrect.Validate();
            Assert.ThrowsException<ArgumentNullException>(() => sensorNameNull.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sensorNameTooShort.Validate());
        }

        [TestMethod]
        public void ValidateTest()
        {
            sensorCorrect.Validate();
            Assert.ThrowsException<ArgumentNullException>(() => sensorMacNull.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sensorMacTooShort.Validate());
            Assert.ThrowsException<ArgumentNullException>(() => sensorNameNull.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sensorNameTooShort.Validate());
        }

        [TestMethod]
        public void ToStringTest()
        {
            string str = sensorCorrect.ToString();
            Assert.AreEqual("{MacAddress=1234, Name=1234}", str);
        }
    }
}
