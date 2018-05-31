using MetroFramework.Forms;
using System;
using GlobalLib;
using System.Collections.Generic;
using MetroFramework;
using System.Windows.Forms;

namespace Orion
{
    public partial class AddNewTripForm : MetroForm
    {
        List<Car> cars;
        List<Rout> marsh;
        public AddNewTripForm()
        {
            InitializeComponent();
            marsh = Routs.GetMarshruts();
            cars = Park.GetCars("1");
            for (int i=0; i < marsh.Count; i++)
            {
                ComboBoxMarsh.Items.Add(marsh[i].name);
            }
            for (int i = 0; i < cars.Count; i++)
            {
                ComboBoxVoditel.Items.Add(cars[i].voditel);
            }
            ComboBoxVoditel.SelectedIndex = 0;
            ComboBoxMarsh.SelectedIndex = 0;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var result = Trips.CreateTrip(metroDateTime1.Value.ToString("yyyy-MM-dd"), cars[ComboBoxVoditel.SelectedIndex].id.ToString(), marsh[ComboBoxMarsh.SelectedIndex].id.ToString());
            if (result != "")
            {
                MetroMessageBox.Show(this, "При добавлении нового рейса произошла ошибка: "+result+" Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                Close();
            }
            else
            {
                Close();
            }
        }
    }
}
