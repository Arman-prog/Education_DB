using Education_DB.Models;

namespace Education_DB.Contexts
{
   public class AddressContext : BaseContext<Address>
    {
        protected override string Sqlexpression { get; } = "SELECT * FROM Address";

    }
}
