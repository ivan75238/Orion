using GlobalLib;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Orion
{
    public partial class ChangeOrderForm : MetroForm
    {
        List<Rout> marshruts;
        List<Trip> trips;
        List<MetroButton> ButtonMass;
        List<int> mesta;
        List<TypeBilet> bilets;
        Order order;
        int IndexTrip = 0, IdMarsh, IdSetOrder;
        public ChangeOrderForm(int Id, DateTime date)
        {
            InitializeComponent();
            bilets = TypeBilets.GetTypeBilets();
            metroButton14.UseCustomBackColor = true;
            metroButton14.BackColor = Color.DimGray;
            IdSetOrder = Id;
            //--------Добавление Button в массив-----
            ButtonMass = new List<MetroButton>();
            
            ButtonMass.Add(metroButton2);
            ButtonMass.Add(metroButton3);
            ButtonMass.Add(metroButton4);
            ButtonMass.Add(metroButton5);
            ButtonMass.Add(metroButton6);
            ButtonMass.Add(metroButton7);
            ButtonMass.Add(metroButton8);
            ButtonMass.Add(metroButton9);
            ButtonMass.Add(metroButton10);
            ButtonMass.Add(metroButton11);
            ButtonMass.Add(metroButton12);
            ButtonMass.Add(metroButton13);
            ButtonMass.Add(metroButton1);
            //---------------------------------------
            marshruts = Routs.GetMarshruts();

            order = Orders.GetOrder(Id.ToString());

            for (int i = 0; i < marshruts.Count; i++)
            {
                ComboBoxNewMarshrut.Items.Add(marshruts[i].name);
                marshruts[i].GetPromPynkt();
                if (marshruts[i].name == order.name_marsh)
                    ComboBoxNewMarshrut.SelectedIndex = i;
            }

            int j = marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt.Count - 1; // переменная для заполнения ComboBoxKyda

            for (int i = 0; i < marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt.Count; i++)
            {
                ComboBoxOtkyda.Items.Add(marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[i].name);
                ComboBoxKyda.Items.Add(marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[j].name);
                j--;
            }

            for (int i = 0; i < marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt.Count; i++)
            {
                if (marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[i].name == order.otkyda)
                {
                    ComboBoxOtkyda.SelectedIndex = i;
                }
                if (marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[i].name == order.kyda)
                {
                    ComboBoxKyda.SelectedIndex = marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt.Count - 1 - i;
                }
            }

            for (int i = 0; i < marshruts.Count; i++)
            {
                if (order.name_marsh == marshruts[i].name)
                {
                    IdMarsh = marshruts[i].id;
                    break;
                }
            }
            trips = Trips.GetTripsOnDate(date.ToString("yyyy-MM-dd"), marshruts[0].PromPynkt[ComboBoxOtkyda.SelectedIndex].id.ToString(), marshruts[0].PromPynkt[marshruts[0].PromPynkt.Count-ComboBoxKyda.SelectedIndex-1].id.ToString(), IdMarsh.ToString());

            for (int i = 0; i < trips.Count; i++){
                if (trips[i].id == order.id_poezdka)
                {
                    IndexTrip = i;
                }
                ComboBoxCar.Items.Add("Микроавтобус №" + (i+1).ToString());
            }

            ComboBoxMesto.Items.Clear();
            mesta = Trips.GetMesta(trips[IndexTrip].id, marshruts[ComboBoxNewMarshrut.SelectedIndex].id, marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[ComboBoxOtkyda.SelectedIndex].id, marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt.Count - 1 - ComboBoxKyda.SelectedIndex].id);
            functions.CheckSvMestaOnShema(mesta, ButtonMass, ComboBoxMesto);

            for (int i = 0; i < bilets.Count; i++)
            {
                ComboBoxTypeBilet.Items.Add(bilets[i].name);
            }

            for (int i = 0; i < marshruts.Count; i++)
            {
                ComboBoxNewMarshrut.Items.Add(marshruts[i].name);
            }
            

            ComboBoxStatus.Items.Add("Оформлен");
            ComboBoxStatus.Items.Add("Забронирован");
            ComboBoxStatus.Items.Add("Оплачен");
            ComboBoxStatus.Items.Add("Отменен");            

            
            DateTimePicker.Value = date;
            LabelSvMest.Text = "Свободных мест: " + trips[IndexTrip].coun_sv_mest;
            if (order.mesto == "13")
            {
                ComboBoxMesto.Items.Add("14");
                ComboBoxMesto.Text = "14";
            } 
            else
            {
                ComboBoxMesto.Items.Add(order.mesto);
                ComboBoxMesto.Text = order.mesto;
            }
            TextBoxFio.Text = order.fio;
            TextBoxCout.Text = order.cost.ToString();
            TextBoxPhone.Text = order.phone;
            ComboBoxTypeBilet.Text = order.type_bilet;
            ComboBoxStatus.Text = functions.CheckStatus(order.status);
            ComboBoxCar.Text = "Микроавтобус №" + (IndexTrip+1).ToString();
        }

        private void ComboBoxNewMarshrut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxNewMarshrut.SelectedIndex != -1 && ComboBoxOtkyda.SelectedIndex != -1 && ComboBoxKyda.SelectedIndex != -1)
            {
                marshruts[ComboBoxNewMarshrut.SelectedIndex].GetPromPynkt();
                int j = marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt.Count - 1; // переменная для заполнения ComboBoxKyda
                ComboBoxOtkyda.Items.Clear();
                ComboBoxKyda.Items.Clear();
                for (int i = 0; i < marshruts[0].PromPynkt.Count; i++)
                {
                    ComboBoxOtkyda.Items.Add(marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[i].name);
                    ComboBoxKyda.Items.Add(marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[j].name);
                    j--;
                }
                trips = Trips.GetTripsOnDate(DateTimePicker.Value.ToString("yyyy-MM-dd"), marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[ComboBoxOtkyda.SelectedIndex].id.ToString(), marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt.Count - ComboBoxKyda.SelectedIndex - 1].id.ToString(), marshruts[ComboBoxNewMarshrut.SelectedIndex].id.ToString());
                ComboBoxCar.Items.Clear();
                for (int i = 0; i < trips.Count; i++)
                {
                    ComboBoxCar.Items.Add("Микроавтобус №" + (i + 1).ToString());
                }

                functions.ClearButtonSvMesta(ButtonMass);

                LabelSvMest.Text = "Свободных мест: ";// + trips[0].coun_sv_mest;
                TextBoxCout.Text = "";// functions.GetPrice(pynkts[0].name, pynkts[pynkts.Count - 1].name);
            }
        }

        private void ComboBoxOtkyda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxTypeBilet.Text != "" && ComboBoxKyda.Text != "" && ComboBoxOtkyda.Text != "")
            {
                string cost = Prices.GetPrice(marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[ComboBoxOtkyda.SelectedIndex].id, marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[(marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt.Count - 1 - ComboBoxKyda.SelectedIndex)].id, marshruts[ComboBoxNewMarshrut.SelectedIndex].id);
                if (cost != "false")
                {
                    if (bilets[ComboBoxTypeBilet.SelectedIndex].fix == 1)
                        TextBoxCout.Text = bilets[ComboBoxTypeBilet.SelectedIndex].cost.ToString();
                    else
                        TextBoxCout.Text = (Convert.ToDouble(cost) * bilets[ComboBoxTypeBilet.SelectedIndex].cost).ToString();
                }
                else
                {
                    MetroMessageBox.Show(this, "Перевозка между этими пунктами не осуществляется.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void ComboBoxKyda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxTypeBilet.Text != "" && ComboBoxKyda.Text != "" && ComboBoxOtkyda.Text != "")
            {
                string cost = Prices.GetPrice(marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[ComboBoxOtkyda.SelectedIndex].id, marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[(marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt.Count - 1 - ComboBoxKyda.SelectedIndex)].id, marshruts[ComboBoxNewMarshrut.SelectedIndex].id);
                if (cost != "false")
                {
                    if (bilets[ComboBoxTypeBilet.SelectedIndex].fix == 1)
                        TextBoxCout.Text = bilets[ComboBoxTypeBilet.SelectedIndex].cost.ToString();
                    else
                        TextBoxCout.Text = (Convert.ToDouble(cost) * bilets[ComboBoxTypeBilet.SelectedIndex].cost).ToString();
                }
                else
                {
                    MetroMessageBox.Show(this, "Перевозка между этими пунктами не осуществляется.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            trips = Trips.GetTripsOnDate(DateTimePicker.Value.ToString("yyyy-MM-dd"), marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[ComboBoxOtkyda.SelectedIndex].id.ToString(), marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt.Count - ComboBoxKyda.SelectedIndex - 1].id.ToString(), marshruts[ComboBoxNewMarshrut.SelectedIndex].id.ToString());
            ComboBoxCar.Items.Clear();
            for (int i = 0; i < trips.Count; i++)
            {
                ComboBoxCar.Items.Add("Микроавтобус №" + (i + 1).ToString());
            }


            functions.ClearButtonSvMesta(ButtonMass);


            LabelSvMest.Text = "Свободных мест: ";// + trips[0].coun_sv_mest;
        }

        private void ComboBoxCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            functions.ClearButtonSvMesta(ButtonMass);
            ComboBoxMesto.Items.Clear();
            mesta = Trips.GetMesta(trips[ComboBoxCar.SelectedIndex].id, marshruts[ComboBoxNewMarshrut.SelectedIndex].id, marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[ComboBoxOtkyda.SelectedIndex].id, marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt.Count - 1 - ComboBoxKyda.SelectedIndex].id);
            functions.CheckSvMestaOnShema(mesta, ButtonMass, ComboBoxMesto);
            LabelSvMest.Text = "Свободных мест: " + trips[ComboBoxCar.SelectedIndex].coun_sv_mest;
        }

        private void TextBoxMesto_TextChanged(object sender, EventArgs e)
        {
            if (ComboBoxMesto.Text != "")
            {
                try
                {
                    int mesto = Convert.ToInt32(ComboBoxMesto.Text);
                    if (mesto > 13)
                    {
                        MetroMessageBox.Show(this, "Введите число не превышающее 13.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        ComboBoxMesto.SelectedIndex = 0;
                    }
                }
                catch (Exception)
                {
                    MetroMessageBox.Show(this, "В поле 'Место' могут быть только цифры.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    ComboBoxMesto.SelectedIndex = 0;
                }
            }
        }

        private void TextBoxPhone_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxPhone.Text != "")
            {
                try
                {
                    long mesto = Convert.ToInt64(TextBoxPhone.Text);
                    if (TextBoxPhone.Text.Substring(0, 1) == "7")
                    {
                        if (TextBoxPhone.Text.Count() > 11)
                        {
                            MetroMessageBox.Show(this, "Номер телефона должен состоять из 11 символов", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Номер телефона должен начинаться с 7", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        TextBoxPhone.Text = "";
                    }
                }
                catch (Exception)
                {
                    MetroMessageBox.Show(this, "В поле 'Телефон' могут быть только цифры.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    TextBoxPhone.Text = "";
                }
            }
        }

        private void ComboBoxTypeBilet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxTypeBilet.Text != "" && ComboBoxKyda.Text != "" && ComboBoxOtkyda.Text != "")
            {
                string cout = Prices.GetPrice(marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[ComboBoxOtkyda.SelectedIndex].id, marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[(marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt.Count - 1 - ComboBoxKyda.SelectedIndex)].id, marshruts[ComboBoxNewMarshrut.SelectedIndex].id);
                if (cout != "false")
                {
                    if (bilets[ComboBoxTypeBilet.SelectedIndex].fix == 1)
                        TextBoxCout.Text = bilets[ComboBoxTypeBilet.SelectedIndex].cost.ToString();
                    else
                        TextBoxCout.Text = (Convert.ToDouble(cout) * bilets[ComboBoxTypeBilet.SelectedIndex].cost).ToString();
                }
                else
                {
                    MetroMessageBox.Show(this, "Перевозка между этими пунктами не осуществляется.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Перевозка между этими пунктами не осуществляется.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void TextBoxCout_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxCout.Text != "")
            {
                try
                {
                    int mesto = Convert.ToInt32(TextBoxCout.Text);
                }
                catch (Exception)
                {
                    MetroMessageBox.Show(this, "В поле 'Стоимость' могут быть только цифры.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    TextBoxCout.Text = "";
                }
            }
        }

        private void ButtonChangeOrChange_Click(object sender, EventArgs e)
        {
            int ClientId = Clients.GetClientId(TextBoxFio.Text, TextBoxPhone.Text);
            string mesto;
            if (ComboBoxMesto.Text == "")
            {
                mesto = order.mesto;
            }
            else
            {
                if (ComboBoxMesto.Text == "14")
                {
                    mesto = "13";
                }
                else
                {
                    mesto = ComboBoxMesto.Text;
                }
            }
            var result = Orders.SetOrder(new Order
            {
                id = IdSetOrder,
                type_bilet = bilets[ComboBoxTypeBilet.SelectedIndex].id.ToString(),
                fio = TextBoxFio.Text,
                otkyda = marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[ComboBoxOtkyda.SelectedIndex].id.ToString(),
                kyda = marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt.Count - 1 - ComboBoxKyda.SelectedIndex].id.ToString(),
                id_poezdka = trips[ComboBoxCar.SelectedIndex].id,
                id_akcia = "0",
                cost = Convert.ToInt32(TextBoxCout.Text),
                mesto = mesto,
                status = ComboBoxStatus.SelectedIndex.ToString()
            }, ClientId);
            if (result == "false")
            {
                MetroMessageBox.Show(this, "При изменении заказа произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                Close();
            }
            else
            {
                Close();
            }
        }


    }
}
