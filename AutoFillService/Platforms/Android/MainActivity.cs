using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace AutoFillService
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        public static Page PendingMainPage { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState); 
            System.Diagnostics.Debug.WriteLine("MainActivity Created!");
        }

        protected override void OnResume()
        {
            base.OnResume();

            if (PendingMainPage is not null)
                Microsoft.Maui.Controls.Application.Current.MainPage = PendingMainPage;

            PendingMainPage = null;
        }
    }
}
