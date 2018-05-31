using GlobalLib;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace Orion
{
    public partial class ChangeLaeseForm : MetroForm
    {
        Car car;
        public ChangeLaeseForm(Car _car)
        {
            InitializeComponent();
            car = _car;
            DateTimeNach.Value = car.arenda_nach;
            DateTimeKonec.Value = car.arenda_konec;
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            var result = Park.RenewLease(car.id.ToString(), DateTimeNach.Value.ToString("yyyy-MM-dd"), DateTimeKonec.Value.ToString("yyyy-MM-dd"));
            if (result != "")
            {
                MetroMessageBox.Show(this, "При продлении договора аренды произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                Close();
            }
            else
            {
                Close();
            }
        }
    }
}
