using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GlobalLib;

namespace Orion
{
    public partial class StartForm : MetroForm
    {
        User user;
        List<User> UsersInfo;
        public StartForm()
        {
            InitializeComponent();
            UsersInfo = Users.GetUsers();
            TextBoxPass.PasswordChar = '*';
            for (int i=0; i<UsersInfo.Count; i++)
            {
                ComboBoxUser.Items.Add(UsersInfo[i].name);
            }
            ComboBoxUser.SelectedIndex = 0;
        }

        private void ButtonIn_Click(object sender, EventArgs e)
        {
            if (ComboBoxUser.Text != "")
            {
                var result = Users.Login(UsersInfo[ComboBoxUser.SelectedIndex].id, GlobalLib.functions.GetHashPassword(TextBoxPass.Text));
                if ( result != null)
                {
                    user = User.GetInstance(result.id, result.name, result.role, result.token);
                    Hide();
                    var MainForm = new MainForm();
                    MainForm.Show();
                }
                else
                {
                    MetroMessageBox.Show(this, "Неверный пароль", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Выберите пользователя", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void ButtonOut_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
