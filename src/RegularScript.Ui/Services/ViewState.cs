using System;
using RegularScript.Ui.Interfaces;

namespace RegularScript.Ui.Services;

public class ViewState : IViewState
{
    private static Type currentView;

    public Type CurrentView
    {
        get => currentView;
        set => currentView = value;
    }
}