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

}
