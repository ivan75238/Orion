using GlobalLib;
using MetroFramework;
using MetroFramework.Forms;
using System.Windows.Forms;

namespace Orion
{
    public partial class NewPassword : MetroForm
    {
        User user;
        public NewPassword(User _user)
        {
            InitializeComponent();
            user = _user;
        }
        private void ButtonChangePassword_Click(object sender, System.EventArgs e)
        {
            if (TextBoxPass.Text != "") {
                var result = user.ChangePassword(TextBoxPass.Text);
                if (result != "")
                {
                    MetroMessageBox.Show(this, "При изменении пароля произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Close();
                }
                else
                {
                    Close();
                }
            } else
            {
                MetroMessageBox.Show(this, "Пароль не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
    }
}
