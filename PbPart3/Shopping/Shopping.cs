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

            int minPrice = 0;
           // int productsWithMinValue = 0;

            for (int i = 1; i < cart.Length; i++)
            {
                if (cart[i].price < minPrice)
                {
                    minPrice = cart[i].price;
                }
            }

            for (int i = 0; i < cart.Length; i++)
            {
                if (cart[i].price == minPrice)
                {
                    //productsWithMinValue++;
                    //Array.Resize(ref cheapestProducts, productsWithMinValue);
                    cheapestProducts = new ShoppingCart[]
                       {
                           new ShoppingCart { price = cart[i].price, product = cart[i].product}
                       };
                }                  
            }

            return cheapestProducts;
        }
    }
}
