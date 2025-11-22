using System;

class Program
{
    static void Main(string[] args)
    {
        // First Order
        Address addr1 = new Address("123 Elm St", "New York", "NY", "USA");
        Customer cust1 = new Customer("John Smith", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("USB Mouse", "A12", 15.99, 2));
        order1.AddProduct(new Product("Keyboard", "B07", 29.99, 1));

        // Second Order (International)
        Address addr2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer cust2 = new Customer("Emily Johnson", addr2);
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Smartphone Case", "C21", 12.50, 3));
        order2.AddProduct(new Product("Screen Protector", "D34", 8.75, 2));

        // Display Order 1
        Console.WriteLine("=== Order 1 ===");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}");
        Console.WriteLine();

        // Display Order 2
        Console.WriteLine("=== Order 2 ===");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}");
    }
}
