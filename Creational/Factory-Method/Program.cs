// See https://aka.ms/new-console-template for more information
IApplication wordApp = new WordApplication();
wordApp.NewDocument();

IApplication pdfApp = new PdfApplication();
pdfApp.NewDocument();



public interface IDocument
{
    public void Open();
    public void Close();
}

public class WordDocument : IDocument
{
    public void Open() => Console.WriteLine("Word Document Opened.");
    public void Close() => Console.WriteLine("Word Document Closed.");
}

public class PdfDocument : IDocument
{
    public void Open() => Console.WriteLine("PDF Document Opened.");
    public void Close() => Console.WriteLine("PDF Document Closed.");
}

public interface IApplication
{
    public abstract IDocument CreateDocument();
    public void NewDocument()
    {
        IDocument doc = CreateDocument();
        doc.Open();
        doc.Close();
    }
}
public class WordApplication : IApplication
{
    public IDocument CreateDocument() => new WordDocument();
}

public class PdfApplication : IApplication
{
    public IDocument CreateDocument() => new PdfDocument();
}