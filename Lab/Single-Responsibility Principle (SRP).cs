using System;
using System.Collections.Generic;

public class Item
{
    public string Name { get; set; }
    public double Price { get; set; }
}

public class Invoice
{
    public int Id { get; set; }
    public List<Item> Items { get; set; }
    public double TaxRate { get; set; }

    public Invoice()
    {
        Items = new List<Item>();
    }
}

public class InvoiceCalculator
{
    public double CalculateTotal(Invoice invoice)
    {
        double subTotal = 0;
        foreach (var item in invoice.Items)
        {
            subTotal += item.Price;
        }
        return subTotal + (subTotal * invoice.TaxRate);
    }
}

public class InvoiceRepository
{
    public void SaveToDatabase(Invoice invoice)
    {
       
        Console.WriteLine($"Invoice {invoice.Id} saved to database.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Invoice invoice = new Invoice
        {
            Id = 1,
            TaxRate = 0.2 
        };

        invoice.Items.Add(new Item { Name = "Item 1", Price = 50 });
        invoice.Items.Add(new Item { Name = "Item 2", Price = 100 });

        InvoiceCalculator calculator = new InvoiceCalculator();
        double total = calculator.CalculateTotal(invoice);
        Console.WriteLine($"Total invoice amount: {total:C}");

        InvoiceRepository repository = new InvoiceRepository();
        repository.SaveToDatabase(invoice);
    }
}
