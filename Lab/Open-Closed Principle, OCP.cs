using System;
using System.Collections.Generic;

public interface IDiscountStrategy
{
    double CalculateDiscount(double amount);
}

public class RegularCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount)
    {
        return amount;
    }
}

public class SilverCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount)
    {
        return amount * 0.9; 
    }
}

public class GoldCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount)
    {
        return amount * 0.8; 
}

public class PlatinumCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount)
    {
        return amount * 0.7; 
    }
}

public class DiscountCalculator
{
    private readonly Dictionary<CustomerType, IDiscountStrategy> _discountStrategies;

    public DiscountCalculator()
    {
        _discountStrategies = new Dictionary<CustomerType, IDiscountStrategy>
        {
            { CustomerType.Regular, new RegularCustomerDiscount() },
            { CustomerType.Silver, new SilverCustomerDiscount() },
            { CustomerType.Gold, new GoldCustomerDiscount() },
            { CustomerType.Platinum, new PlatinumCustomerDiscount() }
        };
    }

    public double CalculateDiscount(CustomerType customerType, double amount)
    {
        if (_discountStrategies.TryGetValue(customerType, out var discountStrategy))
        {
            return discountStrategy.CalculateDiscount(amount);
        }
        else
        {
            throw new ArgumentException("Неизвестный тип клиента");
        }
    }
}

public enum CustomerType
{
    Regular,
    Silver,
    Gold,
    Platinum
}

public class Program
{
    public static void Main(string[] args)
    {
        DiscountCalculator discountCalculator = new DiscountCalculator();

        double amount = 1000;

        Console.WriteLine($"Regular Customer Discount: {discountCalculator.CalculateDiscount(CustomerType.Regular, amount):C}");
        Console.WriteLine($"Silver Customer Discount: {discountCalculator.CalculateDiscount(CustomerType.Silver, amount):C}");
        Console.WriteLine($"Gold Customer Discount: {discountCalculator.CalculateDiscount(CustomerType.Gold, amount):C}");
        Console.WriteLine($"Platinum Customer Discount: {discountCalculator.CalculateDiscount(CustomerType.Platinum, amount):C}");
    }
}
