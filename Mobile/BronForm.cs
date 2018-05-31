using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Graphics.Drawables;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using System.Threading;
using System.Collections.Generic;
using GlobalLib;
using System.Globalization;
using GlobalLib.Item;
using System.Linq;

namespace Mobile
{
    [Activity(NoHistory = true, Theme = "@style/Theme.AppCompat.Light.NoActionBar.FullScreen")]
    public class BronForm : Activity
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
        TextView TextViewSelectRout, TextViewData, TextViewCost, TextViewPoStart, TextViewPoEnd;
        Spinner SpinnerTypeTicket, SpinnerSpots;
        EditText EditTextFIO, EditTextPhone;
        Button m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m14, ButtonBron, ButtonBronFinish, ButtonFullFinish;
        RelativeLayout FinishLayout;
        string RoutsID, TripDate, TripID, StartPOText, StartPOId, EndPOText, EndPOId;
        List<Button> spots;
        List<TypeBilet> bilets;
        List<Rout> routs;
        Rout SelectRout;
        List<IApi> ObratPO;
        List<int> GetsSpots, SpisokForSpinnerSpots;
        string cost;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BronForm);
            //---Переменные для работы NAvigationView
            drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navView = FindViewById<NavigationView>(Resource.Id.nav_view);
            DrawerImage = FindViewById<ImageView>(Resource.Id.Button_menu);
            LoaderView = FindViewById<RelativeLayout>(Resource.Id.LoaderView);
            LoaderImage = FindViewById<ImageView>(Resource.Id.LoaderImage);
            //---Переменные для работы Activity
            m1 = FindViewById<Button>(Resource.Id.m1);
            m2 = FindViewById<Button>(Resource.Id.m2);
            m3 = FindViewById<Button>(Resource.Id.m3);
            m4 = FindViewById<Button>(Resource.Id.m4);
            m5 = FindViewById<Button>(Resource.Id.m5);
            m6 = FindViewById<Button>(Resource.Id.m6);
            m7 = FindViewById<Button>(Resource.Id.m7);
            m8 = FindViewById<Button>(Resource.Id.m8);
            m9 = FindViewById<Button>(Resource.Id.m9);
            m10 = FindViewById<Button>(Resource.Id.m10);
            m11 = FindViewById<Button>(Resource.Id.m11);
            m12 = FindViewById<Button>(Resource.Id.m12);
            m14 = FindViewById<Button>(Resource.Id.m14);
            ButtonBron = FindViewById<Button>(Resource.Id.ButtonBron);
            SpinnerTypeTicket = FindViewById<Spinner>(Resource.Id.SpinnerTypeTicket);
            SpinnerSpots = FindViewById<Spinner>(Resource.Id.SpinnerSpots);
            TextViewSelectRout = FindViewById<TextView>(Resource.Id.TextViewSelectRout);
            TextViewData = FindViewById<TextView>(Resource.Id.TextViewData);
            TextViewCost = FindViewById<TextView>(Resource.Id.TextViewCost);
            TextViewPoStart = FindViewById<TextView>(Resource.Id.TextViewPoStart);
            TextViewPoEnd = FindViewById<TextView>(Resource.Id.TextViewPoEnd);
            EditTextFIO = FindViewById<EditText>(Resource.Id.EditTextFIO);
            EditTextPhone = FindViewById<EditText>(Resource.Id.EditTextPhone);
            FinishLayout = FindViewById<RelativeLayout>(Resource.Id.FinishLayout);
            ButtonBronFinish = FindViewById<Button>(Resource.Id.ButtonBronFinish);
            ButtonFullFinish = FindViewById<Button>(Resource.Id.ButtonFullFinish);
            //----------------------------

            FinishLayout.Visibility = ViewStates.Invisible;
            ButtonBronFinish.Click += ButtonBronFinish_Click;
            ButtonFullFinish.Click += ButtonFullFinish_Click; ;
            AnimationLoader = (AnimationDrawable)LoaderImage.Drawable;
            AnimationLoader.Start();

            DrawerImage.Click += DrawerImage_Click;
            HeaderView = LayoutInflater.From(this).Inflate(Resource.Layout.drawer_header, null, false);

            navView.AddHeaderView(HeaderView);
            navView.NavigationItemSelected += NavView_NavigationItemSelected;
            EditTextPhone.TextChanged += EditTextPhone_TextChanged;
            ButtonBron.Click += ButtonBron_Click;

            RoutsID = Intent.GetStringExtra("RoutsID");
            TripID = Intent.GetStringExtra("TripID");
            TripDate = Intent.GetStringExtra("TripDate");
            StartPOText = Intent.GetStringExtra("StartPOText");
            StartPOId = Intent.GetStringExtra("StartPOId");
            EndPOText = Intent.GetStringExtra("EndPOText");
            EndPOId = Intent.GetStringExtra("EndPOId");

            TextViewPoStart.Text = StartPOText;
            TextViewPoEnd.Text = EndPOText;

            //---Массив мест
            SpisokForSpinnerSpots = new List<int>();
            ObratPO = new List<IApi>();
            spots = new List<Button>();
            spots.Add(m1);
            spots.Add(m2);
            spots.Add(m3);
            spots.Add(m4);
            spots.Add(m5);
            spots.Add(m6);
            spots.Add(m7);
            spots.Add(m8);
            spots.Add(m9);
            spots.Add(m10);
            spots.Add(m11);
            spots.Add(m12);
            spots.Add(m14);

            new Thread(new ThreadStart(delegate //поток для загрузки данных
            {
                bilets = TypeBilets.GetTypeBilets();
                routs = Routs.GetMarshruts();
                foreach (var item in routs)
                {
                    if (item.id.ToString() == RoutsID)
                    {
                        SelectRout = item;
                        break;
                    }
                }
                GetsSpots = Trips.GetMesta(Convert.ToInt32(TripID), Convert.ToInt32(RoutsID), Convert.ToInt32(StartPOId), Convert.ToInt32(EndPOId));
                RunOnUiThread(() => CheckSvMestaOnShema(GetsSpots, spots, SpisokForSpinnerSpots));
                RunOnUiThread(() => SpinnerSpots.Adapter = new SpotsAdapter(this, SpisokForSpinnerSpots));
                RunOnUiThread(() => SpinnerTypeTicket.Adapter = new TicketAdapter(this, bilets));
                cost = Prices.GetPrice(Convert.ToInt32(StartPOId), Convert.ToInt32(EndPOId), Convert.ToInt32(RoutsID));
                if (bilets[0].fix == 1)
                    cost = bilets[0].cost.ToString();
                else
                    cost = (Convert.ToDouble(cost) * bilets[0].cost).ToString();
                RunOnUiThread(() => TextViewCost.Text = cost);
                RunOnUiThread(() => TextViewSelectRout.Text = SelectRout.name);
                RunOnUiThread(() => TextViewData.Text = DateTime.ParseExact(TripDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("dd.MM.yyyy"));
                RunOnUiThread(() => AnimationLoader.Stop());
                RunOnUiThread(() => LoaderView.Visibility = ViewStates.Invisible);
                RunOnUiThread(() => SpinnerTypeTicket.ItemSelected += SpinnerTypeTicket_ItemSelected);
            })).Start();
        }

        private void ButtonFullFinish_Click(object sender, EventArgs e)
        {
            var ClientId = Clients.GetClientId(EditTextFIO.Text, EditTextPhone.Text);
            string mesto = "";
            if (SpisokForSpinnerSpots[SpinnerSpots.SelectedItemPosition] == 14)
                mesto = "13";
            else
                mesto = SpisokForSpinnerSpots[SpinnerSpots.SelectedItemPosition].ToString();
            var result = Orders.CreateNewOrder(new Order
            {
                type_bilet = bilets[SpinnerTypeTicket.SelectedItemPosition].id.ToString(),
                fio = EditTextFIO.Text,
                otkyda = StartPOId,
                kyda = EndPOId,
                id_poezdka = Convert.ToInt32(TripID),
                id_akcia = "0",
                cost = Convert.ToInt32(cost),
                mesto = mesto,
                status = "3",
                from_order = "2"
            }, ClientId.ToString());
            if (result != "false")
            {
                var IdOperation = Tranzactions.Create(result);
                FinishLayout.Visibility = ViewStates.Invisible;
                var intent = new Intent(this, typeof(WebViewActivity));
                intent.PutExtra("url", "http://orion38.pro/mobile/oplata.php?phone="+ EditTextPhone.Text+"&sum="+cost+ "&IDoperation="+ IdOperation);
                StartActivity(intent);
                //-------преход на ктивность с WeView для оплаты
            }
            else
            {
                function.AlertDialogShow("Ошибка", "Заказ не может быть оформленн в настоящие время.", this);
                FinishLayout.Visibility = ViewStates.Invisible;
            }
        }

        private void ButtonBronFinish_Click(object sender, EventArgs e)
        {
            var ClientId = Clients.GetClientId(EditTextFIO.Text, EditTextPhone.Text);
            string mesto = "";
            if (SpisokForSpinnerSpots[SpinnerSpots.SelectedItemPosition] == 14)
                mesto = "13";
            else
                mesto = SpisokForSpinnerSpots[SpinnerSpots.SelectedItemPosition].ToString();
            var result = Orders.CreateNewOrder(new Order
            {
                type_bilet = bilets[SpinnerTypeTicket.SelectedItemPosition].id.ToString(),
                fio = EditTextFIO.Text,
                otkyda = StartPOId,
                kyda = EndPOId,
                id_poezdka = Convert.ToInt32(TripID),
                id_akcia = "0",
                cost = Convert.ToInt32(cost)/100*10,
                mesto = mesto,
                status = "3",
                from_order = "2"
            }, ClientId.ToString());
            if (result != "false")
            {
                var IdOperation = Tranzactions.Create(result);
                FinishLayout.Visibility = ViewStates.Invisible;
                var intent = new Intent(this, typeof(WebViewActivity));
                intent.PutExtra("url", "http://orion38.pro/mobile/oplata.php?phone=" + EditTextPhone.Text + "&sum=" + (Convert.ToInt32(cost) / 100 * 10) .ToString()+ "&IDoperation=" + IdOperation);
                StartActivity(intent);
                //-------преход на ктивность с WeView для оплаты
            }
            else
            {
                function.AlertDialogShow("Ошибка", "Заказ не может быть оформленн в настоящие время.", this);
                FinishLayout.Visibility = ViewStates.Invisible;
            }
        }

        private void ButtonBron_Click(object sender, EventArgs e)
        {
            if (TextViewCost.Text != "-")
            {
                if (EditTextFIO.Text != "")
                {
                    if (EditTextPhone.Text != "" && EditTextPhone.Text.Count() == 11)
                    {
                        FinishLayout.Visibility = ViewStates.Visible;
                        ButtonBronFinish.Text = "Забронировать (" + (Convert.ToInt32(cost) / 100 * 10).ToString() + ")";
                        ButtonFullFinish.Text = "Полная оплата ("+cost + ")";
                    }
                    else
                        function.AlertDialogShow("Предупреждение", "Некорректно введен номер телефона", this);
                }
                else
                    function.AlertDialogShow("Предупреждение", "Введите ФИО", this);
            }
            else
                function.AlertDialogShow("Предупреждение", "Некорректные пункт отправления и назначения", this);
        }

        private void EditTextPhone_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (EditTextPhone.Text != "")
            {
                if (EditTextPhone.Text.Count() <= 11)
                {
                    if (EditTextPhone.Text[0] != '7')
                    {
                        function.AlertDialogShow("Предупреждение", "Номер телефона должен начинаться с '7'", this);
                        EditTextPhone.Text = "";
                    }
                }
                else
                {
                    EditTextPhone.Text = EditTextPhone.Text.Substring(0, 11);
                    function.AlertDialogShow("Предупреждение", "Номер телефона должен содержать 11 цифр", this);
                }
            }
        }

        private void SpinnerTypeTicket_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            cost = Prices.GetPrice(Convert.ToInt32(StartPOId), Convert.ToInt32(EndPOId), Convert.ToInt32(RoutsID));
            if (cost != "false")
            {
                if (bilets[e.Position].fix == 1)
                    cost = bilets[e.Position].cost.ToString();
                else
                    cost = (Convert.ToDouble(cost) * bilets[e.Position].cost).ToString();
                TextViewCost.Text = cost;
            }
            else
            {
                function.AlertDialogShow("Предупреждение", "Между выбранными населеными пунктами перевозка не осуществляется.", this);
                TextViewCost.Text = "-";
            }
        }

       
        public static void CheckSvMestaOnShema(List<int> mesta, List<Button> ButtonMas, List<int> ListMesta)
        {
            for (int i = 0; i < mesta.Count; i++)
            {
                if (mesta[i] == 1)
                {
                    ButtonMas[i].SetBackgroundResource(Resource.Drawable.ButtonStyle);
                }
                else
                {
                    if ((i + 1) != mesta.Count)
                        ListMesta.Add(i + 1);
                    else
                        ListMesta.Add(14);
                }
            }
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
                    intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);
                    break;
                case "Бронь":
                    Finish();
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