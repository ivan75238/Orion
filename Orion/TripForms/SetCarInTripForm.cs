using GlobalLib;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Orion
{
    public partial class SetCarInTripForm : MetroForm
    {
        List<Car> park;
        List<int> mesta;
        List<MetroButton> ButtonMass;
        int IdCar, IdTrip;
        public SetCarInTripForm(Rout rout, string _NameMarsh, int _IdCar, int _IdTrip)
        {
            InitializeComponent();
            metroButton14.UseCustomBackColor = true;
            metroButton14.BackColor = Color.DimGray;
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
            rout.GetPromPynkt();
            mesta = Trips.GetMesta(_IdTrip, rout.id, rout.PromPynkt[0].id, rout.PromPynkt[rout.PromPynkt.Count - 1].id);
            functions.CheckSvMestaOnShema(mesta, ButtonMass);
            IdCar = _IdCar;
            IdTrip = _IdTrip;
            park = Park.GetCars("1");
            for (int i = 0; i < park.Count; i++)
            {
                ComboBoxVoditel.Items.Add(park[i].voditel);
            }
            LabelBus.Text = _NameMarsh;
            if (_IdCar != 0)
            {
                for (int i = 0; i < park.Count; i++)
                {
                    if (IdCar == park[i].id)
                    {
                        ComboBoxVoditel.SelectedIndex = i;
                        LabelGosNumber.Text = "Гос. номер: " + park[i].gos_nomer;
                        break;
                    }
                }
            }
        }
        private void ComboBoxVoditel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelGosNumber.Text = "Гос. номер: " + park[ComboBoxVoditel.SelectedIndex].gos_nomer;
        }
        private void ButtonChange_Click(object sender, EventArgs e)
        {
            var result = Trips.SetCar(IdTrip.ToString(), park[ComboBoxVoditel.SelectedIndex].id.ToString(), IdCar.ToString());
            if (result != "")
            {
                MetroMessageBox.Show(this, "При попытке изменения машины произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                Close();
            }
            else
            {
                Close();
            }
        }
    }
}
