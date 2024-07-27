CharacterFactory factory = new CharacterFactory();

string document = "Hello World";
int[] sizes = { 12, 14, 16, 18, 20 };
int[] colors = { 0xFF0000, 0x00FF00, 0x0000FF, 0xFFFF00, 0xFF00FF };

Random rand = new Random();

for (int i = 0; i < document.Length; i++)
{
    ICharacter character = factory.GetCharacter(document[i]);
    int size = sizes[rand.Next(sizes.Length)];
    int color = colors[rand.Next(colors.Length)];

    character.Display(size, color);
}
public interface ICharacter
{
    void Display(int size, int color);
}
public class Character : ICharacter
{
    private char _symbol;

    public Character(char symbol)
    {
        _symbol = symbol;
    }

    public void Display(int size, int color)
    {
        Console.WriteLine($"Character: {_symbol}, Size: {size}, Color: {color}");
    }
}
public class CharacterFactory
{
    private Dictionary<char, ICharacter> _characters = new Dictionary<char, ICharacter>();

    public ICharacter GetCharacter(char symbol)
    {
        if (!_characters.ContainsKey(symbol))
        {
            _characters[symbol] = new Character(symbol);
        }
        return _characters[symbol];
    }
}