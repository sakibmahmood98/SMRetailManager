using SMRDesktopUI.Models;
using System.Threading.Tasks;

namespace SMRDesktopUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}