namespace RegularScript.Db.Entities;

public class Script
{
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }

    public Script? Parent { get; set; }
    public List<ScriptLocalization> Localizations { get; set; }
}