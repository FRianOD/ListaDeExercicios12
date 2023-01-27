using System;
using System.Globalization;
using ListaDeExercicios12.Entities;
using ListaDeExercicios12.Entities.Enums;

namespace ListaDeExercicios12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Client cliente = new Client(name,email,birthDate);

            Console.WriteLine("\nEnter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Order pedido = new Order(DateTime.Now, status, cliente);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"\nEnter #{i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int productQuant = int.Parse(Console.ReadLine());
                Product produto = new Product(productName, productPrice);
                OrderItem item = new OrderItem(productQuant,productPrice,produto);

                pedido.AddItem(item);
            }

            Console.WriteLine($"\nOrder Summary:\n {pedido}");

        }
    }
}