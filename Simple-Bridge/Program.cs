IMessageSender emailSender = new EmailSender();
IMessageSender smsSender = new SmsSender();

Message shortMessage = new ShortMessage(emailSender);
Message longMessage = new LongMessage(smsSender);

shortMessage.Send("Hello, This Is A Message!");
longMessage.Send("Hello, This Is A Message!");

public interface IMessageSender
{
    void SendMessage(string message);
}
public class EmailSender : IMessageSender
{
    public void SendMessage(string message) => Console.WriteLine($"Sending Email: {message}");
}

public class SmsSender : IMessageSender
{
    public void SendMessage(string message) => Console.WriteLine($"Sending SMS: {message}");
}

public abstract class Message
{
    protected IMessageSender messageSender;

    public Message(IMessageSender sender)
    {
        messageSender = sender;
    }

    public abstract void Send(string content);
}
public class ShortMessage : Message
{
    public ShortMessage(IMessageSender sender) : base(sender) { }

    public override void Send(string content)
    {

        messageSender.SendMessage(content.Trim().Replace(" ", ""));
    }
}

public class LongMessage : Message
{
    public LongMessage(IMessageSender sender) : base(sender) { }

    public override void Send(string content)
    {
        messageSender.SendMessage(content.Replace(" ", "     "));
    }
}
