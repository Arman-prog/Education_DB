
namespace Education_DB.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }     
        public string Region { get; set; }    
        public string City { get; set; }   
        public string StreetOrDistrict { get; set; }     
        public string House { get; set; }      
        public int? Appartment { get; set; }

        public override string ToString()
        {
            return $"{Id}\t{Country}\t{Region}\t{City}\t{StreetOrDistrict}\t{House}\t{Appartment}";
        }
    }
}
