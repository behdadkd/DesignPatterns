
List<Bullet> bullets = new List<Bullet>();

for (int i = 0; i < 1000; i++)
{
    bullets.Add(new Bullet((i, i), "Red", 10, "BulletSprite.png"));
}

foreach (var bullet in bullets)
{
    bullet.Render();
}


public class Bullet
{
    public (int x, int y) Coord { get; set; }
    public int Speed { get; set; }

    public string Color { get; set; }
    public string Sprite { get; set; }

    public Bullet((int x, int y) coord, string color, int speed, string sprite)
    {
        Coord = coord;
        Color = color;
        Speed = speed;
        Sprite = sprite;
    }

    public void Render()
    {
        Console.WriteLine($"Bullet at ({Coord.x}, {Coord.y}) with Color: {Color}, Speed: {Speed}, Sprite: {Sprite}");
    }
}
