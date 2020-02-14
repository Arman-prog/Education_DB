using System;
using Education_DB.Contexts;
using System.Linq;
using Education_DB.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace Education_Database
{
    class Program
    {
        static readonly string connectionString = ConfigurationManager
                                                   .ConnectionStrings["MyConnection"]
                                                   .ConnectionString;
        static void Main()
        {
           
            var context = new DBContext(connectionString);
            /*
           var students = context.AsEnumerable<Student>("SELECT * FROM Student").ToList();
           var teachers = context.AsEnumerable<Teacher>("SELECT * FROM Teacher").ToList();
           var universities = context.AsEnumerable<University>("SELECT * FROM University").ToList();
           var addresses = context.AsEnumerable<Address>("SELECT * FROM Address").ToList();
           var teachersuniversity = context.AsEnumerable<Teacher_University>("SELECT * FROM Teacher_University").ToList();

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

           */
          
            //SqlParameter par1 = new SqlParameter("Name", "Mashtoci");
            //SqlParameter par2 = new SqlParameter("DestroyDate", new DateTime(2020,12,20));
            //SqlParameter par3 = new SqlParameter("PhoneNumber", "+37400000");
            //SqlParameter par4 = new SqlParameter("Gender", 1);
            //context.Insert("University", par1,par2);

            //context.Update("University","Name", "Slavonakan","Mashtoc");

            //context.Delete("Student", "FirstName", "Edik");
        }


    }
}
