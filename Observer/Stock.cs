namespace Observer
{

    using System;


    //using System;
    //using System.Collections.Generic;

    //// رابط Observer
    //public interface IObserver
    //{
    //    void Update(float price);
    //}

    //// رابط Subject
    //public interface IStock
    //{
    //    void RegisterObserver(IObserver observer);
    //    void RemoveObserver(IObserver observer);
    //    void NotifyObservers();
    //}

    //// پیاده‌سازی Subject
    //public class Stock : IStock
    //{
    //    private List<IObserver> observers;
    //    private float price;

    //    public Stock()
    //    {
    //        observers = new List<IObserver>();
    //    }

    //    public void RegisterObserver(IObserver observer)
    //    {
    //        observers.Add(observer);
    //    }

    //    public void RemoveObserver(IObserver observer)
    //    {
    //        observers.Remove(observer);
    //    }

    //    public void NotifyObservers()
    //    {
    //        foreach (var observer in observers)
    //        {
    //            observer.Update(price);
    //        }
    //    }

    //    public void SetPrice(float newPrice)
    //    {
    //        Console.WriteLine($"Stock: Setting new price to {newPrice}");
    //        price = newPrice;
    //        NotifyObservers();
    //    }
    //}

    //// پیاده‌سازی Observer
    //public class Investor : IObserver
    //{
    //    private string _name;

    //    public Investor(string name)
    //    {
    //        _name = name;
    //    }

    //    public void Update(float price)
    //    {
    //        Console.WriteLine($"{_name} notified. New Stock Price: {price}");
    //    }
    //}

    //// استفاده از الگو
    //public class ObserverPatternExample
    //{
    //    static void Main(string[] args)
    //    {
    //        // ایجاد Subject (سهام)
    //        Stock appleStock = new Stock();

    //        // ایجاد Observers (سرمایه‌گذاران)
    //        Investor investor1 = new Investor("Alice");
    //        Investor investor2 = new Investor("Bob");

    //        // ثبت Observers
    //        appleStock.RegisterObserver(investor1);
    //        appleStock.RegisterObserver(investor2);

    //        // تغییر قیمت سهام و اطلاع‌رسانی به Observers
    //        appleStock.SetPrice(120.5f);
    //        appleStock.SetPrice(121.0f);

    //        // حذف یک Observer
    //        appleStock.RemoveObserver(investor1);

    //        // تغییر قیمت سهام و اطلاع‌رسانی به Observers باقی‌مانده
    //        appleStock.SetPrice(122.0f);

    //        Console.ReadLine();
    //    }
    //}



    // کلاس سهام
    public class Stock
    {
        public string Name { get; private set; }
        public float Price { get; private set; }

        public Stock(string name, float initialPrice)
        {
            Name = name;
            Price = initialPrice;
        }

        public void SetPrice(float newPrice)
        {
            Price = newPrice;
            Console.WriteLine($"Stock: {Name} price updated to {Price}");
        }
    }

    // کلاس سرمایه‌گذار
    public class Investor
    {
        private string _name;

        public Investor(string name)
        {
            _name = name;
        }

        public void Notify(float price)
        {
            Console.WriteLine($"{_name} notified. New Stock Price: {price}");
        }
    }

    // کلاس خبرگزاری
    public class NewsAgency
    {
        public void Publish(float price)
        {
            Console.WriteLine($"NewsAgency: Breaking News! Stock price updated to {price}");
        }
    }

    public class StockMarket
    {
        static void Main(string[] args)
        {
            // ایجاد یک سهم
            Stock appleStock = new Stock("Apple", 120.5f);

            // ایجاد سرمایه‌گذار و خبرگزاری
            Investor investor1 = new Investor("Alice");
            Investor investor2 = new Investor("Bob");
            NewsAgency newsAgency = new NewsAgency();

            // به روزرسانی قیمت و اطلاع‌رسانی به صورت دستی
            appleStock.SetPrice(121.0f);
            investor1.Notify(appleStock.Price);
            investor2.Notify(appleStock.Price);
            newsAgency.Publish(appleStock.Price);

            // به روزرسانی دوباره قیمت و اطلاع‌رسانی دستی
            appleStock.SetPrice(122.0f);
            investor1.Notify(appleStock.Price);
            investor2.Notify(appleStock.Price);
            newsAgency.Publish(appleStock.Price);

            Console.ReadLine();
        }
    }



}
