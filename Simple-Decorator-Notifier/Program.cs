INotifier notification = new SMSNotifier();
notification.Send();

Console.WriteLine("-----------------");

notification = new SlackDecorator(notification);
notification.Send();

Console.WriteLine("-----------------");

notification = new FacebookDecorator(notification);
notification.Send();

Console.WriteLine("-----------------");

public interface INotifier
{
    void Send();
}
public class SMSNotifier : INotifier
{
    public void Send() => Console.WriteLine("sms sent");
}

public abstract class NotifierDecorator : INotifier
{
    protected INotifier _decoratedNotifier { get; set; }
    public virtual void Send() => throw new NotImplementedException();
}

public class SlackDecorator : NotifierDecorator
{
    public SlackDecorator(INotifier notifier) { _decoratedNotifier = notifier; }
    public override void Send()
    {
        _decoratedNotifier.Send();
        Console.WriteLine("Slack sent");
    }
}
public class FacebookDecorator : NotifierDecorator
{
    public FacebookDecorator(INotifier notifier) { _decoratedNotifier = notifier; }
    public override void Send()
    {
        _decoratedNotifier.Send();
        Console.WriteLine("Facebook sent");
    }
}