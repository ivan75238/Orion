using GlobalLib;
using GlobalLib.Item;
using MetroFramework;
using MetroFramework.Forms;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Orion
{
    public partial class PromPynktCatalogForm : MetroForm
    {
        User user;
        List<IApi> ListPP;
        public PromPynktCatalogForm()
        {
            InitializeComponent();
            DataGridPP.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DataGridPP.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            user = User.GetInstance();
            ListPP = Routs.GetAllPromPynkt();
            for (int i = 0; i < ListPP.Count; i++)
                DataGridPP.Rows.Add(ListPP[i].name);
        }
        private void ButtonDeletePP_Click(object sender, System.EventArgs e)
        {
            DialogResult dialogResult = MetroMessageBox.Show(this, "Вы действительно хотите удалить промежуточный пункт \""+ ListPP[DataGridPP.CurrentCell.RowIndex].name +"\"?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK)
            {
                var result = ListPP[DataGridPP.CurrentCell.RowIndex].Delete();
                if (result != "")
                {
                    MetroMessageBox.Show(this, "При добавлении нового рейса произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    ListPP = Routs.GetAllPromPynkt();
                    DataGridPP.Rows.Clear();
                    for (int i = 0; i < ListPP.Count; i++)
                    {
                        DataGridPP.Rows.Add(ListPP[i].name);
                    }
                }
            }
        }
        private void ButtonAddPP_Click(object sender, System.EventArgs e)
        {
            var NewPPForm = new PromPynktCatalogAddForm(null);
            NewPPForm.ShowDialog();
            DataGridPP.Rows.Clear();
            ListPP = Routs.GetAllPromPynkt();
            for (int i = 0; i < ListPP.Count; i++)
            {
                DataGridPP.Rows.Add(ListPP[i].name);
            }
        }
        private void ButtonSetPP_Click(object sender, System.EventArgs e)
        {
            var NewPPForm = new PromPynktCatalogAddForm(ListPP[DataGridPP.CurrentCell.RowIndex]);
            NewPPForm.ShowDialog();
            DataGridPP.Rows.Clear();
            ListPP = Routs.GetAllPromPynkt();
            for (int i = 0; i < ListPP.Count; i++)
            {
                DataGridPP.Rows.Add(ListPP[i].name);
            }
        }
    }
}
