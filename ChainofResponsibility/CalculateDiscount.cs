using System;

namespace ChainofResponsibility
{
    public class Customer
    {
        public bool IsVIP { get; set; }
        public bool IsRegular { get; set; }
        public bool IsNew { get; set; }
    }

    public static class Calculate
    {
        public static decimal CalculateDiscount(Customer customer, decimal orderTotal)
        {
            if (customer.IsVIP)
            {
                return orderTotal * 0.8m; // 20% تخفیف
            }
            else if (customer.IsRegular)
            {
                return orderTotal * 0.9m; // 10% تخفیف
            }
            else if (customer.IsNew)
            {
                return orderTotal * 0.95m; // 5% تخفیف
            }
            else
            {
                return orderTotal; // بدون تخفیف
            }
        }

    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var customer = new Customer { IsNew = true };
    //        decimal orderTotal = 10_000;

    //        decimal discountedTotal = Calculate.CalculateDiscount(customer, orderTotal);
    //        Console.WriteLine($"The discounted total is: {discountedTotal}");
    //    }
    //}


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


    class Program
    {
        static void Main(string[] args)
        {
            var vipHandler = new VIPDiscountHandler();
            vipHandler.SetNextHandler(new RegularDiscountHandler())
                      .SetNextHandler(new NewDiscountHandler())
                      .SetNextHandler(new NoDiscountHandler());

            var customer = new Customer { IsNew = true };
            decimal orderTotal = 10_000;
            decimal discountedTotal = vipHandler.Handle(customer, orderTotal);

            Console.WriteLine($"The discounted total is: {discountedTotal}");
        }
    }




    //// پایه‌ای برای تمام هندلرها
    //public abstract class Handler
    //    {
    //        protected Handler Successor;

    //        public void SetSuccessor(Handler successor)
    //        {
    //            Successor = successor;
    //        }

    //        public abstract void Handle(Request request);
    //    }

    //    // هندلر برای چک کردن شماره کارت
    //    public class CardNumberHandler : Handler
    //    {
    //        public override void Handle(Request request)
    //        {
    //            Console.WriteLine("Checking card number");
    //            // ادامه پردازش را به هندلر بعدی منتقل کن
    //            Successor?.Handle(request);
    //        }
    //    }

    //    // هندلر برای چک کردن مبلغ تراکنش
    //    public class TransactionAmountHandler : Handler
    //    {
    //        public override void Handle(Request request)
    //        {
    //            Console.WriteLine("Checking transaction amount");
    //            if (request.Amount > 500_000_000)
    //            {
    //                // اگر مبلغ بیشتر از حد تعیین شده است، درخواست را به هندلر بعدی منتقل کن
    //                Successor?.Handle(request);
    //            }
    //            else
    //            {
    //                Console.WriteLine("Transaction amount is below the threshold, no mobile number check required.");
    //                // اگر مبلغ کمتر از حد است، پردازش ادامه می‌یابد (اگر هندلر بعدی باشد).
    //                Successor?.Handle(request);
    //            }
    //        }
    //    }

    //    // هندلر برای چک کردن شماره موبایل
    //    public class MobileNumberHandler : Handler
    //    {
    //        public override void Handle(Request request)
    //        {
    //            Console.WriteLine("Checking mobile number");
    //            // پردازش را به پایان برسانید (اگر هندلر بعدی باشد، پردازش ادامه می‌یابد).
    //        }
    //    }

    //    // کلاس درخواست
    //    public class Request
    //    {
    //        public string CardNumber { get; set; }
    //        public long Amount { get; set; }
    //        public string MobileNumber { get; set; }
    //    }

    //class Program
    //{
    //    static void Main()
    //    {
    //        // ایجاد هندلرها
    //        var mobileNumberHandler = new MobileNumberHandler();
    //        var transactionAmountHandler = new TransactionAmountHandler();
    //        var cardNumberHandler = new CardNumberHandler();

    //        // تنظیم زنجیره هندلرها
    //        cardNumberHandler.SetSuccessor(transactionAmountHandler);
    //        transactionAmountHandler.SetSuccessor(mobileNumberHandler);

    //        // ایجاد درخواست
    //        var request = new Request
    //        {
    //            CardNumber = "1234-5678-9876-5432",
    //            Amount = 600_000_000,
    //            MobileNumber = "09123456789"
    //        };

    //        // پردازش درخواست
    //        cardNumberHandler.Handle(request);
    //    }
    //}

}

