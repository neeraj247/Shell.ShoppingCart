using System;
using System.Collections.Generic;
using System.Text;

namespace Shell.ShoppingCart
{
    public class ProductManager
    {
        IProduct _product;
        public ProductManager(IProduct product)
        {
            _product = product;
        }

        public double getPrice()
        {
            return _product.GetPrice();
        }
    }
}
