using System.Collections.Generic;
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

        public void InsertToDB(string tablename, params SqlParameter[] parameters)
        {
            var sqlparams = GetParameters(parameters);
            string sqlexpression = string.Format("INSERT INTO {0} ({1}) VALUES ({2})",
                 tablename, sqlparams.Column, sqlparams.Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlexpression, connection);
                command.Parameters.AddRange(parameters);

                command.ExecuteNonQuery();
            }

        }


        private (string Column, string Value) GetParameters(SqlParameter[] parameters)
        {
            StringBuilder columns = new StringBuilder();
            StringBuilder values = new StringBuilder();
            foreach (var parameter in parameters)
            {
                columns.Append(parameter.ParameterName).Append(",");
                values.Append("@").Append(parameter.ParameterName).Append(",");
            }

            return (columns.ToString().TrimEnd(','), values.ToString().TrimEnd(','));
        }



    }
}
