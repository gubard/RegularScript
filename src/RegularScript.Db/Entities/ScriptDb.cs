namespace RegularScript.Db.Entities;

public class ScriptDb
{
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }

    public ScriptDb? Parent { get; set; }
    public List<ScriptLocalizationDb>? Localizations { get; set; }
}