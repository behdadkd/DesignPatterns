var orderProcessor = new OrderProcessor();

// پردازش سفارش با روش ارسال استاندارد
orderProcessor.ProcessOrder(1000m, "Standard");

// پردازش سفارش با روش ارسال اکسپرس
orderProcessor.ProcessOrder(1000m, "Express");

// پردازش سفارش با روش ارسال شبانه
orderProcessor.ProcessOrder(1000m, "Overnight");

Console.ReadLine();



// کلاس برای محاسبه هزینه ارسال
public class ShippingCostCalculator
{
    public decimal CalculateCost(string shippingMethod, decimal orderTotal)
    {
        if (shippingMethod == "Standard")
        {
            return orderTotal * 0.05m; // 5% هزینه ارسال
        }
        else if (shippingMethod == "Express")
        {
            return orderTotal * 0.10m; // 10% هزینه ارسال
        }
        else if (shippingMethod == "Overnight")
        {
            return orderTotal * 0.20m; // 20% هزینه ارسال
        }
        else
        {
            throw new ArgumentException("Unknown shipping method.");
        }
    }
}

// کلاس برای پردازش سفارش
public class OrderProcessor
{
    private ShippingCostCalculator _calculator = new ShippingCostCalculator();

    public void ProcessOrder(decimal orderTotal, string shippingMethod)
    {
        decimal shippingCost = _calculator.CalculateCost(shippingMethod, orderTotal);
        Console.WriteLine($"Order Total: {orderTotal:C}");
        Console.WriteLine($"Shipping Cost for {shippingMethod}: {shippingCost:C}");
        Console.WriteLine($"Total Cost: {orderTotal + shippingCost:C}");
    }
}

