namespace order;
// Interface for Services
public interface IUserService
{
    bool IsUserValid(string userId);
}

public interface IInventoryService
{
    bool IsInStock(string itemId);
    decimal GetItemPrice(string itemId);
}

public interface IDiscountService
{
    decimal GetDiscount(string discountCode);
}

public interface IOrderService
{
    void PlaceOrder(string userId, string itemId, decimal finalPrice);
}

// Concrete implementation of UserService
public class UserService : IUserService
{
    public bool IsUserValid(string userId)
    {
        Console.WriteLine($"Validating user {userId}.");
        return true;
    }
}

// Concrete implementation of InventoryService
public class InventoryService : IInventoryService
{
    public bool IsInStock(string itemId)
    {
        Console.WriteLine($"Checking stock for item {itemId}.");
        return true;
    }

    public decimal GetItemPrice(string itemId)
    {
        Console.WriteLine($"Getting price for item {itemId}.");
        return 100m;
    }
}

// Concrete implementation of DiscountService
public class DiscountService : IDiscountService
{
    public decimal GetDiscount(string discountCode)
    {
        Console.WriteLine($"Applying discount with code {discountCode}.");
        return 10m;
    }
}

// Concrete implementation of OrderService
public class OrderService : IOrderService
{
    public void PlaceOrder(string userId, string itemId, decimal finalPrice)
    {
        Console.WriteLine($"Placing order for user {userId} for item {itemId} at price {finalPrice:C}.");
    }
}

// Class that handles order processing without Mediator
public class OrderProcessor
{
    private readonly IUserService _userService;
    private readonly IInventoryService _inventoryService;
    private readonly IDiscountService _discountService;
    private readonly IOrderService _orderService;

    public OrderProcessor(IUserService userService, IInventoryService inventoryService, IDiscountService discountService, IOrderService orderService)
    {
        _userService = userService;
        _inventoryService = inventoryService;
        _discountService = discountService;
        _orderService = orderService;
    }

    public void ProcessOrder(string userId, string itemId, string discountCode)
    {
        // Step 1: Validate User
        if (!_userService.IsUserValid(userId))
        {
            Console.WriteLine("User validation failed. Aborting order.");
            return;
        }

        // Step 2: Check Inventory
        if (!_inventoryService.IsInStock(itemId))
        {
            Console.WriteLine("Item is out of stock. Aborting order.");
            return;
        }

        // Step 3: Apply Discount
        decimal discount = _discountService.GetDiscount(discountCode);
        decimal itemPrice = _inventoryService.GetItemPrice(itemId);
        decimal finalPrice = itemPrice - discount;

        // Step 4: Place Order
        _orderService.PlaceOrder(userId, itemId, finalPrice);

        Console.WriteLine("Order process completed successfully.");
    }
}

// Usage
class Program
{
    static void Main(string[] args)
    {
        // ایجاد سرویس‌ها
        IUserService userService = new UserService();
        IInventoryService inventoryService = new InventoryService();
        IDiscountService discountService = new DiscountService();
        IOrderService orderService = new OrderService();

        // ایجاد پروسسور سفارش
        OrderProcessor orderProcessor = new OrderProcessor(userService, inventoryService, discountService, orderService);

        // ارسال سفارش
        orderProcessor.ProcessOrder("User1", "Item1", "DISCOUNT2024");

        Console.ReadLine();
    }
}
