using System;
using System.Collections.Generic;
using System.Linq;

namespace PRN222_BookShop.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { get; set; }

        public ShoppingCart(List<ShoppingCartItem> items = null)
        {
            Items = items ?? new List<ShoppingCartItem>();
        }

        public void AddToCart(ShoppingCartItem item, int quantity)
        {
            var existingItem = Items.FirstOrDefault(i => i.BookID == item.BookID);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                existingItem.TotalPrice = existingItem.Quantity * existingItem.Price;
            }
            else
            {
                item.Quantity = quantity;
                item.TotalPrice = item.Quantity * item.Price;
                Items.Add(item);
            }
        }

        public void RemoveFromCart(int bookId)
        {
            var itemToRemove = Items.FirstOrDefault(i => i.BookID == bookId);
            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
            }
        }

        public void UpdateCartItem(int bookId, int quantity)
        {
            var itemToUpdate = Items.SingleOrDefault(i => i.BookID == bookId);
            if (itemToUpdate != null)
            {
                itemToUpdate.Quantity = quantity;
                itemToUpdate.TotalPrice = itemToUpdate.Quantity * itemToUpdate.Price;
            }
        }

        public decimal GetTotalPrice()
        {
            return Items.Sum(i => i.TotalPrice);
        }

        public int GetTotalQuantity()
        {
            return Items.Sum(i => i.Quantity);
        }

        public void ClearCart()
        {
            Items.Clear();
        }

        public class ShoppingCartItem
        {
            public int BookID { get; set; }
            public string? BookName { get; set; }
            public string? CategoryName { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public string? ImageUrl { get; set; }
            public decimal TotalPrice { get; set; }
        }
    }
}
