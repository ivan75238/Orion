using GlobalLib;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace Orion
{
    public partial class SetInformationInCarForm : MetroForm
    {
        Car car;
        public SetInformationInCarForm(Car _car)
        {
            InitializeComponent();
            car = _car;
            TextBoxGosNumber.Text = car.gos_nomer;
            TextBoxMarka.Text = car.marka;
            TextBoxVoditel.Text = car.voditel;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (TextBoxGosNumber.Text != "" && TextBoxMarka.Text != "" && TextBoxVoditel.Text != "")
            {
                var result = new Car {
                    id = car.id,
                    gos_nomer = TextBoxGosNumber.Text,
                    marka = TextBoxMarka.Text,
                    voditel = TextBoxVoditel.Text,
                }.Set();
                if (result != "")
                {
                    MetroMessageBox.Show(this, "При редактировании машины произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Close();
                }
                else
                {
                    Close();
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Заполните все поля.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
    }
}
