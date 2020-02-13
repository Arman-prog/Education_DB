using Education_DB.Models;

namespace Education_DB.Contexts
{
    public class StudentContext : BaseContext<Student>
    {
        protected override string Sqlexpression { get; } = "SELECT * FROM Student";

    }
}
