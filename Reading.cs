using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Class_Library
{
    public class Reading
    {
        public int Id { get; set; }
        public string MacAddressSensor { get; set; }
        public int OpenedBy { get; set; }
        public string Time = DateTime.Now.ToString();

        public void ValidateMacAddressSensor()
        {

            if (string.IsNullOrWhiteSpace(MacAddressSensor)) throw new ArgumentNullException("Navnet må ikke være tomt");
            if (MacAddressSensor.Length < 3) throw new ArgumentOutOfRangeException("Navnet skal være længere end 1 karakter");
        }

        public void ValidateOpenedBy()
        {
            if (OpenedBy == null) throw new ArgumentNullException("Feltet må ikke være tomt");
            if (OpenedBy < 0) throw new ArgumentOutOfRangeException("Feltet må ikke være negativt");
        }


        public void Validate()
        {
            ValidateMacAddressSensor();
            ValidateOpenedBy();
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(MacAddressSensor)}={MacAddressSensor}, {nameof(OpenedBy)}={OpenedBy.ToString()}, {nameof(Time)}={Time.ToString()}}}";
        }
    }
}
