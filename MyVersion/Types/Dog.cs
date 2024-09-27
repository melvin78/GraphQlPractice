namespace MyVersion.Types;

public class Dog : IPet, IMammal
{

    public Dog(string name, string breed)
    {
        Name = name;
        Breed = breed;
    }
    
    public string Name { get; }
    
    public string Breed { get; }

    public string DisplayName() => $"{Name} {Breed}";
}