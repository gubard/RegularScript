using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Media;
using RegularScript.Ui.AvaloniaUi.Converters;

namespace RegularScript.Ui.AvaloniaUi.Services;

public class DynamicResourceBinding : IBinding
{
    private readonly object? anchor;
    private readonly BindingPriority priority;

    public DynamicResourceBinding()
    {
        anchor = null;
        priority = BindingPriority.Animation;
    }

    public DynamicResourceBinding(object resourceKey)
    {
        ResourceKey = resourceKey;
    }

    public object? ResourceKey { get; set; }

    InstancedBinding? IBinding.Initiate(
        AvaloniaObject target,
        AvaloniaProperty? targetProperty,
        object? newAnchor,
        bool enableDataValidation
    )
    {
        if (ResourceKey is null)
        {
            return null;
        }

        var control = target as IResourceHost ?? anchor as IResourceHost;

        if (control != null)
        {
            var source = control.GetResourceObservable(ResourceKey, GetConverter(targetProperty));

            return InstancedBinding.OneWay(source, priority);
        }

        if (anchor is IResourceProvider resourceProvider)
        {
            var source = resourceProvider.GetResourceObservable(
                ResourceKey,
                GetConverter(targetProperty)
            );

            return InstancedBinding.OneWay(source, priority);
        }

        return null;
    }

    private Func<object?, object?>? GetConverter(AvaloniaProperty? targetProperty)
    {
        if (targetProperty?.PropertyType == typeof(IBrush))
        {
            return x => ColorToBrushConverter.Convert(x, typeof(IBrush));
        }

        return null;
    }
}