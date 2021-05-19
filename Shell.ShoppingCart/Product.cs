using System;
using System.Collections.Generic;
using System.Text;

namespace Shell.ShoppingCart
{
    public interface IProduct
    {
        public int nQualtity { get; set; }
        public int ID { get; }
        public string Name();
        public double GetPrice();
    }

    public class DiscountedProduct
    {
        public int ID { get; set; }
        public double DiscountPercentage { get; set; }
        public int AssociatedProdID { get; set; }
        public int Quantity { get; set; }
    }

    public class Apple : IProduct
    {
        public int ProdID = 101;

        public int nQualtity { get ; set; }
        public int ID { get => ProdID; }

        public string Name()
        {
            return "Apple";
        }
        public double GetPrice()
        {
            return 1.0;
        }
    }

    public class Beans : IProduct
    {
        public int ID = 102;
        public int nQualtity { get; set; }
        int IProduct.ID => ID;

        public string Name()
        {
            return "Beans";
        }
        public double GetPrice()
        {
            return 0.7;
        }
    }

    public class Bread : IProduct
    {
        public int nQualtity { get; set; }

        int IProduct.ID => ID;

        public int ID = 103;
        public string Name()
        {
            return "Bread";
        }
        public double GetPrice()
        {
            return 0.8;
        }
    }

    public class Milk : IProduct
    {
        public int ID = 104;
        public int nQualtity { get; set; }
        int IProduct.ID => ID;
        public string Name()
        {
            return "Milk";
        }
        public double GetPrice()
        {
            return 1.3;
        }
    }
}
