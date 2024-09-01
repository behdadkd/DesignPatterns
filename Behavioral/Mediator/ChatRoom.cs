// Mediator Interface
public interface IChatRoom
{
    void SendMessage(string message, User user);
    void RegisterUser(User user);
}

// Concrete Mediator
public class ChatRoom : IChatRoom
{
    private List<User> _users = new List<User>();

    public void RegisterUser(User user)
    {
        if (!_users.Contains(user))
        {
            _users.Add(user);
        }
    }

    public void SendMessage(string message, User sender)
    {
        foreach (var user in _users)
        {
            if (user != sender)
            {
                user.Receive(message, sender.Name);
            }
        }
    }
}

// Colleague
public abstract class User
{
    protected IChatRoom _chatRoom;
    public string Name { get; private set; }

    public User(string name, IChatRoom chatRoom)
    {
        Name = name;
        _chatRoom = chatRoom;
    } 

    public abstract void Send(string message);
    public abstract void Receive(string message, string senderName);
}

// Concrete Colleague
public class ConcreteUser : User
{
    public ConcreteUser(string name, IChatRoom chatRoom) : base(name, chatRoom) { }

    public override void Send(string message)
    {
        Console.WriteLine($"{Name} sends: {message}");
        _chatRoom.SendMessage(message, this);
    }

    public override void Receive(string message, string senderName)
    {
        Console.WriteLine($"{Name} receives from {senderName}: {message}");
    }
}

// Usage
class Program
{
    static void Main(string[] args)
    {
        IChatRoom chatRoom = new ChatRoom();

        User user1 = new ConcreteUser("Alice", chatRoom);
        User user2 = new ConcreteUser("Bob", chatRoom);
        User user3 = new ConcreteUser("Charlie", chatRoom);

        chatRoom.RegisterUser(user1);
        chatRoom.RegisterUser(user2);
        chatRoom.RegisterUser(user3);

        user1.Send("Hello, everyone!");
        user2.Send("Hi, Alice!");
        user3.Send("Hey guys!");
    }
}
