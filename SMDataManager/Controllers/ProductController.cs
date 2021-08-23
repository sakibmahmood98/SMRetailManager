using SMRDataManager.Library.DataAccess;
using SMRDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMDataManager.Controllers
{
    public class ProductController : ApiController
    {
        [Authorize]
        public List<ProductModel> Get()
        {

            ProductData data = new ProductData();
            return data.GetProducts();
        }


    }
}
