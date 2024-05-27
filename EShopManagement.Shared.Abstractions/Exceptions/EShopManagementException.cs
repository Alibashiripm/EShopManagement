
namespace EShopManagement.Shared.Abstractions.Exceptions
{
    public abstract class EShopManagementException : Exception
    {
        protected EShopManagementException(string message) : base(message)
        {

        }
    }
}
