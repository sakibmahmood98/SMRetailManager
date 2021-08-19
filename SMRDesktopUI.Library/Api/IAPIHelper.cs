
using SMRDesktopUI.Models;
using System.Threading.Tasks;

namespace SMRDesktopUI.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}