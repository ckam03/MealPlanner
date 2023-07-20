namespace MealPlanner.API.Exceptions;

public class ShoppingListNotFoundException : Exception
{
    public ShoppingListNotFoundException() : base()
    {
    }

    public ShoppingListNotFoundException(string? message) : base(message)
    {
    }

    public ShoppingListNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
