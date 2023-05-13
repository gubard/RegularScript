namespace RegularScript.Db.Entities;

public class ScriptLocalization
{
    public Guid Id { get; set; }
    public Guid ScriptId { get; set; }
    public Guid LanguageId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public Script? Script { get; set; }
    public Language? Language { get; set; }
}