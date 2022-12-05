using Data_Class_Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Class_Library.Classes
{
    /// <summary>
    /// Key class.
    /// </summary>
    public class Key : IIdentity, IValidate
    {

        #region Properties
        /// <summary>
        /// Id of the Key.
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Name of the Key.
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Email of the Key.
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// PhoneNumber of the Key.
        /// </summary>
        public string? Phone { get; set; }
        #endregion

        #region Constructor
        public Key()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Validate Method that calls the individual Validator Methods.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Validate()
        {
            ValidateName();
            ValidateEmail();
            ValidatePhone();
        }

        #region Validator Methods
        /// <summary>
        /// Method that validates the Name.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void ValidateName()
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentNullException("Name cannot be null or empty.");
            if (Name.Length < 3) throw new ArgumentOutOfRangeException("Name has to be atleast 4 characters.");
        }
        /// <summary>
        /// Method that validates the Email.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void ValidateEmail()
        {
            if (string.IsNullOrWhiteSpace(Email)) throw new ArgumentNullException("Email cannot be null or empty.");
            if (Email.Length < 3) throw new ArgumentOutOfRangeException("Email has to be atleast 4 characters.");
        }
        /// <summary>
        /// Method that validates the PhoneNumber
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void ValidatePhone()
        {
            if (string.IsNullOrWhiteSpace(Phone)) throw new ArgumentNullException("Phone number cannot be null or empty.");
            if (Phone.Length < 3) throw new ArgumentOutOfRangeException("Phone number has to be atleast 4 characters.");
        }
        #endregion
        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id}, {nameof(Name)}={Name}, {nameof(Email)}={Email}, {nameof(Phone)}={Phone}}}";
        }
        #endregion
    }
}
