using System;
using RegularScript.Core.DependencyInjection.Extensions;
using RegularScript.Core.DependencyInjection.Services;
using RegularScript.Core.ModularSystem.Services;
using RegularScript.Ui.Desktop.Configurations;

namespace RegularScript.Ui.Desktop.Modules;

public class DesktopModule : Module
{
    private const string IdString = "89c7044f-52d0-4cb2-84b9-c32597912c8d";
    private static readonly DependencyInjector MainDependencyInjector;

    public static readonly Guid IdValue = Guid.Parse(IdString);

    static DesktopModule()
    {
        var register = new DependencyInjectorRegister();
        register.RegisterConfiguration<DesktopDependencyInjectorConfiguration>();
        MainDependencyInjector = register.Build();
    }

    public DesktopModule() : base(IdValue, MainDependencyInjector)
    {
    }
}