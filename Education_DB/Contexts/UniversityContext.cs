using Education_DB.Models;

namespace Education_DB.Contexts
{
    public class UniversityContext : BaseContext<University>
    {
        protected override string Sqlexpression { get; } = "SELECT * FROM University";

    }
}
