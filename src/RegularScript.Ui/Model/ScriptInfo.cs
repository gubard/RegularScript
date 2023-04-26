using System;

namespace RegularScript.Model;

public class ScriptInfo
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public ushort ChildrenCount { get; }
}