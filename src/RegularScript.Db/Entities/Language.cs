﻿namespace RegularScript.Db.Entities;

public class Language
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    
    public List<ScriptLocalization> ScriptLocalizations { get; set; }
}