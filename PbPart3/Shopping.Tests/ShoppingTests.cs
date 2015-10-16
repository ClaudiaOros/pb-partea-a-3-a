using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopping;

namespace Shopping.Tests
{
    [TestClass]
    public class ShoppingTests
    {
        public static Shopping.ShoppingCart[] cart = new Shopping.ShoppingCart[]
          {
              new Shopping.ShoppingCart { product = "bananaaaaas", price = 10 },
              new Shopping.ShoppingCart { product = "apples", price = 3 },
              new Shopping.ShoppingCart { product = "grapes", price = 4 },
              new Shopping.ShoppingCart { product = "pears", price = 3 },
              new Shopping.ShoppingCart { product = "oranges", price = 11 },
              new Shopping.ShoppingCart { product = "lemons", price = 11 },
              new Shopping.ShoppingCart { product = "applepie", price = 50 },
              new Shopping.ShoppingCart { product = "cherries", price = 25 },
          };

        [TestMethod]
        public void VerifyTotalPriceOfTheShoppingCart()
        {
            var expectedTotalPrice = 119;

            var totalPrice = Shopping.CalculateTotatlPriceOfTheShoppingCart(cart);

            Assert.AreEqual(expectedTotalPrice, totalPrice);
        }

        [TestMethod]
        public void VerifyTheCheapestProductsFromTheShoppingCart()
        {
            Shopping.ShoppingCart[] cheapestProductsExpected = new Shopping.ShoppingCart[]
            {
                new Shopping.ShoppingCart { product = "apples", price = 3 },
                new Shopping.ShoppingCart { product = "pears", price = 3 }
            };

            Shopping.ShoppingCart[] cheapestProducts = Shopping.ReturnCheapestProducts(cart);
            CollectionAssert.AreEqual(cheapestProductsExpected, cheapestProducts);
        }
    }
}
