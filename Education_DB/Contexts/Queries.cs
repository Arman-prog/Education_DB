
namespace Education_DB.Contexts
{
    public class Queries
    {
        public const string insertWithParams = "INSERT INTO {0} ({1}) VALUES ({2});SET @id=SCOPE_IDENTITY()";
        public const string updateWithParam = "UPDATE {0} SET {1} WHERE Id={2}";
        public const string deleteWithParam = "DELETE FROM {0} WHERE Id='{1}'";
    }
}
