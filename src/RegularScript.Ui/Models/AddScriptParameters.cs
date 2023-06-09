using System;

namespace RegularScript.Ui.Models;

public class AddScriptParameters
{
    public Guid ParentId { get; set; }
    public Guid LanguageId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}