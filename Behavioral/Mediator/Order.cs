namespace order;
// Mediator Interface
public interface IOrderMediator
{
    void OnUserValidated(string userId);
    void OnUserInvalid(string userId);
    void OnStockChecked(string itemId, bool inStock);
    void OnDiscountApplied(string userId, decimal discountAmount);
    void OnOrderPlaced(string userId, string itemId, decimal finalPrice);
}



// Concrete Mediator
public class OrderMediator : IOrderMediator
{
    private UserService _userService;
    private DiscountService _discountService;
    private StockService _stockService;
    private OrderService _orderService;

    public void RegisterUserService(UserService userService)
    {
        _userService = userService;
    }

    public void RegisterDiscountService(DiscountService discountService)
    {
        _discountService = discountService;
    }

    public void RegisterStockService(StockService stockService)
    {
        _stockService = stockService;
    }

    public void RegisterOrderService(OrderService orderService)
    {
        _orderService = orderService;
    }

    public void OnUserValidated(string userId)
    {
        Console.WriteLine($"Mediator: User {userId} validated.");
        // ادامه فرآیند پس از اعتبارسنجی کاربر
    }

    public void OnUserInvalid(string userId)
    {
        Console.WriteLine($"Mediator: User {userId} is not valid. Aborting process.");
        // متوقف کردن عملیات در صورت نامعتبر بودن کاربر
    }

    public void OnStockChecked(string itemId, bool inStock)
    {
        if (inStock)
        {
            Console.WriteLine($"Mediator: Item {itemId} is in stock.");
            // درخواست اعمال تخفیف
            _discountService.ApplyDiscount("User1");
        }
        else
        {
            Console.WriteLine($"Mediator: Item {itemId} is out of stock.");
        }
    }

    public void OnDiscountApplied(string userId, decimal discountAmount)
    {
        Console.WriteLine($"Mediator: Discount of {discountAmount:C} applied.");
        // پردازش نهایی سفارش
        _orderService.PlaceOrder(userId, "Item1", discountAmount);
    }

    public void OnOrderPlaced(string userId, string itemId, decimal finalPrice)
    {
        Console.WriteLine($"Mediator: Order placed for User {userId} for Item {itemId} at price {finalPrice:C}.");
    }
}

public class UserService
{
    private IOrderMediator _mediator;

    public UserService(IOrderMediator mediator)
    {
        _mediator = mediator;
    }

    public void ValidateUser(string userId)
    {
        bool isValid = IsUserValid(userId);

        if (isValid)
        {
            Console.WriteLine($"User {userId} is valid.");
            _mediator.OnUserValidated(userId);
        }
        else
        {
            Console.WriteLine($"User {userId} is not valid.");
            _mediator.OnUserInvalid(userId);
        }
    }

    private bool IsUserValid(string userId)
    {
        // منطق واقعی اعتبارسنجی کاربر
        return true; // فرض بر اینکه کاربر معتبر است
    }
}


public class DiscountService
{
    private IOrderMediator _mediator;

    public DiscountService(IOrderMediator mediator)
    {
        _mediator = mediator;
    }

    public void ApplyDiscount(string userId)
    {
        // فرض بر اینکه تخفیف ثابت است
        decimal discountAmount = 10.0m;
        Console.WriteLine($"Applying discount of {discountAmount:C} for User {userId}.");
        _mediator.OnDiscountApplied(userId, discountAmount);
    }
}

public class StockService
{
    private IOrderMediator _mediator;

    public StockService(IOrderMediator mediator)
    {
        _mediator = mediator;
    }

    public void CheckStock(string itemId)
    {
        bool inStock = IsItemInStock(itemId);
        _mediator.OnStockChecked(itemId, inStock);
    }

    private bool IsItemInStock(string itemId)
    {
        // منطق واقعی بررسی موجودی
        return true; // فرض بر اینکه کالا موجود است
    }
}

public class OrderService
{
    private IOrderMediator _mediator;

    public OrderService(IOrderMediator mediator)
    {
        _mediator = mediator;
    }

    public void PlaceOrder(string userId, string itemId, decimal finalPrice)
    {
        // منطق واقعی ثبت سفارش
        Console.WriteLine($"Placing order for User {userId} with Item {itemId} at final price {finalPrice:C}.");
        _mediator.OnOrderPlaced(userId, itemId, finalPrice);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // ایجاد واسطه (Mediator)
        IOrderMediator orderMediator = new OrderMediator();

        // ایجاد و ثبت سرویس‌ها در واسطه
        UserService userService = new UserService(orderMediator);
        DiscountService discountService = new DiscountService(orderMediator);
        StockService stockService = new StockService(orderMediator);
        OrderService orderService = new OrderService(orderMediator);

        ((OrderMediator)orderMediator).RegisterUserService(userService);
        ((OrderMediator)orderMediator).RegisterDiscountService(discountService);
        ((OrderMediator)orderMediator).RegisterStockService(stockService);
        ((OrderMediator)orderMediator).RegisterOrderService(orderService);

        // شروع فرآیند سفارش
        userService.ValidateUser("User1");
        stockService.CheckStock("Item1");

        Console.ReadLine();
    }
}
