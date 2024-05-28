using System;

namespace WeightMeasure
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnConvertClicked(object sender, EventArgs e)
        {
            if (double.TryParse(inputWeight.Text, out double weight))
            {
                string inputUnit = inputUnitPicker.SelectedItem?.ToString();
                string outputUnit = outputUnitPicker.SelectedItem?.ToString();

                if (inputUnit != null && outputUnit != null)
                {
                    double weightInKg = ConvertToKilograms(weight, inputUnit);
                    double convertedWeight = ConvertFromKilograms(weightInKg, outputUnit);
                    resultLabel.Text = $"Result: {convertedWeight} {outputUnit}";
                }
                else
                {
                    DisplayAlert("Invalid Input", "Please select both input and output units", "OK");
                }
            }
            else
            {
                DisplayAlert("Invalid Input", "Please enter a valid number", "OK");
            }
        }

        private double ConvertToKilograms(double weight, string unit)
        {
            return unit switch
            {
                "Kilograms" => weight,
                "Grams" => weight / 1000,
                "Tons" => weight * 1000,
                "Pounds" => weight / 2.20462,
                "Ounces" => weight / 35.274,
                _ => throw new NotImplementedException($"Conversion from {unit} is not implemented."),
            };
        }

        private double ConvertFromKilograms(double weightInKg, string unit)
        {
            return unit switch
            {
                "Kilograms" => weightInKg,
                "Grams" => weightInKg * 1000,
                "Tons" => weightInKg / 1000,
                "Pounds" => weightInKg * 2.20462,
                "Ounces" => weightInKg * 35.274,
                _ => throw new NotImplementedException($"Conversion to {unit} is not implemented."),
            };
        }

        
    }
}
