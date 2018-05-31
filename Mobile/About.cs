using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;

namespace Mobile
{
    [Activity(NoHistory = true, Theme = "@style/Theme.AppCompat.Light.NoActionBar.FullScreen")]
    public class About : Activity
    {
        DrawerLayout drawer;
        NavigationView navView;
        View HeaderView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AboutLayout);

            drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navView = FindViewById<NavigationView>(Resource.Id.nav_view);
            ImageView DrawerImage = FindViewById<ImageView>(Resource.Id.Button_menu);
            DrawerImage.Click += DrawerImage_Click;
            HeaderView = LayoutInflater.From(this).Inflate(Resource.Layout.drawer_header, null, false);

            navView.AddHeaderView(HeaderView);
            navView.NavigationItemSelected += NavView_NavigationItemSelected;
        }

        void DrawerImage_Click(object sender, EventArgs e)
        {
            drawer.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
        }

        void NavView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            drawer.CloseDrawers();
            Intent intent = null;
            switch (e.MenuItem.ToString())
            {
                case "Главная":
                    Finish();
                    break;
                case "Бронь":
                    intent = new Intent(this, typeof(Bron));
                    StartActivity(intent);
                    break;
                case "О приложении":
                    break;
                case "Выход":
                    FinishAffinity();
                    break;
            }
        }
    }
}