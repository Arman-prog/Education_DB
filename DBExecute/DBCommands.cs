using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBExecute
{
    public class DBCommands
    {
        private readonly string connectionString;
        //;SET @id=SCOPE_IDENTITY()"
        public DBCommands(string connectionString)
        {
            this.connectionString = connectionString;
        }

        



      
    }
}
