namespace Domain.Exceptions;

public class CategoryNotFoundException : Exception
{
    public CategoryNotFoundException(string name)
        : base($"Category with Name {name} was not found") { }
}
