using GlobalLib;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace Orion
{
    public partial class EditClientDopInfoForm : MetroForm
    {
        Client client;
        public EditClientDopInfoForm(Client _client)
        {
            InitializeComponent();
            client = _client;
            if (client != null)
            {
                TextBoxFIO.Text = client.fio;
                TextBoxPhone.Text = client.phone;
                TextBoxEmail.Text = client.email;
                DateTimeDR.Value = client.date;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (TextBoxFIO.Text != "")
            {
                if (TextBoxPhone.Text != "")
                {
                    string result = "";
                    if (TextBoxEmail.Text != "")
                    {
                        result = client.Set(TextBoxFIO.Text, TextBoxPhone.Text, DateTimeDR.Value, TextBoxEmail.Text);
                    }
                    else
                    {
                        result = client.Set(TextBoxFIO.Text, TextBoxPhone.Text, DateTimeDR.Value, "нет информации");
                    }
                    if (result != "")
                    {
                        MetroMessageBox.Show(this, "При редактировании клиента произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Изменения успешно сохранены.", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        Close();
                    }
                }
                else
                {

                }
            }
            else
            {

            }
        }
    }
}
