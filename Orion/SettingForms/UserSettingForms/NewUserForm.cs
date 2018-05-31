using GlobalLib;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace Orion
{
    public partial class NewUserForm : MetroForm
    {
        User SetUser;
        public NewUserForm(User _user)
        {
            InitializeComponent();
            ComboBoxRole.Items.Add("Диспетчер");
            ComboBoxRole.Items.Add("Администратор");
            TextBoxPass.PasswordChar = '*';
            if (_user != null)
            {
                SetUser = _user;
                TextBoxFio.Text = SetUser.name;
                if (SetUser.role == "0")
                    ComboBoxRole.SelectedIndex = 0;
                else
                    ComboBoxRole.SelectedIndex = 1;
                ButtonAdd.Text = "Изменить";
                Text = "Редактор пользоателя";
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (ButtonAdd.Text == "Изменить")
            {
                var result = new User
                {
                    id = SetUser.id,
                    name = TextBoxFio.Text,
                    role = ComboBoxRole.SelectedIndex.ToString(),
                    pass = TextBoxPass.Text
                }.Set();
                if (result != "")
                {
                    MetroMessageBox.Show(this, "При зменении данных пользователя произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Close();
                }
                else
                {
                    Close();
                }
            }
            else
            {
                var result = new User
                {
                    name = TextBoxFio.Text,
                    pass = TextBoxPass.Text,
                    role = ComboBoxRole.SelectedIndex.ToString()
                }.Create();
                if (result != "")
                {
                    MetroMessageBox.Show(this, "При зменении данных пользователя произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
