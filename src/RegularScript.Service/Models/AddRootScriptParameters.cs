using System;

namespace RegularScript.Service.Models;

public class AddRootScriptParameters
{
    public Guid LanguageId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}