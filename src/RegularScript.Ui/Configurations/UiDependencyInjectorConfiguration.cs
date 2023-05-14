using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ReactiveUI;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.DependencyInjection.Extensions;
using RegularScript.Core.DependencyInjection.Interfaces;
using RegularScript.Core.DependencyInjection.Models;
using RegularScript.Core.Expressions.Extensions;
using RegularScript.Ui.AvaloniaUi.Helpers;
using RegularScript.Ui.AvaloniaUi.Services;
using RegularScript.Ui.Interfaces;
using RegularScript.Ui.Models;
using RegularScript.Ui.Profiles;
using RegularScript.Ui.Services;
using RegularScript.Ui.ViewModels;
using RegularScript.Ui.Views;

namespace RegularScript.Ui.Configurations;

public readonly struct UiDependencyInjectorConfiguration : IDependencyInjectorConfiguration
{
    public void Configure(IDependencyInjectorRegister register)
    {
        register.RegisterScope<Application, App>();
        register.RegisterScope<IScriptService, ScriptService>();
        register.RegisterScope<ILanguageService, LanguageService>();
        register.RegisterScope(() => new MapperConfiguration(cfg => cfg.AddProfile<UiProfile>()));
        register.RegisterScope<IMapper>((MapperConfiguration cfg) => new Mapper(cfg));
        register.RegisterScope(() => UriBase.AppStyleUri);
        register.RegisterScope<IEnumerable<IDataTemplate>>((IDataTemplate viewLocator) => new[] { viewLocator });
        register.RegisterScope<ViewModelBase>();
        register.RegisterScope<AppDataTemplateBuilder>();
        register.RegisterScope<IEnumerable<IResourceProvider>>(() => Array.Empty<IResourceProvider>());
        register.RegisterScope<FluentTheme>(() => new FluentTheme(null));
        register.RegisterScope(() => new Window());
        register.RegisterScope<Control, MainView>();
        register.RegisterScope(() => new RoutingState(null));
        RegisterViewModels(register);
        register.RegisterScope(() => Enumerable.Empty<IStyle>());

        register.RegisterScope<IConfiguration>(() =>
            new ConfigurationBuilder().AddJsonFile("appsettings.json").Build());

        register.RegisterScope<GrpcServiceOptions>((IConfiguration configuration) =>
            configuration.GetSection(GrpcServiceOptions.ConfigurationPath).Get<GrpcServiceOptions>());

        register.RegisterScope<IOptions<GrpcServiceOptions>>((GrpcServiceOptions options) =>
            new OptionsWrapper<GrpcServiceOptions>(options));

        register.RegisterScope<IDataTemplate>(
            (AppDataTemplateBuilder builder) => builder.Build()
        );

        register.RegisterScopeAutoInject(
            (Window window) => window.Content,
            (Control control) => control
        );
    }

    private void RegisterViewModels(IDependencyInjectorRegister register)
    {
        var styledElementType = typeof(StyledElement);
        var member = styledElementType.GetProperty(nameof(StyledElement.DataContext)).ThrowIfNull();
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var autoInjectMember = new AutoInjectMember(member);

        foreach (var assembly in assemblies)
        {
            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                if (type.Namespace.IsNullOrWhiteSpace()) continue;

                if (!styledElementType.IsAssignableFrom(type)) continue;

                var ns = type.Namespace
                    .Replace(".Views.", ".ViewModels.")
                    .Replace(".Views", ".ViewModels");

                var viewModelName = $"{ns}.{type.Name}Model";
                var viewModelType = assembly.GetType(viewModelName);

                if (viewModelType is null) continue;

                var autoInjectIdentifier = new AutoInjectMemberIdentifier(type, autoInjectMember);
                var variable = viewModelType.ToVariableAutoName();
                register.RegisterScope(type);
                register.RegisterScope(viewModelType);

                register.RegisterScopeAutoInjectMember(
                    autoInjectIdentifier,
                    variable.ToLambda(variable)
                );
            }
        }
    }
}