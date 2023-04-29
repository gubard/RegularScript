using System;

namespace RegularScript.Ui.AvaloniaUi.Exceptions;

public class NotFoundNamedControlException : Exception
{
    public string ControlName { get; }
    public Type ControlType { get; }

    public NotFoundNamedControlException(string controlName, Type controlType)
        : base(message: $"Can't find control {controlType} with name {controlName}.")
    {
        ControlName = controlName;
        ControlType = controlType;
    }
}