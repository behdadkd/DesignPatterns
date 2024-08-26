var customer = new Customer { IsNew = true };
decimal orderTotal = 10_000;

decimal discountedTotal = Calculate.CalculateDiscount(customer, orderTotal);
Console.WriteLine($"The discounted total is: {discountedTotal}");



public class Customer
{
    public bool IsVIP { get; set; }
    public bool IsRegular { get; set; }
    public bool IsNew { get; set; }
}

public static class Calculate
{
    public static decimal CalculateDiscount(Customer customer, decimal orderTotal)
    {
        if (customer.IsVIP)
        {
            return orderTotal * 0.8m; // 20% تخفیف
        }
        else if (customer.IsRegular)
        {
            return orderTotal * 0.9m; // 10% تخفیف
        }
        else if (customer.IsNew)
        {
            return orderTotal * 0.95m; // 5% تخفیف
        }
        else
        {
            return orderTotal; // بدون تخفیف
        }
    }

}