namespace TemplateMethod
{
    // کلاس برای سفارش آنلاین
    class OnlineOrder
    {
        public void ProcessOrder()
        {
            Console.WriteLine("Selecting items for the order.");
            Console.WriteLine("Processing online payment through credit card or PayPal.");
            Console.WriteLine("Delivering order via courier to the customer's address.");
            Console.WriteLine("Sending order confirmation to the customer.");
        }
    }

    // کلاس برای سفارش حضوری
    class InStoreOrder
    {
        public void ProcessOrder()
        {
            Console.WriteLine("Selecting items for the order.");
            Console.WriteLine("Processing payment through cash or card at the counter.");
            Console.WriteLine("Handing over the items to the customer in-store.");
            Console.WriteLine("Sending order confirmation to the customer.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Processing an online order:");
            OnlineOrder onlineOrder = new OnlineOrder();
            onlineOrder.ProcessOrder();
            // Output:
            // Selecting items for the order.
            // Processing online payment through credit card or PayPal.
            // Delivering order via courier to the customer's address.
            // Sending order confirmation to the customer.

            Console.WriteLine("\nProcessing an in-store order:");
            InStoreOrder inStoreOrder = new InStoreOrder();
            inStoreOrder.ProcessOrder();
            // Output:
            // Selecting items for the order.
            // Processing payment through cash or card at the counter.
            // Handing over the items to the customer in-store.
            // Sending order confirmation to the customer.
        }
    }
}






abstract class OrderProcess
{
    // Template Method
    public void ProcessOrder()
    {
        SelectItems();       // مرحله 1: انتخاب آیتم‌ها
        ProcessPayment();    // مرحله 2: پردازش پرداخت
        DeliverOrder();      // مرحله 3: تحویل سفارش
        SendConfirmation();  // مرحله 4: ارسال تأییدیه
    }

    // مرحله انتخاب آیتم‌ها - این مرحله در تمام سفارش‌ها یکسان است
    protected void SelectItems()
    {
        Console.WriteLine("Selecting items for the order.");
    }

    // مرحله پردازش پرداخت - این مرحله باید توسط زیرکلاس‌ها پیاده‌سازی شود
    protected abstract void ProcessPayment();

    // مرحله تحویل سفارش - این مرحله باید توسط زیرکلاس‌ها پیاده‌سازی شود
    protected abstract void DeliverOrder();

    // مرحله ارسال تأییدیه - این مرحله در تمام سفارش‌ها یکسان است
    protected void SendConfirmation()
    {
        Console.WriteLine("Sending order confirmation to the customer.");
    }
}

class OnlineOrder : OrderProcess
{
    protected override void ProcessPayment()
    {
        Console.WriteLine("Processing online payment through credit card or PayPal.");
    }

    protected override void DeliverOrder()
    {
        Console.WriteLine("Delivering order via courier to the customer's address.");
    }
}

class InStoreOrder : OrderProcess
{
    protected override void ProcessPayment()
    {
        Console.WriteLine("Processing payment through cash or card at the counter.");
    }

    protected override void DeliverOrder()
    {
        Console.WriteLine("Handing over the items to the customer in-store.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Processing an online order:");
        OrderProcess onlineOrder = new OnlineOrder();
        onlineOrder.ProcessOrder();
        // Output:
        // Selecting items for the order.
        // Processing online payment through credit card or PayPal.
        // Delivering order via courier to the customer's address.
        // Sending order confirmation to the customer.

        Console.WriteLine("\nProcessing an in-store order:");
        OrderProcess inStoreOrder = new InStoreOrder();
        inStoreOrder.ProcessOrder();
        // Output:
        // Selecting items for the order.
        // Processing payment through cash or card at the counter.
        // Handing over the items to the customer in-store.
        // Sending order confirmation to the customer.
    }
}




abstract class DataProcessor
{
    // متد Template که ساختار اصلی الگوریتم را تعریف می‌کند
    public void ProcessData()
    {
        ReadData();       // مرحله اول: خواندن داده‌ها
        ProcessData();    // مرحله دوم: پردازش داده‌ها
        SaveData();       // مرحله سوم: ذخیره داده‌ها
    }

    // این مراحل را زیرکلاس‌ها پیاده‌سازی خواهند کرد
    protected abstract void ReadData();
    protected abstract void ProcessData();

    // مرحله ذخیره‌سازی، می‌تواند در کلاس پایه پیاده‌سازی شود
    protected virtual void SaveData()
    {
        Console.WriteLine("Data saved to default storage");
    }
}
class FileDataProcessor : DataProcessor
{
    protected override void ReadData()
    {
        Console.WriteLine("Reading data from file...");
    }

    protected override void ProcessData()
    {
        Console.WriteLine("Processing file data...");
    }
}
class DatabaseDataProcessor : DataProcessor
{
    protected override void ReadData()
    {
        Console.WriteLine("Reading data from database...");
    }

    protected override void ProcessData()
    {
        Console.WriteLine("Processing database data...");
    }

    // امکان override کردن مرحله ذخیره‌سازی به شکل متفاوت:
    protected override void SaveData()
    {
        Console.WriteLine("Data saved to database");
    }
}
class Program
{
    static void Main(string[] args)
    {
        // پردازش داده از فایل
        DataProcessor fileProcessor = new FileDataProcessor();
        fileProcessor.ProcessData();
        // خروجی:
        // Reading data from file...
        // Processing file data...
        // Data saved to default storage

        // پردازش داده از دیتابیس
        DataProcessor databaseProcessor = new DatabaseDataProcessor();
        databaseProcessor.ProcessData();
        // خروجی:
        // Reading data from database...
        // Processing database data...
        // Data saved to database
    }
}

