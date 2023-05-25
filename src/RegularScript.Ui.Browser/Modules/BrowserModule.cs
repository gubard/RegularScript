using System;
using RegularScript.Core.DependencyInjection.Services;
using RegularScript.Core.ModularSystem.Services;
using RegularScript.Ui.Browser.Configurations;
using RegularScript.Core.DependencyInjection.Extensions;

namespace RegularScript.Ui.Browser.Modules;

public class BrowserModule : Module
{
    private const string IdString = "eef62ce8-e24d-4159-885e-7488035909a3";
    private static readonly DependencyInjector MainDependencyInjector;

    public static readonly Guid IdValue = Guid.Parse(IdString);

    static BrowserModule()
    {
        var register = new DependencyInjectorRegister();
        register.RegisterConfiguration<BrowserDependencyInjectorConfiguration>();
        MainDependencyInjector = register.Build();
    }

    public BrowserModule() : base(IdValue, MainDependencyInjector)
    {
    }
}