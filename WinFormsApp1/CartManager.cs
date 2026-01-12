using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1;
    }


    public static class CartManager
    {
        public static List<CartItem> Items { get; } = new List<CartItem>();

        public static void AddItem(CartItem item)
        {
            var existing = Items.FirstOrDefault(i => i.Id == item.Id);
            if (existing != null)
            {
                existing.Quantity += item.Quantity;
            }
            else
            {
                Items.Add(new CartItem
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity
                });
            }
        }

        public static int GetQuantity(int id)
        {
            var existing = Items.FirstOrDefault(i => i.Id == id);
            return existing?.Quantity ?? 0;
        }

        public static void RemoveItem(int id)
        {
            var existing = Items.FirstOrDefault(i => i.Id == id);
            if (existing != null)
            {
                Items.Remove(existing);
            }
        }

        public static void ClearCart()
        {
            Items.Clear();
        }
    }

}
