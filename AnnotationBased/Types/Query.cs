namespace AnnotationBased.Types;

public class Query
{
    public Book GetBook()
        => new Book("C# in depth.", new Author("Jon Skeet"));
}