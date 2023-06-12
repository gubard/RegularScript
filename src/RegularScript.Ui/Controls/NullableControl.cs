using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Layout;
using Avalonia.Metadata;

namespace RegularScript.Ui.Controls;

public class NullableControl : TemplatedControl
{
    /// <summary>
    /// Defines the <see cref="Content"/> property.
    /// </summary>
    public static readonly StyledProperty<IDataTemplate?> CurrentContentTemplateProperty =
        AvaloniaProperty.Register<NullableControl, IDataTemplate?>(nameof(CurrentContentTemplate));

    /// <summary>
    /// Defines the <see cref="Content"/> property.
    /// </summary>
    public static readonly StyledProperty<object?> CurrentContentProperty =
        AvaloniaProperty.Register<NullableControl, object?>(nameof(CurrentContent));

    /// <summary>
    /// Defines the <see cref="Content"/> property.
    /// </summary>
    public static readonly StyledProperty<object?> NullContentProperty =
        AvaloniaProperty.Register<NullableControl, object?>(nameof(NullContent));

    /// <summary>
    /// Defines the <see cref="ContentTemplate"/> property.
    /// </summary>
    public static readonly StyledProperty<IDataTemplate?> NullContentTemplateProperty =
        AvaloniaProperty.Register<NullableControl, IDataTemplate?>(nameof(NullContentTemplate));

    /// <summary>
    /// Defines the <see cref="Content"/> property.
    /// </summary>
    public static readonly StyledProperty<object?> ContentProperty =
        AvaloniaProperty.Register<NullableControl, object?>(nameof(Content));

    /// <summary>
    /// Defines the <see cref="ContentTemplate"/> property.
    /// </summary>
    public static readonly StyledProperty<IDataTemplate?> ContentTemplateProperty =
        AvaloniaProperty.Register<NullableControl, IDataTemplate?>(nameof(ContentTemplate));

    /// <summary>
    /// Defines the <see cref="Target"/> property.
    /// </summary>
    public static readonly StyledProperty<object?> TargetProperty =
        AvaloniaProperty.Register<NullableControl, object?>(nameof(Target));


    /// <summary>
    /// Defines the <see cref="HorizontalContentAlignment"/> property.
    /// </summary>
    public static readonly StyledProperty<HorizontalAlignment> HorizontalContentAlignmentProperty =
        AvaloniaProperty.Register<NullableControl, HorizontalAlignment>(nameof(HorizontalContentAlignment));

    /// <summary>
    /// Defines the <see cref="VerticalContentAlignment"/> property.
    /// </summary>
    public static readonly StyledProperty<VerticalAlignment> VerticalContentAlignmentProperty =
        AvaloniaProperty.Register<NullableControl, VerticalAlignment>(nameof(VerticalContentAlignment));


    static NullableControl()
    {
        NullContentProperty.Changed.AddClassHandler<NullableControl>((x, _) => x.UpdateCurrentContent());
        ContentProperty.Changed.AddClassHandler<NullableControl>((x, _) => x.UpdateCurrentContent());
        TargetProperty.Changed.AddClassHandler<NullableControl>((x, _) => x.UpdateCurrentContent());

        NullContentTemplateProperty.Changed.AddClassHandler<NullableControl>(
            (x, _) => x.UpdateCurrentContentTemplate()
        );
        ContentTemplateProperty.Changed.AddClassHandler<NullableControl>((x, _) => x.UpdateCurrentContentTemplate());
        TargetProperty.Changed.AddClassHandler<NullableControl>((x, _) => x.UpdateCurrentContentTemplate());
    }

    /// <summary>
    /// Gets or sets whether the <see cref="ToggleButton"/> is checked.
    /// </summary>
    public object? Target
    {
        get => GetValue(TargetProperty);
        set => SetValue(TargetProperty, value);
    }

    [DependsOn(nameof(CurrentContentTemplate))]
    public object? CurrentContent
    {
        get => GetValue(CurrentContentProperty);
        set => SetValue(CurrentContentProperty, value);
    }

    public IDataTemplate? CurrentContentTemplate
    {
        get => GetValue(CurrentContentTemplateProperty);
        set => SetValue(CurrentContentTemplateProperty, value);
    }

    /// <summary>
    /// Gets or sets the content to display.
    /// </summary>
    [Content]
    [DependsOn(nameof(ContentTemplate))]
    public object? Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    /// <summary>
    /// Gets or sets the data template used to display the content of the control.
    /// </summary>
    public IDataTemplate? ContentTemplate
    {
        get => GetValue(ContentTemplateProperty);
        set => SetValue(ContentTemplateProperty, value);
    }

    /// <summary>
    /// Gets or sets the content to display.
    /// </summary>
    [DependsOn(nameof(NullContentTemplate))]
    public object? NullContent
    {
        get => GetValue(NullContentProperty);
        set => SetValue(NullContentProperty, value);
    }

    /// <summary>
    /// Gets or sets the data template used to display the content of the control.
    /// </summary>
    public IDataTemplate? NullContentTemplate
    {
        get => GetValue(NullContentTemplateProperty);
        set => SetValue(NullContentTemplateProperty, value);
    }

    /// <summary>
    /// Gets or sets the horizontal alignment of the content within the control.
    /// </summary>
    public HorizontalAlignment HorizontalContentAlignment
    {
        get => GetValue(HorizontalContentAlignmentProperty);
        set => SetValue(HorizontalContentAlignmentProperty, value);
    }

    /// <summary>
    /// Gets or sets the vertical alignment of the content within the control.
    /// </summary>
    public VerticalAlignment VerticalContentAlignment
    {
        get => GetValue(VerticalContentAlignmentProperty);
        set => SetValue(VerticalContentAlignmentProperty, value);
    }

    private void UpdateCurrentContentTemplate()
    {
        SetValue(CurrentContentTemplateProperty, Target is null ? NullContentTemplate : ContentTemplate);
    }

    private void UpdateCurrentContent()
    {
        SetValue(CurrentContentProperty, Target is null ? NullContent : Content);
    }
}