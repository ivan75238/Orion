using GlobalLib;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Orion
{
    public partial class CreateNewPriceForm : MetroForm
    {
        List<Rout> marshruts;
        public CreateNewPriceForm()
        {
            InitializeComponent();
            marshruts = Routs.GetMarshruts();
            for (int i = 0; i < marshruts.Count; i += 2)
            {
                ComboBoxPriceMarsh.Items.Add(marshruts[i].name);
            }
            ComboBoxPriceMarsh.SelectedIndex = 0;
            marshruts[0].GetPromPynkt();
            int j = marshruts[0].PromPynkt.Count - 1;
            for(int i = 0; i < marshruts[0].PromPynkt.Count; i++)
            {
                ComboBoxPriceOtkuda.Items.Add(marshruts[0].PromPynkt[i].name);
                ComboBoxPriceKyda.Items.Add(marshruts[0].PromPynkt[j].name);
                j--;
            }
            ComboBoxPriceKyda.SelectedIndex = 0;
            ComboBoxPriceOtkuda.SelectedIndex = 0;
        }

        private void TextBoxPriceCout_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxPriceCout.Text != "")
            {
                try
                {
                    int mesto = Convert.ToInt32(TextBoxPriceCout.Text);
                }
                catch (Exception)
                {
                    MetroMessageBox.Show(this, "В поле 'Стоимость' могут быть только цифры.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    TextBoxPriceCout.Text = "";
                }
            }
        }

        private void ButtonAddPrice_Click(object sender, EventArgs e)
        {
            var result = new Price
            {
                Otkyda = marshruts[ComboBoxPriceMarsh.SelectedIndex].PromPynkt[ComboBoxPriceOtkuda.SelectedIndex].id.ToString(),
                Kyda = marshruts[ComboBoxPriceMarsh.SelectedIndex].PromPynkt[marshruts[ComboBoxPriceMarsh.SelectedIndex].PromPynkt.Count - 1 - ComboBoxPriceOtkuda.SelectedIndex].id.ToString(),
                cost = Convert.ToInt32(TextBoxPriceCout.Text),
                id_marsh = marshruts[ComboBoxPriceMarsh.SelectedIndex].id
            }.Create();
            if (result != "")
            {
                MetroMessageBox.Show(this, "При создании новой стоимости между пунктами произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                Close();
            }
            else
            {
                Close();
            }
        }
    }
}
