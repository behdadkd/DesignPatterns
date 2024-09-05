
public class PaymentRequest
{
    public string CardNumber { get; set; }
    public string MobileNumber { get; set; }
    public string RegisteredMobileNumber { get; set; }
    public decimal Amount { get; set; }
    public string DestinationCardNumber { get; set; }
    public bool IsCardBlocked { get; set; }
    public decimal DailyTransactionAmount { get; set; }
    public bool IsCardAndMobileMatched { get; set; }
    public string OriginCountry { get; set; }
    public string DestinationCountry { get; set; }
    public bool IsProcessingStopped { get; set; } = false; // برای کنترل توقف پردازش
}




//var vipHandler = new VIPDiscountHandler();
//vipHandler.SetNextHandler(new RegularDiscountHandler())
//          .SetNextHandler(new NewDiscountHandler())
//          .SetNextHandler(new NoDiscountHandler());

//var customer = new Customer { IsNew = true };
//decimal orderTotal = 10_000;
//decimal discountedTotal = vipHandler.Handle(customer, orderTotal);

//Console.WriteLine($"The discounted total is: {discountedTotal}");



//public class Customer
//{
//    public bool IsVIP { get; set; }
//    public bool IsRegular { get; set; }
//    public bool IsNew { get; set; }
//}


//public abstract class DiscountHandler
//{
//    protected DiscountHandler _nextHandler;

//    public DiscountHandler SetNextHandler(DiscountHandler nextHandler)
//    {
//        _nextHandler = nextHandler;
//        return nextHandler;
//    }

//    public abstract decimal Handle(Customer customer, decimal orderTotal);
//}

//public class VIPDiscountHandler : DiscountHandler
//{
//    public override decimal Handle(Customer customer, decimal orderTotal)
//    {
//        if (customer.IsVIP)
//        {
//            return orderTotal * 0.8m; // 20% تخفیف
//        }
//        else if (_nextHandler != null)
//        {
//            return _nextHandler.Handle(customer, orderTotal);
//        }

//        return orderTotal;
//    }
//}

//public class RegularDiscountHandler : DiscountHandler
//{
//    public override decimal Handle(Customer customer, decimal orderTotal)
//    {
//        if (customer.IsRegular)
//        {
//            return orderTotal * 0.9m; // 10% تخفیف
//        }
//        else if (_nextHandler != null)
//        {
//            return _nextHandler.Handle(customer, orderTotal);
//        }

//        return orderTotal;
//    }
//}

//public class NewDiscountHandler : DiscountHandler
//{
//    public override decimal Handle(Customer customer, decimal orderTotal)
//    {
//        if (customer.IsNew)
//        {
//            return orderTotal * 0.95m; // 5% تخفیف
//        }
//        else if (_nextHandler != null)
//        {
//            return _nextHandler.Handle(customer, orderTotal);
//        }

//        return orderTotal;
//    }
//}

//public class NoDiscountHandler : DiscountHandler
//{
//    public override decimal Handle(Customer customer, decimal orderTotal)
//    {
//        return orderTotal; // بدون تخفیف
//    }
//}



//توقف زنجیر 

//public interface IHandler
//{
//    IHandler SetNext(IHandler handler);
//    void Handle(PaymentRequest request);
//}
//public abstract class BaseHandler : IHandler
//{
//    private IHandler _nextHandler;

//    public IHandler SetNext(IHandler handler)
//    {
//        _nextHandler = handler;
//        return handler;
//    }

//    public virtual void Handle(PaymentRequest request)
//    {
//        if (request.IsProcessingStopped)
//        {
//            return; // پردازش متوقف شده است، هیچ هندلری پردازش را ادامه نمی‌دهد
//        }

//        if (_nextHandler != null)
//        {
//            _nextHandler.Handle(request);
//        }
//    }
//}
//public class CardValidationHandler : BaseHandler
//{
//    public override void Handle(PaymentRequest request)
//    {
//        if (request.IsCardBlocked)
//        {
//            Console.WriteLine("کارت مسدود است.");
//            request.IsProcessingStopped = true; // توقف پردازش
//            return;
//        }

//        if (request.DailyTransactionAmount > 10000000)
//        {
//            Console.WriteLine("محدودیت روزانه تراکنش بیشتر از 10 میلیون است.");
//            request.IsProcessingStopped = true; // توقف پردازش
//            return;
//        }

//        base.Handle(request);
//    }
//}

//public class AmountValidationHandler : BaseHandler
//{
//    public override void Handle(PaymentRequest request)
//    {
//        if (request.Amount > 200000000)
//        {
//            // چک کردن مطابقت شماره کارت و موبایل
//            if (!request.IsCardAndMobileMatched)
//            {
//                Console.WriteLine("شماره کارت و شماره موبایل مطابقت ندارند.");
//                request.IsProcessingStopped = true; // توقف پردازش
//                return;
//            }
//        }

//        base.Handle(request);
//    }
//}

//public class DestinationCardValidationHandler : BaseHandler
//{
//    public override void Handle(PaymentRequest request)
//    {
//        if (string.IsNullOrEmpty(request.DestinationCardNumber))
//        {
//            Console.WriteLine("شماره کارت مقصد نامعتبر است.");
//            request.IsProcessingStopped = true; // توقف پردازش
//            return;
//        }

//        base.Handle(request);
//    }
//}
//public class TransactionHandler : BaseHandler
//{
//    public override void Handle(PaymentRequest request)
//    {
//        if (request.IsProcessingStopped)
//        {
//            // پردازش متوقف شده است، بنابراین هیچ تراکنشی انجام نمی‌شود
//            Console.WriteLine("پردازش تراکنش متوقف شده است.");
//            return;
//        }

//        Console.WriteLine("تراکنش با موفقیت انجام شد.");
//    }
//}

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        // ایجاد هندلرها
//        var cardValidation = new CardValidationHandler();
//        var amountValidation = new AmountValidationHandler();
//        var destinationCardValidation = new DestinationCardValidationHandler();
//        var transaction = new TransactionHandler();

//        // تنظیم زنجیره هندلرها
//        cardValidation.SetNext(amountValidation)
//                      .SetNext(destinationCardValidation)
//                      .SetNext(transaction);

//        // نمونه‌ای از درخواست پرداخت
//        var request = new PaymentRequest
//        {
//            CardNumber = "1234-5678-9876-5432",
//            MobileNumber = "09121234567",
//            RegisteredMobileNumber = "09121234567",
//            Amount = 250000000, // مبلغ بیشتر از 200 میلیون
//            DestinationCardNumber = "4321-8765-6789-1234",
//            IsCardBlocked = false,
//            DailyTransactionAmount = 5000000,
//            IsCardAndMobileMatched = false // شماره کارت و موبایل مطابقت ندارد
//        };

//        // اجرای زنجیره
//        cardValidation.Handle(request);
//    }
//}




//شرط ورود 
public class CardValidationHandler : BaseHandler
{
    public override void Handle(PaymentRequest request)
    {
        if (request.IsCardBlocked)
        {
            Console.WriteLine("کارت مسدود است، اما پردازش ادامه می‌یابد.");
        }
        else
        {
            Console.WriteLine("کارت معتبر است.");
        }

        // ادامه زنجیره
        base.Handle(request);
    }
}
public class AmountValidationHandler : BaseHandler
{
    public override void Handle(PaymentRequest request)
    {
        // شرط ورود: فقط اگر مبلغ تراکنش بیشتر از 200 میلیون باشد
        if (request.Amount <= 200000000)
        {
            // اگر شرط ورود برقرار نباشد، به هندلر بعدی می‌رود
            base.Handle(request);
            return;
        }

        // اگر شرط ورود برقرار باشد
        if (request.IsCardAndMobileMatched)
        {
            Console.WriteLine("شماره کارت و شماره موبایل مطابقت دارند، ادامه پردازش.");
        }
        else
        {
            Console.WriteLine("شماره کارت و شماره موبایل مطابقت ندارند.");
        }

        // ادامه زنجیره
        base.Handle(request);
    }
}

public class DestinationCardValidationHandler : BaseHandler
{
    public override void Handle(PaymentRequest request)
    {
        if (string.IsNullOrEmpty(request.DestinationCardNumber))
        {
            Console.WriteLine("شماره کارت مقصد نامعتبر است.");
        }

        base.Handle(request);
    }
}
public class TransactionHandler : BaseHandler
{
    public override void Handle(PaymentRequest request)
    {
        if (!request.IsProcessingStopped)
        {
            Console.WriteLine("تراکنش با موفقیت انجام شد.");
        }
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        // ایجاد هندلرها
        var cardValidation = new CardValidationHandler();
        var amountValidation = new AmountValidationHandler();
        var destinationCardValidation = new DestinationCardValidationHandler();
        var transaction = new TransactionHandler();

        // تنظیم زنجیره هندلرها
        cardValidation.SetNext(amountValidation)
                      .SetNext(destinationCardValidation)
                      .SetNext(transaction);

        // نمونه‌ای از درخواست پرداخت
        var request = new PaymentRequest
        {
            CardNumber = "1234-5678-9876-5432",
            MobileNumber = "09121234567",
            RegisteredMobileNumber = "09121234567",
            Amount = 150000000, // مبلغ کمتر از 200 میلیون
            DestinationCardNumber = "4321-8765-6789-1234",
            IsCardBlocked = false,
            DailyTransactionAmount = 5000000,
            IsCardAndMobileMatched = true // شماره کارت و موبایل مطابقت دارند
        };

        // اجرای زنجیره
        cardValidation.Handle(request);
    }
}












//قابلیت پویایی
public abstract class BaseHandler
{
    private BaseHandler _nextHandler;

    // تنظیم هندلر بعدی در زنجیره
    public BaseHandler SetNext(BaseHandler nextHandler)
    {
        _nextHandler = nextHandler;
        return _nextHandler;
    }

    // متد مجازی برای پردازش درخواست
    public virtual void Handle(PaymentRequest request)
    {
        if (_nextHandler != null && !request.IsProcessingStopped)
        {
            _nextHandler.Handle(request);
        }
    }
}


//public class CardValidationHandler : BaseHandler
//{
//    public override void Handle(PaymentRequest request)
//    {
//        if (request.IsCardBlocked)
//        {
//            Console.WriteLine("کارت مسدود است. پردازش متوقف شد.");
//            request.IsProcessingStopped = true;
//        }
//        else
//        {
//            Console.WriteLine("کارت معتبر است.");
//            base.Handle(request);
//        }
//    }
//}

//public class AmountValidationHandler : BaseHandler
//{
//    public override void Handle(PaymentRequest request)
//    {
//        if (request.Amount > 200000000)
//        {
//            if (request.IsCardAndMobileMatched)
//            {
//                Console.WriteLine("مبلغ بالا است و شماره کارت و موبایل مطابقت دارند.");
//            }
//            else
//            {
//                Console.WriteLine("مبلغ بالا است و شماره کارت و موبایل مطابقت ندارند. پردازش متوقف شد.");
//                request.IsProcessingStopped = true;
//                return;
//            }
//        }
//        base.Handle(request);
//    }
//}

public class DomesticTransactionHandler : BaseHandler
{
    public override void Handle(PaymentRequest request)
    {
        Console.WriteLine("پردازش تراکنش داخلی.");
        base.Handle(request);
    }
}

public class InternationalTransactionHandler : BaseHandler
{
    public override void Handle(PaymentRequest request)
    {
        if (request.OriginCountry == request.DestinationCountry)
        {
            Console.WriteLine("تراکنش بین‌المللی، اما کشورهای مبدأ و مقصد یکی هستند. ادامه پردازش.");
        }
        else
        {
            Console.WriteLine("تراکنش بین‌المللی با کشورهای مختلف. بررسی‌های بیشتری لازم است.");
        }
        base.Handle(request);
    }
}

//public class TransactionHandler : BaseHandler
//{
//    public override void Handle(PaymentRequest request)
//    {
//        if (!request.IsProcessingStopped)
//        {
//            Console.WriteLine("تراکنش با موفقیت انجام شد.");
//        }
//    }
//}



//public class Program
//{
//    public static void Main(string[] args)
//    {
//        // ایجاد هندلرها
//        var cardValidation = new CardValidationHandler();
//        var amountValidation = new AmountValidationHandler();
//        var domesticTransaction = new DomesticTransactionHandler();
//        var internationalTransaction = new InternationalTransactionHandler();
//        var transaction = new TransactionHandler();

//        // تصمیم‌گیری بر اساس نوع تراکنش
//        var request = new PaymentRequest
//        {
//            CardNumber = "1234-5678-9876-5432",
//            MobileNumber = "09121234567",
//            RegisteredMobileNumber = "09121234567",
//            Amount = 250000000, // مبلغ بیش از 200 میلیون
//            DestinationCardNumber = "4321-8765-6789-1234",
//            IsCardBlocked = false,
//            DailyTransactionAmount = 5000000,
//            IsCardAndMobileMatched = true,
//            OriginCountry = "IR",
//            DestinationCountry = "US" // تراکنش بین‌المللی
//        };

//        if (request.OriginCountry == "IR" && request.DestinationCountry == "IR")
//        {
//            // زنجیره برای تراکنش‌های داخلی
//            cardValidation.SetNext(amountValidation)
//                          .SetNext(domesticTransaction)
//                          .SetNext(transaction);
//        }
//        else
//        {
//            // زنجیره برای تراکنش‌های بین‌المللی
//            cardValidation.SetNext(amountValidation)
//                          .SetNext(internationalTransaction)
//                          .SetNext(transaction);
//        }

//        // اجرای زنجیره مناسب
//        cardValidation.Handle(request);
//    }
//}







