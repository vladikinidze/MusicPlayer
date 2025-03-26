namespace UserService.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string entity, string key) : base($"Entity {entity} with key = {key} not found")
    { }
}   