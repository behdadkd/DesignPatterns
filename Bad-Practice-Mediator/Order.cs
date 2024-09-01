using System;

// Services
public class UserService
{
    public bool IsUserValid(string userId)
    {
        // منطق اعتبارسنجی کاربر
        Console.WriteLine($"Validating user: {userId}");
        return true;
    }
}

public class InventoryService
{
    public bool IsInStock(string itemId)
    {
        // منطق بررسی موجودی
        Console.WriteLine($"Checking stock for item: {itemId}");
        return true;
    }

    public decimal GetItemPrice(string itemId)
    {
        // منطق برای دریافت قیمت کالا
        return 100m;
    }
}

public class DiscountService
{
    public decimal GetDiscount(string userId, string itemId)
    {
        // منطق اعمال تخفیف
        Console.WriteLine($"Applying discount for user: {userId} on item: {itemId}");
        return 10m;
    }
}

public class OrderService
{
    public void ProcessOrder(string userId, string itemId, decimal finalPrice)
    {
        // منطق ثبت سفارش
        Console.WriteLine($"Processing order for user {userId} with item {itemId} at final price {finalPrice:C}.");
    }
}

// Main Order Processor Class
public class OrderProcessor
{
    private UserService _userService;
    private InventoryService _inventoryService;
    private DiscountService _discountService;
    private OrderService _orderService;

    public OrderProcessor(UserService userService, InventoryService inventoryService, DiscountService discountService, OrderService orderService)
    {
        _userService = userService;
        _inventoryService = inventoryService;
        _discountService = discountService;
        _orderService = orderService;
    }

    public void PlaceOrder(string userId, string itemId)
    {
        // 1. Validate user
        if (!_userService.IsUserValid(userId))
        {
            Console.WriteLine($"User {userId} is not valid. Aborting order.");
            return;
        }

        // 2. Check inventory
        if (!_inventoryService.IsInStock(itemId))
        {
            Console.WriteLine($"Item {itemId} is out of stock. Aborting order.");
            return;
        }

        // 3. Apply discount
        decimal discount = _discountService.GetDiscount(userId, itemId);
        decimal finalPrice = _inventoryService.GetItemPrice(itemId) - discount;
        Console.WriteLine($"Discount applied. Final price is {finalPrice:C}.");

        // 4. Place order
        _orderService.ProcessOrder(userId, itemId, finalPrice);
        Console.WriteLine($"Order placed successfully for user {userId}.");
    }
}

// Usage
class Program
{
    static void Main(string[] args)
    {
        // ایجاد سرویس‌ها
        UserService userService = new UserService();
        InventoryService inventoryService = new InventoryService();
        DiscountService discountService = new DiscountService();
        OrderService orderService = new OrderService();

        // ایجاد پروسسور سفارش
        OrderProcessor orderProcessor = new OrderProcessor(userService, inventoryService, discountService, orderService);

        // ثبت سفارش
        orderProcessor.PlaceOrder("User1", "Item1");

        Console.ReadLine();
    }
}
