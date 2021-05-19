using System;

namespace Shell.ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            Cart cart = new Cart();
            Console.Write("PriceCalculator ");
            string strInput = Console.ReadLine();

            string[] strArray = strInput.Split(" ");
            IProduct product = null;
            double dPrice = 0.0;
            string strDiscountMessage = string.Empty;
            foreach (string strProduct in strArray)
            {
                switch (strProduct)
                {
                    case "Apple":
                        product = new Apple();
                        break;
                    case "Beans":
                        product = new Beans();
                        break;
                    case "Bread":
                        product = new Bread();
                        break;
                    case "Milk":
                        product = new Milk();
                        break;
                    default:
                        break;
                }

                ProductManager manager = new ProductManager(product);
                cart.addItem(product);
            }
            dPrice = cart.GetCartValue();

            var DiscountedPrice = cart.GetDiscountedCartValue();
            strDiscountMessage = DiscountedPrice.Item2 == "" ? "(No offers available)" : DiscountedPrice.Item2;
            Console.WriteLine("Subtotal: £" + dPrice.ToString("N2"));
            Console.WriteLine(strDiscountMessage);
            Console.WriteLine("Total: £" + (dPrice- DiscountedPrice.Item1).ToString("N2"));
            Console.ReadLine();
        }
    }
}
