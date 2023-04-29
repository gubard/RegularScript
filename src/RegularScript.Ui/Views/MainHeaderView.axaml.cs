﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RegularScript.Ui.Views;

public partial class MainHeaderView : UserControl
{
    public MainHeaderView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(obj: this);
    }
}