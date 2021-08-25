using SMRDesktopUI.Library.Models;
using System.Threading.Tasks;

namespace SMRDesktopUI.Library.Api
{
    public interface ISaleEndpoint
    {
        Task PostSale(SaleModel sale);
    }
}