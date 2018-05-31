using GlobalLib;
using GlobalLib.Item;
using MetroFramework;
using MetroFramework.Forms;
using System.Windows.Forms;

namespace Orion
{
    public partial class PromPynktCatalogAddForm : MetroForm
    {
        User user;
        IApi pynkt;
        public PromPynktCatalogAddForm(IApi _pynkt)
        {
            InitializeComponent();
            user = User.GetInstance();
            if (_pynkt != null)
            {
                pynkt = _pynkt;
                TextBoxAddPP.Text = pynkt.name;
                ButtonAddPP.Text = "Сохранить";
            }
        }

        private void ButtonAddPP_Click(object sender, System.EventArgs e)
        {
            if (TextBoxAddPP.Text == "")
                MetroMessageBox.Show(this, "Вы не заполнили название промежуточного пункта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
            else
            {
                if (pynkt == null)
                {
                    var result = new IApi { name = TextBoxAddPP.Text }.Create();
                    if (result != "")
                    {
                        MetroMessageBox.Show(this, "При добавлении нового промежуточного пункта произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Нувый пункт добавлен в справочник.", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        Close();
                    }
                } 
                else
                {
                    var result = new IApi
                    {
                        id = pynkt.id,
                        name = TextBoxAddPP.Text
                    }.Set();
                    if (result != "")
                    {
                        MetroMessageBox.Show(this, "При редактировании промежуточного пункта произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Изменения успешно сохранены.", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        Close();
                    }
                }
            }
        }
    }
}
