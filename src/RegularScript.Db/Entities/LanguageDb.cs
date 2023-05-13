namespace RegularScript.Db.Entities;

public class LanguageDb
{
    public Guid Id { get; set; }
    public string? CodeIso3 { get; set; }
    public string? Name { get; set; }
    public bool IsSupported { get; set; }

    public List<ScriptLocalizationDb>? ScriptLocalizations { get; set; }
}