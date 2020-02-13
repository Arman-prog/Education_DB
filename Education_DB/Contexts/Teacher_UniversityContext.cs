using Education_DB.Models;

namespace Education_DB.Contexts
{
    class Teacher_UniversityContext : BaseContext<Teacher_University>
    {
        protected override string Sqlexpression { get; } = "SELECT * FROM Teacher_University";
    }
}
