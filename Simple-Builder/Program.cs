IHouseBuilder builder = new HouseBuilder();

// Create a director
HouseDirector director = new HouseDirector(builder);

// Construct a simple house
director.ConstructSimpleHouse();
House simpleHouse = builder.GetResult();
Console.WriteLine(simpleHouse);


director.ConstructLuxuryHouse();
House luxuryHouse = builder.GetResult();
Console.WriteLine(luxuryHouse);

public class House
{
    public int Windows { get; set; }
    public int Doors { get; set; }
    public bool HasGarage { get; set; }
    public bool HasSwimmingPool { get; set; }
    public bool HasStatues { get; set; }
    public bool HasGarden { get; set; }

    public override string ToString()
    {
        return $"House with {Windows} windows, {Doors} doors, " +
               $"{(HasGarage ? "a garage, " : "")}" +
               $"{(HasSwimmingPool ? "a swimming pool, " : "")}" +
               $"{(HasStatues ? "statues, " : "")}" +
               $"{(HasGarden ? "a garden." : "no garden.")}";
    }
}

public interface IHouseBuilder
{
    void BuildWindows(int number);
    void BuildDoors(int number);
    void BuildGarage();
    void BuildSwimmingPool();
    void BuildStatues();
    void BuildGarden();
    House GetResult();
}

public class HouseBuilder : IHouseBuilder
{
    private House _house = new House();

    public void BuildWindows(int number) => _house.Windows = number;
    public void BuildDoors(int number) => _house.Doors = number;
    public void BuildGarage() => _house.HasGarage = true;
    public void BuildSwimmingPool() => _house.HasSwimmingPool = true;
    public void BuildStatues() => _house.HasStatues = true;
    public void BuildGarden() => _house.HasGarden = true;

    public House GetResult() => _house;

    //public void ConstructLuxuryHouse()
    //{
    //    BuildWindows(10);
    //    BuildDoors(5);
    //    BuildGarage();
    //    BuildSwimmingPool();
    //    BuildStatues();
    //    BuildGarden();
    //}
}

public class HouseDirector
{
    private readonly IHouseBuilder _builder;

    public HouseDirector(IHouseBuilder builder)
    {
        _builder = builder;
    }

    public void ConstructSimpleHouse()
    {
        _builder.BuildWindows(4);
        _builder.BuildDoors(2);
        _builder.BuildGarden();
    }

    public void ConstructLuxuryHouse()
    {
        _builder.BuildWindows(10);
        _builder.BuildDoors(5);
        _builder.BuildGarage();
        _builder.BuildSwimmingPool();
        _builder.BuildStatues();
        _builder.BuildGarden();
    }
}