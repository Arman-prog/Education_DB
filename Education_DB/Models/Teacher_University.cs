using Education_DB.Attributes;
using System;

namespace Education_DB.Models
{
    public class Teacher_University
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int UniversityId { get; set; }
        [Date]
        public DateTime? StartDate { get; set; }
        [Date]
        public DateTime? EndDate { get; set; }
        public int? Hour { get; set; }

        [Ignore]
        public University University { get; set; }
        [Ignore]
        public Teacher Teacher { get; set; }

        public override string ToString()
        {
            return $"{Id}\t{TeacherId}\t{UniversityId}\t{StartDate}\t{EndDate}\t{Hour}";
        }
    }
}
