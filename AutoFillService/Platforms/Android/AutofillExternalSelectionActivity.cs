using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.AppCompat.App;

namespace AutoFillService.Droid.Autofill
{
    [Activity(
        Theme = "@style/Maui.SplashTheme",
        NoHistory = true,
        LaunchMode = LaunchMode.SingleTop)]
    public class AutofillExternalSelectionActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            System.Diagnostics.Debug.WriteLine("AutofillExternalSelectionActivity Created!");

            SetResult(Result.Canceled);

            AutoFillService.MainActivity.PendingMainPage = new NavigationPage(new ContentPage()
            {
                Content = new Label() { Text = "New Pager" }
            });

            Finish();
            return;
        }
    }
}
