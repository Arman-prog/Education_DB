using Education_DB.Attributes;

namespace Education_DB.Models
{
    public class Student
    {        
        public int Id { get; set; }      
        public string FirstName { get; set; }       
        public string LastName { get; set; }      
        public string PhoneNumber { get; set; }
        public string Email { get; set; }      
        public byte Gender { get; set; }
        public int? UniversityId { get; set; }
        public int? AddressId { get; set; }

        [Ignore]
        public University University { get; set; }
        [Ignore]
        public Address Address { get; set; }

        public override string ToString()
        {
            return $"{Id}\t{FirstName}\t{LastName}\t{PhoneNumber}\t{Email}\t{Gender}\t{UniversityId}\t{AddressId}";
        }
    }
}
