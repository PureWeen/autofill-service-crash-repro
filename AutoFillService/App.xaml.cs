
namespace AutoFillService
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }


        protected override Window CreateWindow(IActivationState activationState)
        {
            if (activationState.State.Count > 0)
                 return new Window(new NavigationPage(new ContentPage() { Content = new Label() { Text = "Auto Fill service page!" } }));

            return new Window(new NavigationPage(new MainPage()));
        }
    }
}
