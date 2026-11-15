using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MyFirstApp.Pages;

public sealed partial class HomePage : Page
{
    public HomePage()
    {
        InitializeComponent();
    }

    private void BmiCalculatorButton_Click(object sender, RoutedEventArgs args)
    {
        Frame.Navigate(typeof(BmiCalculatorPage));
    }
}
