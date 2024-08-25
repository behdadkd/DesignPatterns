//var _logger = Logger.GetInstance();
//_logger.Log("test");


//var _logger2 = Logger.GetInstance();
//_logger2.Log("test2");


//var _logger3 = Logger.GetInstance();
//_logger3.Log("test3");


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



public class Logger
{
    private static Logger _instance = default!;
    private Logger()
    {
        Console.WriteLine("New instance was created");
    }
    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Logger();

        }
        return _instance;
    }
    public void Log(string message)
    {
        Console.WriteLine($"message  => {message}");
    }
}