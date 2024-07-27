// Create subsystem components
DVDPlayer dvdPlayer = new DVDPlayer();
Projector projector = new Projector();
SoundSystem soundSystem = new SoundSystem();
Lights lights = new Lights();

// Create the facade
HomeTheaterFacade homeTheater = new HomeTheaterFacade(dvdPlayer, projector, soundSystem, lights);

// Use the facade to control the subsystem
homeTheater.WatchMovie("Inception");
homeTheater.EndMovie();

public class DVDPlayer
{
    public void On() => Console.WriteLine("DVD Player is on.");
    public void Play(string movie) => Console.WriteLine($"Playing movie: {movie}");
    public void Stop() => Console.WriteLine("DVD Player stopped.");
    public void Off() => Console.WriteLine("DVD Player is off.");
}
public class Projector
{
    public void On() => Console.WriteLine("Projector is on.");
    public void Off() => Console.WriteLine("Projector is off.");
    public void SetInput(string input) => Console.WriteLine($"Projector input set to {input}");
}

public class SoundSystem
{
    public void On() => Console.WriteLine("Sound System is on.");
    public void Off() => Console.WriteLine("Sound System is off.");
    public void SetVolume(int level) => Console.WriteLine($"Sound System volume set to {level}");
}

public class Lights
{
    public void Dim(int level) => Console.WriteLine($"Lights dimmed to {level}%");
}


public class HomeTheaterFacade
{
    private readonly DVDPlayer _dvdPlayer;
    private readonly Projector _projector;
    private readonly SoundSystem _soundSystem;
    private readonly Lights _lights;

    public HomeTheaterFacade(DVDPlayer dvdPlayer, Projector projector, SoundSystem soundSystem, Lights lights)
    {
        _dvdPlayer = dvdPlayer;
        _projector = projector;
        _soundSystem = soundSystem;
        _lights = lights;
    }

    public void WatchMovie(string movie)
    {
        Console.WriteLine("Get ready to watch a movie...");
        _lights.Dim(10);
        _projector.On();
        _projector.SetInput("DVD");
        _soundSystem.On();
        _soundSystem.SetVolume(5);
        _dvdPlayer.On();
        _dvdPlayer.Play(movie);
    }

    public void EndMovie()
    {
        Console.WriteLine("Shutting down the home theater...");
        _dvdPlayer.Stop();
        _dvdPlayer.Off();
        _soundSystem.Off();
        _projector.Off();
        _lights.Dim(100);
    }
}