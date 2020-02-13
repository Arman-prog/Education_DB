using Education_DB.Models;

namespace Education_DB.Contexts
{
    public class TeacherContext : BaseContext<Teacher>
    {
        protected override string Sqlexpression { get; } = "SELECT * FROM Teacher";

    }
}
