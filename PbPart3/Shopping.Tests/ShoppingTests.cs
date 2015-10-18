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
              new Shopping.ShoppingCart { product = "grapes", price = 50 },
              new Shopping.ShoppingCart { product = "pears", price = 3 },
              new Shopping.ShoppingCart { product = "oranges", price = 11 },
              new Shopping.ShoppingCart { product = "lemons", price = 11 },
              new Shopping.ShoppingCart { product = "applepie", price = 50 },
              new Shopping.ShoppingCart { product = "cherries", price = 25 }
          };

        [TestMethod]
        public void VerifyTotalPriceOfTheShoppingCart()
        {
            var expectedTotalPrice = 163;

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

            Assert.AreEqual(cheapestProductsExpected.Length, cheapestProducts.Length);
            CollectionAssert.AreEqual(cheapestProductsExpected, cheapestProducts);
        }

        [TestMethod]
        public void VerifyThatTheMostExpensiveProductsAreEliminatedFromTheCart()
        {
            Shopping.ShoppingCart[] expectedCart = new Shopping.ShoppingCart[]
          {
              new Shopping.ShoppingCart { product = "bananaaaaas", price = 10 },
              new Shopping.ShoppingCart { product = "apples", price = 3 },
              new Shopping.ShoppingCart { product = "pears", price = 3 },
              new Shopping.ShoppingCart { product = "oranges", price = 11 },
              new Shopping.ShoppingCart { product = "lemons", price = 11 },
              new Shopping.ShoppingCart { product = "cherries", price = 25 },
          };

            Shopping.ShoppingCart[] newCart = Shopping.EliminateTheMostExpensiveProduct(cart);

            Assert.AreEqual(expectedCart.Length,newCart.Length);
            CollectionAssert.AreEqual(expectedCart,newCart);
        }

        [TestMethod]
        public void VerifyThatNewProductWasAddedToTheCart()
        {
            Shopping.ShoppingCart[] expectedNewCart = new Shopping.ShoppingCart[]
          {
              new Shopping.ShoppingCart { product = "bananaaaaas", price = 10 },
              new Shopping.ShoppingCart { product = "apples", price = 3 },
              new Shopping.ShoppingCart { product = "grapes", price = 50 },
              new Shopping.ShoppingCart { product = "pears", price = 3 },
              new Shopping.ShoppingCart { product = "oranges", price = 11 },
              new Shopping.ShoppingCart { product = "lemons", price = 11 },
              new Shopping.ShoppingCart { product = "applepie", price = 50 },
              new Shopping.ShoppingCart { product = "cherries", price = 25 },
              new Shopping.ShoppingCart { product = "melon", price = 37 }
          };

            Shopping.ShoppingCart[] newCart = Shopping.AddNewEntry(cart, "melon", 37);

            CollectionAssert.AreEqual(expectedNewCart, newCart);
        }

        [TestMethod]
        public void VerifyTheAveragePrice()
        {
            double expectedAverage = 20.38;

            double average = Shopping.CalculateTheAverage(cart);

            Assert.AreEqual(expectedAverage, average);
        }
    }
}
