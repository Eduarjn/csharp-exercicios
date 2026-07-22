using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalPrice()
    {
        double totalCost = 0;

        // Sum up the total cost of each product
        foreach (Product product in _products)
        {
            totalCost += product.GetTotalCost();
        }

        // Add shipping cost based on location
        if (_customer.IsInUSA())
        {
            totalCost += 5.00;
        }
        else
        {
            totalCost += 35.00;
        }

        return totalCost;
    }

    public string GetPackingLabel()
    {
        string label = "--- Packing Label ---\n";
        foreach (Product product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = "--- Shipping Label ---\n";
        label += $"{_customer.GetName()}\n";
        label += $"{_customer.GetAddress().GetFullAddress()}\n";
        return label;
    }
}
