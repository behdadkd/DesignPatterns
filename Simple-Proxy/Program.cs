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
    private string _reportContent;

    public RealReport(string content)
    {
        // Simulate expensive report generation
        Console.WriteLine("Generating report...");
        _reportContent = content;
    }

    public void GenerateReport()
    {
        Console.WriteLine($"Report Content: {_reportContent}");
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
        if (_realReport == null)
        {
            _realReport = new RealReport(_reportContent);
        }
        _realReport.GenerateReport();
    }
}
