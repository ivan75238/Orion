using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using GlobalLib;
using System.Linq;
using Orion.WorkPlanForms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Orion
{
    public partial class MainForm : MetroForm
    {
        List<Order> orders;
        List<Rout> marshruts;
        DateTime ChekDay;
        User user;
        List<User> users;
        List<Stock> stocks;
        int SelectTabIndex, SummaruCoutForOtchetCars, DayCount, CountLastOrderNotDispetcher = 0, SelectMarshId;
        List<Trip> trips;
        List<Client> clients;
        List<Car> park;
        List<TypeBilet> bilets;
        List<Price> prices;
        List<OrderInService> OrdersForService;
        List<WorkPlan> plans;
        private List<News> news;
        FromOrder fromOrder;
        int PositionForSetBilet;
        int CountOrderForOtcehtCars, SrCoutOnTripForOtchetpark, SrCoutOnOrderForOtchetpark;

        #region MainFom Methods
        public MainForm()
        {
            InitializeComponent();
            user = User.GetInstance();
            KeyPreview = true;
            TabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            marshruts = Routs.GetMarshruts();
            fromOrder = new FromOrder();
            SelectTabIndex = 0;
            
            for (int i = 0; i < marshruts.Count; i++)
            {
                ComboBoxMarshrut.Items.Add(marshruts[i].name);
            }
            SelectMarshId = marshruts[0].id;
            ComboBoxMarshrut.SelectedIndex = 0;
            ChekDay = DateTime.Today;
            orders = Orders.GetOrders(ChekDay.ToString("yyyy-MM-dd"), SelectMarshId.ToString());
            DataGridOrders.Rows.Clear();
            //------------Обработка Grids------------
            DataGridOrders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DataGridOrders.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            GridAkcia.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            GridAkcia.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            GridClient.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            GridClient.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            GridPark.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            GridPark.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            GridPrice.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            GridPrice.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            GridTrip.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            GridTrip.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            GridUser.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            GridUser.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            GridTypeBilet.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            GridTypeBilet.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //---------------------------------------
            // DataGridOrders.DataSource = orders;    //Оставлю как памятка о возможности
            if (orders.Count > 0)
            {
                for (int i = 0; i < orders.Count; i++)
                {
                    string status = functions.CheckStatus(orders[i].status);
                    DataGridOrders.Rows.Add((i + 1).ToString(), orders[i].type_bilet, orders[i].fio, orders[i].phone, orders[i].data.ToShortDateString(), orders[i].name_marsh, orders[i].otkyda, orders[i].kyda, orders[i].mesto, orders[i].voditel, orders[i].gos_nomer, orders[i].cost, orders[i].cost_bron, status);
                }
            } else
            {
                MetroMessageBox.Show(this, "На сегодня нет заказов.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

            foreach (DataGridViewColumn column in GridAkcia.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in GridClient.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in GridPark.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in GridPrice.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in GridTrip.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in GridUser.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in DataGridOrders.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in GridTypeBilet.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in DataGridTabMarshrutsPromPunkt.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            //----------Служба для отслеживания заказов полученных не от диспетчера--------
            if (CountLastOrderNotDispetcher == 0)
            {
                if (File.Exists(Application.StartupPath + @"\" + "order.php"))
                {
                    CountLastOrderNotDispetcher = Convert.ToInt32(File.ReadAllText(Application.StartupPath + @"\" + "order.php"));
                }
                else
                {
                    CountLastOrderNotDispetcher = Orders.CountOrderFromSiteAndMobile();
                    File.WriteAllText(Application.StartupPath + @"\" + "order.php", CountLastOrderNotDispetcher.ToString());
                }
            }
            new Thread(new ThreadStart(delegate //поток для отслеживания изменений в количесве заказов
            {
                while (true)
                {
                    Thread.Sleep(60000);
                    SearchOrder();
                }
            })).Start();
            //--------------------------------------------
        }
        void SearchOrder()
        {
            int NewCount = Orders.CountOrderFromSiteAndMobile();
            if (CountLastOrderNotDispetcher < NewCount)
            {
                OrdersForService = Orders.GetLastOrderNotDispetcher((NewCount - CountLastOrderNotDispetcher).ToString());
                string messege = "Были оформленны заказы через интернет:\n№-----ФИО-----Дата-----Маршрут-----Место\n";
                for (int i = 0; i < (NewCount - CountLastOrderNotDispetcher); i++)
                {
                    messege += (i + 1).ToString() + "-----" + OrdersForService[i].fio + "-----" + OrdersForService[i].data.ToShortDateString() + "-----" + OrdersForService[i].name_marsh + "-----" + OrdersForService[i].mesto + "\n";
                }
                messege += "Для более подробной информации откройте эти заказы";
                CountLastOrderNotDispetcher = NewCount;
                File.WriteAllText(Application.StartupPath + @"\" + "order.php", CountLastOrderNotDispetcher.ToString());
                MetroMessageBox.Show(this, messege, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
            } else if (CountLastOrderNotDispetcher > NewCount)
            {
                CountLastOrderNotDispetcher = NewCount;
                File.WriteAllText(Application.StartupPath + @"\" + "order.php", CountLastOrderNotDispetcher.ToString());
            }
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion
        private async void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0: //заказы
                    #region TabOrders
                    marshruts = Routs.GetMarshruts();
                    ComboBoxMarshrut.Items.Clear();
                    for (int i = 0; i < marshruts.Count; i++)
                    {
                        ComboBoxMarshrut.Items.Add(marshruts[i].name);
                    }
                    SelectMarshId = marshruts[0].id;
                    ComboBoxMarshrut.SelectedIndex = 0;
                    ChekDay = DateTime.Today;
                    metroDateTime1.Value = ChekDay;
                    orders = Orders.GetOrders(ChekDay.ToString("yyyy-MM-dd"), SelectMarshId.ToString());
                    DataGridOrders.Rows.Clear();
                    // DataGridOrders.DataSource = orders;    //Оставлю как памятка о возможности
                    if (orders.Count > 0)
                    {
                        for (int i = 0; i < orders.Count; i++)
                        {
                            string MestoFromDataGrid;
                            if (orders[i].mesto == "13")
                                MestoFromDataGrid = "14";
                            else
                                MestoFromDataGrid = orders[i].mesto;
                            string status = functions.CheckStatus(orders[i].status);
                            DataGridOrders.Rows.Add((i+1).ToString(), orders[i].type_bilet, orders[i].fio, orders[i].phone, orders[i].data.ToShortDateString(), orders[i].name_marsh, orders[i].otkyda, orders[i].kyda, MestoFromDataGrid, orders[i].voditel, orders[i].gos_nomer, orders[i].cost, orders[i].cost_bron, status);
                        }
                    }
                    #endregion
                    break;
                case 1: //расписание
                    #region TabTrip
                    marshruts = Routs.GetMarshruts();
                    ComboBoxTripsMarsh.Items.Clear();
                    for (int i=0; i < marshruts.Count; i++)
                    {
                        ComboBoxTripsMarsh.Items.Add(marshruts[i].name);
                    }
                    marshruts[0].GetPromPynkt();
                    int g = marshruts[0].PromPynkt.Count - 1;
                    for (int i = 0; i < marshruts[0].PromPynkt.Count; i++)
                    {
                        ComboBoxFrom.Items.Add(marshruts[0].PromPynkt[i]);
                        ComboBoxTo.Items.Add(marshruts[0].PromPynkt[g]);
                        g--;
                    }
                    ComboBoxTripsMarsh.SelectedIndex = 0;
                    ComboBoxFrom.Visible = false;
                    ComboBoxTo.Visible = false;
                    ComboBoxFrom.SelectedIndex = 0;
                    ComboBoxTo.SelectedIndex = 0;
                    trips = Trips.GetTripsOnDate(DateTimeTrip.Value.ToString("yyyy-MM-dd"), marshruts[0].PromPynkt[0].id.ToString(), marshruts[0].PromPynkt[marshruts[0].PromPynkt.Count-1].id.ToString(), marshruts[ComboBoxTripsMarsh.SelectedIndex].id.ToString());
                    GridTrip.Rows.Clear();
                    for (int i=0; i < trips.Count; i++)
                    {
                        GridTrip.Rows.Add("Микроавтобус №"+(i+1).ToString(), trips[i].gos_nomer, trips[i].voditel);
                    }
                    #endregion
                    break;
                case 2: //клиенты
                    #region TabClient
                    GridClient.Rows.Clear();
                    ProgressBarClient.Visible = true;
                    LabelProgressbarClient.Visible = true;
                    clients = Clients.GetAllClient();
                    ProgressBarClient.Minimum = 0;
                    ProgressBarClient.Maximum = clients.Count;
                    ProgressBarClient.Value = 0;
                    new Thread(new ThreadStart(delegate
                    {
                        for (int i = 0; i < clients.Count; i++)
                        {
                            GridClient.Invoke(new Action(() => { GridClient.Rows.Add(clients[i].fio, clients[i].phone, clients[i].count, clients[i].cost); }));
                            ProgressBarClient.Invoke(new Action(() => { ProgressBarClient.Value++; }));
                        }
                        ProgressBarClient.Invoke(new Action(() => { ProgressBarClient.Visible = false; }));
                        LabelProgressbarClient.Invoke(new Action(() => { LabelProgressbarClient.Visible = false; }));
                    })).Start();
                    #endregion
                    break;
                case 3: //акции
                    #region TabStock
                    stocks = Stocks.GetStock();
                    GridAkcia.Rows.Clear();
                    TextBoxNewNameAkcia.Enabled = false;
                    CheckBoxNewAkcia.Checked = false;
                    ComboBoAkciaName.Items.Clear();
                    for (int i=0; i < stocks.Count; i++)
                    {
                        ComboBoAkciaName.Items.Add(stocks[i].name);
                        GridAkcia.Rows.Add(stocks[i].name, stocks[i].data_nach.ToShortDateString(), stocks[i].data_konec.ToShortDateString(), stocks[i].cost);
                    }
                    #endregion
                    break;
                case 4: //парк
                    #region TabPark
                    if (user.role == "0")
                    {
                        TabControl.SelectedIndex = SelectTabIndex;
                        MetroMessageBox.Show(this, "Недостаточно прав.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        ComboBoxSelectCars.Items.Clear();
                        GridPark.Rows.Clear();
                        park =  Park.GetCars("0");
                        ComboBoxSelectCars.Items.Add("Все");
                        ComboBoxSelectCars.Items.Add("Активные");
                        ComboBoxSelectCars.Items.Add("Неактивные");
                        ComboBoxSelectCars.SelectedIndex = 0;
                        for (int i = 0; i < park.Count; i++)
                        {
                            GridPark.Rows.Add(park[i].marka, park[i].gos_nomer, park[i].voditel, park[i].count_poezd, park[i].teh_obslyzh, park[i].arenda_nach.ToShortDateString(), park[i].arenda_konec.ToShortDateString(), 
                                park[i].status == "0" ? "Работает" : "Уволен");
                        }
                    }
                    #endregion
                    break;
                case 5: //цены
                    #region TabPrice
                    if (user.role == "0")
                    {
                        TabControl.SelectedIndex = SelectTabIndex;
                        MetroMessageBox.Show(this, "Недостаточно прав.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        GridPrice.Rows.Clear();
                        ComboBoxPriceMarsh.Items.Clear();
                        marshruts = Routs.GetMarshruts();
                        for (int i = 0; i < marshruts.Count; i += 2)
                        {
                            ComboBoxPriceMarsh.Items.Add(marshruts[i].name);
                        }
                        ComboBoxPriceMarsh.SelectedIndex = 0;
                        BrowserPrice.ScriptErrorsSuppressed = true;
                        BrowserPrice.Navigate("http://orion38.pro/maps/maps.php?url_map=" + marshruts[ComboBoxPriceMarsh.SelectedIndex].url_map);
                        prices = Prices.GetPriceForMarsID(marshruts[ComboBoxPriceMarsh.SelectedIndex].id.ToString());
                        GridPrice.Rows.Clear();
                        for (int i = 0; i < prices.Count; i++)
                        {
                            GridPrice.Rows.Add(prices[i].Otkyda, prices[i].Kyda, prices[i].cost);
                        }
                    }
                    #endregion
                    break;
                case 6: //маршруты
                    #region TabMarshryt
                    marshruts = Routs.GetMarshruts();
                    ButtonOpenCatalogPP.Text = "Справочник\nпромежуточных\nпунктов";
                    ComboBoxMarshrutMarshrut.Items.Clear();
                    DataGridTabMarshrutsPromPunkt.Rows.Clear();
                    DataGridTabMarshrutsPromPunkt.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    DataGridTabMarshrutsPromPunkt.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    for (int i = 0; i < marshruts.Count; i++)
                    {
                        ComboBoxMarshrutMarshrut.Items.Add(marshruts[i].name);
                    }
                    marshruts[0].GetPromPynkt();
                    for (int i = 0; i < marshruts[0].PromPynkt.Count; i++)
                    {
                        DataGridTabMarshrutsPromPunkt.Rows.Add(marshruts[0].PromPynkt[i].name);
                    }
                    BrowserMarshrutMap.ScriptErrorsSuppressed = true;
                    ComboBoxMarshrutMarshrut.SelectedIndex = 0;
                    BrowserMarshrutMap.Navigate("http://orion38.pro/maps/maps.php?url_map=" + marshruts[ComboBoxMarshrutMarshrut.SelectedIndex].url_map);
                    #endregion
                    break;
                case 7: //тип билета
                    #region TabTypeBilet
                    if (user.role == "0")
                    {
                        TabControl.SelectedIndex = SelectTabIndex;
                        MetroMessageBox.Show(this, "Недостаточно прав.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        LabelAddTypeBilet.Visible = false;
                        TextBoxAddTypeBilet.Visible = false;
                        LabelFixed.Visible = false;
                        ToggleFixedCost.Visible = false;
                        LabelCost.Visible = false;
                        TextBoxCost.Visible = false;
                        ButtonCreateTypeBilet.Visible = false;
                        GridTypeBilet.Rows.Clear();
                        bilets = TypeBilets.GetTypeBilets();
                        for (int i = 0; i < bilets.Count; i++)
                        {
                            GridTypeBilet.Rows.Add(bilets[i].name, Convert.ToBoolean(bilets[i].fix), bilets[i].cost);
                        }
                    }
                    #endregion
                    break;
                case 8: //план работы
                    #region TabWorkPlan
                    GridViewWorkPlan.Rows.Clear();
                    ComboBoxWorkPlan.Items.Clear();
                    plans = await WorkPlan.Get();
                    for (int i = 0; i < plans.Count; i++)
                    {
                        ComboBoxWorkPlan.Items.Add(plans[i].year.ToString("yyyy"));
                    }
                    if (plans.Count > 0)
                        ComboBoxWorkPlan.SelectedIndex = 0;
                    #endregion
                    break;
                case 9: //настройки
                    #region TabNastroiki
                    if (user.role == "0")
                    {
                        TabControl.SelectedIndex = SelectTabIndex;
                        MetroMessageBox.Show(this, "Недостаточно прав.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        users = Users.GetUsers();
                        GridUser.Rows.Clear();
                        for (int i=0; i < users.Count; i++)
                        {
                            string role = "";
                            if (users[i].role == "0")
                            {
                                role = "Диспетчер";
                            }
                            else
                            {
                                role = "Администратор";
                            }
                            GridUser.Rows.Add(users[i].name, role);
                        }
                    }
                    #endregion
                    break;
                case 10: //отчеты
                    #region TabOtchet
                    if (user.role == "0")
                    {
                        TabControl.SelectedIndex = SelectTabIndex;
                        MetroMessageBox.Show(this, "Недостаточно прав.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        if (GridOtchetParks.Rows.Count == 0)
                        {
                            GridOtchetParks.Rows.Clear();
                            park =  Park.GetCars("1");
                            DateTimeOtchetParkS.Value = DateTime.Today.AddDays(-30);
                            DateTimeOtchetParkPO.Value = DateTime.Today;
                            ProgressBarOtchetPark.Visible = true;
                            LabelOtchetPark.Visible = true;
                            ProgressBarOtchetPark.Minimum = 0;
                            ProgressBarOtchetPark.Maximum = park.Count;
                            ProgressBarOtchetPark.Value = 0;
                            new Thread(new ThreadStart(delegate
                            {
                                for (int i = 0; i < park.Count; i++)
                                {
                                    if (park[i].id != 0)
                                    {
                                        CountOrderForOtcehtCars = 0;
                                        SummaruCoutForOtchetCars = 0;
                                        trips = Trips.GetTripsForOtchetPark(park[i].id.ToString(), DateTimeOtchetParkS.Value.ToString("yyyy-MM-dd"), DateTime.Today.ToString("yyyy-MM-dd"));
                                        for (int j = 0; j < trips.Count; j++)
                                        {
                                            orders = Orders.GetOrders(trips[j].id.ToString());
                                            CountOrderForOtcehtCars += orders.Count;
                                            for (int k = 0; k < orders.Count; k++)
                                            {
                                                SummaruCoutForOtchetCars += Convert.ToInt32(orders[k].cost);
                                            }
                                        }
                                        if (trips.Count == 0)
                                        {
                                            SrCoutOnTripForOtchetpark =  0;
                                        }
                                        else
                                        {
                                            SrCoutOnTripForOtchetpark =  SummaruCoutForOtchetCars / trips.Count;
                                        }
                                        if (CountOrderForOtcehtCars == 0)
                                        {
                                            SrCoutOnOrderForOtchetpark =  0;
                                        }
                                        else
                                        {
                                            SrCoutOnOrderForOtchetpark =  SummaruCoutForOtchetCars / CountOrderForOtcehtCars;
                                        }
                                        GridOtchetParks.Invoke(new Action(() => { GridOtchetParks.Rows.Add(park[i].voditel, trips.Count, CountOrderForOtcehtCars, SummaruCoutForOtchetCars, SrCoutOnTripForOtchetpark, SrCoutOnOrderForOtchetpark); }));
                                    }
                                    ProgressBarOtchetPark.Invoke(new Action(() => { ProgressBarOtchetPark.Value++; }));
                                }
                                ProgressBarOtchetPark.Invoke(new Action(() => { ProgressBarOtchetPark.Visible = false; }));
                                LabelOtchetPark.Invoke(new Action(() => { LabelOtchetPark.Visible = false; }));
                            })).Start();
                        }
                    }
                    #endregion
                    break;
                case 11: //Управление Смс
                    UpdateSmsBalance();
                    break;
                case 12: //Управление нвостями на сайте
                    UpdateTableNews();
                    break;
            }
        }

        #region TabOrder Methods
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && e.Control)
            {
                switch (SelectTabIndex)
                {
                    case 0:

                        break;
                }
            }
        }

        private void ButtonSelectLast_Click(object sender, EventArgs e)
        {
            orders = Orders.GetLastOrder();
            DataGridOrders.Rows.Clear();
            for (int i = 0; i < orders.Count; i++)
            {
                string MestoFromDataGrid;
                if (orders[i].mesto == "13")
                    MestoFromDataGrid = "14";
                else
                    MestoFromDataGrid = orders[i].mesto;
                string status = functions.CheckStatus(orders[i].status);
                DataGridOrders.Rows.Add((i + 1).ToString(), orders[i].type_bilet, orders[i].fio, orders[i].phone, orders[i].data.ToShortDateString(), orders[i].name_marsh, orders[i].otkyda, orders[i].kyda, MestoFromDataGrid, orders[i].voditel, orders[i].gos_nomer, orders[i].cost, orders[i].cost_bron, status);
            }
        }

        private void ButtonGetOrders_Click(object sender, EventArgs e)
        {
            orders = Orders.GetOrders(ChekDay.ToString("yyyy-MM-dd"), SelectMarshId.ToString());
            DataGridOrders.Rows.Clear();
            // DataGridOrders.DataSource = orders;    //Оставлю как памятка о возможности
            if (orders.Count > 0)
            {
                for (int i = 0; i < orders.Count; i++)
                {
                    string MestoFromDataGrid;
                    if (orders[i].mesto == "13")
                        MestoFromDataGrid = "14";
                    else
                        MestoFromDataGrid = orders[i].mesto;
                    string status = functions.CheckStatus(orders[i].status);
                    DataGridOrders.Rows.Add((i + 1).ToString(), orders[i].type_bilet, orders[i].fio, orders[i].phone, orders[i].data.ToShortDateString(), orders[i].name_marsh, orders[i].otkyda, orders[i].kyda, MestoFromDataGrid, orders[i].voditel, orders[i].gos_nomer, orders[i].cost, orders[i].cost_bron, status);
                }
            }
            else
            {
                MetroMessageBox.Show(this, "На этот день нет заказов.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {
            ChekDay = metroDateTime1.Value;
        }

        private void ButtonNewOrder_Click(object sender, EventArgs e)
        {
            var NewOrder = new NewOrderForm();
            NewOrder.ShowDialog();
            DataGridOrders.Rows.Clear();
            // DataGridOrders.DataSource = orders;    //Оставлю как памятка о возможности
            if (orders.Count > 0)
            {
                for (int i = 0; i < orders.Count; i++)
                {
                    string status = functions.CheckStatus(orders[i].status);
                    DataGridOrders.Rows.Add((i + 1).ToString(), orders[i].type_bilet, orders[i].fio, orders[i].phone, orders[i].data.ToShortDateString(), orders[i].name_marsh, orders[i].otkyda, orders[i].kyda, orders[i].mesto, orders[i].voditel, orders[i].gos_nomer, orders[i].cost, orders[i].cost_bron, status);
                }
            }
        }

        private void DataGridOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Orders.CheckEditOrder(orders[e.RowIndex].id.ToString()))
            {
                var ChangeOrder = new ChangeOrderForm(orders[e.RowIndex].id, metroDateTime1.Value);
                ChangeOrder.ShowDialog();
                orders = Orders.GetOrders(ChekDay.ToString("yyyy-MM-dd"), SelectMarshId.ToString());
                DataGridOrders.Rows.Clear();
                // DataGridOrders.DataSource = orders;    //Оставлю как памятка о возможности
                if (orders.Count > 0)
                {
                    for (int i = 0; i < orders.Count; i++)
                    {
                        string status = functions.CheckStatus(orders[i].status);
                        DataGridOrders.Rows.Add((i + 1).ToString(), orders[i].type_bilet, orders[i].fio, orders[i].phone, orders[i].data.ToShortDateString(), orders[i].name_marsh, orders[i].otkyda, orders[i].kyda, orders[i].mesto, orders[i].voditel, orders[i].gos_nomer, orders[i].cost, orders[i].cost_bron, status);
                    }
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Отмененные заказы нельзя редактировать.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void ComboBoxMarshrut_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < marshruts.Count; i++)
            {
                if (marshruts[i].name == ComboBoxMarshrut.SelectedItem.ToString())
                {
                    SelectMarshId = marshruts[i].id;
                    break;
                }
            }
        }

        #endregion

        #region TabStock Methods
        private void ComboBoAkciaName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (user.role == "0")
            {
                TabControl.SelectedIndex = SelectTabIndex;
                MetroMessageBox.Show(this, "Недостаточно прав.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                DateTimeAkciaNach.Value = stocks[ComboBoAkciaName.SelectedIndex].data_nach;
                DateTimeAkciaKonec.Value = stocks[ComboBoAkciaName.SelectedIndex].data_konec;
                TextBoxAkciaCout.Text = stocks[ComboBoAkciaName.SelectedIndex].cost.ToString();
            }
        }

        private void ButtonAkciaRemove_Click(object sender, EventArgs e)
        {
            if (ComboBoAkciaName.SelectedIndex != -1)
            {
                var result = stocks[ComboBoAkciaName.SelectedIndex].Delete();
                if (result == "")
                {
                    GridAkcia.Rows.Clear();
                    ComboBoAkciaName.Items.Clear();
                    stocks = Stocks.GetStock();
                    for (int i = 0; i < stocks.Count; i++)
                    {
                        ComboBoAkciaName.Items.Add(stocks[i].name);
                        GridAkcia.Rows.Add(stocks[i].name, stocks[i].data_nach.ToShortDateString(), stocks[i].data_konec.ToShortDateString(), stocks[i].cost);
                    }
                    MetroMessageBox.Show(this, "Акция удалена.", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MetroMessageBox.Show(this, result + ". Обратитесь к системуному администратору.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void CheckBoxNewAkcia_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxNewAkcia.Checked)
            {
                TextBoxNewNameAkcia.Enabled = true;
                ComboBoAkciaName.Enabled = false;
                ButtonAkciaChange.Text = "Добавить";
            }
            else
            {
                TextBoxNewNameAkcia.Enabled = false;
                ComboBoAkciaName.Enabled = true;
                ButtonAkciaChange.Text = "Изменить";
            }
        }
        
        private void metroButton1_Click(object sender, EventArgs e) //добавление новой или изменение старой
        {
            if (user.role == "0")
            {
                TabControl.SelectedIndex = SelectTabIndex;
                MetroMessageBox.Show(this, "Недостаточно прав.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                if (CheckBoxNewAkcia.Checked)
                {
                    var result = new Stock
                    {
                        name = TextBoxNewNameAkcia.Text,
                        data_nach = DateTimeAkciaNach.Value,
                        data_konec = DateTimeAkciaKonec.Value,
                        cost = Convert.ToInt32(TextBoxAkciaCout.Text)
                    }.Create();
                    if (result == "")
                    {
                        MetroMessageBox.Show(this, "Новая акция добавлена.", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        GridAkcia.Rows.Clear();
                        ComboBoAkciaName.Items.Clear();
                        stocks = Stocks.GetStock();
                        for (int i = 0; i < stocks.Count; i++)
                        {
                            ComboBoAkciaName.Items.Add(stocks[i].name);
                            GridAkcia.Rows.Add(stocks[i].name, stocks[i].data_nach.ToShortDateString(), stocks[i].data_konec.ToShortDateString(), stocks[i].cost);
                        }
                        CheckBoxNewAkcia.Checked = false;
                        TextBoxNewNameAkcia.Enabled = false;
                        TextBoxNewNameAkcia.Text = "";
                        ComboBoAkciaName.Enabled = true;
                        ButtonAkciaChange.Text = "Изменить";
                        TextBoxAkciaCout.Text = "";
                    }
                    else
                    {
                        MetroMessageBox.Show(this, result + ". Обратитесь к системуному администратору.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
                else
                {
                    var result = new Stock
                    {
                        id = stocks[ComboBoAkciaName.SelectedIndex].id,
                        name = ComboBoAkciaName.Text,
                        data_nach = DateTimeAkciaNach.Value,
                        data_konec = DateTimeAkciaKonec.Value,
                        cost = Convert.ToInt32(TextBoxAkciaCout.Text)
                    }.Set();
                    if (result == "")
                    {
                        MetroMessageBox.Show(this, "Изменения сохранены.", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        GridAkcia.Rows.Clear();
                        ComboBoAkciaName.Items.Clear();
                        stocks = Stocks.GetStock();
                        for (int i = 0; i < stocks.Count; i++)
                        {
                            ComboBoAkciaName.Items.Add(stocks[i].name);
                            GridAkcia.Rows.Add(stocks[i].name, stocks[i].data_nach.ToShortDateString(), stocks[i].data_konec.ToShortDateString(), stocks[i].cost);
                        }
                    }
                    else
                    {
                        MetroMessageBox.Show(this, result + ". Обратитесь к системуному администратору.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
            }
        }

        #endregion

        #region TabNastrioki Methods
        private void GridUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var NewUserForm = new NewUserForm(users[e.RowIndex]);
            NewUserForm.ShowDialog();
            GridUser.Rows.Clear();
            users = Users.GetUsers();
            for (int i = 0; i < users.Count; i++)
            {
                string role = "";
                if (users[i].role == "0")
                {
                    role = "Диспетчер";
                }
                else
                {
                    role = "Администратор";
                }
                GridUser.Rows.Add(users[i].name, role);
            }
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (user.id != users[GridUser.CurrentCell.RowIndex].id)
            {
                var result = users[GridUser.CurrentCell.RowIndex].Delete();
                if (result == "")
                {
                    users = Users.GetUsers();
                    GridUser.Rows.Clear();
                    for (int i = 0; i < users.Count; i++)
                    {
                        string role = "";
                        if (users[i].role == "0")
                        {
                            role = "Диспетчер";
                        }
                        else
                        {
                            role = "Администратор";
                        }
                        GridUser.Rows.Add(users[i].name, role);
                    }
                } 
                else
                {
                    MetroMessageBox.Show(this, "При удалении пользователя произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            } 
            else
            {
                MetroMessageBox.Show(this, "Нельзя удалить активного пользователя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        
        private void ButtonUserAdd_Click(object sender, EventArgs e)
        {
            var NewUserForm = new NewUserForm(null);
            NewUserForm.ShowDialog();
            users = Users.GetUsers();
            GridUser.Rows.Clear();
            for (int i = 0; i < users.Count; i++)
            {
                string role = "";
                if (users[i].role == "0")
                {
                    role = "Диспетчер";
                }
                else
                {
                    role = "Администратор";
                }
                GridUser.Rows.Add(users[i].name, role);
            }
        }

        private void ButtonChangePassword_Click(object sender, EventArgs e)
        {
            var ChangePass = new NewPassword(users[GridUser.CurrentCell.RowIndex]);
            ChangePass.ShowDialog();
        }

        #endregion

        #region TabTrips Methods

        private void ButtonTripSelect_Click(object sender, EventArgs e)
        {
            trips = Trips.GetTripsOnDate(DateTimeTrip.Value.ToString("yyyy-MM-dd"), marshruts[ComboBoxTripsMarsh.SelectedIndex].PromPynkt[0].id.ToString(), marshruts[ComboBoxTripsMarsh.SelectedIndex].PromPynkt[marshruts[ComboBoxTripsMarsh.SelectedIndex].PromPynkt.Count - 1].id.ToString(), marshruts[ComboBoxTripsMarsh.SelectedIndex].id.ToString());
            GridTrip.Rows.Clear();
            for (int i = 0; i < trips.Count; i++)
            {
                GridTrip.Rows.Add("Микроавтобус №" + (i + 1).ToString(), trips[i].gos_nomer, trips[i].voditel);
            }
        }

        private void ButtonTripAdd_Click(object sender, EventArgs e)
        {
            if (GridTrip.Rows.Count < 3)
            {
                var NewTripForm = new AddNewTripForm();
                NewTripForm.ShowDialog();
                trips = Trips.GetTripsOnDate(DateTimeTrip.Value.ToString("yyyy-MM-dd"), marshruts[ComboBoxTripsMarsh.SelectedIndex].PromPynkt[0].id.ToString(), marshruts[ComboBoxTripsMarsh.SelectedIndex].PromPynkt[marshruts[ComboBoxTripsMarsh.SelectedIndex].PromPynkt.Count - 1].id.ToString(), marshruts[ComboBoxTripsMarsh.SelectedIndex].id.ToString());
                GridTrip.Rows.Clear();
                for (int i = 0; i < trips.Count; i++)
                {
                    GridTrip.Rows.Add("Микроавтобус №" + (i + 1).ToString(), trips[i].gos_nomer, trips[i].voditel);
                }
            }
            else
            {
                if (user.role == "1")
                {
                    var NewTripForm = new AddNewTripForm();
                    NewTripForm.ShowDialog();
                    trips = Trips.GetTripsOnDate(DateTimeTrip.Value.ToString("yyyy-MM-dd"), marshruts[ComboBoxTripsMarsh.SelectedIndex].PromPynkt[0].id.ToString(), marshruts[ComboBoxTripsMarsh.SelectedIndex].PromPynkt[marshruts[ComboBoxTripsMarsh.SelectedIndex].PromPynkt.Count - 1].id.ToString(), marshruts[ComboBoxTripsMarsh.SelectedIndex].id.ToString());
                    GridTrip.Rows.Clear();
                    for (int i = 0; i < trips.Count; i++)
                    {
                        GridTrip.Rows.Add("Микроавтобус №" + (i + 1).ToString(), trips[i].gos_nomer, trips[i].voditel);
                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "Для добавления 4 поездки недостаточно прав. Обратитесь к администратору.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void GridTrip_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var SetCarForm = new SetCarInTripForm(marshruts[ComboBoxTripsMarsh.SelectedIndex], "Микроавтобус №" + (e.RowIndex + 1).ToString(), trips[e.RowIndex].id_car, trips[e.RowIndex].id);
            SetCarForm.ShowDialog();
            trips = Trips.GetTripsOnDate(DateTimeTrip.Value.ToString("yyyy-MM-dd"), marshruts[ComboBoxTripsMarsh.SelectedIndex].PromPynkt[0].id.ToString(), marshruts[ComboBoxTripsMarsh.SelectedIndex].PromPynkt[marshruts[ComboBoxTripsMarsh.SelectedIndex].PromPynkt.Count - 1].id.ToString(), marshruts[ComboBoxTripsMarsh.SelectedIndex].id.ToString());
            GridTrip.Rows.Clear();
            for (int i = 0; i < trips.Count; i++)
            {
                GridTrip.Rows.Add("Микроавтобус №" + (i + 1).ToString(), trips[i].gos_nomer, trips[i].voditel);
            }
        }

        private void ComboBoxTripsMarsh_SelectedIndexChanged(object sender, EventArgs e)
        {
            marshruts[ComboBoxTripsMarsh.SelectedIndex].GetPromPynkt();
            ComboBoxFrom.Items.Clear();
            ComboBoxTo.Items.Clear();
            int j = marshruts[ComboBoxTripsMarsh.SelectedIndex].PromPynkt.Count - 1;
            for (int i = 0; i < marshruts[ComboBoxTripsMarsh.SelectedIndex].PromPynkt.Count; i++)
            {
                ComboBoxFrom.Items.Add(marshruts[ComboBoxTripsMarsh.SelectedIndex].PromPynkt[i].name);
                ComboBoxTo.Items.Add(marshruts[ComboBoxTripsMarsh.SelectedIndex].PromPynkt[j].name);
                j--;
            }
        }

        private void ButtonDelTrip_Click(object sender, EventArgs e)
        {
            if (GridTrip.CurrentRow == null) return;
            if (GridTrip.CurrentRow.Index == -1) return;
            trips[GridTrip.CurrentRow.Index].Delete();
            ButtonTripSelect_Click(null, null);
        }
        #endregion

        #region TabClient Methods
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (TextBoxPhone.Text != "")
            {
                clients = Clients.SearchClients(TextBoxPhone.Text);
                if (clients.Count == 0)
                {
                    MetroMessageBox.Show(this, "Такого пользователя нет в базе.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    TextBoxPhone.Text = "";
                }
                else
                {
                    GridClient.Rows.Clear();
                    for (int i = 0; i < clients.Count; i++)
                    {
                        GridClient.Rows.Add(clients[i].fio, clients[i].phone, clients[i].count, clients[i].cost);
                    }
                    TextBoxPhone.Text = "";
                }
            }
        }
        private void ButtonGetAll_Click(object sender, EventArgs e)
        {
            GridClient.Rows.Clear();
            ProgressBarClient.Visible = true;
            LabelProgressbarClient.Visible = true;
            clients = Clients.GetAllClient();
            ProgressBarClient.Minimum = 0;
            ProgressBarClient.Maximum = clients.Count;
            ProgressBarClient.Value = 0;
            new Thread(new ThreadStart(delegate
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    GridClient.Invoke(new Action(() => { GridClient.Rows.Add(clients[i].fio, clients[i].phone, clients[i].count, clients[i].cost); }));
                    ProgressBarClient.Invoke(new Action(() => { ProgressBarClient.Value++; }));
                }
                ProgressBarClient.Invoke(new Action(() => { ProgressBarClient.Visible = false; }));
                LabelProgressbarClient.Invoke(new Action(() => { LabelProgressbarClient.Visible = false; }));
            })).Start();
        }
        private void GridClient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var ClientInfo = new ClientInfoForm(clients[e.RowIndex].id);
                ClientInfo.Show();
            }
        }
        #endregion

        #region TabPark Methods
        private void ButtonSelectCar_Click(object sender, EventArgs e)
        {
            GridPark.Rows.Clear();
            switch (ComboBoxSelectCars.SelectedIndex)
            {   
                case 0:
                    park =  Park.GetCars("0");
                    break;
                case 1:
                    park =  Park.GetCars("1");
                    break;
                case 2:
                    park =  Park.GetCars("2");
                    break;
            }
            for (int i = 0; i < park.Count; i++)
            {
                GridPark.Rows.Add(park[i].marka, park[i].gos_nomer, park[i].voditel, park[i].count_poezd, park[i].teh_obslyzh, park[i].arenda_nach.ToShortDateString(), park[i].arenda_konec.ToShortDateString(), park[i].status == "0" ? "Работает" : "Уволен");
            }
        }
        private void ButtonChangeTeh_Click(object sender, EventArgs e)
        {
            if (GridPark.CurrentCell.RowIndex != 0)
            {
                bool Value = Convert.ToBoolean(GridPark.Rows[GridPark.CurrentCell.RowIndex].Cells[4].Value);
                if (Value == true) {
                    var result = Park.ChangeTehObsluzh(park[GridPark.CurrentCell.RowIndex].id.ToString(), "0");
                    if (result != "")
                    {
                        MetroMessageBox.Show(this, "При изменении информации о техническом обслуживании произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
                else
                {
                    var result = Park.ChangeTehObsluzh(park[GridPark.CurrentCell.RowIndex].id.ToString(), "1");
                    if (result != "")
                    {
                        MetroMessageBox.Show(this, "При изменении информации о техническом обслуживании произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
                GridPark.Rows.Clear();
                park =  Park.GetCars("0");
                for (int i = 0; i < park.Count; i++)
                {
                    GridPark.Rows.Add(park[i].marka, park[i].gos_nomer, park[i].voditel, park[i].count_poezd, park[i].teh_obslyzh, park[i].arenda_nach.ToShortDateString(), park[i].arenda_konec.ToShortDateString(), park[i].status == "0" ? "Работает" : "Уволен");
                }
            } 
            else
            {
                MetroMessageBox.Show(this, "Эта запись не редактируется.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
}
        private void ButtonChangeLease_Click(object sender, EventArgs e)
        {
            var ChangeLeaseform = new ChangeLaeseForm(park[GridPark.CurrentCell.RowIndex]);
            ChangeLeaseform.ShowDialog();
            GridPark.Rows.Clear();
            park =  Park.GetCars("0");
            for (int i = 0; i < park.Count; i++)
            {
                GridPark.Rows.Add(park[i].marka, park[i].gos_nomer, park[i].voditel, park[i].count_poezd, park[i].teh_obslyzh, park[i].arenda_nach.ToShortDateString(), park[i].arenda_konec.ToShortDateString(), park[i].status == "0" ? "Работает" : "Уволен");
            }
        }
        private void ButtonCreateCar_Click(object sender, EventArgs e)
        {
            var CreateNewCarForm = new CreateNewCarForm();
            CreateNewCarForm.ShowDialog();
            GridPark.Rows.Clear();
            park =  Park.GetCars("0");
            for (int i = 0; i < park.Count; i++)
            {
                GridPark.Rows.Add(park[i].marka, park[i].gos_nomer, park[i].voditel, park[i].count_poezd, park[i].teh_obslyzh, park[i].arenda_nach.ToShortDateString(), park[i].arenda_konec.ToShortDateString(), park[i].status == "0" ? "Работает" : "Уволен");
            }
        }
        private void ButtonRemoveCar_Click(object sender, EventArgs e)
        {
            if (GridPark.CurrentCell.RowIndex != 0)
            {
                var result = park[GridPark.CurrentCell.RowIndex].Delete();
                if (result != "")
                {
                    MetroMessageBox.Show(this, "При увольнении машины произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    GridPark.Rows.Clear();
                    park = Park.GetCars("0");
                    for (int i = 0; i < park.Count; i++)
                    {
                        GridPark.Rows.Add(park[i].marka, park[i].gos_nomer, park[i].voditel, park[i].count_poezd, park[i].teh_obslyzh, park[i].arenda_nach.ToShortDateString(), park[i].arenda_konec.ToShortDateString(), park[i].status == "0" ? "Работает" : "Уволен");
                    }
                }
            } 
            else
            {
                MetroMessageBox.Show(this, "Эта запись не редактируется.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void ButtonSetCar_Click(object sender, EventArgs e)
        {
            if (GridPark.CurrentCell.RowIndex != 0)
            {
                var SetInfo = new SetInformationInCarForm(park[GridPark.CurrentCell.RowIndex]);
                SetInfo.ShowDialog();
                GridPark.Rows.Clear();
                park = Park.GetCars("0");
                for (int i = 0; i < park.Count; i++)
                {
                    GridPark.Rows.Add(park[i].marka, park[i].gos_nomer, park[i].voditel, park[i].count_poezd, park[i].teh_obslyzh, park[i].arenda_nach.ToShortDateString(), park[i].arenda_konec.ToShortDateString(), park[i].status == "0" ? "Работает" : "Уволен");
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Эта запись не редактируется.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        #endregion

        #region TabPrice Methods
        private void ButtonCreateNewPrice_Click(object sender, EventArgs e)
        {
            var CreateNewPriceForm = new CreateNewPriceForm();
            CreateNewPriceForm.ShowDialog();
            GridPrice.Rows.Clear();
            prices = Prices.GetPriceForMarsID(marshruts[ComboBoxPriceMarsh.SelectedIndex].id.ToString());
            for (int i = 0; i < prices.Count; i++)
            {
                GridPrice.Rows.Add(prices[i].Otkyda, prices[i].Kyda, prices[i].cost);
            }
        }
        private void ButtonPriceSetCout_Click(object sender, EventArgs e)
        {
            var SetCoutInPriceForm = new SetCoutInPriceForm(prices[GridPrice.CurrentCell.RowIndex].id.ToString());
            SetCoutInPriceForm.ShowDialog();
            GridPrice.Rows.Clear();
            prices = Prices.GetPriceForMarsID(marshruts[ComboBoxPriceMarsh.SelectedIndex].id.ToString());
            for (int i = 0; i < prices.Count; i++)
            {
                GridPrice.Rows.Add(prices[i].Otkyda, prices[i].Kyda, prices[i].cost);
            }
        }
        private void ComboBoxPriceMarsh_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridPrice.Rows.Clear();
            BrowserPrice.ScriptErrorsSuppressed = true;
            BrowserPrice.Navigate("http://orion38.pro/maps/maps.php?url_map=" + marshruts[ComboBoxPriceMarsh.SelectedIndex].url_map);
            prices = Prices.GetPriceForMarsID(marshruts[ComboBoxPriceMarsh.SelectedIndex].id.ToString());
            for (int i = 0; i < prices.Count; i++)
            {
                GridPrice.Rows.Add(prices[i].Otkyda, prices[i].Kyda, prices[i].cost);
            }
        }
        private void ButtonDeletePrice_Click(object sender, EventArgs e)
        {
            var result = prices[GridPrice.CurrentCell.RowIndex].Delete();
            if (result != "")
            {
                MetroMessageBox.Show(this, "При удалении стоимости произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                Close();
            }
            else
            {
                GridPrice.Rows.Clear();
                prices = Prices.GetPriceForMarsID(marshruts[ComboBoxPriceMarsh.SelectedIndex].id.ToString());
                for (int i = 0; i < prices.Count; i++)
                {
                    GridPrice.Rows.Add(prices[i].Otkyda, prices[i].Kyda, prices[i].cost);
                }
            }
        }       
        #endregion

        #region TabMarsh Methods
        private void ButtonMarshrutSelect_Click(object sender, EventArgs e)
        {
            BrowserMarshrutMap.ScriptErrorsSuppressed = true;
            BrowserMarshrutMap.Navigate("http://orion38.pro/maps/maps.php?url_map=" + marshruts[ComboBoxMarshrutMarshrut.SelectedIndex].url_map);
            DataGridTabMarshrutsPromPunkt.Rows.Clear();
            marshruts[ComboBoxMarshrutMarshrut.SelectedIndex].GetPromPynkt();
            for (int i = 0; i < marshruts[ComboBoxMarshrutMarshrut.SelectedIndex].PromPynkt.Count; i++)
            {
                DataGridTabMarshrutsPromPunkt.Rows.Add(marshruts[ComboBoxMarshrutMarshrut.SelectedIndex].PromPynkt[i].name);
            }
        }
        private void ButtonDeletMarshrut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MetroMessageBox.Show(this, "Отправить маршрут \"" + marshruts[ComboBoxMarshrutMarshrut.SelectedIndex].name + "\" в архив?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK)
            {
                var result = marshruts[ComboBoxMarshrutMarshrut.SelectedIndex].ToArchive();
                if (result != "")
                {
                    MetroMessageBox.Show(this, "При удалении маршрута произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                { 
                    marshruts = Routs.GetMarshruts();
                    ComboBoxMarshrutMarshrut.Items.Clear();
                    for (int i = 0; i < marshruts.Count; i++)
                    {
                        ComboBoxMarshrutMarshrut.Items.Add(marshruts[i].name);
                    }
                    BrowserMarshrutMap.ScriptErrorsSuppressed = true;
                    ComboBoxMarshrutMarshrut.SelectedIndex = 0;
                    BrowserMarshrutMap.Navigate("http://orion38.pro/maps/maps.php?url_map=" + marshruts[ComboBoxMarshrutMarshrut.SelectedIndex].url_map);
                }
            }
        }
        private void ButtonAddMarshrut_Click(object sender, EventArgs e)
        {
            var AddMarshrutForm = new AddMarshrut(null);
            AddMarshrutForm.ShowDialog();
            marshruts = Routs.GetMarshruts();
            ComboBoxMarshrutMarshrut.Items.Clear();
            for (int i = 0; i < marshruts.Count; i++)
            {
                ComboBoxMarshrutMarshrut.Items.Add(marshruts[i].name);
            }
            BrowserMarshrutMap.ScriptErrorsSuppressed = true;
            ComboBoxMarshrutMarshrut.SelectedIndex = 0;
            BrowserMarshrutMap.Navigate("http://orion38.pro/maps/maps.php?url_map=" + marshruts[ComboBoxMarshrutMarshrut.SelectedIndex].url_map);
        }
        private void ButtonSetMarshrut_Click(object sender, EventArgs e)
        {
            var AddMarshrutForm = new AddMarshrut(marshruts[ComboBoxMarshrutMarshrut.SelectedIndex]);
            AddMarshrutForm.ShowDialog();
            marshruts = Routs.GetMarshruts();
            ComboBoxMarshrutMarshrut.Items.Clear();
            for (int i = 0; i < marshruts.Count; i++)
            {
                ComboBoxMarshrutMarshrut.Items.Add(marshruts[i].name);
            }
            BrowserMarshrutMap.ScriptErrorsSuppressed = true;
            ComboBoxMarshrutMarshrut.SelectedIndex = 0;
            BrowserMarshrutMap.Navigate("http://orion38.pro/maps/maps.php?url_map=" + marshruts[ComboBoxMarshrutMarshrut.SelectedIndex].url_map);
        }
        private void ButtonOpenCatalogPP_Click(object sender, EventArgs e)
        {
            var CatalogPPForm = new PromPynktCatalogForm();
            CatalogPPForm.ShowDialog();
            DataGridTabMarshrutsPromPunkt.Rows.Clear();
            marshruts[ComboBoxMarshrutMarshrut.SelectedIndex].GetPromPynkt();
            for (int i = 0; i < marshruts[ComboBoxMarshrutMarshrut.SelectedIndex].PromPynkt.Count; i++)
            {
                DataGridTabMarshrutsPromPunkt.Rows.Add(marshruts[ComboBoxMarshrutMarshrut.SelectedIndex].PromPynkt[i].name);
            }
            BrowserMarshrutMap.ScriptErrorsSuppressed = true;
            ComboBoxMarshrutMarshrut.SelectedIndex = 0;
            BrowserMarshrutMap.Navigate("http://orion38.pro/maps/maps.php?url_map=" + marshruts[ComboBoxMarshrutMarshrut.SelectedIndex].url_map);
        }
        private void ButtonArchive_Click(object sender, EventArgs e)
        {
            var Archive = new MarshrutArchive();
            Archive.ShowDialog();
            marshruts = Routs.GetMarshruts();
            ComboBoxMarshrutMarshrut.Items.Clear();
            for (int i = 0; i < marshruts.Count; i++)
            {
                ComboBoxMarshrutMarshrut.Items.Add(marshruts[i].name);
            }
            BrowserMarshrutMap.ScriptErrorsSuppressed = true;
            ComboBoxMarshrutMarshrut.SelectedIndex = 0;
            BrowserMarshrutMap.Navigate("http://orion38.pro/maps/maps.php?url_map=" + marshruts[ComboBoxMarshrutMarshrut.SelectedIndex].url_map);
        }
        #endregion

        #region TabTypeBilet Methods
        private void ButtonAddNewTypeBilet_Click(object sender, EventArgs e)
        {
            LabelAddTypeBilet.Visible = true;
            TextBoxAddTypeBilet.Visible = true;
            LabelFixed.Visible = true;
            ToggleFixedCost.Visible = true;
            LabelCost.Visible = true;
            TextBoxCost.Visible = true;
            ButtonCreateTypeBilet.Visible = true;
            ButtonCreateTypeBilet.Text = "Добавить";
            TextBoxAddTypeBilet.Text = "";
            TextBoxCost.Text = "";
        }
        private void GridTypeBilet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LabelAddTypeBilet.Visible = true;
            TextBoxAddTypeBilet.Visible = true;
            LabelFixed.Visible = true;
            ToggleFixedCost.Visible = true;
            LabelCost.Visible = true;
            TextBoxCost.Visible = true;
            ButtonCreateTypeBilet.Visible = true;
            ButtonCreateTypeBilet.Text = "Изменить";
            TextBoxAddTypeBilet.Text = bilets[e.RowIndex].name;
            TextBoxCost.Text = bilets[e.RowIndex].cost.ToString();
            ToggleFixedCost.Checked = Convert.ToBoolean(bilets[e.RowIndex].fix);
            PositionForSetBilet = e.RowIndex;
        }
        private void ButtonDeleteTypeBilet_Click(object sender, EventArgs e)
        {
            var result = bilets[GridTypeBilet.CurrentCell.RowIndex].Delete();
            if (result != "")
            {
                MetroMessageBox.Show(this, "При удалении типа билета произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                GridTypeBilet.Rows.Clear();
                bilets = TypeBilets.GetTypeBilets();
                for (int i = 0; i < bilets.Count; i++)
                {
                    GridTypeBilet.Rows.Add(bilets[i].name, Convert.ToBoolean(bilets[i].fix), bilets[i].cost);
                }
            }
        }
        
        private void ButtonCreateTypeBilet_Click(object sender, EventArgs e)
        {
            if (ButtonCreateTypeBilet.Text == "Добавить")
            {
                var cost = TextBoxCost.Text.Split('.');
                if (cost.Count() > 1)
                {
                    TextBoxCost.Text = cost[0] + "," + cost[1];
                }
                var result = new TypeBilet { name = TextBoxAddTypeBilet.Text,
                    fix = Convert.ToInt32(ToggleFixedCost.Checked),
                    cost = Convert.ToDouble(TextBoxCost.Text)
                }.Create();
                if (result != "")
                {
                    MetroMessageBox.Show(this, "При добавлении нового типа билета произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    LabelAddTypeBilet.Visible = false;
                    TextBoxAddTypeBilet.Visible = false;
                    LabelFixed.Visible = false;
                    ToggleFixedCost.Visible = false;
                    LabelCost.Visible = false;
                    TextBoxCost.Visible = false;
                    ButtonCreateTypeBilet.Visible = false;
                    GridTypeBilet.Rows.Clear();
                    bilets = TypeBilets.GetTypeBilets();
                    for (int i = 0; i < bilets.Count; i++)
                    {
                        GridTypeBilet.Rows.Add(bilets[i].name, Convert.ToBoolean(bilets[i].fix), bilets[i].cost);
                    }
                }
            } 
            else
            {
                var cost = TextBoxCost.Text.Split('.');
                if (cost.Count() > 1)
                {
                    TextBoxCost.Text = cost[0] + "," + cost[1];
                }
                var result = new TypeBilet {
                    id = bilets[PositionForSetBilet].id,
                    name = TextBoxAddTypeBilet.Text,
                    fix = Convert.ToInt32(ToggleFixedCost.Checked),
                    cost = Convert.ToDouble(TextBoxCost.Text)
                }.Set();
                if (result != "")
                {
                    MetroMessageBox.Show(this, "При редактировании типа билета произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    LabelAddTypeBilet.Visible = false;
                    TextBoxAddTypeBilet.Visible = false;
                    LabelFixed.Visible = false;
                    ToggleFixedCost.Visible = false;
                    LabelCost.Visible = false;
                    TextBoxCost.Visible = false;
                    ButtonCreateTypeBilet.Visible = false;
                    GridTypeBilet.Rows.Clear();
                    bilets = TypeBilets.GetTypeBilets();
                    for (int i = 0; i < bilets.Count; i++)
                    {
                        GridTypeBilet.Rows.Add(bilets[i].name, Convert.ToBoolean(bilets[i].fix), bilets[i].cost);
                    }
                }
            }
        }
        #endregion

        #region TabOthcet Methods
        private void TabControlOtchets_SelectedIndexChanged(object sender, EventArgs e)
            {
                switch ((sender as TabControl).SelectedIndex)
                {
                    case 0: //отчет по каждой машине
                    #region TabPark
                        if (GridOtchetParks.Rows.Count == 0)
                        {
                            GridOtchetParks.Rows.Clear();
                            park =  Park.GetCars("1");
                            DateTimeOtchetParkS.Value = DateTime.Today.AddDays(-30);
                            DateTimeOtchetParkPO.Value = DateTime.Today;
                            ProgressBarOtchetPark.Visible = true;
                            LabelOtchetPark.Visible = true;
                            ProgressBarOtchetPark.Minimum = 0;
                            ProgressBarOtchetPark.Maximum = park.Count;
                            ProgressBarOtchetPark.Value = 0;
                            new Thread(new ThreadStart(delegate
                            {
                                for (int i = 0; i < park.Count; i++)
                                {
                                    if (park[i].id != 0)
                                    {
                                        CountOrderForOtcehtCars = 0;
                                        SummaruCoutForOtchetCars = 0;
                                        trips = Trips.GetTripsForOtchetPark(park[i].id.ToString(), DateTimeOtchetParkS.Value.ToString("yyyy-MM-dd"), DateTime.Today.ToString("yyyy-MM-dd"));
                                        for (int j = 0; j < trips.Count; j++)
                                        {
                                            orders = Orders.GetOrders(trips[j].id.ToString());
                                            CountOrderForOtcehtCars += orders.Count;
                                            for (int k = 0; k < orders.Count; k++)
                                            {
                                                SummaruCoutForOtchetCars += Convert.ToInt32(orders[k].cost);
                                            }
                                        }
                                        if (trips.Count == 0)
                                        {
                                            SrCoutOnTripForOtchetpark = 0;
                                        }
                                        else
                                        {
                                            SrCoutOnTripForOtchetpark = SummaruCoutForOtchetCars / trips.Count;
                                        }
                                        if (CountOrderForOtcehtCars == 0)
                                        {
                                            SrCoutOnOrderForOtchetpark = 0;
                                        }
                                        else
                                        {
                                            SrCoutOnOrderForOtchetpark = SummaruCoutForOtchetCars / CountOrderForOtcehtCars;
                                        }
                                        GridOtchetParks.Invoke(new Action(() => { GridOtchetParks.Rows.Add(park[i].voditel, trips.Count, CountOrderForOtcehtCars, SummaruCoutForOtchetCars, SrCoutOnTripForOtchetpark, SrCoutOnOrderForOtchetpark); }));
                                    }
                                    ProgressBarOtchetPark.Invoke(new Action(() => { ProgressBarOtchetPark.Value++; }));
                                }
                                ProgressBarOtchetPark.Invoke(new Action(() => { ProgressBarOtchetPark.Visible = false; }));
                                LabelOtchetPark.Invoke(new Action(() => { LabelOtchetPark.Visible = false; }));
                            })).Start();
                        }
                        #endregion
                        break;
                    case 1: //график загруженности
                        #region TabGraphikZagruz
                        if (ChartGrphikZagryz.Series.Count == 0)
                        {
                            DateTimeGraphikZagrS.Value = DateTime.Today.AddDays(-30);
                            DateTimeGraphikZagrPO.Value = DateTime.Today;
                            ProgressBarGraphicZagr.Visible = true;
                            LabelProgressBarGraphicZagr.Visible = true;
                            DayCount = (DateTimeGraphikZagrPO.Value - DateTimeGraphikZagrS.Value).Days + 1;
                            marshruts = Routs.GetMarshruts();
                            ProgressBarGraphicZagr.Minimum = 0;
                            ProgressBarGraphicZagr.Maximum = DayCount * marshruts.Count + DayCount;
                            ProgressBarGraphicZagr.Value = 0;
                            new Thread(new ThreadStart(delegate
                            {
                                try {
                                    string[] axisXData = new string[DayCount];
                                    var DateForMassiv = DateTimeGraphikZagrS.Value;
                                    for (int i = 0; i < DayCount; i++)
                                    {
                                        axisXData[i] = DateForMassiv.ToString("yyyy-MM-dd");
                                        DateForMassiv = DateForMassiv.AddDays(1);
                                        ProgressBarGraphicZagr.Invoke(new Action(() => { ProgressBarGraphicZagr.Value++; }));
                                    }
                                    double[] axisYData;
                                    var series = new List<Series>();
                                    for (int i = 0; i < marshruts.Count; i++)
                                    {
                                        axisYData = new double[DayCount];
                                        series.Add(new Series(marshruts[i].name));
                                        series[i].ChartType = SeriesChartType.Line;
                                        series[i].BorderWidth = 5;
                                        for (int j = 0; j < DayCount; j++)
                                        {
                                            axisYData[j] = Orders.GetOrderCount(axisXData[j], marshruts[i].id.ToString(), "0");
                                            ProgressBarGraphicZagr.Invoke(new Action(() => { ProgressBarGraphicZagr.Value++; }));
                                        }
                                        series[i].Points.DataBindXY(axisXData, axisYData);
                                        ChartGrphikZagryz.Invoke(new Action(() => { ChartGrphikZagryz.Series.Add(series[i]); }));
                                    }
                                    ChartGrphikZagryz.Invoke(new Action(() => { ChartGrphikZagryz.ChartAreas[0].AxisX.Interval = 2; }));
                                    ChartGrphikZagryz.Invoke(new Action(() => { ChartGrphikZagryz.ChartAreas[0].AxisY.Interval = 5; }));
                                    ProgressBarGraphicZagr.Invoke(new Action(() => { ProgressBarGraphicZagr.Visible = false; }));
                                    LabelProgressBarGraphicZagr.Invoke(new Action(() => { LabelProgressBarGraphicZagr.Visible = false; }));
                                } catch (Exception)
                                {

                                }
                            })).Start();
                        }
                        #endregion
                        break;
                    case 2: //график по типу билета
                        #region TabGraphicTypeBilet
                        if (ChartGrphikTypeBilet.Series.Count == 0)
                        {
                            DateTimeGraphikTypeBiletS.Value = DateTime.Today.AddDays(-30);
                            DateTimeGraphikTypeBiletPO.Value = DateTime.Today;
                            ProgressBarGraphicTypeBilet.Visible = true;
                            LabelProgressBarGraphicTypeBilet.Visible = true;
                            DayCount = (DateTimeGraphikTypeBiletPO.Value - DateTimeGraphikTypeBiletS.Value).Days + 1;
                            bilets = TypeBilets.GetTypeBilets();
                            ProgressBarGraphicTypeBilet.Minimum = 0;
                            ProgressBarGraphicTypeBilet.Maximum = DayCount * bilets.Count + DayCount;
                            ProgressBarGraphicTypeBilet.Value = 0;
                            new Thread(new ThreadStart(delegate
                            {
                                string[] axisXData = new string[DayCount];
                                var DateForMassiv = DateTimeGraphikTypeBiletS.Value;
                                for (int i = 0; i < DayCount; i++)
                                {
                                    axisXData[i] = DateForMassiv.ToString("yyyy-MM-dd");
                                    DateForMassiv = DateForMassiv.AddDays(1);
                                    ProgressBarGraphicTypeBilet.Invoke(new Action(() => { ProgressBarGraphicTypeBilet.Value++; }));
                                }
                                double[] axisYData;
                                var series = new List<Series>();
                                for (int i = 0; i < bilets.Count; i++)
                                {
                                    axisYData = new double[DayCount];
                                    series.Add(new Series(bilets[i].name));
                                    series[i].ChartType = SeriesChartType.Line;
                                    series[i].BorderWidth = 5;
                                    for (int j = 0; j < DayCount; j++)
                                    {
                                        axisYData[j] = Orders.GetOrderCount(axisXData[j], bilets[i].id.ToString(), "1");
                                        ProgressBarGraphicTypeBilet.Invoke(new Action(() => { ProgressBarGraphicTypeBilet.Value++; }));
                                    }
                                    series[i].Points.DataBindXY(axisXData, axisYData);
                                    ChartGrphikTypeBilet.Invoke(new Action(() => { ChartGrphikTypeBilet.Series.Add(series[i]); }));
                                }
                                ChartGrphikTypeBilet.Invoke(new Action(() => { ChartGrphikTypeBilet.ChartAreas[0].AxisX.Interval = 2; }));
                                ChartGrphikTypeBilet.Invoke(new Action(() => { ChartGrphikTypeBilet.ChartAreas[0].AxisY.Interval = 5; }));
                                ProgressBarGraphicTypeBilet.Invoke(new Action(() => { ProgressBarGraphicTypeBilet.Visible = false; }));
                                LabelProgressBarGraphicTypeBilet.Invoke(new Action(() => { LabelProgressBarGraphicTypeBilet.Visible = false; }));
                            })).Start();
                        }
                        #endregion
                        break;
                    case 3: //акции
                        #region TabGraphicFromOrder
                        if (ChartGraphicFromOrder.Series.Count == 0)
                        {
                            DateTimeGraphikFromOrderS.Value = DateTime.Today.AddDays(-30);
                            DateTimeGraphikFromOrderPO.Value = DateTime.Today;
                            ProgressBarGraphicFromOrder.Visible = true;
                            LabelProgressBarGraphicFromOrder.Visible = true;
                            DayCount = (DateTimeGraphikFromOrderPO.Value - DateTimeGraphikFromOrderS.Value).Days + 1;
                            ProgressBarGraphicFromOrder.Minimum = 0;
                            ProgressBarGraphicFromOrder.Maximum = DayCount * fromOrder.item.Count + DayCount;
                            ProgressBarGraphicFromOrder.Value = 0;
                            new Thread(new ThreadStart(delegate
                            {
                                string[] axisXData = new string[DayCount];
                                var DateForMassiv = DateTimeGraphikFromOrderS.Value;
                                for (int i = 0; i < DayCount; i++)
                                {
                                    axisXData[i] = DateForMassiv.ToString("yyyy-MM-dd");
                                    DateForMassiv = DateForMassiv.AddDays(1);
                                    ProgressBarGraphicFromOrder.Invoke(new Action(() => { ProgressBarGraphicFromOrder.Value++; }));
                                }
                                double[] axisYData;
                                var series = new List<Series>();
                                for (int i = 0; i < fromOrder.item.Count; i++)
                                {
                                    axisYData = new double[DayCount];
                                    series.Add(new Series(fromOrder.item[i].name));
                                    series[i].ChartType = SeriesChartType.Line;
                                    series[i].BorderWidth = 5;
                                    for (int j = 0; j < DayCount; j++)
                                    {
                                        axisYData[j] = Orders.GetOrderCount(axisXData[j], fromOrder.item[i].id.ToString(), "2");
                                        ProgressBarGraphicFromOrder.Invoke(new Action(() => { ProgressBarGraphicFromOrder.Value++; }));
                                    }
                                    series[i].Points.DataBindXY(axisXData, axisYData);
                                    ChartGraphicFromOrder.Invoke(new Action(() => { ChartGraphicFromOrder.Series.Add(series[i]); }));
                                }
                                ChartGraphicFromOrder.Invoke(new Action(() => { ChartGraphicFromOrder.ChartAreas[0].AxisX.Interval = 2; }));
                                ChartGraphicFromOrder.Invoke(new Action(() => { ChartGraphicFromOrder.ChartAreas[0].AxisY.Interval = 5; }));
                                ProgressBarGraphicFromOrder.Invoke(new Action(() => { ProgressBarGraphicFromOrder.Visible = false; }));
                                LabelProgressBarGraphicFromOrder.Invoke(new Action(() => { LabelProgressBarGraphicFromOrder.Visible = false; }));
                            })).Start();
                        }
                        #endregion
                        break;
                }
            }


        #region TabOtchetPark Methods
        private void ButtonOtchetParkSelect_Click(object sender, EventArgs e)
                {
                    GridOtchetParks.Rows.Clear();
                    park =  Park.GetCars("1");
                    ProgressBarOtchetPark.Visible = true;
                    LabelOtchetPark.Visible = true;
                    ProgressBarOtchetPark.Minimum = 0;
                    ProgressBarOtchetPark.Maximum = park.Count;
                    ProgressBarOtchetPark.Value = 0;
                    new Thread(new ThreadStart(delegate
                    {
                        for (int i = 0; i < park.Count; i++)
                        {
                            if (park[i].id != 0)
                            {
                                CountOrderForOtcehtCars = 0;
                                SummaruCoutForOtchetCars = 0;
                                trips = Trips.GetTripsForOtchetPark(park[i].id.ToString(), DateTimeOtchetParkS.Value.ToString("yyyy-MM-dd"), DateTimeOtchetParkPO.Value.ToString("yyyy-MM-dd"));
                                for (int j = 0; j < trips.Count; j++)
                                {
                                    orders = Orders.GetOrders(trips[j].id.ToString());
                                    CountOrderForOtcehtCars += orders.Count;
                                    for (int k = 0; k < orders.Count; k++)
                                    {
                                        SummaruCoutForOtchetCars += Convert.ToInt32(orders[k].cost);
                                    }
                                }
                                if (trips.Count == 0)
                                {
                                    SrCoutOnTripForOtchetpark =  0;
                                }
                                else
                                {
                                    SrCoutOnTripForOtchetpark =  SummaruCoutForOtchetCars / trips.Count;
                                }
                                if (CountOrderForOtcehtCars == 0)
                                {
                                    SrCoutOnOrderForOtchetpark =  0;
                                }
                                else
                                {
                                    SrCoutOnOrderForOtchetpark =  SummaruCoutForOtchetCars / CountOrderForOtcehtCars;
                                }
                                GridOtchetParks.Invoke(new Action(() => { GridOtchetParks.Rows.Add(park[i].voditel, trips.Count, CountOrderForOtcehtCars, SummaruCoutForOtchetCars, SrCoutOnTripForOtchetpark, SrCoutOnOrderForOtchetpark); }));
                            }
                            ProgressBarOtchetPark.Invoke(new Action(() => { ProgressBarOtchetPark.Value++; }));
                        }
                        ProgressBarOtchetPark.Invoke(new Action(() => { ProgressBarOtchetPark.Visible = false; }));
                        LabelOtchetPark.Invoke(new Action(() => { LabelOtchetPark.Visible = false; }));
                    })).Start();
        }
        #endregion

        #region TabGraphicZagr Methods
        private void ButtonOtchetGraphicZagrSelect_Click(object sender, EventArgs e)
            {
                if (DateTimeGraphikZagrS.Value < DateTimeGraphikZagrPO.Value)
                {
                    ChartGrphikZagryz.Series.Clear();
                    ProgressBarGraphicZagr.Visible = true;
                    LabelProgressBarGraphicZagr.Visible = true;
                    DayCount = (DateTimeGraphikZagrPO.Value - DateTimeGraphikZagrS.Value).Days + 1;
                    marshruts = Routs.GetMarshruts();
                    ProgressBarGraphicZagr.Minimum = 0;
                    ProgressBarGraphicZagr.Maximum = DayCount * marshruts.Count + DayCount;
                    ProgressBarGraphicZagr.Value = 0;
                    new Thread(new ThreadStart(delegate
                    {
                        string[] axisXData = new string[DayCount];
                        var DateForMassiv = DateTimeGraphikZagrS.Value;
                        for (int i = 0; i < DayCount; i++)
                        {
                            axisXData[i] = DateForMassiv.ToString("yyyy-MM-dd");
                            DateForMassiv = DateForMassiv.AddDays(1);
                            ProgressBarGraphicZagr.Invoke(new Action(() => { ProgressBarGraphicZagr.Value++; }));
                        }
                        double[] axisYData;
                        var series = new List<Series>();
                        for (int i = 0; i < marshruts.Count; i++)
                        {
                            axisYData = new double[DayCount];
                            series.Add(new Series(marshruts[i].name));
                            series[i].ChartType = SeriesChartType.Line;
                            series[i].BorderWidth = 5;
                            for (int j = 0; j < DayCount; j++)
                            {
                                axisYData[j] = Orders.GetOrderCount(axisXData[j], marshruts[i].id.ToString(), "0");
                                ProgressBarGraphicZagr.Invoke(new Action(() => { ProgressBarGraphicZagr.Value++; }));
                            }
                            series[i].Points.DataBindXY(axisXData, axisYData);
                            ChartGrphikZagryz.Invoke(new Action(() => { ChartGrphikZagryz.Series.Add(series[i]); }));
                        }
                        ChartGrphikZagryz.Invoke(new Action(() => { ChartGrphikZagryz.ChartAreas[0].AxisX.Interval = 2; }));
                        ChartGrphikZagryz.Invoke(new Action(() => { ChartGrphikZagryz.ChartAreas[0].AxisY.Interval = 5; }));
                        ProgressBarGraphicZagr.Invoke(new Action(() => { ProgressBarGraphicZagr.Visible = false; }));
                        ProgressBarGraphicZagr.Invoke(new Action(() => { LabelProgressBarGraphicZagr.Visible = false; }));
                    })).Start();
            }
            else
            {
                MetroMessageBox.Show(this, "Неверные даты формирования графика.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        #endregion

        #region TabGraphicTypeBilet Methods
        private void ButtonOtchetGraphicTypeBileSelect_Click(object sender, EventArgs e)
            {
                if (DateTimeGraphikTypeBiletS.Value < DateTimeGraphikTypeBiletPO.Value)
                {
                    ChartGrphikTypeBilet.Series.Clear();
                    ProgressBarGraphicTypeBilet.Visible = true;
                    LabelProgressBarGraphicTypeBilet.Visible = true;
                    DayCount = (DateTimeGraphikTypeBiletPO.Value - DateTimeGraphikTypeBiletS.Value).Days + 1;
                    bilets = TypeBilets.GetTypeBilets();
                    ProgressBarGraphicTypeBilet.Minimum = 0;
                    ProgressBarGraphicTypeBilet.Maximum = DayCount * bilets.Count + DayCount;
                    ProgressBarGraphicTypeBilet.Value = 0;
                    new Thread(new ThreadStart(delegate
                    {
                        string[] axisXData = new string[DayCount];
                        var DateForMassiv = DateTimeGraphikTypeBiletS.Value;
                        for (int i = 0; i < DayCount; i++)
                        {
                            axisXData[i] = DateForMassiv.ToString("yyyy-MM-dd");
                            DateForMassiv = DateForMassiv.AddDays(1);
                            ProgressBarGraphicTypeBilet.Invoke(new Action(() => { ProgressBarGraphicTypeBilet.Value++; }));
                        }
                        double[] axisYData;
                        var series = new List<Series>();
                        for (int i = 0; i < bilets.Count; i++)
                        {
                            axisYData = new double[DayCount];
                            series.Add(new Series(bilets[i].name));
                            series[i].ChartType = SeriesChartType.Line;
                            series[i].BorderWidth = 5;
                            for (int j = 0; j < DayCount; j++)
                            {
                                axisYData[j] = Orders.GetOrderCount(axisXData[j], bilets[i].id.ToString(), "1");
                                ProgressBarGraphicTypeBilet.Invoke(new Action(() => { ProgressBarGraphicTypeBilet.Value++; }));
                            }
                            series[i].Points.DataBindXY(axisXData, axisYData);
                            ChartGrphikTypeBilet.Invoke(new Action(() => { ChartGrphikTypeBilet.Series.Add(series[i]); }));
                        }
                        ChartGrphikTypeBilet.Invoke(new Action(() => { ChartGrphikTypeBilet.ChartAreas[0].AxisX.Interval = 2; }));
                        ChartGrphikTypeBilet.Invoke(new Action(() => { ChartGrphikTypeBilet.ChartAreas[0].AxisY.Interval = 5; }));
                        ProgressBarGraphicTypeBilet.Invoke(new Action(() => { ProgressBarGraphicTypeBilet.Visible = false; }));
                        LabelProgressBarGraphicTypeBilet.Invoke(new Action(() => { LabelProgressBarGraphicTypeBilet.Visible = false; }));
                    })).Start();
                } 
                else
                {
                    MetroMessageBox.Show(this, "Неверные даты формирования графика.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        #endregion

        #region TabGraphicFromOrder Methods
            private void ButtonGraphicFromOrder_Click(object sender, EventArgs e)
            {
                ChartGraphicFromOrder.Series.Clear();
                ProgressBarGraphicFromOrder.Visible = true;
                LabelProgressBarGraphicFromOrder.Visible = true;
                DayCount = (DateTimeGraphikFromOrderPO.Value - DateTimeGraphikFromOrderS.Value).Days + 1;
                ProgressBarGraphicFromOrder.Minimum = 0;
                ProgressBarGraphicFromOrder.Maximum = DayCount * fromOrder.item.Count + DayCount;
                ProgressBarGraphicFromOrder.Value = 0;
                new Thread(new ThreadStart(delegate
                {
                    string[] axisXData = new string[DayCount];
                    var DateForMassiv = DateTimeGraphikFromOrderS.Value;
                    for (int i = 0; i < DayCount; i++)
                    {
                        axisXData[i] = DateForMassiv.ToString("yyyy-MM-dd");
                        DateForMassiv = DateForMassiv.AddDays(1);
                        ProgressBarGraphicFromOrder.Invoke(new Action(() => { ProgressBarGraphicFromOrder.Value++; }));
                    }
                    double[] axisYData;
                    var series = new List<Series>();
                    for (int i = 0; i < fromOrder.item.Count; i++)
                    {
                        axisYData = new double[DayCount];
                        series.Add(new Series(fromOrder.item[i].name));
                        series[i].ChartType = SeriesChartType.Line;
                        series[i].BorderWidth = 5;
                        for (int j = 0; j < DayCount; j++)
                        {
                            axisYData[j] = Orders.GetOrderCount(axisXData[j], fromOrder.item[i].id.ToString(), "2");
                            ProgressBarGraphicFromOrder.Invoke(new Action(() => { ProgressBarGraphicFromOrder.Value++; }));
                        }
                        series[i].Points.DataBindXY(axisXData, axisYData);
                        ChartGraphicFromOrder.Invoke(new Action(() => { ChartGraphicFromOrder.Series.Add(series[i]); }));
                    }
                    ChartGraphicFromOrder.Invoke(new Action(() => { ChartGraphicFromOrder.ChartAreas[0].AxisX.Interval = 2; }));
                    ChartGraphicFromOrder.Invoke(new Action(() => { ChartGraphicFromOrder.ChartAreas[0].AxisY.Interval = 5; }));
                    ProgressBarGraphicFromOrder.Invoke(new Action(() => { ProgressBarGraphicFromOrder.Visible = false; }));
                    LabelProgressBarGraphicFromOrder.Invoke(new Action(() => { LabelProgressBarGraphicFromOrder.Visible = false; }));
                })).Start();
            }
        #endregion

        #endregion

        #region TabWorkPlan
        private void ComboBoxWorkPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxWorkPlan.SelectedIndex != -1)
            {
                GridViewWorkPlan.Rows.Clear();
                string year = plans[ComboBoxWorkPlan.SelectedIndex].year.ToString("yyyy");
                var resultCount = WorkPlan.GetCountOrder(
                    DateTime.Parse("01.01." + year),
                    DateTime.Parse("31.01." + year));
                GridViewWorkPlan.Rows.Add("Январь", plans[ComboBoxWorkPlan.SelectedIndex].january, resultCount);

                resultCount = WorkPlan.GetCountOrder(
                    DateTime.Parse("01.02." + year),
                    DateTime.Parse("28.02." + year));
                GridViewWorkPlan.Rows.Add("Февраль", plans[ComboBoxWorkPlan.SelectedIndex].february, resultCount);

                resultCount = WorkPlan.GetCountOrder(
                    DateTime.Parse("01.03." + year),
                    DateTime.Parse("31.03." + year));
                GridViewWorkPlan.Rows.Add("Март", plans[ComboBoxWorkPlan.SelectedIndex].march, resultCount);

                resultCount = WorkPlan.GetCountOrder(
                    DateTime.Parse("01.04." + year),
                    DateTime.Parse("30.04." + year));
                GridViewWorkPlan.Rows.Add("Апрель", plans[ComboBoxWorkPlan.SelectedIndex].april, resultCount);

                resultCount = WorkPlan.GetCountOrder(
                    DateTime.Parse("01.05." + year),
                    DateTime.Parse("31.05." + year));
                GridViewWorkPlan.Rows.Add("Май", plans[ComboBoxWorkPlan.SelectedIndex].may, resultCount);

                resultCount = WorkPlan.GetCountOrder(
                    DateTime.Parse("01.06." + year),
                    DateTime.Parse("30.06." + year));
                GridViewWorkPlan.Rows.Add("Июнь", plans[ComboBoxWorkPlan.SelectedIndex].june, resultCount);

                resultCount = WorkPlan.GetCountOrder(
                    DateTime.Parse("01.07." + year),
                    DateTime.Parse("31.07." + year));
                GridViewWorkPlan.Rows.Add("Июль", plans[ComboBoxWorkPlan.SelectedIndex].july, resultCount);

                resultCount = WorkPlan.GetCountOrder(
                    DateTime.Parse("01.08." + year),
                    DateTime.Parse("31.08." + year));
                GridViewWorkPlan.Rows.Add("Август", plans[ComboBoxWorkPlan.SelectedIndex].august, resultCount);

                resultCount = WorkPlan.GetCountOrder(
                    DateTime.Parse("01.09." + year),
                    DateTime.Parse("30.09." + year));
                    GridViewWorkPlan.Rows.Add("Сентябрь", plans[ComboBoxWorkPlan.SelectedIndex].september, resultCount);

                resultCount = WorkPlan.GetCountOrder(
                    DateTime.Parse("01.10." + year),
                    DateTime.Parse("31.10." + year));
                GridViewWorkPlan.Rows.Add("Октябрь", plans[ComboBoxWorkPlan.SelectedIndex].october, resultCount);

                resultCount = WorkPlan.GetCountOrder(
                    DateTime.Parse("01.11." + year),
                    DateTime.Parse("30.11." + year));
                GridViewWorkPlan.Rows.Add("Ноябрь", plans[ComboBoxWorkPlan.SelectedIndex].november, resultCount);

                resultCount = WorkPlan.GetCountOrder(
                    DateTime.Parse("01.12." + year),
                    DateTime.Parse("31.12." + year));
                GridViewWorkPlan.Rows.Add("Декабрь", plans[ComboBoxWorkPlan.SelectedIndex].february, resultCount);
            }
        }

        private async void ButtonCreateWorkPlan_Click(object sender, EventArgs e)
        {
            if (user.role == "0")
            {
                MetroMessageBox.Show(this, "Недостаточно прав.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                var CreateWorkPlan = new CreateWorkPlanForm();
                CreateWorkPlan.ShowDialog();
                GridViewWorkPlan.Rows.Clear();
                ComboBoxWorkPlan.Items.Clear();
                plans = await WorkPlan.Get();
                for (int i = 0; i < plans.Count; i++)
                {
                    ComboBoxWorkPlan.Items.Add(plans[i].year.ToString("yyyy"));
                }
                if (plans.Count > 0)
                    ComboBoxWorkPlan.SelectedIndex = 0;
            }
        }

        private async void ButtonEditWorkPlan_Click(object sender, EventArgs e)
        {
            if (user.role == "0")
            {
                MetroMessageBox.Show(this, "Недостаточно прав.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                if (ComboBoxWorkPlan.SelectedIndex != -1)
                {
                    var CreateWorkPlan = new CreateWorkPlanForm(plans[ComboBoxWorkPlan.SelectedIndex]);
                    CreateWorkPlan.ShowDialog();
                    GridViewWorkPlan.Rows.Clear();
                    ComboBoxWorkPlan.Items.Clear();
                    plans = await WorkPlan.Get();
                    for (int i = 0; i < plans.Count; i++)
                    {
                        ComboBoxWorkPlan.Items.Add(plans[i].year.ToString("yyyy"));
                    }
                    if (plans.Count > 0)
                        ComboBoxWorkPlan.SelectedIndex = 0;
                }
            }
        }

        private async void ButtonDeleteWorkPlan_Click(object sender, EventArgs e)
        {
            if (user.role == "0")
            {
                MetroMessageBox.Show(this, "Недостаточно прав.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                if (ComboBoxWorkPlan.SelectedIndex != -1)
                {
                    plans[ComboBoxWorkPlan.SelectedIndex].Delete();
                    GridViewWorkPlan.Rows.Clear();
                    ComboBoxWorkPlan.Items.Clear();
                    plans = await WorkPlan.Get();
                    for (int i = 0; i < plans.Count; i++)
                    {
                        ComboBoxWorkPlan.Items.Add(plans[i].year.ToString("yyyy"));
                    }
                    if (plans.Count > 0)
                        ComboBoxWorkPlan.SelectedIndex = 0;
                }
            }
        }
        #endregion

        #region Manage Sms
        private void ButtonSmsUpdateBalance_Click(object sender, EventArgs e)
        {
            UpdateSmsBalance();
        }

        private void UpdateSmsBalance()
        {
            LabelSmsBalance.Text = $"Баланс: {SmscRu.GetBalance().ToString()}";
        }
        #endregion

        #region TabNews

        private void UpdateTableNews()
        {
            news = News.Get();
            GridNews.Rows.Clear();
            foreach (var @new in news)
            {
                GridNews.Rows.Add(@new.title, @new.messages, $"{@new.date.ToShortDateString()} {@new.date.ToShortTimeString()}", @new.status == 0 ? "Опубликована" : "Снята с публикации");
            }
        }

        private void ButtonNewsAdd_Click(object sender, EventArgs e)
        {
            new AddNewsForm().ShowDialog();
            UpdateTableNews();
        }

        private void ButtonNewsEdit_Click(object sender, EventArgs e)
        {
            if (GridNews.CurrentRow.Index == -1) return;
            if (GridNews.CurrentRow.Index > news.Count) return;
            new AddNewsForm(news[GridNews.CurrentRow.Index]).ShowDialog();
            UpdateTableNews();
        }

        private void GridNews_SelectionChanged(object sender, EventArgs e)
        {
            if (GridNews.CurrentRow.Index == -1) return;
            if (GridNews.CurrentRow.Index > news.Count) return;
            ButtonNewsDelete.Text = news[GridNews.CurrentRow.Index].status != 0 ? "Опубликовать" : "Снять с публикации";
        }

        private void ButtonNewsDelete_Click(object sender, EventArgs e)
        {
            if (GridNews.CurrentRow.Index == -1) return;
            if (GridNews.CurrentRow.Index > news.Count) return;
            if (news[GridNews.CurrentRow.Index].status == 0)
                news[GridNews.CurrentRow.Index].Unpublished();
            else
                news[GridNews.CurrentRow.Index].Published();
            UpdateTableNews();
        }
        #endregion
    }
}
