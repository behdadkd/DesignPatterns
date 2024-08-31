namespace order;
public class UserService
{
    private DiscountService _discountService;
    private StockService _stockService;
    private OrderService _orderService;

    public UserService(DiscountService discountService, StockService stockService, OrderService orderService)
    {
        _discountService = discountService;
        _stockService = stockService;
        _orderService = orderService;
    }

    public void ValidateUser(string userId)
    {
        bool isValid = IsUserValid(userId);

        if (isValid)
        {
            Console.WriteLine($"User {userId} is valid.");
            _stockService.CheckStock("Item1");
        }
        else
        {
            Console.WriteLine($"User {userId} is not valid. Aborting process.");
        }
    }

    private bool IsUserValid(string userId)
    {
        // منطق واقعی اعتبارسنجی کاربر
        return true; // فرض بر اینکه کاربر معتبر است
    }
}


public class StockService
{
    private DiscountService _discountService;
    private OrderService _orderService;

    public StockService(DiscountService discountService, OrderService orderService)
    {
        _discountService = discountService;
        _orderService = orderService;
    }

    public void CheckStock(string itemId)
    {
        bool inStock = IsItemInStock(itemId);

        if (inStock)
        {
            Console.WriteLine($"Item {itemId} is in stock.");
            _discountService.ApplyDiscount("User1");
        }
        else
        {
            Console.WriteLine($"Item {itemId} is out of stock.");
        }
    }

    private bool IsItemInStock(string itemId)
    {
        // منطق بررسی موجودی کالا در اینجا قرار می‌گیرد.
        return true; // فرض می‌کنیم که کالا موجود است.
    }
}


public class DiscountService
{
    private OrderService _orderService;

    public DiscountService(OrderService orderService)
    {
        _orderService = orderService;
    }

    public void ApplyDiscount(string userId)
    {
        decimal discountAmount = 10.0m;
        Console.WriteLine($"Applying discount of {discountAmount:C} for User {userId}.");
        _orderService.PlaceOrder(userId, "Item1", discountAmount);
    }
}


public class OrderService
{
    public void PlaceOrder(string userId, string itemId, decimal finalPrice)
    {
        // منطق ثبت سفارش در اینجا قرار می‌گیرد.
        Console.WriteLine($"Placing order for User {userId} with Item {itemId} at final price {finalPrice:C}.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // ایجاد سرویس‌ها و تزریق وابستگی‌ها
        OrderService orderService = new OrderService();
        DiscountService discountService = new DiscountService(orderService);
        StockService stockService = new StockService(discountService, orderService);
        UserService userService = new UserService(discountService, stockService, orderService);

        // شروع فرآیند سفارش
        userService.ValidateUser("User1");

        Console.ReadLine();
    }
}
