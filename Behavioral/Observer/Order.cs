
namespace Observer
{
    using System;
    using System.Collections.Generic;

    // رابط Observer
    public interface IObserver
    {
        void Update(string productName, int quantity);
    }

    // رابط Subject
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    public class Product : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private string _name;
        private int _stock;

        public Product(string name, int stock)
        {
            _name = name;
            _stock = stock;
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_name, _stock);
            }
        }

        public void PlaceOrder(int quantity)
        {
            if (quantity > _stock)
            {
                Console.WriteLine($"Not enough stock for {quantity} of {_name}. Available stock: {_stock}.");
            }
            else
            {
                _stock -= quantity;
                Console.WriteLine($"Order placed for {quantity} of {_name}. Remaining stock: {_stock}.");
                NotifyObservers();
            }
        }
    }
    public class Customer : IObserver
    {
        private string _name;

        public Customer(string name)
        {
            _name = name;
        }

        public void Update(string productName, int quantity)
        {
            Console.WriteLine($"{_name} has been notified: {productName} stock has been updated. Current stock: {quantity}.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // ایجاد محصولات
            var product1 = new Product("Laptop", 50);
            var product2 = new Product("Smartphone", 30);

            // ایجاد مشتریان
            var customer1 = new Customer("Alice");
            var customer2 = new Customer("Bob");

            // ثبت‌نام مشتریان به محصولات
            product1.RegisterObserver(customer1);
            product1.RegisterObserver(customer2);

            product2.RegisterObserver(customer1);

            // ثبت سفارش و اطلاع‌رسانی به مشتریان
            product1.PlaceOrder(10); // این تغییر باعث اطلاع‌رسانی به مشتریان می‌شود.
            product1.PlaceOrder(45); // این تغییر هم باعث اطلاع‌رسانی می‌شود.
            product2.PlaceOrder(5);  // این تغییر باعث اطلاع‌رسانی به Alice می‌شود.

            Console.ReadLine();
        }
    }


}
