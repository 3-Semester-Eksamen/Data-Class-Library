using Data_Class_Library.Interfaces;
using System.Net.Mail;
using System.Xml.Linq;

namespace Data_Class_Library.Classes
{
    /// <summary>
    /// Sensor Class. Which is defined as the "Lock".
    /// </summary>
    public class Sensor : IIdentity, IValidate
    {



        #region Properties
        /// <summary>
        /// Id of the Sensor.
        /// </summary>
        public int Id { get; set; } = 0;
        /// <summary>
        /// MacAddress of the Sensor.
        /// </summary>
        public string? MacAddress { get; set; }
        /// <summary>
        /// Name of the Sensor.
        /// </summary>
        public string? Name { get; set; }
        #endregion

        #region Constructor
        public Sensor()
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
            ValidateId();
            ValidateMacAddress();
            ValidateName();
        }

        #region Validator Methods
        /// <summary>
        /// Method that validates the Id.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void ValidateId()
        {
            if (Id < 1) throw new ArgumentOutOfRangeException("Id has to be atleast 1.");
        }
        /// <summary>
        /// Method that validates the MacAdress.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void ValidateMacAddress()
        {
            if (string.IsNullOrEmpty(MacAddress)) throw new ArgumentNullException("MacAddress cannot be null or empty.");
            if (MacAddress.Length < 4) throw new ArgumentOutOfRangeException("MacAddress has to be atleast 4 characters.");
        }
        /// <summary>
        /// Method that validates the Name.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void ValidateName()
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentNullException("Name cannot be null or empty.");
            if (Name.Length < 4) throw new ArgumentOutOfRangeException("Name has to be atleast 4 characters.");
        }
        #endregion

        public override string ToString()
        {
            return $"{{{nameof(MacAddress)}={MacAddress}, {nameof(Name)}={Name}}}";
        }
        #endregion

    }
}