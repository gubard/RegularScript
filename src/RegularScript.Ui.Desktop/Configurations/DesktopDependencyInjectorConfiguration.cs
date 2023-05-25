using Microsoft.Extensions.Configuration;
using RegularScript.Core.DependencyInjection.Interfaces;
using RegularScript.Core.DependencyInjection.Extensions;
using RegularScript.Ui.Configurations;

namespace RegularScript.Ui.Desktop.Configurations;

public readonly struct DesktopDependencyInjectorConfiguration : IDependencyInjectorConfiguration
{
    public void Configure(IDependencyInjectorRegister register)
    {
        new UiDependencyInjectorConfiguration().Configure(register);
        
        register.RegisterScope<IConfiguration>(
            () =>
                new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()
        );
    }
}