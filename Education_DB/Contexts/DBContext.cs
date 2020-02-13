using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

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

    }
}
