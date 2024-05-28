namespace WeightMeasure
{
    // MainPage klasse erft van ContentPage
    public partial class MainPage : ContentPage
    {
        // Constructor initialiseert de pagina
        public MainPage()
        {
            InitializeComponent();
        }

        // Event handler voor Convert-knop klik
        private void OnConvertClicked(object sender, EventArgs e)
        {
            // Probeer het invoergewicht naar double te parsen
            if (double.TryParse(inputWeight.Text, out double weight))
            {
                // Haal geselecteerde invoer- en uitvoereenheden op
                string inputUnit = inputUnitPicker.SelectedItem?.ToString();
                string outputUnit = outputUnitPicker.SelectedItem?.ToString();

                // Controleer of beide eenheden zijn geselecteerd
                if (inputUnit != null && outputUnit != null)
                {
                    // Converteer invoergewicht naar kilogrammen
                    double weightInKg = ConvertToKilograms(weight, inputUnit);
                    // Converteer gewicht van kilogrammen naar de gewenste uitvoereenheid
                    double convertedWeight = ConvertFromKilograms(weightInKg, outputUnit);
                    // Toon het resultaat
                    resultLabel.Text = $"Result: {convertedWeight} {outputUnit}";
                }
                else
                {
                    // Toon waarschuwing als eenheden niet zijn geselecteerd
                    DisplayAlert("Ongeldige invoer", "Selecteer zowel invoer- als uitvoereenheden", "OK");
                }
            }
            else
            {
                // Toon waarschuwing als het invoergewicht ongeldig is
                DisplayAlert("Ongeldige invoer", "Voer een geldig nummer in", "OK");
            }
        }

        // Converteer gewicht van geselecteerde eenheid naar kilogrammen
        private double ConvertToKilograms(double weight, string unit)
        {
            return unit switch
            {
                "Kilograms" => weight,
                "Grams" => weight / 1000,
                "Tons" => weight * 1000,
                "Pounds" => weight * 0.453592,
                "Ounces (UK/US)" => weight * 0.0283495,
                "Ons (NL)" => weight * 0.1,
                _ => throw new NotImplementedException($"Conversie van {unit} is niet geïmplementeerd."),
            };
        }

        // Converteer gewicht van kilogrammen naar geselecteerde uitvoereenheid
        private double ConvertFromKilograms(double weightInKg, string unit)
        {
            return unit switch
            {
                "Kilograms" => weightInKg,
                "Grams" => weightInKg * 1000,
                "Tons" => weightInKg / 1000,
                "Pounds" => weightInKg / 0.453592,
                "Ounces (UK/US)" => weightInKg / 0.0283495,
                "Ons (NL)" => weightInKg / 0.1,
                _ => throw new NotImplementedException($"Conversie naar {unit} is niet geïmplementeerd."),
            };
        }
    }
}
