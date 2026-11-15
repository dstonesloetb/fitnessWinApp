using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using MyFirstApp.Pages;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MyFirstApp;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        SetTheme(((App)Application.Current).IsDarkTheme);

        ExtendsContentIntoTitleBar = true;
        SetTitleBar(AppTitleBar);
        AppWindow.TitleBar.PreferredHeightOption = TitleBarHeightOption.Tall;
        AppWindow.SetIcon("Assets/AppIcon.ico");
    }

    public void SetTheme(bool isDarkTheme)
    {
        RootGrid.RequestedTheme = isDarkTheme ? ElementTheme.Dark : ElementTheme.Light;
    }

    private void TitleBar_PaneToggleRequested(TitleBar sender, object args)
    {
        NavView.IsPaneOpen = !NavView.IsPaneOpen;
    }

    private void TitleBar_BackRequested(TitleBar sender, object args)
    {
        NavFrame.GoBack();
    }

    private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (args.IsSettingsSelected)
        {
            NavFrame.Navigate(typeof(SettingsPage));
        }
        else if (args.SelectedItem is NavigationViewItem item)
        {
            switch (item.Tag)
            {
                case "home":
                    NavFrame.Navigate(typeof(HomePage));
                    break;
                case "about":
                    NavFrame.Navigate(typeof(AboutPage));
                    break;
                default:
                    throw new InvalidOperationException($"Unknown navigation item tag: {item.Tag}");
            }
        }
    }
}
