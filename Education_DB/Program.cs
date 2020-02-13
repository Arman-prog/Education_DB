using System;
using Education_DB.Contexts;
using System.Linq;

namespace Education_Database
{
    class Program
    {
        static void Main()
        {
            var studentcontext = new StudentContext();
            var students = studentcontext.AsEnumerable().ToList();

            var teachercontext = new TeacherContext();
            var teachers = teachercontext.AsEnumerable().ToList();

            var universitycontext = new UniversityContext();
            var universities = universitycontext.AsEnumerable().ToList();

            var addresscontext = new AddressContext();
            var addresses = addresscontext.AsEnumerable().ToList();

            var teacher_Universitycontext = new Teacher_UniversityContext();
            var teachersuniversity = teacher_Universitycontext.AsEnumerable().ToList();

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
