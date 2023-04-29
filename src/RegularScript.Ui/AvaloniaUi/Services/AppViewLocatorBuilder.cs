using System;
using System.Collections.Generic;
using RegularScript.Core.Common.Interfaces;
using RegularScript.Core.DependencyInjection.Interfaces;

namespace RegularScript.Ui.AvaloniaUi.Services;

public class AppViewLocatorBuilder : IBuilder<AppViewLocator>
{
    private readonly IResolver resolver;
    private readonly Dictionary<Type, Type> resolveViewDictionary;

    public AppViewLocatorBuilder(IResolver resolver)
    {
        this.resolver = resolver;
        resolveViewDictionary = new ();
    }

    public AppViewLocator Build()
    {
        return new (resolveViewDictionary, resolver);
    }

    public void AddResolve(Type viewModelType, Type viewType)
    {
        resolveViewDictionary.Add(viewModelType, viewType);
    }
}