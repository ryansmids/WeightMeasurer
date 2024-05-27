namespace WeightMeasure
{
    public partial class FlyoutMenuPage : FlyoutPage
    {
        public FlyoutMenuPage()
        {
            InitializeComponent();
        }

        private void OnHomeClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new MainPage());
            IsPresented = false;
        }

        private void OnAboutClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new AboutPage());
            IsPresented = false;
        }

        private void OnHelloWorldClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new HelloWorldPage());
            IsPresented = false;
        }

        private void OnThemeSwitchToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                // Switch to Dark Theme
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(new DarkTheme());
            }
            else
            {
                // Switch to Light Theme
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(new LightTheme());
            }
        }
    }
}
