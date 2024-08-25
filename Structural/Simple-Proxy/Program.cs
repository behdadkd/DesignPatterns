IReport report = new ProxyReport("This is a detailed report on Proxy Pattern.");

// The real report is not generated yet
Console.WriteLine("ProxyReport is created. Report generation is deferred.");

// When the report is needed, it is generated
report.GenerateReport();


public interface IReport
{
    void GenerateReport();
}
public class RealReport : IReport
{

    public RealReport(string content)
    {
        Console.WriteLine("Generating report...");
    }

    public void GenerateReport()
    {
        Console.WriteLine($"Report Created");
    }
}

public class ProxyReport : IReport
{
    private RealReport? _realReport;
    private string _reportContent;

    public ProxyReport(string content)
    {
        _reportContent = content;
    }

    public void GenerateReport()
    {
        if (CheckAccess())
        {
            _realReport.GenerateReport();
        }
        LogAccess();

        bool CheckAccess()
        {
            Console.WriteLine("Proxy: Checking access prior to firing a real request.");
            return true;
        }

        void LogAccess() => Console.WriteLine("Proxy: Logging the time of request.");
    }
}
