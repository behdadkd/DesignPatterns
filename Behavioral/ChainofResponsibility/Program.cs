var vipHandler = new VIPDiscountHandler();
vipHandler.SetNextHandler(new RegularDiscountHandler())
          .SetNextHandler(new NewDiscountHandler())
          .SetNextHandler(new NoDiscountHandler());

var customer = new Customer { IsNew = true };
decimal orderTotal = 10_000;
decimal discountedTotal = vipHandler.Handle(customer, orderTotal);

Console.WriteLine($"The discounted total is: {discountedTotal}");



public class Customer
{
    public bool IsVIP { get; set; }
    public bool IsRegular { get; set; }
    public bool IsNew { get; set; }
}
public abstract class DiscountHandler
{
    protected DiscountHandler _nextHandler;

    public DiscountHandler SetNextHandler(DiscountHandler nextHandler)
    {
        _nextHandler = nextHandler;
        return nextHandler;
    }

    public abstract decimal Handle(Customer customer, decimal orderTotal);
}

public class VIPDiscountHandler : DiscountHandler
{
    public override decimal Handle(Customer customer, decimal orderTotal)
    {
        if (customer.IsVIP)
        {
            return orderTotal * 0.8m; // 20% تخفیف
        }
        else if (_nextHandler != null)
        {
            return _nextHandler.Handle(customer, orderTotal);
        }

        return orderTotal;
    }
}

public class RegularDiscountHandler : DiscountHandler
{
    public override decimal Handle(Customer customer, decimal orderTotal)
    {
        if (customer.IsRegular)
        {
            return orderTotal * 0.9m; // 10% تخفیف
        }
        else if (_nextHandler != null)
        {
            return _nextHandler.Handle(customer, orderTotal);
        }

        return orderTotal;
    }
}

public class NewDiscountHandler : DiscountHandler
{
    public override decimal Handle(Customer customer, decimal orderTotal)
    {
        if (customer.IsNew)
        {
            return orderTotal * 0.95m; // 5% تخفیف
        }
        else if (_nextHandler != null)
        {
            return _nextHandler.Handle(customer, orderTotal);
        }

        return orderTotal;
    }
}

public class NoDiscountHandler : DiscountHandler
{
    public override decimal Handle(Customer customer, decimal orderTotal)
    {
        return orderTotal; // بدون تخفیف
    }
}
