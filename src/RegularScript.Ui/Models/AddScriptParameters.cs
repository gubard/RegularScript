using System;

namespace RegularScript.Ui.Models;

public class AddScriptParameters
{
    public required Guid LanguageId { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
}