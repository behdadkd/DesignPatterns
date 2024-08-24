namespace Mediator
{
    using System;


    // کلاس کاربر
    public class User
    {
        public string Name { get; private set; }

        public User(string name)
        {
            Name = name;
        }

        public void SendMessage(User receiver, string message)
        {
            if (receiver == null || string.IsNullOrWhiteSpace(message))
                return;

            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] {Name} to {receiver.Name}: {message}");
            receiver.ReceiveMessage(this, message);
        }

        public void ReceiveMessage(User sender, string message)
        {
            if (sender == null || string.IsNullOrWhiteSpace(message))
                return;

            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] {Name} received a message from {sender.Name}: {message}");
        }
    }

    // استفاده از سیستم چت روم
    public class ChatRoomDemo
    {
        static void Main(string[] args)
        {
            try
            {
                User hossein = new User("Hossein");
                User abbas = new User("Abbas");

                hossein.SendMessage(abbas, "Hi Abbas");
                abbas.SendMessage(hossein, "Hello Hossein");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadLine();
        }
    }



    //// رابط واسطه
    //public interface IChatRoomMediator
    //{
    //    void ShowMessage(User user, string message);
    //}

    //// پیاده‌سازی واسطه
    //public class ChatRoom : IChatRoomMediator
    //{
    //    public void ShowMessage(User user, string message)
    //    {
    //        if (user == null || string.IsNullOrWhiteSpace(message))
    //            return;
    //        Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] {user.Name} : {message}");
    //    }
    //}


    //// کلاس کاربر
    //public class User
    //{
    //    public string Name { get; private set; }
    //    private IChatRoomMediator _chatRoom;

    //    public User(string name, IChatRoomMediator chatRoom)
    //    {
    //        Name = name;
    //        _chatRoom = chatRoom;
    //    }

    //    public void SendMessage(string message)
    //    {
    //        _chatRoom.ShowMessage(this, message);
    //    }
    //}


    //// استفاده از الگو
    //public class MediatorPatternDemo
    //{
    //    static void Main(string[] args)
    //    {
    //        try
    //        {
    //            IChatRoomMediator chatRoom = new ChatRoom();

    //            User hossein = new User("Hossein", chatRoom);
    //            User abbas = new User("Abbas", chatRoom);

    //            hossein.SendMessage("Hi Abbas");
    //            abbas.SendMessage("Hello Hossein");
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Error: {ex.Message}");
    //        }
    //        Console.ReadLine();
    //    }


    //}
}




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
