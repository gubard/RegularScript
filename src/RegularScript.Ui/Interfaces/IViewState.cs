using System;

namespace RegularScript.Ui.Interfaces;

public interface IViewState
{
    Type CurrentView { get; set; }
}