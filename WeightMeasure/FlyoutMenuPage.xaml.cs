namespace WeightMeasure
{
    public partial class FlyoutMenuPage : FlyoutPage
    {
        public FlyoutMenuPage()
        {
            InitializeComponent();
        }

        // Methode voor de Home-knop
        private void OnHomeClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new MainPage());
            IsPresented = false;
        }

        // Methode voor de About-knop
        private void OnAboutClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new AboutPage());
            IsPresented = false;
        }

        // Methode voor de Hello World-knop
        private void OnHelloWorldClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new HelloWorldPage());
            IsPresented = false;
        }

        // Methode voor de ThemeSwitch-schakelaar
        private void OnThemeSwitchToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                // Schakel naar donkere modus
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(new DarkTheme());
            }
            else
            {
                // Schakel naar lichte modus
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(new LightTheme());
            }
        }
    }
}
