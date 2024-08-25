namespace Strategy
{
    using System;


    //// رابط استراتژی
    //public interface IShippingStrategy
    //    {
    //        decimal CalculateShippingCost(decimal orderTotal);
    //    }

    //    // استراتژی ارسال استاندارد
    //    public class StandardShippingStrategy : IShippingStrategy
    //    {
    //        public decimal CalculateShippingCost(decimal orderTotal)
    //        {
    //            return orderTotal * 0.05m; // 5% هزینه ارسال
    //        }
    //    }

    //    // استراتژی ارسال اکسپرس
    //    public class ExpressShippingStrategy : IShippingStrategy
    //    {
    //        public decimal CalculateShippingCost(decimal orderTotal)
    //        {
    //            return orderTotal * 0.10m; // 10% هزینه ارسال
    //        }
    //    }

    //    // استراتژی ارسال شبانه
    //    public class OvernightShippingStrategy : IShippingStrategy
    //    {
    //        public decimal CalculateShippingCost(decimal orderTotal)
    //        {
    //            return orderTotal * 0.20m; // 20% هزینه ارسال
    //        }
    //    }

    //    // کلاس برای پردازش سفارش
    //    public class OrderProcessor
    //    {
    //        private IShippingStrategy _shippingStrategy;

    //        public OrderProcessor(IShippingStrategy shippingStrategy)
    //        {
    //            _shippingStrategy = shippingStrategy;
    //        }

    //        public void ProcessOrder(decimal orderTotal)
    //        {
    //            decimal shippingCost = _shippingStrategy.CalculateShippingCost(orderTotal);
    //            Console.WriteLine($"Order Total: {orderTotal:C}");
    //            Console.WriteLine($"Shipping Cost: {shippingCost:C}");
    //            Console.WriteLine($"Total Cost: {orderTotal + shippingCost:C}");
    //        }
    //    }

    //    class Program
    //    {
    //        static void Main(string[] args)
    //        {
    //            // پردازش سفارش با استراتژی ارسال استاندارد
    //            var standardShipping = new StandardShippingStrategy();
    //            var orderProcessorStandard = new OrderProcessor(standardShipping);
    //            orderProcessorStandard.ProcessOrder(1000m);

    //            // پردازش سفارش با استراتژی ارسال اکسپرس
    //            var expressShipping = new ExpressShippingStrategy();
    //            var orderProcessorExpress = new OrderProcessor(expressShipping);
    //            orderProcessorExpress.ProcessOrder(1000m);

    //            // پردازش سفارش با استراتژی ارسال شبانه
    //            var overnightShipping = new OvernightShippingStrategy();
    //            var orderProcessorOvernight = new OrderProcessor(overnightShipping);
    //            orderProcessorOvernight.ProcessOrder(1000m);

    //            Console.ReadLine();
    //        }
    //    }




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

    class Program
    {
        static void Main(string[] args)
        {
            var orderProcessor = new OrderProcessor();

            // پردازش سفارش با روش ارسال استاندارد
            orderProcessor.ProcessOrder(1000m, "Standard");

            // پردازش سفارش با روش ارسال اکسپرس
            orderProcessor.ProcessOrder(1000m, "Express");

            // پردازش سفارش با روش ارسال شبانه
            orderProcessor.ProcessOrder(1000m, "Overnight");

            Console.ReadLine();
        }
    }




}
