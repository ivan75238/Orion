using Android.App;
using Android.Content;
using Android.OS;
using System.Threading.Tasks;

namespace Mobile
{
    [Activity(Label = "Орион", Icon = "@drawable/icon", Theme = "@style/SplashTheme", MainLauncher = true, NoHistory = true)]
    public class SplashLoader : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        protected override void OnResume()
        {
            base.OnResume();
            var startupWork = new Task(() =>
            {
                Task.Delay(10000);  // Simulate a bit of startup work.
            });

            startupWork.ContinueWith(t =>
            {
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }
    }
}