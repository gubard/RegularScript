namespace RegularScript.Db.Entities;

public class ScriptLocalizationDb
{
    public Guid Id { get; set; }
    public Guid ScriptId { get; set; }
    public Guid LanguageId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public ScriptDb? Script { get; set; }
    public LanguageDb? Language { get; set; }
}