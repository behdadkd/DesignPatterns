// See https://aka.ms/new-console-template for more information
IApplication wordApp = ApplicationFactory.CreateApplication(AppType.Word);
wordApp.Run();

IApplication pdfApp = ApplicationFactory.CreateApplication(AppType.Pdf);
pdfApp.Run();



public interface IApplication
{
    public void Run();
}

public class WordApplication : IApplication
{
    public void Run() => Console.WriteLine("Word Application Run.");
}
public class PdfApplication : IApplication
{
    public void Run() => Console.WriteLine("Pdf Application Run.");
}
public static class ApplicationFactory
{
    public static IApplication CreateApplication(AppType appType)
    {
        return appType switch
        {
            AppType.Word => new WordApplication(),
            AppType.Pdf => new PdfApplication(),
            _ => throw new ArgumentException("Invalid app type"),
        };
    }
}

public enum AppType
{
    Word,
    Pdf
}