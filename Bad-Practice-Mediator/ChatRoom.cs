public class User
{
    public string Name { get; private set; }
    private List<User> _contacts;

    public User(string name)
    {
        Name = name;
        _contacts = new List<User>();
    }

    public void AddContact(User user)
    {
        if (!_contacts.Contains(user))
        {
            _contacts.Add(user);
        }
    }

    public void Send(string message)
    {
        Console.WriteLine($"{Name} sends: {message}");
        foreach (var contact in _contacts)
        {
            contact.Receive(message, Name);
        }
    }

    public void Receive(string message, string senderName)
    {
        Console.WriteLine($"{Name} receives from {senderName}: {message}");
    }
}


class Program
{
    static void Main(string[] args)
    {
        // ایجاد کاربران
        User user1 = new User("Alice");
        User user2 = new User("Bob");
        User user3 = new User("Charlie");

        // اضافه کردن کاربران به لیست مخاطبین یکدیگر
        user1.AddContact(user2);
        user1.AddContact(user3);

        user2.AddContact(user1);
        user2.AddContact(user3);

        user3.AddContact(user1);
        user3.AddContact(user2);

        // ارسال پیام توسط کاربران
        user1.Send("Hello, everyone!");
        user2.Send("Hi, Alice!");
        user3.Send("Hey guys!");
    }
}

