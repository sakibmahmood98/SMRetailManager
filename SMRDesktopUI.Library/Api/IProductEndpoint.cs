using SMRDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMRDesktopUI.Library.Api
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
    }
}