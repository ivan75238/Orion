using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Graphics.Drawables;
using System.Threading;
using GlobalLib;
using GlobalLib.Item;

namespace Mobile
{
    [Activity(Theme = "@style/Theme.AppCompat.Light.NoActionBar.FullScreen")]
    public class Bron : Activity
    {
        //---Блок переменных для работы с NavigationView и LaoderLayout
        DrawerLayout drawer;
        NavigationView navView;
        View HeaderView;
        RelativeLayout LoaderView;
        ImageView LoaderImage;
        AnimationDrawable AnimationLoader;
        ImageView DrawerImage;
        //---Переменные для работы с Activity
        ListView ListViewTrips;
        Spinner SpinnerRouts, SpinnerPoStart, SpinnerPoEnd;
        TextView TextViewData;
        List<Rout> routs;
        List<Trip> trips;
        DateTime TripDate;
        List<IApi> ObratPO;
        ViewGroup.LayoutParams ListViewTripsParmetr;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BronLayout);
             //---Переменные для работы NAvigationView
            drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navView = FindViewById<NavigationView>(Resource.Id.nav_view);
            DrawerImage = FindViewById<ImageView>(Resource.Id.Button_menu);
            LoaderView = FindViewById<RelativeLayout>(Resource.Id.LoaderView);
            LoaderImage = FindViewById<ImageView>(Resource.Id.LoaderImage);
            //---Переменные для работы с Activity
            ListViewTrips = FindViewById<ListView>(Resource.Id.ListViewTrips);
            SpinnerRouts = FindViewById<Spinner>(Resource.Id.SpinnerRouts);
            SpinnerPoStart = FindViewById<Spinner>(Resource.Id.SpinnerPoStart);
            SpinnerPoEnd = FindViewById<Spinner>(Resource.Id.SpinnerPoEnd);
            TextViewData = FindViewById<TextView>(Resource.Id.TextViewData);

            TextViewData.Click += TextViewData_Click;
            SpinnerRouts.ItemSelected += SpinnerRouts_ItemSelected;
            SpinnerPoStart.ItemSelected += SpinnerPoStart_ItemSelected;
            SpinnerPoEnd.ItemSelected += SpinnerPoEnd_ItemSelected;
            AnimationLoader = (AnimationDrawable)LoaderImage.Drawable;
            AnimationLoader.Start();

            ListViewTrips.DividerHeight = 0;
            ListViewTripsParmetr = ListViewTrips.LayoutParameters;
            ListViewTrips.ItemClick += ListViewTrips_ItemClick;
            DrawerImage.Click += DrawerImage_Click;
            HeaderView = LayoutInflater.From(this).Inflate(Resource.Layout.drawer_header, null, false);

            navView.AddHeaderView(HeaderView);
            navView.NavigationItemSelected += NavView_NavigationItemSelected;

            new Thread(new ThreadStart(delegate //поток для загрузки данных
            {
                ObratPO = new List<IApi>();
                TripDate = DateTime.Today;
                RunOnUiThread(() => TextViewData.Text = TripDate.ToString("dd.MM.yyyy"));
                routs = Routs.GetMarshruts();
                routs[0].GetPromPynkt();
                for (int i = routs[0].PromPynkt.Count-1; i >= 0; i--)
                {
                    ObratPO.Add(routs[0].PromPynkt[i]);
                }
                RunOnUiThread(() => SpinnerRouts.Adapter = new RoutAdapter(this, routs));
                RunOnUiThread(() => SpinnerPoStart.Adapter = new PromPynktAdapter(this, routs[0].PromPynkt));
                RunOnUiThread(() => SpinnerPoEnd.Adapter = new PromPynktAdapter(this, ObratPO));
                trips = Trips.GetTripsOnDate(TripDate.ToString("yyyy-MM-dd"), routs[0].PromPynkt[0].id.ToString(), ObratPO[0].id.ToString(), routs[0].id.ToString());
                ListViewTripsParmetr.Height = Convert.ToInt32(function.convertDpToPixel(90, this)) * trips.Count;
                RunOnUiThread(() => ListViewTrips.Adapter = new TripsAdapter(this, trips));
                RunOnUiThread(() => AnimationLoader.Stop());
                RunOnUiThread(() => LoaderView.Visibility = ViewStates.Invisible);
            })).Start();
        }

        private void SpinnerPoEnd_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (SpinnerPoEnd.SelectedItemPosition != -1)
            {
                LoaderView.Visibility = ViewStates.Visible;
                AnimationLoader.Start();
                new Thread(new ThreadStart(delegate //поток для загрузки данных
                {
                    var cost = Prices.GetPrice(routs[SpinnerRouts.SelectedItemPosition].PromPynkt[SpinnerPoStart.SelectedItemPosition].id, ObratPO[SpinnerPoEnd.SelectedItemPosition].id, routs[SpinnerRouts.SelectedItemPosition].id);
                    if (cost != "false")
                    {
                        trips = Trips.GetTripsOnDate(TripDate.ToString("yyyy-MM-dd"), routs[SpinnerRouts.SelectedItemPosition].PromPynkt[SpinnerPoStart.SelectedItemPosition].id.ToString(), ObratPO[SpinnerPoEnd.SelectedItemPosition].id.ToString(), routs[SpinnerRouts.SelectedItemPosition].id.ToString());
                        ListViewTripsParmetr.Height = Convert.ToInt32(function.convertDpToPixel(90, this)) * trips.Count;
                        RunOnUiThread(() => ListViewTrips.Adapter = new TripsAdapter(this, trips));
                        RunOnUiThread(() => AnimationLoader.Stop());
                        RunOnUiThread(() => LoaderView.Visibility = ViewStates.Invisible);
                    }
                    else
                    {
                        RunOnUiThread(() => ListViewTrips.Adapter = null);
                        RunOnUiThread(() => AnimationLoader.Stop());
                        RunOnUiThread(() => LoaderView.Visibility = ViewStates.Invisible);
                        RunOnUiThread(() => function.AlertDialogShow("Предупреждение", "Между выбранными пунктами не осуществляется перевозка.", this));
                    }
                })).Start();
            }
        }

        private void SpinnerPoStart_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (SpinnerPoStart.SelectedItemPosition != -1)
            {
                LoaderView.Visibility = ViewStates.Visible;
                AnimationLoader.Start();
                new Thread(new ThreadStart(delegate //поток для загрузки данных
                {
                    var cost = Prices.GetPrice(routs[SpinnerRouts.SelectedItemPosition].PromPynkt[SpinnerPoStart.SelectedItemPosition].id, ObratPO[SpinnerPoEnd.SelectedItemPosition].id, routs[SpinnerRouts.SelectedItemPosition].id);
                    if (cost != "false")
                    {
                        trips = Trips.GetTripsOnDate(TripDate.ToString("yyyy-MM-dd"), routs[SpinnerRouts.SelectedItemPosition].PromPynkt[SpinnerPoStart.SelectedItemPosition].id.ToString(), ObratPO[SpinnerPoEnd.SelectedItemPosition].id.ToString(), routs[SpinnerRouts.SelectedItemPosition].id.ToString());
                        ListViewTripsParmetr.Height = Convert.ToInt32(function.convertDpToPixel(90, this)) * trips.Count;
                        RunOnUiThread(() => ListViewTrips.Adapter = new TripsAdapter(this, trips));
                        RunOnUiThread(() => AnimationLoader.Stop());
                        RunOnUiThread(() => LoaderView.Visibility = ViewStates.Invisible);
                    }
                    else
                    {
                        RunOnUiThread(() => ListViewTrips.Adapter = null);
                        RunOnUiThread(() => AnimationLoader.Stop());
                        RunOnUiThread(() => LoaderView.Visibility = ViewStates.Invisible);
                        RunOnUiThread(() => function.AlertDialogShow("Предупреждение", "Между выбранными пунктами не осуществляется перевозка.", this));
                    }
                })).Start();
            }
        }

        private void ListViewTrips_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (trips[e.Position].coun_sv_mest != 0)
            {
                var intent = new Intent(this, typeof(BronForm));
                intent.PutExtra("TripID", trips[e.Position].id.ToString());
                intent.PutExtra("RoutsID", routs[SpinnerRouts.SelectedItemPosition].id.ToString());
                intent.PutExtra("TripDate", TripDate.ToString("yyyy-MM-dd"));
                intent.PutExtra("StartPOText", routs[SpinnerRouts.SelectedItemPosition].PromPynkt[SpinnerPoStart.SelectedItemPosition].name);
                intent.PutExtra("StartPOId", routs[SpinnerRouts.SelectedItemPosition].PromPynkt[SpinnerPoStart.SelectedItemPosition].id.ToString());
                intent.PutExtra("EndPOText", ObratPO[SpinnerPoEnd.SelectedItemPosition].name);
                intent.PutExtra("EndPOId", ObratPO[SpinnerPoEnd.SelectedItemPosition].id.ToString());
                StartActivity(intent);
            }
            else
                function.AlertDialogShow("Предупреждение", "На выбранный рейс нет свободных мест.", this);
        }

        private void SpinnerRouts_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            LoaderView.Visibility = ViewStates.Visible;
            AnimationLoader.Start();
            new Thread(new ThreadStart(delegate //поток для загрузки данных
            {
                routs[e.Position].GetPromPynkt();
                ObratPO = new List<IApi>();
                for (int i = routs[e.Position].PromPynkt.Count - 1; i >= 0; i--)
                {
                    ObratPO.Add(routs[e.Position].PromPynkt[i]);
                }
                RunOnUiThread(() => SpinnerPoStart.Adapter = new PromPynktAdapter(this, routs[e.Position].PromPynkt));
                RunOnUiThread(() => SpinnerPoEnd.Adapter = new PromPynktAdapter(this, ObratPO));
                trips = Trips.GetTripsOnDate(TripDate.ToString("yyyy-MM-dd"), routs[e.Position].PromPynkt[0].id.ToString(), ObratPO[0].id.ToString(), routs[e.Position].id.ToString());
                ListViewTripsParmetr.Height = Convert.ToInt32(function.convertDpToPixel(90, this)) * trips.Count;
                RunOnUiThread(() => ListViewTrips.Adapter = new TripsAdapter(this, trips));
                RunOnUiThread(() => AnimationLoader.Stop());
                RunOnUiThread(() => LoaderView.Visibility = ViewStates.Invisible);
            })).Start();
        }

        private void TextViewData_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                TripDate = time;
                TextViewData.Text = time.ToString("dd.MM.yyyy");
                LoaderView.Visibility = ViewStates.Visible;
                AnimationLoader.Start();
                new Thread(new ThreadStart(delegate //поток для загрузки данных
                {
                    var cost = Prices.GetPrice(routs[SpinnerRouts.SelectedItemPosition].PromPynkt[SpinnerPoStart.SelectedItemPosition].id, ObratPO[SpinnerPoEnd.SelectedItemPosition].id, routs[SpinnerRouts.SelectedItemPosition].id);
                    if (cost != "false")
                    {
                        trips = Trips.GetTripsOnDate(TripDate.ToString("yyyy-MM-dd"), routs[SpinnerRouts.SelectedItemPosition].PromPynkt[SpinnerPoStart.SelectedItemPosition].id.ToString(), ObratPO[SpinnerPoEnd.SelectedItemPosition].id.ToString(), routs[SpinnerRouts.SelectedItemPosition].id.ToString());
                        ListViewTripsParmetr.Height = Convert.ToInt32(function.convertDpToPixel(90, this)) * trips.Count;
                        RunOnUiThread(() => ListViewTrips.Adapter = new TripsAdapter(this, trips));
                        RunOnUiThread(() => AnimationLoader.Stop());
                        RunOnUiThread(() => LoaderView.Visibility = ViewStates.Invisible);
                    } 
                    else
                    {
                        RunOnUiThread(() => ListViewTrips.Adapter = null);
                        RunOnUiThread(() => AnimationLoader.Stop());
                        RunOnUiThread(() => LoaderView.Visibility = ViewStates.Invisible);
                        RunOnUiThread(() => function.AlertDialogShow("Предупреждение", "Между выбранными пунктами не осуществляется перевозка.", this));
                    }
                })).Start();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
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