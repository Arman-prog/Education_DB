using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace Education_DB.Contexts
{
    public class DBContext
    {
        private readonly string connectionString;

        public DBContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<TModel> AsEnumerable<TModel>(string Sqlexpression)
            where TModel : class, new()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(Sqlexpression, connection);
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    yield return dataReader.ToModel<TModel>();
                }

                dataReader.Close();
            }

        }

        public void InsertToDB(string tablename, string[] columns, params SqlParameter[] parameters)
        {
            var sqlparams = GetParameters(parameters);
            string columnsnames = GetColumns(columns);
            string sqlexpression = string.Format("INSERT INTO {0} ({1}) VALUES ({2})",
                 tablename, columnsnames, sqlparams.Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlexpression, connection);
                command.Parameters.AddRange(parameters);

                command.ExecuteNonQuery();
            }

        }


        private (string Name, string Value) GetParameters(SqlParameter[] parameters)
        {
            StringBuilder names = new StringBuilder();
            StringBuilder values = new StringBuilder();
            foreach (var parameter in parameters)
            {
                names.Append(parameter.ParameterName).Append(",");
                values.Append("@").Append(parameter.ParameterName).Append(",");
            }

            return (names.ToString().TrimEnd(','), values.ToString().TrimEnd(','));
        }

        private string GetColumns(string[] columns)
        {
            StringBuilder columnsnames = new StringBuilder();
            foreach (var item in columns)
            {
                columnsnames.Append(item).Append(',');
            }

            return columnsnames.ToString().TrimEnd(',');
        }

    }
}
