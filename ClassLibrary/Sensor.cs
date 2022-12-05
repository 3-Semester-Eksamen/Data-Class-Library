namespace Class_Library
{
    public class Sensor
    {
        public string MacAddress { get; set; }
        public string Name { get; set; }

        public void ValidateMacAddress()
        {
            if (string.IsNullOrWhiteSpace(MacAddress)) throw new ArgumentNullException("MacAddresse må ikke være tom");
            if (MacAddress.Length <= 2) throw new ArgumentOutOfRangeException("MacAddresse skal være længere end 2 karakterer lang" + MacAddress);
        }

        public void ValidateName()
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentNullException("Navnet må ikke være tomt");
            if (Name.Length <= 2) throw new ArgumentOutOfRangeException("Navnet skal være længere end 2 karakterer langt");
        }

        public void Validate()
        {
            ValidateMacAddress();
            ValidateName();
        }

        public override string ToString()
        {
            return $"{{{nameof(MacAddress)}={MacAddress}, {nameof(Name)}={Name}}}";
        }
    }
}