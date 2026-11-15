using System.Globalization;
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
        MetricUnitsRadioButton.Checked += UnitsRadioButton_Checked;
        ImperialUnitsRadioButton.Checked += UnitsRadioButton_Checked;
        UpdateUnits();
    }

    private void UnitsRadioButton_Checked(object sender, RoutedEventArgs args)
    {
        UpdateUnits();
        BmiValueText.Text = "--";
        BmiCategoryText.Text = "Enter your measurements to begin.";
    }

    private void UpdateUnits()
    {
        var usesImperialUnits = ImperialUnitsRadioButton.IsChecked == true;
        HeightInput.Header = usesImperialUnits ? "Height (in)" : "Height (cm)";
        WeightInput.Header = usesImperialUnits ? "Weight (lb)" : "Weight (kg)";
        HeightInput.Maximum = usesImperialUnits ? 120 : 300;
        WeightInput.Maximum = usesImperialUnits ? 1100 : 500;
    }

    private void CalculateButton_Click(object sender, RoutedEventArgs args)
    {
        var height = HeightInput.Value;
        var weight = WeightInput.Value;

        if (!double.IsFinite(height) || !double.IsFinite(weight) || height <= 0 || weight <= 0)
        {
            BmiValueText.Text = "--";
            BmiCategoryText.Text = "Enter a height and weight greater than zero.";
            return;
        }

        var bmi = ImperialUnitsRadioButton.IsChecked == true
            ? weight / (height * height) * 703
            : weight / Math.Pow(height / 100, 2);

        BmiValueText.Text = bmi.ToString("0.0", CultureInfo.CurrentCulture);
        BmiCategoryText.Text = bmi switch
        {
            < 18.5 => "Underweight",
            < 25 => "Healthy weight",
            < 30 => "Overweight",
            _ => "Obesity range"
        };
    }
}
