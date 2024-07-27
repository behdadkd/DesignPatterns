IUIFactory lightFactory = new LightThemeFactory();

IButton lightButton = lightFactory.CreateButton();
ITextBox lightTextBox = lightFactory.CreateTextBox();

Console.WriteLine(lightButton.RenderButton());
Console.WriteLine(lightTextBox.RenderTextBox());
Console.WriteLine(lightTextBox.ChangeTextBox(lightButton));

IUIFactory darkFactory = new DarkThemeFactory();
IButton darkButton = darkFactory.CreateButton();
ITextBox darkTextBox = darkFactory.CreateTextBox();

Console.WriteLine(darkButton.RenderButton());
Console.WriteLine(darkTextBox.RenderTextBox());
Console.WriteLine(darkTextBox.ChangeTextBox(lightButton));

public interface IUIFactory
{
    IButton CreateButton();
    ITextBox CreateTextBox();
}
class LightThemeFactory : IUIFactory
{
    public IButton CreateButton() => new LightButton();
    public ITextBox CreateTextBox() => new LightTextBox();
}

class DarkThemeFactory : IUIFactory
{
    public IButton CreateButton() => new DarkButton();

    public ITextBox CreateTextBox() => new DarkTextBox();
}

public interface IButton
{
    string RenderButton();
}

class LightButton : IButton
{
    public string RenderButton() => "Render Light Button";
}
class DarkButton : IButton
{
    public string RenderButton() => "Render Dark Button";
}

public interface ITextBox
{
    string RenderTextBox();
    string ChangeTextBox(IButton collaborator);
}

class LightTextBox : ITextBox
{
    public string RenderTextBox() => "Render Light TextBox";
    public string ChangeTextBox(IButton collaborator)
    {
        var result = collaborator.RenderButton();
        return $"The result of the 'Light Text Box' collaborating with the ({result})";
    }
}

class DarkTextBox : ITextBox
{
    public string RenderTextBox() => "Render Dark TextBox";
    public string ChangeTextBox(IButton collaborator)
    {
        var result = collaborator.RenderButton();
        return $"The result of the 'Dark Text Box' collaborating with the ({result})";
    }
}
