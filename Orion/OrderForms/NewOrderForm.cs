using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework;
using GlobalLib;

namespace Orion
{
    public partial class NewOrderForm : MetroForm
    {
        List<Rout> marshruts;
        List<Trip> trips;
        List<MetroButton> ButtonMass;
        List<int> SvobodMesta;
        List<TypeBilet> bilets;
        List<int> mesta;
        public NewOrderForm()
        {
            InitializeComponent();

            metroButton14.UseCustomBackColor = true;
            metroButton14.BackColor = Color.DimGray;
            SvobodMesta = new List<int>();

            //--------Добавление Button в массив-----
            TextBoxMesto.Text = "";
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
            bilets = TypeBilets.GetTypeBilets();

            for (int i = 0; i < bilets.Count; i++)
            {
                ComboBoxTypeBilet.Items.Add(bilets[i].name);
            }

            for (int i = 0; i < marshruts.Count; i++)
            {
                ComboBoxNewMarshrut.Items.Add(marshruts[i].name);
            }

            marshruts[0].GetPromPynkt();
            int j = marshruts[0].PromPynkt.Count - 1; // переменная для заполнения ComboBoxKyda
            for (int i = 0; i < marshruts[0].PromPynkt.Count; i++)
            {
                ComboBoxOtkyda.Items.Add(marshruts[0].PromPynkt[i].name);
                ComboBoxKyda.Items.Add(marshruts[0].PromPynkt[j].name);
                j--;
            }
            functions.ClearButtonSvMesta(ButtonMass);
        }
        private void ComboBoxNewMarshrut_SelectedIndexChanged(object sender, EventArgs e)
        {
            marshruts[ComboBoxNewMarshrut.SelectedIndex].GetPromPynkt();
            int j = marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt.Count - 1; // переменная для заполнения ComboBoxKyda
            ComboBoxOtkyda.Items.Clear();
            ComboBoxKyda.Items.Clear();
            for (int i = 0; i < marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt.Count; i++)
            {
                ComboBoxOtkyda.Items.Add(marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[i].name);
                ComboBoxKyda.Items.Add(marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[j].name);
                j--;
            }
            ComboBoxOtkyda.SelectedIndex = 0;
            ComboBoxKyda.SelectedIndex = 0;
            trips = Trips.GetTripsOnDate(DateTimePicker.Value.ToString("yyyy-MM-dd"), marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[ComboBoxOtkyda.SelectedIndex].id.ToString(), marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt.Count-1 - ComboBoxOtkyda.SelectedIndex].id.ToString(), marshruts[ComboBoxNewMarshrut.SelectedIndex].id.ToString());
            ComboBoxCar.Items.Clear();
            for (int i = 0; i < trips.Count; i++)
            {
                ComboBoxCar.Items.Add("Микроавтобус №"+ (i+1).ToString());
            }

             functions.ClearButtonSvMesta(ButtonMass);

            LabelSvMest.Text = "Свободных мест: ";// + trips[0].coun_sv_mest;
            TextBoxCout.Text = "";// functions.GetPrice(pynkts[0].name, pynkts[pynkts.Count - 1].name);
        }
        private void ComboBoxOtkyda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxKyda.Text != "" && ComboBoxOtkyda.Text != "" && ComboBoxTypeBilet.Text != "")
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
        }
        private void ComboBoxKyda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxOtkyda.Text != "" && ComboBoxTypeBilet.Text != "" && ComboBoxKyda.Text != "")
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
        }
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            trips = Trips.GetTripsOnDate(DateTimePicker.Value.ToString("yyyy-MM-dd"), marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[ComboBoxOtkyda.SelectedIndex].id.ToString(), marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt.Count - 1 - ComboBoxOtkyda.SelectedIndex].id.ToString(), marshruts[ComboBoxNewMarshrut.SelectedIndex].id.ToString());
            ComboBoxCar.Items.Clear();
            for (int i = 0; i < trips.Count; i++)
            {
                ComboBoxCar.Items.Add("Микроавтобус №" + (i+1).ToString());
            }


            functions.ClearButtonSvMesta(ButtonMass);


            LabelSvMest.Text = "Свободных мест: ";// + trips[0].coun_sv_mest;
        }
        private void ComboBoxCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            functions.ClearButtonSvMesta(ButtonMass);
            TextBoxMesto.Text = "";
            mesta = Trips.GetMesta(trips[ComboBoxCar.SelectedIndex].id, marshruts[ComboBoxNewMarshrut.SelectedIndex].id, marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[ComboBoxOtkyda.SelectedIndex].id, marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt.Count - 1 - ComboBoxKyda.SelectedIndex].id);
            functions.CheckSvMestaOnShema(mesta, ButtonMass, SvobodMesta);
            LabelSvMest.Text = "Свободных мест: " + trips[ComboBoxCar.SelectedIndex].coun_sv_mest;
        }
        private void ButtonAddOrChange_Click(object sender, EventArgs e)
        {
            if (ComboBoxKyda.Text != ComboBoxOtkyda.Text)
            {
                if (TextBoxMesto.Text != "" && TextBoxFio.Text != "" && TextBoxPhone.Text != "" && TextBoxCout.Text != "")
                {
                    var NewMesta = TextBoxMesto.Text.Split(' ');
                    int index = 0;
                    for (int i = 0; i < NewMesta.Count(); i++)
                    {
                        if (NewMesta[i] != "")
                        {
                            if (Convert.ToInt32(NewMesta[i]) < 15 && Convert.ToInt32(NewMesta[i]) != 13)
                            {
                                bool search = false;

                                for (int j = 0; j < SvobodMesta.Count(); j++)
                                {
                                    if (Convert.ToInt32(NewMesta[i]) == SvobodMesta[j])
                                    {
                                        search = true;
                                        index = j;
                                        break;
                                    }
                                }
                                if (!search)
                                {
                                    search = false;
                                    MetroMessageBox.Show(this, "Билет на место " + NewMesta[i] + " не может быть оформленн так как место уже занято. Программа проложит оформлять оставшиеся заказы.", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                }
                                else
                                {
                                    var ClientId = Clients.GetClientId(TextBoxFio.Text, TextBoxPhone.Text);
                                    string mesto = null;
                                    if (NewMesta[i] == "14")
                                    {
                                        mesto = "13";
                                    }
                                    else
                                    {
                                        mesto = NewMesta[i];
                                    }
                                    var result = Orders.CreateNewOrder( new Order {
                                        type_bilet = bilets[ComboBoxTypeBilet.SelectedIndex].id.ToString(),
                                        fio = TextBoxFio.Text,
                                        otkyda = marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[ComboBoxOtkyda.SelectedIndex].id.ToString(),
                                        kyda = marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt[marshruts[ComboBoxNewMarshrut.SelectedIndex].PromPynkt.Count - 1 - ComboBoxKyda.SelectedIndex].id.ToString(),
                                        id_poezdka = trips[ComboBoxCar.SelectedIndex].id,
                                        id_akcia = "0",
                                        cost = Convert.ToInt32(TextBoxCout.Text),
                                        mesto = mesto,
                                        status = "0",
                                        from_order = "0",
                                    }, ClientId.ToString());
                                    if (result != "false")
                                    {
                                        MetroMessageBox.Show(this, "Заказ на место под номером " + NewMesta[i] +" оформлен.", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                        SvobodMesta[index] = 0;
                                    }
                                    else
                                    {
                                        MetroMessageBox.Show(this, "Заказ не может быть добавлен в настоящие время. Попробуйте еще раз в другое время.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                    }
                                }
                            }
                            else
                            {
                                MetroMessageBox.Show(this, "Место под номером " +NewMesta[i] + "не существует. Заказ не может быть оформлен.", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            }
                        }
                    }
                    Close();
                }
                else
                {
                    MetroMessageBox.Show(this, "Заполните все поля.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }

            }
            else
            {
                MetroMessageBox.Show(this, "Пункт отправки и конечный пункт не могут совпадать.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
                    } else
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
        private void TextBoxMesto_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxMesto.Text != "") {
                if (TextBoxMesto.Text[TextBoxMesto.Text.Count() - 1] == ' ' || TextBoxMesto.Text[TextBoxMesto.Text.Count() - 1] == '0' ||
                    TextBoxMesto.Text[TextBoxMesto.Text.Count() - 1] == '1' || TextBoxMesto.Text[TextBoxMesto.Text.Count() - 1] == '2' ||
                    TextBoxMesto.Text[TextBoxMesto.Text.Count() - 1] == '3' || TextBoxMesto.Text[TextBoxMesto.Text.Count() - 1] == '4' ||
                    TextBoxMesto.Text[TextBoxMesto.Text.Count() - 1] == '5' || TextBoxMesto.Text[TextBoxMesto.Text.Count() - 1] == '6' ||
                    TextBoxMesto.Text[TextBoxMesto.Text.Count() - 1] == '7' || TextBoxMesto.Text[TextBoxMesto.Text.Count() - 1] == '8' ||
                    TextBoxMesto.Text[TextBoxMesto.Text.Count() - 1] == '9')
                {

                } else
                {
                    MetroMessageBox.Show(this, "Неверный символ! Номера пасажирских мест должны быть разделены пробелом.", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    TextBoxMesto.Text = TextBoxMesto.Text.Substring(0, TextBoxMesto.Text.Count() - 1);
                    TextBoxMesto.SelectionStart = TextBoxMesto.Text.Length;
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
    }
}
