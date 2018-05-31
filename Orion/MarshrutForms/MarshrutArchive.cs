using GlobalLib;
using MetroFramework;
using MetroFramework.Forms;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Orion
{
    public partial class MarshrutArchive : MetroForm
    {
        List<Rout> marshruts;
        public MarshrutArchive()
        {
            InitializeComponent();
            GridMarshrut.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            GridMarshrut.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            marshruts = Routs.GetMarshrutInArchive();
            if (marshruts.Count == 0)
            {
                GridMarshrut.Rows.Add("В архиве нет маршрутов");
            }
            for (int i = 0; i < marshruts.Count; i++)
            {
                GridMarshrut.Rows.Add(marshruts[i].name);
            }
        }
        private void ButtonReturn_Click(object sender, System.EventArgs e)
        {
            if (GridMarshrut.Rows[GridMarshrut.CurrentCell.RowIndex].Cells[0].Value.ToString() != "В архиве нет маршрутов")
            {
                var result = marshruts[GridMarshrut.CurrentCell.RowIndex].Unarchive();
                if (result != "")
                {
                    MetroMessageBox.Show(this, "При восстановлении маршрута произошла ошибка: " + result + " Попробуйте позже или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MetroMessageBox.Show(this, "Маршрут успешно восстановлен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    GridMarshrut.Rows.Clear();
                    marshruts = Routs.GetMarshrutInArchive();
                    if (marshruts.Count == 0)
                    {
                        GridMarshrut.Rows.Add("В архиве нет маршрутов");
                    }
                    for (int i = 0; i < marshruts.Count; i++)
                    {
                        GridMarshrut.Rows.Add(marshruts[i].name);
                    }
                }
            }
        }
    }
}
