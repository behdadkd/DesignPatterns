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


//// Mediator Interface
//public interface IChatRoom
//{
//    void SendMessage(string message, User user);
//    void RegisterUser(User user);
//}

//// Concrete Mediator
//public class ChatRoom : IChatRoom
//{
//    private List<User> _users = new List<User>();

//    public void RegisterUser(User user)
//    {
//        if (!_users.Contains(user))
//        {
//            _users.Add(user);
//        }
//    }

//    public void SendMessage(string message, User sender)
//    {
//        foreach (var user in _users)
//        {
//            if (user != sender)
//            {
//                user.Receive(message, sender.Name);
//            }
//        }
//    }
//}

//// Colleague
//public abstract class User
//{
//    protected IChatRoom _chatRoom;
//    public string Name { get; private set; }

//    public User(string name, IChatRoom chatRoom)
//    {
//        Name = name;
//        _chatRoom = chatRoom;
//    }

//    public abstract void Send(string message);
//    public abstract void Receive(string message, string senderName);
//}

//// Concrete Colleague
//public class ConcreteUser : User
//{
//    public ConcreteUser(string name, IChatRoom chatRoom) : base(name, chatRoom) { }

//    public override void Send(string message)
//    {
//        Console.WriteLine($"{Name} sends: {message}");
//        _chatRoom.SendMessage(message, this);
//    }

//    public override void Receive(string message, string senderName)
//    {
//        Console.WriteLine($"{Name} receives from {senderName}: {message}");
//    }
//}

//// Usage
//class Program
//{
//    static void Main(string[] args)
//    {
//        IChatRoom chatRoom = new ChatRoom();

//        User user1 = new ConcreteUser("Alice", chatRoom);
//        User user2 = new ConcreteUser("Bob", chatRoom);
//        User user3 = new ConcreteUser("Charlie", chatRoom);

//        chatRoom.RegisterUser(user1);
//        chatRoom.RegisterUser(user2);
//        chatRoom.RegisterUser(user3);

//        user1.Send("Hello, everyone!");
//        user2.Send("Hi, Alice!");
//        user3.Send("Hey guys!");
//    }
//}
