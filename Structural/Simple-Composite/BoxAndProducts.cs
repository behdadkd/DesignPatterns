namespace Simple_Composite;
public class BoxAndProducts
{
}

public interface IComponent
{
    public decimal Price { get; set; }
    public decimal GetPrice();
}

public class Phone : IComponent
{
    public decimal Price { get; set; }
    public decimal GetPrice() => 500;
}
public class Charger : IComponent
{
    public decimal Price { get; set; }
    public decimal GetPrice() => 100;
}

public class Box : IComponent
{
    private List<IComponent> _items = new List<IComponent>();

    public decimal Price { get; set; }
    public decimal GetPrice() => 5.5m + _items.Sum(s => s.Price);
    public void AddItem(IComponent component) => _items.Add(component);
    public void RemoveItem(IComponent component) => _items.Remove(component);
}
