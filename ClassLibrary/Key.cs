using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library
{
    public class Key
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public void ValidateName()
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentNullException("Navnet må ikke være tomt");
            if (Name.Length < 3) throw new ArgumentOutOfRangeException("Navnet skal være længere end 1 karakter");
        }

        public void ValidateEmail()
        {
            if (string.IsNullOrWhiteSpace(Email)) throw new ArgumentNullException("Email må ikke være tomt");
            if (Email.Length < 3) throw new ArgumentOutOfRangeException("Email skal være længere end 1 karakter");
        }

        public void ValidatePhone()
        {
            if (string.IsNullOrWhiteSpace(Phone)) throw new ArgumentNullException("Telefon må ikke være tomt");
            if (Phone.Length < 3) throw new ArgumentOutOfRangeException("Telefon skal være længere end 1 karakter");
        }

        public void Validate()
        {
            ValidateName();
            ValidateEmail();
            ValidatePhone();
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Email)}={Email}, {nameof(Phone)}={Phone}}}";
        }
    }
}
