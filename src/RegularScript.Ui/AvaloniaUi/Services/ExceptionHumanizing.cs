using System;
using Avalonia.Controls;
using Avalonia.Media;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.Common.Interfaces;

namespace RegularScript.Ui.AvaloniaUi.Services;

public class ExceptionHumanizing : IHumanizing<Exception, object>
{
    private readonly IHumanizing<Exception, string> humanizing;

    public ExceptionHumanizing(IHumanizing<Exception, string> humanizing)
    {
        this.humanizing = humanizing.ThrowIfNull();
    }

    public object Humanize(Exception input)
    {
        var text = humanizing.Humanize(input);

        return new TextBox
        {
            AcceptsReturn = true,
            TextWrapping = TextWrapping.Wrap,
            Text = text
        };
    }
}