using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    public class Shopping
    {
        public struct ShoppingCart
        {
            public int price;
            public string product;
        }

        public static int CalculateTotatlPriceOfTheShoppingCart(ShoppingCart[] cart)
        {
            int totalPrice = 0;

            for (int i = 0; i < cart.Length; i++)
            {
                totalPrice += cart[i].price;
            }

            return totalPrice;
        }

        public static ShoppingCart[] ReturnCheapestProducts(ShoppingCart[] cart)
        {
            ShoppingCart[] cheapestProducts = new ShoppingCart[0];

            int minPrice = ReturnMinValue(cart);

            int productsWithMinValue = 0;
            for (int i = 0; i < cart.Length; i++)
            {
                if (cart[i].price == minPrice)
                {
                    productsWithMinValue++;
                    Array.Resize(ref cheapestProducts, productsWithMinValue);
                    
                    cheapestProducts[productsWithMinValue-1] =

                        new ShoppingCart { price = cart[i].price, product = cart[i].product };                       
                }
            }

            return cheapestProducts;
        }

        public static ShoppingCart[] EliminateTheMostExpensiveProduct(ShoppingCart[] cart)
        {
            ShoppingCart[] resultedCart = new ShoppingCart[cart.Length];
            int maxPrice = ReturnMaxValue(cart);
            int productsWithMaxValue = 0;

            for (int i = 0; i < cart.Length; i++)
            {
                if (cart[i].price == maxPrice)
                {
                    productsWithMaxValue++;

                    Array.Resize(ref resultedCart, cart.Length - productsWithMaxValue);
                }
                else
                {
                    resultedCart[i-productsWithMaxValue] = cart[i];
                }
            }

            return resultedCart;
        }

        public static ShoppingCart[] AddNewEntry(ShoppingCart[] cart, string newProd, int newPrice)
        {
            ShoppingCart[] newCart = new ShoppingCart[cart.Length];

            for (int i = 0; i < cart.Length; i++)
            {
                newCart[i] = cart[i];
            }

            Array.Resize(ref newCart, newCart.Length + 1);
            newCart[newCart.Length - 1] = new ShoppingCart { price = newPrice, product = newProd };

            return newCart;
        }

        public static double CalculateTheAverage(ShoppingCart[] cart)
        {
            return  Math.Round((double)CalculateTotatlPriceOfTheShoppingCart(cart)/cart.Length,2);
        }

        private static int ReturnMinValue(ShoppingCart[] cart)
        {
            int minPrice = cart[0].price;
            for (int i = 1; i < cart.Length; i++)
            {
                if (cart[i].price < minPrice)
                {
                    minPrice = cart[i].price;
                }
            }

            return minPrice;
        }

        private static int ReturnMaxValue(ShoppingCart[] cart)
        {
            int maxPrice = cart[0].price;
            for (int i = 1; i < cart.Length; i++)
            {
                if (cart[i].price > maxPrice)
                {
                    maxPrice = cart[i].price;
                }
            }

            return maxPrice;
        }
    }
}
