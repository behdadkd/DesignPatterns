Employee dev1 = new Developer("Behdad", "Developer");
Employee dev2 = new Developer("Kiarash", "Developer");
Employee designer = new Designer("Amirreza", "Designer");

Manager devManager = new Manager("Haj Mehran", "Manager");
devManager.AddStaff(dev1);
devManager.AddStaff(dev2);

Manager generalManager = new Manager("Haj Mehdi", "Majesty of Love");
generalManager.AddStaff(devManager);
generalManager.AddStaff(designer);

Console.WriteLine(generalManager.GetDetails());

public abstract class Employee
{
    public string Name { get; set; }
    public string Position { get; set; }

    protected Employee(string name, string position)
    {
        Name = name;
        Position = position;
    }

    public virtual string GetDetails() => $"{Name}: {Position}";

}
public class Developer : Employee
{
    public Developer(string name, string position) : base(name, position) { }
}

public class Designer : Employee
{
    public Designer(string name, string position) : base(name, position) { }

}

public class Manager : Employee
{
    private List<Employee> _staff;

    public Manager(string name, string position) : base(name, position)
    {
        _staff = new List<Employee>();
    }

    public void AddStaff(Employee employee) => _staff.Add(employee);

    public void RemoveStaff(Employee employee) => _staff.Remove(employee);

    public override string GetDetails()
    {
        var details = $"{Name}: {Position} {{";
        foreach (var subordinate in _staff)
        {
            details += $"{subordinate.GetDetails()}, ";
        }
        details += $"}}";
        return details.ToString();
    }
}
