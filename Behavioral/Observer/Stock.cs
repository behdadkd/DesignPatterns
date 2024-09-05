namespace Observer
{

    using System;
    using System.Collections.Generic;

    // رابط Observer
    public interface IObserver
    {
        void Update(float price);
    }

    // رابط Subject
    public interface IStock
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    // پیاده‌سازی Subject
    public class Stock : IStock
    {
        private List<IObserver> observers;
        private float price;

        public Stock()
        {
            observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(price);
            }
        }

        public void SetPrice(float newPrice)
        {
            Console.WriteLine($"Stock: Setting new price to {newPrice}");
            price = newPrice;
            NotifyObservers();
        }
    }

    // پیاده‌سازی Observer
    public class Investor : IObserver
    {
        private string _name;

        public Investor(string name)
        {
            _name = name;
        }

        public void Update(float price)
        {
            Console.WriteLine($"{_name} notified. New Stock Price: {price}");
        }
    }

    // استفاده از الگو
    public class ObserverPatternExample
    {
        static void Main(string[] args)
        {
            // ایجاد Subject (سهام)
            Stock appleStock = new Stock();

            // ایجاد Observers (سرمایه‌گذاران)
            Investor investor1 = new Investor("Alice");
            Investor investor2 = new Investor("Bob");

            // ثبت Observers
            appleStock.RegisterObserver(investor1);
            appleStock.RegisterObserver(investor2);

            // تغییر قیمت سهام و اطلاع‌رسانی به Observers
            appleStock.SetPrice(120.5f);
            appleStock.SetPrice(121.0f);

            // حذف یک Observer
            appleStock.RemoveObserver(investor1);

            // تغییر قیمت سهام و اطلاع‌رسانی به Observers باقی‌مانده
            appleStock.SetPrice(122.0f);

            Console.ReadLine();
        }
    }
}


