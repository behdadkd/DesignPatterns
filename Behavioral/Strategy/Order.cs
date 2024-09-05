namespace Strategy
{

    // رابط استراتژی
    public interface IShippingStrategy
    {
        decimal CalculateShippingCost(decimal orderTotal);
    }

    // استراتژی ارسال استاندارد
    public class StandardShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShippingCost(decimal orderTotal)
        {
            return orderTotal * 0.05m; // 5% هزینه ارسال
        }
    }

    // استراتژی ارسال اکسپرس
    public class ExpressShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShippingCost(decimal orderTotal)
        {
            return orderTotal * 0.10m; // 10% هزینه ارسال
        }
    }

    // استراتژی ارسال شبانه
    public class OvernightShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShippingCost(decimal orderTotal)
        {
            return orderTotal * 0.20m; // 20% هزینه ارسال
        }
    }

    // کلاس برای پردازش سفارش
    public class OrderProcessor
    {
        private IShippingStrategy _shippingStrategy;

        public OrderProcessor(IShippingStrategy shippingStrategy)
        {
            _shippingStrategy = shippingStrategy;
        }

        public void ProcessOrder(decimal orderTotal)
        {
            decimal shippingCost = _shippingStrategy.CalculateShippingCost(orderTotal);
            Console.WriteLine($"Order Total: {orderTotal:C}");
            Console.WriteLine($"Shipping Cost: {shippingCost:C}");
            Console.WriteLine($"Total Cost: {orderTotal + shippingCost:C}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // ایجاد متغیر از نوع IShippingStrategy
            IShippingStrategy shippingStrategy;

            // ایجاد پردازشگر سفارش
            OrderProcessor orderProcessor;

            // 1. استفاده از استراتژی ارسال استاندارد
            shippingStrategy = new StandardShippingStrategy();
            orderProcessor = new OrderProcessor(shippingStrategy);
            orderProcessor.ProcessOrder(1000m);

            // 2. تغییر استراتژی به ارسال اکسپرس
            shippingStrategy = new ExpressShippingStrategy();
            orderProcessor = new OrderProcessor(shippingStrategy);
            orderProcessor.ProcessOrder(1000m);

            // 3. تغییر استراتژی به ارسال شبانه
            shippingStrategy = new OvernightShippingStrategy();
            orderProcessor = new OrderProcessor(shippingStrategy);
            orderProcessor.ProcessOrder(1000m);

            Console.ReadLine();






            //// پردازش سفارش با استراتژی ارسال استاندارد
            //var standardShipping = new StandardShippingStrategy();
            //var orderProcessorStandard = new OrderProcessor(standardShipping);
            //orderProcessorStandard.ProcessOrder(1000m);

            //// پردازش سفارش با استراتژی ارسال اکسپرس
            //var expressShipping = new ExpressShippingStrategy();
            //var orderProcessorExpress = new OrderProcessor(expressShipping);
            //orderProcessorExpress.ProcessOrder(1000m);

            //// پردازش سفارش با استراتژی ارسال شبانه
            //var overnightShipping = new OvernightShippingStrategy();
            //var orderProcessorOvernight = new OrderProcessor(overnightShipping);
            //orderProcessorOvernight.ProcessOrder(1000m);

            Console.ReadLine();
        }
    }








}
