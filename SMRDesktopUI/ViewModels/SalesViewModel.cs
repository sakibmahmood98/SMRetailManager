using Caliburn.Micro;
using SMRDesktopUI.Library.Api;
using SMRDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMRDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        IProductEndpoint _productEndpoint;


        public SalesViewModel(IProductEndpoint productEndpoint)
        {
            _productEndpoint = productEndpoint;
            
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadProducts();
        }

        private async Task LoadProducts()
        {
            var productList = await _productEndpoint.GetAll();
            Products = new BindingList<ProductModel>(productList);
        }






        private BindingList<ProductModel> _products;
        public BindingList<ProductModel> Products
        {
            get { return _products;  }
            set 
            { 
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }

        }


        private BindingList<ProductModel> _cart;
        public BindingList<ProductModel> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }

        }


        private string _itemQuantity;

        public string ItemQuantity
        {
            get { return _itemQuantity;  }
            set 
            { 
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            
            }
        }


        public string SubTotal
        {
            get
            {
                //TODO - replace with calculation
                return "$0.00";
            }
        }

        public string Tax
        {
            get
            {
                //TODO - replace with calculation
                return "$0.00";
            }
        }

        public string Total
        {
            get
            {
                //TODO - replace with calculation
                return "$0.00";
            }
        }


        public bool CanAddToCart
        {
            get
            {
                bool output = false;
                //Make sure something is selected
                //make sure there is an item quantity
                return output; 
            }
        }

        public void AddToCart()
        {

        }

        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;
                //Make sure something is selected

                return output;
            }
        }

        public void RemoveFromCart()
        {

        }

        public bool CanCheckOut
        {
            get
            {
                bool output = false;
                //Make sure something is selected

                return output;
            }
        }

        public void CheckOut()
        {

        }



    }
}
