using System.Collections.Generic;
using System.Data;
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

        public int Insert(string tablename, params SqlParameter[] parameters)
        {
            var sqlparams = GetInsertParams(parameters);
            string sqlexpression = string.Format(Queries.insertWithParams, tablename, sqlparams.Column, sqlparams.Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                SqlCommand command = new SqlCommand(sqlexpression, connection);
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.AddRange(parameters);
                command.Parameters.Add(idParam);

                command.ExecuteScalar();

                return (int)idParam.Value;
            }
        }

        public void Update(string tablename, int id, params SqlParameter[] parameter)
        {
            string sqlparams = GetUpdateParams(parameter);
            string sqlexpression = string.Format(Queries.updateWithParam,
                 tablename, sqlparams, id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                SqlCommand command = new SqlCommand(sqlexpression, connection);
                command.Parameters.AddRange(parameter);
                command.ExecuteNonQuery();
            }

        }

        public void Delete(string tablename, SqlParameter parameter)
        {
            string sqlexpression = string.Format(Queries.deleteWithParam, tablename, parameter.Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                SqlCommand command = new SqlCommand(sqlexpression, connection);
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
            }

        }


        private (string Column, string Value) GetInsertParams(SqlParameter[] parameters)
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

        private string GetUpdateParams(SqlParameter[] parameters)
        {
            StringBuilder updatevalues = new StringBuilder();
            foreach (var parameter in parameters)
            {

                updatevalues.Append("[").Append(parameter.ParameterName).Append("]")
                    .Append("=").Append("@").Append(parameter.ParameterName).Append(",");
            }

            return updatevalues.ToString().TrimEnd(',');
        }

    }
}
