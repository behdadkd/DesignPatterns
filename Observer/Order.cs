

// Subject
public class Store
{
    private List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
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
            observer.Update();
        }
    }

    public void NewProductArrived()
    {
        // Logic for new product arrival
        NotifyObservers();
    }
}

// Observer Interface
public interface IObserver
{
    void Update();
}

// Concrete Observer
public class Customer : IObserver
{
    private string name;

    public Customer(string name)
    {
        this.name = name;
    }

    public void Update()
    {
        Console.WriteLine($"Hey {name}, a new product has arrived!");
    }
}

// Usage
public class Program
{
    public static void Main()
    {
        Store store = new Store();
        Customer customer1 = new Customer("Alice");
        Customer customer2 = new Customer("Bob");

        store.AddObserver(customer1);
        store.AddObserver(customer2);

        store.NewProductArrived();
    }
}
