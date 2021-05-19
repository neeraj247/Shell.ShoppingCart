using System;
using System.Collections.Generic;
using System.Text;

namespace Shell.ShoppingCart
{
    public interface IDiscount
    {
        public DiscountedProduct getDiscount();
    }
    public class PercentageDiscount : IDiscount
    {
        public DiscountedProduct getDiscount()
        {
            return new DiscountedProduct() { ID = 101, DiscountPercentage = .1 };
        }
    }

    public class HalfPriceDiscount : IDiscount
    {
        public DiscountedProduct getDiscount()
        {
            return new DiscountedProduct() { ID = 102, Quantity = 2, DiscountPercentage = .5, AssociatedProdID = 103 };
        }
    }
}