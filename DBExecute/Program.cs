using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBExecute
{
    class Program
    {
        static readonly string connectionString = ConfigurationManager
                                                  .ConnectionStrings["MyConnection"]
                                                  .ConnectionString;
        static void Main(string[] args)
        {
            DBCommands commands = new DBCommands(connectionString);
            SqlParameter par1 = new SqlParameter("FirstName", "Araik");
            SqlParameter par2 = new SqlParameter("LastName", "Miqaelyan");
            SqlParameter par3 = new SqlParameter("PhoneNumber", "+3749999");
            commands.InsertToDB("Student", par1, par2, par3);
        }
    }
}
