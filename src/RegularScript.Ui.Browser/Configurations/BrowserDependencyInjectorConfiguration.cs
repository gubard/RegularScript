using System.Reflection;
using Microsoft.Extensions.Configuration;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.DependencyInjection.Interfaces;
using RegularScript.Core.DependencyInjection.Extensions;
using RegularScript.Ui.Configurations;

namespace RegularScript.Ui.Browser.Configurations;

public readonly struct BrowserDependencyInjectorConfiguration : IDependencyInjectorConfiguration
{
    public void Configure(IDependencyInjectorRegister register)
    {
        new UiDependencyInjectorConfiguration().Configure(register);

        register.RegisterScopeDel<IConfiguration>(
            () =>
            {
                using var stream = Assembly.GetEntryAssembly()
                    ?.GetManifestResourceStream("RegularScript.Ui.Browser.appsettings.json")
                    .ThrowIfNull();

                return new ConfigurationBuilder().AddJsonStream(stream).Build();
            }
        );
    }
}