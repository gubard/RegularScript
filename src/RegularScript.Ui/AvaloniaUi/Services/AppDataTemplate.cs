using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using ReactiveUI;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.DependencyInjection.Interfaces;
using RegularScript.Ui.ViewModels;

namespace RegularScript.Ui.AvaloniaUi.Services;

public class AppDataTemplate : IDataTemplate
{
    private readonly IResolver resolver;
    private readonly Dictionary<Type, Type> resolveViewDictionary;

    public AppDataTemplate(IReadOnlyDictionary<Type, Type> resolveViewDictionary, IResolver resolver)
    {
        this.resolver = resolver;
        this.resolveViewDictionary = new Dictionary<Type, Type>(resolveViewDictionary);
    }

    public Control? Build(object? param)
    {
        if (param is null)
        {
            return null;
        }

        var type = param.GetType();

        if (resolveViewDictionary.TryGetValue(type, out var viewType))
        {
            return (Control)resolver.Resolve(viewType);
        }

        return new TextBlock
        {
            Text = type.FullName
        };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }

    public IViewFor ResolveView<T>(T? viewModel, string? contract = null)
    {
        if (resolveViewDictionary.TryGetValue(typeof(T), out var viewType))
        {
            return CreateViewFor(viewType, viewModel);
        }

        viewType = GetViewTypeOrNull(typeof(T));

        if (viewType is null)
        {
            throw new ArgumentOutOfRangeException(nameof(viewModel));
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
            .Replace(".ViewModels.", ".Views.")
            .Replace(".ViewModels", ".Views");

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