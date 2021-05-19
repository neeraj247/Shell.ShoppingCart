using System;
using System.Collections.Generic;
using System.Text;

namespace Shell.ShoppingCart
{
    public interface ICart
    {
        public void addItem(IProduct product);
        public double GetCartValue();
        public (double,string) GetDiscountedCartValue();
    }
    public class Cart : ICart
    {
        public List<IProduct> _product { get; set; }

        public void addItem(IProduct product)
        {
            if (_product == null)
            {
                _product = new List<IProduct>();
                product.nQualtity = 1;
                _product.Add(product);
            }
            else
            {
                if (_product.FindAll(e => e.Name() == product.Name()).Count == 0)
                {
                    product.nQualtity = 1;
                    _product.Add(product);
                }
                else
                {
                    int i = _product.FindIndex(e => e.Name() == product.Name());
                    _product[i].nQualtity++;
                }
            }
        }

        public double GetCartValue()
        {
            double d = 0.0;
            foreach (var item in _product)
                d += item.GetPrice() * item.nQualtity;

            return d;
        }

        public (double, string) GetDiscountedCartValue()
        {
            string strMessage = string.Empty;
            DiscountedProduct DP = new PercentageDiscount().getDiscount();
            double discount = 0.0;
            if(_product.FindAll(e => e.ID == DP.ID).Count > 0)
            {
                IProduct product = _product[0];
                discount = (product.GetPrice() * product.nQualtity) * DP.DiscountPercentage;
                strMessage = "Apples 10% off: -" + discount * 100 + "p \r\n";
            }

            DP = new HalfPriceDiscount().getDiscount();
            if ((_product.FindAll(e => e.ID == DP.ID).Count > 0) && (_product.Find(e => e.ID == DP.ID).nQualtity >= 2))
            {
                IProduct product = _product.Find(e => e.ID == 103);
                if (product != null)
                {
                    discount += (product.GetPrice() * product.nQualtity) * DP.DiscountPercentage;
                    strMessage += "Bread 50% off: -" + discount * 100 + "p";
                }
            }
            else
                strMessage = strMessage.Replace("\r\n", "");

            return (discount, strMessage);
        }
    }
}
