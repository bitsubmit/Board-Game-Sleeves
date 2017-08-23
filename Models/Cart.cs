using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace Board_game_sleeves.Models
{
    public class Cart
    {
        private List<OrderItem> lines = new List<OrderItem>();
        public decimal TotalPrice
        {
            //Linq syntax
            get { return lines.Sum((Func<OrderItem, decimal>)(e => e.Product.Price * e.Quantity)); }
        }
        public List<OrderItem> CartLines { get { return lines; } }
        public Cart() { }
        public void AddItem(Product product, int quantity)
        {
            OrderItem item = lines.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();
            if (item == null)
            {
                lines.Add(new OrderItem { Product = product, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
        }
        public void RemoveItem(Product product)
        {
            lines.RemoveAll((Predicate<OrderItem>)(i => i.Product.ProductId == product.ProductId));
        }
        public void Clear()
        {
            lines.Clear();
        }
    }
}