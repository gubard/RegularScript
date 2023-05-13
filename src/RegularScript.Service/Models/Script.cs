namespace RegularScript.Service.Models;

public class Script
{
    public required Guid Id { get; init; }
    public required string? Name { get; init; }
    public required string? Description { get; init; }
}