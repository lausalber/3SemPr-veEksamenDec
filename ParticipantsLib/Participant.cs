using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParticipantsLib
{
    public class Participant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        public void ValidateName()
        {
            if (Name == null)
            {
                throw new ArgumentNullException("Name can't be null");
            }
            if (Name.Length < 2)
            {
                throw new ArgumentOutOfRangeException($"Name has to be at least 2 characters: {Name}");
            }
        }

        public void ValidateAge()
        {
            if (Age < 12)
            {
                throw new ArgumentOutOfRangeException($"Age has to be at least 12: {Age}");
            }
        }

        public void ValidateCountry()
        {
            if (Country == null)
            {
                throw new ArgumentNullException("Country can't be null");
            }
            if (Country.Length < 3)
            {
                throw new ArgumentOutOfRangeException($"Country has to be at least 3 characters: {Country}");
            }
        }

        public void Validate()
        {
            ValidateName();
            ValidateAge();
            ValidateCountry();
        }

        public override string ToString()
        {
            return $"{{{nameof(ID)}={ID.ToString()}, {nameof(Name)}={Name}, {nameof(Age)}={Age.ToString()}, {nameof(Country)}={Country}}}";
        }
    }
}
