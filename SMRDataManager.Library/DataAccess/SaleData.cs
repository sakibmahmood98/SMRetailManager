using SMRDataManager.Library.Internal.DataAccess;
using SMRDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMRDataManager.Library.DataAccess
{
    public class SaleData
    {

        public void SaveSale(SaleModel saleInfo, string cashierId)
        {
            //TODO: Make this SOLID/DRY?Better
            //Start filling in the sale detal models we will save to the database

            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();
            ProductData products = new ProductData();
            var taxRate = ConfigHelper.GetTaxRate()/100;

            foreach (var item in saleInfo.SaleDetails)
            {
                var detail = new SaleDetailDBModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };

                //Get the information about this product
                var productInfo = products.GetProductById(detail.ProductId);

                if(productInfo == null)
                {
                    throw new Exception($"The product if of {detail.ProductId} could not be found in the database ");
                }


                detail.PurchasePrice = ( productInfo.RetailPrice * detail.Quantity);

                if(productInfo.IsTaxable)
                {
                    detail.Tax = (detail.PurchasePrice * taxRate);
                }

                details.Add(detail);
            }


            //Create the sale model
            SaleDBModel sale = new SaleDBModel
            {
                SubTotal = details.Sum(x=> x.PurchasePrice),
                Tax = details.Sum(x=> x.Tax),
                CashierId = cashierId
            };

            sale.Total = sale.SubTotal + sale.Tax;

            //Save the sale model
            SqlDataAccess sql = new SqlDataAccess();

            sql.SaveData("dbo.spSale_Insert", sale, "SMData");

            //Get the ID from the sale mode

            sale.Id = sql.LoadData<int, dynamic>("dbo.spSale_Lookup", new {  sale.CashierId, sale.SaleDate}, "SMData").FirstOrDefault();

            //Finish filling in the sale detail models

            foreach (var item in details)
            {
                item.SaleId = sale.Id;
                sql.SaveData("dbo.spSaleDetail_Insert", item, "SMData");
            }



            //Save the sale detail models
            
        }




        /*public List<ProductModel> GetProducts()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetAll", new { }, "SMData");

            return output;
        }*/
    }
}
