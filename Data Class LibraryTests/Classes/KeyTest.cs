using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data_Class_Library.Classes;

namespace Data_Class_Library.Managers.Tests
{
    [TestClass]
    public class KeyTest
    {
        readonly Key keyCorrect = new() { Id = 1, Name = "Key1", Email = "Key1@gmail.com", Phone = "12345678" };
        readonly Key keyNameNull = new() { Id = 2, Name = null, Email = "Key2@gmail.com", Phone = "12345678" };
        readonly Key keyNameTooShort = new() { Id = 3, Name = "Ke", Email = "Key3@gmail.com", Phone = "12345678" };
        readonly Key keyEmailNull = new() { Id = 4, Name = "KeyErGod", Email = null, Phone = "123456" };
        readonly Key keyEmailTooShort = new() { Id = 5, Name = "KeyErGod", Email = "Em", Phone = "123456" };
        readonly Key keyPhoneNull = new() { Id = 6, Name = "KeyErGod", Email = "Email", Phone = null };
        readonly Key keyPhoneTooShort = new() { Id = 7, Name = "KeyErGod", Email = "Email", Phone = "12" };

        [TestMethod]
        public void ValidateName()
        {
            keyCorrect.Validate();
            Assert.ThrowsException<ArgumentNullException>(() => keyNameNull.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => keyNameTooShort.Validate());
        }

        [TestMethod]
        public void ValidateEmail()
        {
            Assert.ThrowsException<ArgumentNullException>(() => keyEmailNull.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => keyEmailTooShort.Validate());
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