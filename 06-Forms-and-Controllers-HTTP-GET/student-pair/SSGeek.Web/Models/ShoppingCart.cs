﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.Models
{
    public class ShoppingCart
    {
        public IList<ShoppingCartItem> Items { get; } = new List<ShoppingCartItem>();

        public void AddToCart(Product p, int quantity)
        {

            var shoppingCartItem = Items.FirstOrDefault(i => i.Product.Id == p.Id);

            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem() { Product = p, Quantity = 0 };
                Items.Add(shoppingCartItem);

            }

            shoppingCartItem.Quantity += quantity;
        }


        public decimal GrandTotal
        {
            get
            {
                decimal total = 0.0M;

                foreach(var item in Items)
                {
                    total += (item.Product.Price) * item.Quantity;

                }
                return total;
            }
        }

    }
}
