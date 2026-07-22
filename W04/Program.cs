using System;

class Program
{
    static void Main(string[] args)
    {
        // --- Create Order 1 (USA Customer) ---
        Address address1 = new Address("123 Maple Street", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        
        order1.AddProduct(new Product("Laptop", "LPT-100", 850.00, 1));
        order1.AddProduct(new Product("Wireless Mouse", "MOU-020", 25.50, 2));

        // --- Create Order 2 (International Customer) ---
        Address address2 = new Address("456 Oak Avenue", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Mechanical Keyboard", "KEY-500", 75.99, 1));
        order2.AddProduct(new Product("HD Monitor", "MON-240", 150.00, 2));
        order2.AddProduct(new Product("HDMI Cable", "CAB-010", 12.00, 3));

        // --- Display Results ---

        // Display Order 1
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}\n");
        Console.WriteLine("========================================\n");

        // Display Order 2
        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}\n");
    }
}
