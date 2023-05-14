using System;
using System.Collections.Generic;
using RegularScript.Core.Common.Interfaces;
using RegularScript.Core.DependencyInjection.Interfaces;

namespace RegularScript.Ui.AvaloniaUi.Services;

public class AppDataTemplateBuilder : IBuilder<AppDataTemplate>
{
    private readonly IResolver resolver;
    private readonly Dictionary<Type, Type> resolveViewDictionary;

    public AppDataTemplateBuilder(IResolver resolver)
    {
        this.resolver = resolver;
        resolveViewDictionary = new Dictionary<Type, Type>();
    }

    public AppDataTemplate Build()
    {
        return new AppDataTemplate(resolveViewDictionary, resolver);
    }

    public void AddResolve(Type viewModelType, Type viewType)
    {
        resolveViewDictionary.Add(viewModelType, viewType);
    }
}