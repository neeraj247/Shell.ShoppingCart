using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shell.ShoppingCart.UnitTest
{
    [TestClass]
    public class ShoppingCartTest
    {
        Cart cart = null;
        IProduct product = null;
        double dPrice = 0.0;
        string[] strInputArray = null;

        [TestInitialize]
        public void CartInitialize()
        {
            strInputArray = "Apple Bread, Beans Milk".Split(" ");
            cart = new Cart();
        }
        [TestMethod]
        public void BuildCart()
        {
            product = new Apple();
            ProductManager manager = new ProductManager(product);
            cart.addItem(product);
            Assert.IsNotNull(cart._product);
            Assert.IsTrue(cart._product.Count > 0);
        }

        [TestMethod]
        public void BuildCartWithSingleItem()
        {
            product = new Apple();
            ProductManager manager = new ProductManager(product);
            cart.addItem(product);
            Assert.IsNotNull(cart._product);
            Assert.IsTrue(cart._product.Count == 1);
            Assert.IsNotNull(cart.GetCartValue());
        }

        [TestMethod]
        public void BuildCartWithdiscountedItem()
        {
            product = new Apple();
            ProductManager manager = new ProductManager(product);
            cart.addItem(product);
            cart.addItem(product);
            Assert.IsNotNull(cart._product);
            Assert.IsTrue(cart._product[0].nQualtity > 1);
            Assert.AreNotEqual(cart.GetDiscountedCartValue(), cart.GetCartValue());
        }

        [TestMethod]
        public void BuildCartWithdiscountedItemAndMessage()
        {
            product = new Apple();
            ProductManager manager = new ProductManager(product);
            cart.addItem(product);
            Assert.IsNotNull(cart._product);
            Assert.IsTrue(cart.GetDiscountedCartValue().Item2 != "");
            Assert.IsTrue(cart.GetDiscountedCartValue().Item2.Contains(cart._product[0].Name()));
        }

        [TestMethod]
        public void BuildCartWithNoDiscount()
        {
            ProductManager manager = new ProductManager(product);
            cart.addItem(new Beans());
            Assert.IsNotNull(cart._product);
            Assert.IsTrue(cart.GetDiscountedCartValue().Item2 == "");
            Assert.AreEqual(cart.GetDiscountedCartValue().Item1, 0);
        }

        [TestMethod]
        public void BuildCartWith50PercentDiscount()
        {
            ProductManager manager = new ProductManager(product);
            cart.addItem(new Beans());
            cart.addItem(new Beans());
            cart.addItem(new Bread());
            Assert.IsNotNull(cart._product);
            Assert.IsTrue(cart.GetDiscountedCartValue().Item2 != "");
            Assert.IsTrue(cart.GetDiscountedCartValue().Item2.Contains("50% off"));
        }

        [TestMethod]
        public void BuildCartWith50PercentDiscountLessQty()
        {
            ProductManager manager = new ProductManager(product);
            cart.addItem(new Beans());
            cart.addItem(new Bread());
            Assert.IsNotNull(cart._product);
            Assert.IsFalse(cart.GetDiscountedCartValue().Item2.Contains("50% off"));
        }

        [TestMethod]
        public void BuildCartWithMultipleDiscount()
        {
            ProductManager manager = new ProductManager(product);
            cart.addItem(new Apple());
            cart.addItem(new Beans());
            cart.addItem(new Beans());
            cart.addItem(new Bread());
            Assert.IsNotNull(cart._product);
            Assert.IsTrue(cart.GetDiscountedCartValue().Item2 != "");
            Assert.IsTrue(cart.GetDiscountedCartValue().Item2.Contains("10% off"));
            Assert.IsTrue(cart.GetDiscountedCartValue().Item2.Contains("50% off"));
        }
    }
}
