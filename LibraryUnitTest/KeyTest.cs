using Eksamen_ClassLibrary;
using System.Numerics;
using System.Xml.Linq;

namespace LibraryUnitTest
{
    [TestClass]
    public class KeyTest
    {
        Key keyCorrect = new Key { Id = 1, Name = "Key1", Email = "Key1@gmail.com", Phone = "12345678" };
        Key keyNameNull = new Key { Id = 2, Name = null, Email = "Key2@gmail.com", Phone = "12345678" };
        Key keyNameTooShort = new Key { Id = 3, Name = "Ke", Email = "Key3@gmail.com", Phone = "12345678" };
        Key keyEmailNull = new Key { Id = 4, Name = "KeyErGod", Email = null, Phone = "123456" };
        Key keyEmailTooShort = new Key { Id = 5, Name = "KeyErGod", Email = "Em", Phone = "123456" };
        Key keyPhoneNull = new Key { Id = 6, Name = "KeyErGod", Email = "Email", Phone = null };
        Key keyPhoneTooShort = new Key { Id = 7, Name = "KeyErGod", Email = "Email", Phone = "12" };

        [TestMethod]
        public void ValidateName()
        {
            keyCorrect.ValidateName();
            Assert.ThrowsException<ArgumentNullException>(() => keyNameNull.ValidateName());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => keyNameTooShort.ValidateName());
        }

        [TestMethod]
        public void ValidateEmail()
        {
            Assert.ThrowsException<ArgumentNullException>(() => keyEmailNull.ValidateEmail());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => keyEmailTooShort.ValidateEmail());
        }

        [TestMethod]
        public void ValidatePhone()
        {
            Assert.ThrowsException<ArgumentNullException>(() => keyPhoneNull.ValidatePhone());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => keyPhoneTooShort.ValidatePhone());
        }

        [TestMethod]
        public void ValidateTest()
        {
            keyCorrect.Validate();
            Assert.ThrowsException<ArgumentNullException>(() => keyNameNull.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => keyNameTooShort.Validate());
            Assert.ThrowsException<ArgumentNullException>(() => keyEmailNull.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => keyEmailTooShort.Validate());
            Assert.ThrowsException<ArgumentNullException>(() => keyPhoneNull.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => keyPhoneTooShort.Validate());
        }

        [TestMethod]
        public void ToStringTest()
        {
            string str = keyCorrect.ToString();
            Assert.AreEqual("{Id=1, Name=Key1, Email=Key1@gmail.com, Phone=12345678}", str);
        }
    }
}