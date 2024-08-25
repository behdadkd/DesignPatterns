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

public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _decoratedCoffee { get; set; }
    public string GetDescription() => throw new NotImplementedException();
    public double GetCost() => throw new NotImplementedException();
}

public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) { _decoratedCoffee = coffee; }
    public string GetDescription() => _decoratedCoffee.GetDescription() + ", with milk";
    public new double GetCost() => _decoratedCoffee.GetCost() + 0.50;
}
public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) { _decoratedCoffee = coffee; }
    public string GetDescription() => _decoratedCoffee.GetDescription() + ", with sugar";
    public double GetCost() => _decoratedCoffee.GetCost() + 0.20;
}