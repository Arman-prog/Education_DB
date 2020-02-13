using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Education_DB.Contexts
{
    public abstract class BaseContext<TModel> where TModel : new()
    {
        private readonly string connectionString = ConfigurationManager
                                                 .ConnectionStrings["MyConnection"]
                                                 .ConnectionString;
        protected abstract string Sqlexpression { get; }

        public IEnumerable<TModel> AsEnumerable()
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
