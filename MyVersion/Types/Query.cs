namespace MyVersion.Types;

public class Query
{
    public Book GetBook() => new Book("c# in depth", new Author("Martin Fowler"));

    private bool _dog;

    public IEnumerable<IPet> GetPets() => new IPet[]
    {
        new Dog("Buddy", "Golden Retriever"),
        new Cat("Garfiled", true, CatLives.Four),
        new Cat("John", true, CatLives.Seven),
        new Parrot("Barbosa", false)
    };

    public IMammal GetCatOrDog()
    {
        _dog = !_dog;
        return _dog
            ? new Dog("Buddy", "Golden Retriever")
            : new Cat("Snowball", true, CatLives.Three);
    }

    public IEnumerable<Cat> GetAllCats(CatLives? lives)
    {
        if (lives is not null)
        {
            return GetPets().OfType<Cat>().Where(t => t.CatLives == lives);
        }

        return GetPets().OfType<Cat>();
    }

    public string GetDogName(Dog dog) => dog.Name;

    public string GetDogOrCatName(DogOrCat dogOrCat) => dogOrCat.cat?.Name ?? dogOrCat.Dog?.Name!;
}

[OneOf]
public record DogOrCat(Dog? Dog, Cat? cat);