ICoffee coffee = new SimpleCoffee();
Console.WriteLine($"{coffee.GetDescription()} : ${coffee.GetCost()}");

// Add milk
coffee = new MilkDecorator(coffee);
Console.WriteLine($"{coffee.GetDescription()} : ${coffee.GetCost()}");

// Add sugar
coffee = new SugarDecorator(coffee);
Console.WriteLine($"{coffee.GetDescription()} : ${coffee.GetCost()}");


public interface ICoffee
{
    string GetDescription();
    double GetCost();
}
public class SimpleCoffee : ICoffee
{
    public string GetDescription() => "Simple coffee";
    public double GetCost() => 2.00;
}

public interface ICoffeeDecorator : ICoffee
{
    protected ICoffee _decoratedCoffee { get; set; }
    public string GetDescription();
    public double GetCost();
}

public class MilkDecorator : ICoffeeDecorator
{
    public ICoffee _decoratedCoffee { get; set; }
    public MilkDecorator(ICoffee coffee) { _decoratedCoffee = coffee; }
    public string GetDescription() => _decoratedCoffee.GetDescription() + ", with milk";
    public double GetCost() => _decoratedCoffee.GetCost() + 0.50;
}
public class SugarDecorator : ICoffeeDecorator
{
    public ICoffee _decoratedCoffee { get; set; }
    public SugarDecorator(ICoffee coffee) { _decoratedCoffee = coffee; }
    public string GetDescription() => _decoratedCoffee.GetDescription() + ", with sugar";
    public double GetCost() => _decoratedCoffee.GetCost() + 0.20;
}