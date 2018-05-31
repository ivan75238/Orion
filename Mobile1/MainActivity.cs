using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Graphics.Drawables;
using System.Threading;
using GlobalLib;
using System;
using Android.Content;

namespace Mobile
{
    [Activity(Label = "Орион", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        DrawerLayout drawer;
        NavigationView navView;
        View HeaderView;
        RelativeLayout LoaderView;
        ImageView LoaderImage;
        AnimationDrawable AnimationLoader;
        ListView ListViewMarsh, ListViewPO;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navView = FindViewById<NavigationView>(Resource.Id.nav_view);
            LoaderView = FindViewById<RelativeLayout>(Resource.Id.LoaderView);
            LoaderImage = FindViewById<ImageView>(Resource.Id.LoaderImage);
            LoaderView = FindViewById<RelativeLayout>(Resource.Id.LoaderView);
            ListViewMarsh = FindViewById<ListView>(Resource.Id.ListViewMarsh);
            ListViewPO = FindViewById<ListView>(Resource.Id.ListViewPO);
            ImageView DrawerImage = FindViewById<ImageView>(Resource.Id.Button_menu);

            DrawerImage.Click += DrawerImage_Click;

            AnimationLoader = (AnimationDrawable)LoaderImage.Drawable;
            AnimationLoader.Start();

            HeaderView = LayoutInflater.From(this).Inflate(Resource.Layout.drawer_header, null, false);

            navView.AddHeaderView(HeaderView);
            navView.NavigationItemSelected += NavView_NavigationItemSelected;
            new Thread(new ThreadStart(delegate //поток для загрузки данных
            {
                var user = User.GetInstance(0, "", "", GetString(Resource.String.token));
                var marshruts = Marshruts.GetMarshruts();
                marshruts[0].GetPromPynkt();
                RunOnUiThread(() => ListViewMarsh.Adapter = new ArrayAdapter<Marshrut> (this, Android.Resource.Layout.SimpleListItem1, marshruts));
                RunOnUiThread(() => AnimationLoader.Stop());
                RunOnUiThread(() => LoaderView.Visibility = ViewStates.Invisible);
            })).Start();
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
                    break;
                case "Бронь":
                    /*intent = new Intent(this, typeof(VacancyPage)); //указываем на какую активити мы собираемся перейти
                    StartActivity(intent); //открываем следующий активити*/
                    break;
                case "Мой профиль":
                    /*intent = new Intent(this, typeof(MyProfile)); //указываем на какую активити мы собираемся перейти
                    StartActivity(intent); //открываем следующий активити*/
                    break;
                case "Выход":
                    FinishAffinity();
                    break;
            }
        }
    }
}

