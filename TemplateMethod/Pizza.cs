
public abstract class Pizza
{
    public void Make()
    {
        PrepareDough();
        AddSauce();
        AddToppings();
        Bake();
    }

    protected abstract void PrepareDough();
    protected abstract void AddSauce();
    protected abstract void AddToppings();
    protected virtual void Bake()
    {
        Console.WriteLine("Baking pizza at 400 degrees for 20 minutes.");
    }
}

public class PepperoniPizza : Pizza
{
    protected override void PrepareDough()
    {
        Console.WriteLine("Preparing thick crust dough.");
    }
    protected override void AddSauce()
    {
        Console.WriteLine("Adding tomato sauce.");
    }
    protected override void AddToppings()
    {
        Console.WriteLine("Adding pepperoni, cheese, and mushrooms.");
    }
}

public class MargheritaPizza : Pizza
{
    protected override void PrepareDough()
    {
        Console.WriteLine("Preparing thin crust dough.");
    }
    protected override void AddSauce()
    {
        Console.WriteLine("Adding marinara sauce.");
    }
    protected override void AddToppings()
    {
        Console.WriteLine("Adding mozzarella cheese and basil.");
    }
}

public class Program
{
    public static void Main()
    {
        Pizza pepperoniPizza = new PepperoniPizza();
        pepperoniPizza.Make();
        Console.WriteLine();
        Pizza margheritaPizza = new MargheritaPizza();
        margheritaPizza.Make();
    }
}
