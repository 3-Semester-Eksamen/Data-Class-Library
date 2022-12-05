using Data_Class_Library.Classes;

namespace LibraryUnitTest
{
    [TestClass]
    public class SensorTest
    {

        readonly Sensor sensorCorrect = new() { MacAddress = "QWERTY", Name = "Sensor1" };
        readonly Sensor sensorMacNull = new() { MacAddress = null, Name = "Sensor1" };
        readonly Sensor sensorMacTooShort = new() { MacAddress = "Q", Name = "Sensor1" };
        readonly Sensor sensorNameNull = new() { MacAddress = "QWERTY", Name = null };
        readonly Sensor sensorNameTooShort = new() { MacAddress = "QWERTY", Name = "S" };

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
            Assert.AreEqual("{MacAddress=QWERTY, Name=Sensor1}", str);
        }
    }
}
