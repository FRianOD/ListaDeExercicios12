using ListaDeExercicios12.Entities.Enums;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace ListaDeExercicios12.Entities
{
    internal class Order
    {
        //Atributos autoimplementados
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        //Construtores
        public Order() 
        {

        }
        public Order(DateTime date, OrderStatus status, Client client)
        {
            Date = date;
            Status = status;
            Client = client;
        }

        //Metodos
        public void AddItem(OrderItem Item)
        {
            Items.Add(Item);
        }

        public void RemoveItem(OrderItem Item)
        {
            Items.Remove(Item);
        }

        public double Total()
        {
            double total = 0;
            foreach (OrderItem Item in Items)
            {
                total += Item.SubTotal();
            }

            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Order moment: {Date}");
            sb.AppendLine($"Status: {Status}");
            sb.AppendLine($"Client: {Client.Name} ({Client.BirthDate}) - {Client.Email}");
            sb.AppendLine("Order items:");
            foreach (OrderItem Item in Items)
            {
                sb.AppendLine($"{Item.Product.Name}, ${Item.Product.Price.ToString("F2", CultureInfo.InvariantCulture)}, Quantity: {Item.Quantity}, Subtotal: {Item.SubTotal().ToString("F2", CultureInfo.InvariantCulture)} ");
            }
            sb.AppendLine($"Total: {Total().ToString("F2", CultureInfo.InvariantCulture)}");
            return sb.ToString();
        }

    }
}
