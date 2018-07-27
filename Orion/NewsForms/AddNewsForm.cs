using System;
using GlobalLib;
using MetroFramework.Forms;
using System.Linq;
using System.Windows.Forms;
using MetroFramework;

namespace Orion
{
    public partial class AddNewsForm : MetroForm
    {
        private News news;
        private string uploadFileName, uploadFileNamePath;

        public AddNewsForm()
        {
            InitializeComponent();
            DateTimePublication.Value = DateTime.Now;
        }
        
        public AddNewsForm(News _news)
        {
            InitializeComponent();
            Text = "Редактор новости";
            ButtonAdd.Text = "Сохранить";
            news = _news;
            TextBoxTitle.Text = news.title;
            TextBoxMessage.Text = news.messages;
            DateTimePublication.Value = news.date;
            var file_mass = news.image_url.Split('/');
            LabelNameImage.Text = file_mass.Last();
            uploadFileName = news.image_url;
        }

        private void ButtonSelectImage_Click(object sender, System.EventArgs e)
        {
            if (openFileDialogImage.ShowDialog() == DialogResult.OK)
            {
                uploadFileName = openFileDialogImage.FileName;
            }
        }

        private void ButtonAdd_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxTitle.Text))
            {
                if (!string.IsNullOrEmpty(TextBoxMessage.Text))
                {
                    if (!string.IsNullOrEmpty(uploadFileName))
                    {
                        if (news == null)
                            CreateNews();
                        else
                            EditNews();

                    }
                    else
                        MetroMessageBox.Show(this, "Выберите изображение", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                    MetroMessageBox.Show(this, "Введите сообщение новости", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
                MetroMessageBox.Show(this, "Введите заголовок новости", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void CreateNews()
        {
            uploadFileNamePath = ApiFile.Upload(uploadFileName, $"news_{((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString()}", ApiFilePath.News);
            News.Create(new News
            {
                title = TextBoxTitle.Text,
                messages = TextBoxMessage.Text,
                date = DateTimePublication.Value,
                image_url = uploadFileNamePath,
                id_user = User.GetInstance().id
            });
            MetroMessageBox.Show(this, "Новость опубликована", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
            Close();
        }

        private void EditNews()
        {
            if (uploadFileName != news.image_url)
                uploadFileNamePath = ApiFile.Upload(uploadFileName, $"news_{((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString()}", ApiFilePath.News);
            else
                uploadFileNamePath = uploadFileName;
            News.Edit(new News
            {
                id = news.id,
                title = TextBoxTitle.Text,
                messages = TextBoxMessage.Text,
                date = DateTimePublication.Value,
                image_url = uploadFileNamePath,
                id_user = User.GetInstance().id
            });
            MetroMessageBox.Show(this, "Новость изменена", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
            Close();
        }
    }
}
