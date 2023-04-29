namespace RegularScript.Db.Entities;

public class Language
{
    public Guid Id { get; set; }
    public string CodeIso3 { get; set; }
    public string Name { get; set; }
    public bool IsSupported { get; set; }

    public List<ScriptLocalization> ScriptLocalizations { get; set; }
}