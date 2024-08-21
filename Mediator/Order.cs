// کلاس انبار که به صورت مستقیم به کلاس‌های دیگر وابسته است
public class Stock
{
    private Payment _payment;
    private Shipping _shipping;

    public Stock(Payment payment, Shipping shipping)
    {
        _payment = payment;
        _shipping = shipping;
    }

    public bool IsInStock(string item)
    {
        // برای سادگی، فرض می‌کنیم همه چیز در انبار موجود است.
        return true;
    }

    public void CheckOut(string item)
    {
        if (IsInStock(item))
        {
            Console.WriteLine($"Item '{item}' is in stock.");
            if (_payment.ProcessPayment())
            {
                Console.WriteLine("Payment processed successfully.");
                _shipping.ShipItem(item);
            }
            else
            {
                Console.WriteLine("Payment failed.");
            }
        }
        else
        {
            Console.WriteLine($"Item '{item}' is out of stock.");
        }
    }
}

// کلاس پرداخت که به صورت مستقیم به کلاس‌های دیگر وابسته است
public class Payment
{
    private Shipping _shipping;

    public Payment(Shipping shipping)
    {
        _shipping = shipping;
    }

    public bool ProcessPayment()
    {
        // برای سادگی، فرض می‌کنیم پرداخت همیشه موفق است.
        return true;
    }
}

// کلاس ارسال که به صورت مستقیم به کلاس‌های دیگر وابسته است
public class Shipping
{
    public void ShipItem(string item)
    {
        Console.WriteLine($"Item '{item}' has been shipped.");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        // ایجاد بخش‌های مختلف
        var shipping = new Shipping();
        var payment = new Payment(shipping);
        var stock = new Stock(payment, shipping);

        // پردازش سفارش به صورت مستقیم
        stock.CheckOut("Laptop");

        Console.ReadLine();
    }
}




// رابط واسطه
//public interface IOrderMediator
//{
//    void ProcessOrder(string item);
//    void RegisterStock(Stock stock);
//    void RegisterPayment(Payment payment);
//    void RegisterShipping(Shipping shipping);
//}
//// پیاده‌سازی واسطه
//public class OrderManager : IOrderMediator
//{
//    private Stock _stock;
//    private Payment _payment;
//    private Shipping _shipping;

//    public void RegisterStock(Stock stock)
//    {
//        _stock = stock;
//    }

//    public void RegisterPayment(Payment payment)
//    {
//        _payment = payment;
//    }

//    public void RegisterShipping(Shipping shipping)
//    {
//        _shipping = shipping;
//    }

//    public void ProcessOrder(string item)
//    {
//        if (_stock.IsInStock(item))
//        {
//            Console.WriteLine($"Item '{item}' is in stock.");
//            if (_payment.ProcessPayment())
//            {
//                Console.WriteLine("Payment processed successfully.");
//                _shipping.ShipItem(item);
//            }
//            else
//            {
//                Console.WriteLine("Payment failed.");
//            }
//        }
//        else
//        {
//            Console.WriteLine($"Item '{item}' is out of stock.");
//        }
//    }
//}

//// کلاس انبار
//public class Stock
//{
//    private IOrderMediator _mediator;

//    public Stock(IOrderMediator mediator)
//    {
//        _mediator = mediator;
//    }

//    public bool IsInStock(string item)
//    {
//        // برای سادگی، فرض می‌کنیم همه چیز در انبار موجود است.
//        return true;
//    }
//}

//// کلاس پرداخت
//public class Payment
//{
//    private IOrderMediator _mediator;

//    public Payment(IOrderMediator mediator)
//    {
//        _mediator = mediator;
//    }

//    public bool ProcessPayment()
//    {
//        // برای سادگی، فرض می‌کنیم پرداخت همیشه موفق است.
//        return true;
//    }
//}

//// کلاس ارسال
//public class Shipping
//{
//    private IOrderMediator _mediator;

//    public Shipping(IOrderMediator mediator)
//    {
//        _mediator = mediator;
//    }

//    public void ShipItem(string item)
//    {
//        Console.WriteLine($"Item '{item}' has been shipped.");
//    }
//}

//// استفاده از الگو
//public class MediatorPatternExample
//{
//    static void Main(string[] args)
//    {
//        // ایجاد واسطه
//        IOrderMediator orderManager = new OrderManager();

//        // ایجاد و ثبت بخش‌های مختلف
//        Stock stock = new Stock(orderManager);
//        Payment payment = new Payment(orderManager);
//        Shipping shipping = new Shipping(orderManager);

//        orderManager.RegisterStock(stock);
//        orderManager.RegisterPayment(payment);
//        orderManager.RegisterShipping(shipping);

//        // پردازش سفارش
//        orderManager.ProcessOrder("Laptop");

//        Console.ReadLine();
//    }
//}


