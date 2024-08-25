
var threads = Enumerable.Range(1, 10)
            .Select(threadNumber => new Thread(() =>
            {
                Logger logger = Logger.GetInstance();
                logger.Log($"Thread{threadNumber}");
            })).ToArray();

foreach (var thread in threads)
{
    thread.Start();
}

foreach (var thread in threads)
{
    thread.Join();
}



public sealed class Logger
{
    private static Logger _instance = default!;
    private static readonly object _lock = new object();

    private Logger()
    {
        Console.WriteLine("new instance was created");
    }
    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Logger();

                }
            }

        }
        return _instance;
    }
    public void Log(string message)
    {
        Console.WriteLine($"message  => {message}");
    }
}