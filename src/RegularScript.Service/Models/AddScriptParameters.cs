using System;

namespace RegularScript.Service.Models;

public class AddScriptParameters
{
    public Guid ParentId { get; set; }
    public Guid LanguageId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}