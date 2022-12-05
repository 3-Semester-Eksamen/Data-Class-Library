using Eksamen_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUnitTest
{
    [TestClass]
    public class SensorTest
    {
        Sensor sensorCorrect = new Sensor { MacAddress = "QWERTY", Name = "Sensor1" };
        Sensor sensorMacNull = new Sensor { MacAddress = null, Name = "Sensor1" };
        Sensor sensorMacTooShort = new Sensor { MacAddress = "Q", Name = "Sensor1" };
        Sensor sensorNameNull = new Sensor { MacAddress = "QWERTY", Name = null };
        Sensor sensorNameTooShort = new Sensor { MacAddress = "QWERTY", Name = "S" };

        [TestMethod]
        public void ValidateMacAddress()
        {
            sensorCorrect.ValidateMacAddress();
            Assert.ThrowsException<ArgumentNullException>(() => sensorMacNull.ValidateMacAddress());
            Assert.ThrowsException<ArgumentOutOfRangeException> (() => sensorMacTooShort.ValidateMacAddress());
        }

        [TestMethod]
        public void ValidateName()
        {
            sensorCorrect.ValidateName();
            Assert.ThrowsException<ArgumentNullException>(() => sensorNameNull.ValidateName());
            Assert.ThrowsException<ArgumentOutOfRangeException> (() => sensorNameTooShort.ValidateName());
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
