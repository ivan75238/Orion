using GlobalLib;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace Orion
{
    public partial class CreateNewCarForm : MetroForm
    {
        public CreateNewCarForm()
        {
            InitializeComponent();
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            if (TextBoxFIO.Text == "" || TextBoxGosNumber.Text == "" || TextBoxMarka.Text == "")
            {
                MetroMessageBox.Show(this, "Заполните все поля.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                if (DateTimeNach.Value.ToString("yyyy-MM-dd") == DateTimeKonec.Value.ToString("yyyy-MM-dd"))
                {
                    MetroMessageBox.Show(this, "Неправильно указаны даты аренды.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);

                } 
                else
                {
                    var result = new Car
                    {
                        marka = TextBoxMarka.Text,
                        gos_nomer = TextBoxGosNumber.Text,
                        voditel = TextBoxFIO.Text,
                        teh_obslyzh = Convert.ToInt32(ToggleTehObsl.Checked),
                        arenda_nach = DateTimeNach.Value,
                        arenda_konec = DateTimeKonec.Value,

                    }.Create();
                    if (result != "")
                    {
                        MetroMessageBox.Show(this, "При добавлении новой машины в парк произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        Close();
                    }
                    else
                    {
                        Close();
                    }
                }
            }
        }
    }
}
