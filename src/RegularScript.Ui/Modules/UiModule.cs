using System;
using RegularScript.Core.DependencyInjection.Extensions;
using RegularScript.Core.DependencyInjection.Services;
using RegularScript.Core.ModularSystem.Services;
using RegularScript.Ui.Configurations;

namespace RegularScript.Ui.Modules;

public class UiModule : Module
{
    private const string IdString = "a8b52bdd-264c-4f94-a195-32749e60edfa";
    private static readonly DependencyInjector MainDependencyInjector;

    public static readonly Guid IdValue = Guid.Parse(IdString);

    static UiModule()
    {
        var register = new DependencyInjectorRegister();
        register.RegisterConfiguration<UiDependencyInjectorConfiguration>();
        MainDependencyInjector = register.Build();
    }

    public UiModule() : base(IdValue, MainDependencyInjector)
    {
    }
}