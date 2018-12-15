using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Graphics.Drawables;
using System.Threading;
using System;
using GlobalLib;
using Android.Content;
using Android.Webkit;
using System.Collections.Generic;
using Android.Graphics;

namespace Mobile
{
    [Activity(Theme = "@style/Theme.AppCompat.Light.NoActionBar.FullScreen")]
    public class MainActivity : Activity
    {
        DrawerLayout drawer;
        NavigationView navView;
        View HeaderView;
        //WebView MapView;
        RelativeLayout LoaderView;
        ImageView LoaderImage;
        AnimationDrawable AnimationLoader;
        ListView ListViewMarsh, ListViewPO;
        List<Rout> marshruts;
        Button ButtonBron;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            //MapView = FindViewById<WebView>(Resource.Id.MapView);
            drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navView = FindViewById<NavigationView>(Resource.Id.nav_view);
            LoaderView = FindViewById<RelativeLayout>(Resource.Id.LoaderView);
            LoaderImage = FindViewById<ImageView>(Resource.Id.LoaderImage);
            ListViewMarsh = FindViewById<ListView>(Resource.Id.ListViewMarsh);
            ListViewPO = FindViewById<ListView>(Resource.Id.ListViewPO);
            ImageView DrawerImage = FindViewById<ImageView>(Resource.Id.Button_menu);
            ButtonBron = FindViewById<Button>(Resource.Id.ButtonBron);

            DrawerImage.Click += DrawerImage_Click;
            ButtonBron.Click += ButtonBron_Click;

            AnimationLoader = (AnimationDrawable)LoaderImage.Drawable;
            AnimationLoader.Start();

            HeaderView = LayoutInflater.From(this).Inflate(Resource.Layout.drawer_header, null, false);
            
            navView.AddHeaderView(HeaderView);
            navView.NavigationItemSelected += NavView_NavigationItemSelected;
            ListViewMarsh.ChoiceMode = ChoiceMode.Single;
            ListViewMarsh.DividerHeight = 0;
            ListViewMarsh.ItemClick += ListViewMarsh_ItemClick;
            ListViewPO.DividerHeight = 0;
            var paramMarsh = ListViewMarsh.LayoutParameters;
            var paramPO = ListViewPO.LayoutParameters;
            //MapView.Settings.JavaScriptEnabled = true;
            new Thread(new ThreadStart(delegate //поток для загрузки данных
            {
                var user = User.GetInstance(0, "", "", GetString(Resource.String.token));
                marshruts = Routs.GetMarshruts();
                foreach (var item in marshruts)
                {
                    item.GetPromPynkt();
                }
                //RunOnUiThread(() => MapView.LoadUrl("http://orion38.pro/maps/maps.php?url_map=" + marshruts[0].url_map));
                paramMarsh.Height = Convert.ToInt32(function.convertDpToPixel(45, this)) * marshruts.Count;
                paramPO.Height = Convert.ToInt32(function.convertDpToPixel(35, this)) * (marshruts[0].PromPynkt.Count+1);
                RunOnUiThread(() => ListViewMarsh.Adapter = new RoutAdapter(this, marshruts));
                RunOnUiThread(() => ListViewPO.Adapter = new PromPynktAdapter(this, marshruts[0].PromPynkt));
                RunOnUiThread(() => AnimationLoader.Stop());
                RunOnUiThread(() => LoaderView.Visibility = ViewStates.Invisible);
            })).Start();
        }

        private void ButtonBron_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(Bron)));
        }

        private void ListViewMarsh_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            for (int i = 0; i < marshruts.Count; i++)
            {
                if (e.Position == i)
                    ListViewMarsh.GetChildAt(i).SetBackgroundColor(Color.ParseColor("#d3d3d3"));
                else
                    ListViewMarsh.GetChildAt(i).SetBackgroundColor(Color.ParseColor("#ffffff"));
            }
            //MapView.LoadUrl("http://orion38.pro/maps/maps.php?url_map=" + marshruts[e.Position].url_map);
            ListViewPO.Adapter = new PromPynktAdapter(this, marshruts[e.Position].PromPynkt);
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
                    intent = new Intent(this, typeof(Bron));
                    StartActivity(intent);
                    break;
                case "О приложении":
                    intent = new Intent(this, typeof(About)); 
                    StartActivity(intent); 
                    break;
                case "Выход":
                    FinishAffinity();
                    break;
            }
        }
    }
}

