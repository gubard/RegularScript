using ReactiveUI;
using RegularScript.Core.ModularSystem.Interfaces;
using Splat;

namespace RegularScript.Ui.Services;

public class UiModuleSetup : IModuleSetup
{
    public void Setup(IViewLocator viewLocator)
    {
        Locator.CurrentMutable.RegisterLazySingleton(() => viewLocator, typeof(IViewLocator));
    }
}