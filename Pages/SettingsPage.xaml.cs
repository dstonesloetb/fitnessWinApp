// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MyFirstApp.Pages;

public sealed partial class SettingsPage : Page
{
    public SettingsPage()
    {
        InitializeComponent();
        DarkModeToggle.IsOn = ((App)Application.Current).IsDarkTheme;
        DarkModeToggle.Toggled += DarkModeToggle_Toggled;
    }

    private void DarkModeToggle_Toggled(object sender, RoutedEventArgs args)
    {
        ((App)Application.Current).SetDarkTheme(((ToggleSwitch)sender).IsOn);
    }
}
