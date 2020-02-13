using System;
using Education_DB.Contexts;
using System.Linq;
using Education_DB.Models;
using System.Configuration;

namespace Education_Database
{
    class Program
    {
        static readonly string connectionString = ConfigurationManager
                                                   .ConnectionStrings["MyConnection"]
                                                   .ConnectionString;
        static void Main()
        {
            var studentcontext = new DBContext(connectionString);
            var students = studentcontext.AsEnumerable<Student>("SELECT * FROM Student").ToList();

            var teachercontext = new DBContext(connectionString);
            var teachers = teachercontext.AsEnumerable<Teacher>("SELECT * FROM Teacher").ToList();

            var universitycontext = new DBContext(connectionString);
            var universities = universitycontext.AsEnumerable<University>("SELECT * FROM University").ToList();

            var addresscontext = new DBContext(connectionString);
            var addresses = addresscontext.AsEnumerable<Address>("SELECT * FROM Address").ToList();

            var teacher_Universitycontext = new DBContext(connectionString);
            var teachersuniversity = teacher_Universitycontext.AsEnumerable<Teacher_University>("SELECT * FROM Teacher_University").ToList();

            var query1 = from s in students
                         from u in universities
                         where u.Id == s.UniversityId
                         from a in addresses
                         where a.Id == s.AddressId
                         select (s.FirstName, s.LastName,
                                 a.City, a.StreetOrDistrict, a.House, a.Appartment,
                                 u.Name);

            var stquery = query1.ToList();

            var query2 = from tu in teachersuniversity
                         from t in teachers
                         where t.Id == tu.TeacherId
                         from u in universities
                         where u.Id == tu.UniversityId
                         from a in addresses
                         where a.Id == u.AddressId
                         select (t.FirstName, t.LastName,
                                u.Name, a.City);

            var teachersquery = query2.ToList();


            Console.WriteLine("QUERY - Students\n");
            foreach (var item in stquery)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("QUERY - Teachers\n");
            foreach (var item in teachersquery)
            {
                Console.WriteLine(item);
            }
        }
    }
}
