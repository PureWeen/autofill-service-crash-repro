
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
            // I just picked something here to trigger two different paths. In your code you'd probably inspect the bundle
            // or context to determine what you want to do
            /*
            #if ANDROID
            if (activationState is ActivationState aState)
            {
                aState.SavedInstance.GetBoolean("isAutoFill");
            }
            #endif
            */
            if (activationState.State.Count > 0)
            {
                var userApplicaitonWindow = Windows.OfType<UserApplicationWindow>().FirstOrDefault();

                if (userApplicaitonWindow is not null)
                {
                    userApplicaitonWindow.PendingPage = new NavigationPage(new ContentPage() { Content = new Label() { Text = "reseting page on main page!" } });
                }

                 return new AutoFillWindow(new ContentPage() { Content = new Label() { Text = "Auto Fill service page!" } });
            }


            var autofillWindow = Windows.OfType<AutoFillWindow>().FirstOrDefault();
            if (autofillWindow is not null)
            {
                autofillWindow.PendingPage = new NavigationPage(new ContentPage() { Content = new Label() { Text = "User opened main app" } });
                // or you could close the autofill window here if you wanted to
            }

            return new UserApplicationWindow(new NavigationPage(new MainPage()));
        }
    }

    public class ResumeHackWindow : Window
    {
        public Page PendingPage {get;set;}

        public ResumeHackWindow(Page page) : base(page)
        {

        }

        /// <summary>
        /// You need to do this inside OnActivated not OnResumed
        /// Androids OnResume maps to OnActivated
        /// Androids OnRestart is what Maps to OnResumed
        /// I realize this is confusing from the perspective of Android
        /// https://github.com/dotnet/maui/issues/1720 explains it a bit better
        /// </summary>
        protected override void OnActivated()
        {
            base.OnActivated();

            // This shouldn't be necessary. I'll need to investigate why you can't just set the page during this call
           // await Task.Yield();
            if (PendingPage is not null)
                Page = PendingPage;

            PendingPage = null;
        }
    }
    
    public class UserApplicationWindow : ResumeHackWindow
    {

        public UserApplicationWindow(Page page) : base(page)
        {

        }
    }

    public class AutoFillWindow : ResumeHackWindow
    {       
        public AutoFillWindow(Page page) : base(page)
        {

        }

    }
}
