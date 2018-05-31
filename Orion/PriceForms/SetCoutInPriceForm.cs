using GlobalLib;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace Orion
{
    public partial class SetCoutInPriceForm : MetroForm
    {
        string id;
        public SetCoutInPriceForm(string _id)
        {
            InitializeComponent();
            id = _id;
        }
        private void ButtonSet_Click(object sender, EventArgs e)
        {
            var result = new Price { id = Convert.ToInt32(id), cost = Convert.ToInt32(TextBoxCout.Text) }.Set();
            if (result != "")
            {
                MetroMessageBox.Show(this, "При изменении стоимости произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                Close();
            }
            else
            {
                Close();
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
    }
}
