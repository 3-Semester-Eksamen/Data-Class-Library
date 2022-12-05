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
        public int? Id { get; set; }
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
            ValidateMacAddress();
            ValidateName();
        }

        #region Validator Methods
        /// <summary>
        /// Method that validates the MacAdress.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void ValidateMacAddress()
        {
            if (string.IsNullOrWhiteSpace(MacAddress)) throw new ArgumentNullException("MacAddresse må ikke være tom");
            if (MacAddress.Length <= 2) throw new ArgumentOutOfRangeException("MacAddresse skal være længere end 2 karakterer lang" + MacAddress);
        }
        /// <summary>
        /// Method that validates the Name.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void ValidateName()
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentNullException("Navnet må ikke være tomt");
            if (Name.Length <= 2) throw new ArgumentOutOfRangeException("Navnet skal være længere end 2 karakterer langt");
        }
        #endregion

        public override string ToString()
        {
            return $"{{{nameof(MacAddress)}={MacAddress}, {nameof(Name)}={Name}}}";
        }
        #endregion

        /*
                

                

                public void Validate()
                {
                    ValidateMacAddress();
                    ValidateName();
                }

                */
    }
}