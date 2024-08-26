BulletFactory factory = new BulletFactory();

IBullet bullet = factory.GetBullet("Red", "BulletSprite.png");
for (int i = 0; i < 100; i++)
{
    bullet.Render((i, i), i * i);
}




public interface IBullet
{
    public string Color { get; set; }
    public string Sprite { get; set; }
    void Render((int x, int y) coord, int speed);
}
public class Bullet : IBullet
{
    public string Color { get; set; }
    public string Sprite { get; set; }
    public Bullet(string color, string sprite)
    {
        Color = color;
        Sprite = sprite;
    }
    public void Render((int x, int y) coord, int speed)
    {
        Console.WriteLine($"Bullet at ({coord.x}, {coord.y}) with Color: {Color}, Speed: {speed}, Sprite: {Sprite}");
    }
}
public class BulletFactory
{
    private Dictionary<string, IBullet> _bulletTypes = new Dictionary<string, IBullet>();

    public IBullet GetBullet(string color, string sprite)
    {
        string key = $"{color}-{sprite}";
        if (!_bulletTypes.ContainsKey(key))
        {
            _bulletTypes[key] = new Bullet(color, sprite);
        }
        return _bulletTypes[key];
    }
}
