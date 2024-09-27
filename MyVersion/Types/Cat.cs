namespace MyVersion.Types;

public class Cat: IPet, IMammal
{
    public string Name { get; }
    
    public bool CanMeow { get; }
    
    public CatLives CatLives { get; }

    public Cat(string name, bool canMeow, CatLives catLives)
    {
        Name = name;
        CanMeow = canMeow;
        CatLives = catLives;
    }
}

public enum CatLives
{
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight
}