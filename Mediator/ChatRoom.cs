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
