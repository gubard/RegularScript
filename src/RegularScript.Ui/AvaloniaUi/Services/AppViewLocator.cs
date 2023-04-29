using System;
using System.Collections.Generic;
using Avalonia;
using ReactiveUI;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.DependencyInjection.Interfaces;

namespace RegularScript.Ui.AvaloniaUi.Services;

public class AppViewLocator : IViewLocator
{
    private readonly IResolver resolver;
    private readonly Dictionary<Type, Type> resolveViewDictionary;

    public AppViewLocator(IReadOnlyDictionary<Type, Type> resolveViewDictionary, IResolver resolver)
    {
        this.resolver = resolver;
        this.resolveViewDictionary = new (resolveViewDictionary);
    }

    public IViewFor ResolveView<T>(T? viewModel, string? contract = null)
    {
        if (resolveViewDictionary.TryGetValue(key: typeof(T), value: out var viewType))
        {
            return CreateViewFor(viewType, viewModel);
        }

        viewType = GetViewTypeOrNull(viewModelType: typeof(T));

        if (viewType is null)
        {
            throw new ArgumentOutOfRangeException(paramName: nameof(viewModel));
        }

        return CreateViewFor(viewType, viewModel);
    }

    private Type? GetViewTypeOrNull(Type viewModelType)
    {
        var assembly = viewModelType.Assembly;

        if (viewModelType.Namespace.IsNullOrWhiteSpace())
        {
            return null;
        }

        var ns = viewModelType.Namespace
           .Replace(oldValue: ".ViewModels.", newValue: ".Views.")
           .Replace(oldValue: ".ViewModels", newValue: ".Views");

        var viewTypeName = $"{ns}.{viewModelType.Name}"[..^5];
        var viewType = assembly.GetType(viewTypeName);

        return viewType;
    }

    private IViewFor CreateViewFor<TViewModel>(Type viewType, TViewModel viewModel)
    {
        var view = resolver.Resolve(viewType);

        if (view is IDataContextProvider dataContextProvider)
        {
            dataContextProvider.DataContext = viewModel;
        }

        return view.ThrowIfIsNot<IViewFor>();
    }
}