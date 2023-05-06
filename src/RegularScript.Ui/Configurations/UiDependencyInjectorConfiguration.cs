using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;
using ReactiveUI;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.DependencyInjection.Extensions;
using RegularScript.Core.DependencyInjection.Interfaces;
using RegularScript.Core.DependencyInjection.Models;
using RegularScript.Core.Expressions.Extensions;
using RegularScript.Ui.AvaloniaUi.Helpers;
using RegularScript.Ui.AvaloniaUi.Services;
using RegularScript.Ui.ViewModels;
using RegularScript.Ui.Views;

namespace RegularScript.Ui.Configurations;

public readonly struct UiDependencyInjectorConfiguration : IDependencyInjectorConfiguration
{
    public void Configure(IDependencyInjectorRegister register)
    {
        register.RegisterTransient<Application, App>();
        register.RegisterTransient(() => UriBase.AppStyleUri);
        register.RegisterTransient<IEnumerable<IDataTemplate>>((IDataTemplate viewLocator) => new []{viewLocator});
        register.RegisterTransient<ViewModelBase>();
        register.RegisterTransient<AppDataTemplateBuilder>();
        register.RegisterTransient<IEnumerable<IResourceProvider>>(() => Array.Empty<IResourceProvider>());
        register.RegisterTransient<FluentTheme>(() => new(null));
        register.RegisterTransient(() => new Window());
        register.RegisterTransient<Control, MainView>();
        register.RegisterTransient(() => new RoutingState(null));
        RegisterViewModels(register);
        register.RegisterTransient(() => Enumerable.Empty<IStyle>());

        register.RegisterTransient<IDataTemplate>(
            (AppDataTemplateBuilder builder) => builder.Build()
        );

        register.RegisterTransientAutoInject(
            (Window window) => window.Content,
            (Control control) => control
        );
    }

    private void RegisterViewModels(IDependencyInjectorRegister register)
    {
        var styledElementType = typeof(StyledElement);
        var member = styledElementType.GetMember(nameof(StyledElement.DataContext))[0];
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var autoInjectMember = new AutoInjectMember(member);

        foreach (var assembly in assemblies)
        {
            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                if (type.Namespace.IsNullOrWhiteSpace())
                {
                    continue;
                }

                if (!styledElementType.IsAssignableFrom(type))
                {
                    continue;
                }

                var ns = type.Namespace
                    .Replace(".Views.", ".ViewModels.")
                    .Replace(".Views", ".ViewModels");

                var viewModelName = $"{ns}.{type.Name}Model";
                var viewModelType = assembly.GetType(viewModelName);

                if (viewModelType is null)
                {
                    continue;
                }

                var autoInjectIdentifier = new AutoInjectMemberIdentifier(type, autoInjectMember);
                var variable = viewModelType.ToVariableAutoName();
                register.RegisterTransient(type);
                register.RegisterTransient(viewModelType);

                register.RegisterTransientAutoInjectMember(
                    autoInjectIdentifier,
                    variable.ToLambda(variable)
                );
            }
        }
    }
}