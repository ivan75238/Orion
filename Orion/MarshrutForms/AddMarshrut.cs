using GlobalLib;
using GlobalLib.Item;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Orion
{
    public partial class AddMarshrut : MetroForm
    {
        Rout rout;
        public AddMarshrut(Rout _rout)
        {
            InitializeComponent();
            DataGridAllPP.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DataGridAllPP.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            rout = _rout;
            var pynkts = Routs.GetAllPromPynkt();
            for (int i = 0; i < pynkts.Count; i++)
            {
                DataGridAllPP.Rows.Add(pynkts[i].id, pynkts[i].name);
            }
            if (rout != null)
            {
                Text = "Редактор маршрута";
                NewMarshrutButtonAdd.Text = "Сохранить";
                TextBoxName.Text = rout.name;
                TextBoxUrl.Text = rout.url_map;
                rout.GetPromPynkt();
                for (int i = 0; i < rout.PromPynkt.Count; i++)
                {
                    DataGridPP.Rows.Add(rout.PromPynkt[i].id, rout.PromPynkt[i].name);
                }
            }
        }
        private void NewMarshrutButtonAdd_Click(object sender, EventArgs e)
        {
            if (TextBoxName.Text == "")
            {
                MetroMessageBox.Show(this, "Введите название маршрута", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                if (TextBoxUrl.Text == "")
                {
                    MetroMessageBox.Show(this, "Введите ссылку на карту маршрута", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    if (rout != null)
                    {
                        var PromPynkts = new List<IApi>();
                        for (int i = 0; i < DataGridPP.Rows.Count; i++)
                        {
                            PromPynkts.Add(new IApi
                            {
                                id = Convert.ToInt32(DataGridPP.Rows[i].Cells[0].Value),
                                name = DataGridPP.Rows[i].Cells[1].Value.ToString()
                            });
                        }
                        new Rout
                        {
                            id = rout.id,
                            name = TextBoxName.Text,
                            url_map = "1",
                            PromPynkt = PromPynkts
                        }.SetMarshrut();
                        Routs.SetMap(rout.id.ToString(), TextBoxUrl.Text);
                    }
                    else
                    {
                        var PromPynkts = new List<IApi>();
                        for (int i = 0; i < DataGridPP.Rows.Count; i++)
                        {
                            PromPynkts.Add(new IApi
                            {
                                id = Convert.ToInt32(DataGridPP.Rows[i].Cells[0].Value),
                                name = DataGridPP.Rows[i].Cells[1].Value.ToString()
                            });
                        }
                        var id = new Rout
                        {
                            name = TextBoxName.Text,
                            url_map = "1",
                            PromPynkt = PromPynkts
                        }.CreateMarshrut();
                        Routs.SetMap(id, TextBoxUrl.Text);
                    }
                    Close();
                }
            }
        }
        private void DataGridAllPP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridPP.Rows.Add(DataGridAllPP.Rows[e.RowIndex].Cells[0].Value, DataGridAllPP.Rows[e.RowIndex].Cells[1].Value);
        }
        private void DataGridPP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridPP.Rows.RemoveAt(e.RowIndex);
        }
        private void PictureBoxUp_Click(object sender, EventArgs e)
        {
            if (DataGridPP.CurrentCell.RowIndex != 0)
            {
                var position = DataGridPP.CurrentRow.Index;
                DataGridPP.Rows.Insert(position- 1, DataGridPP.Rows[DataGridPP.CurrentRow.Index].Cells[0].Value, DataGridPP.Rows[DataGridPP.CurrentRow.Index].Cells[1].Value);
                DataGridPP.Rows.RemoveAt(position + 1);
                DataGridPP.CurrentRow.Selected = false;
                DataGridPP.CurrentCell = DataGridPP.Rows[position - 1].Cells[0];
                DataGridPP.Rows[position - 1].Selected = true;
            }
        }
        private void PictureBoxDown_Click(object sender, EventArgs e)
        {
            if (DataGridPP.CurrentRow.Index != DataGridPP.Rows.Count-1)
            {
                var position = DataGridPP.CurrentRow.Index;
                DataGridPP.Rows.Insert(position + 2, DataGridPP.Rows[DataGridPP.CurrentRow.Index].Cells[0].Value, DataGridPP.Rows[DataGridPP.CurrentRow.Index].Cells[1].Value);
                DataGridPP.Rows.RemoveAt(position );
                DataGridPP.CurrentRow.Selected = false;
                DataGridPP.CurrentCell = DataGridPP.Rows[position + 1].Cells[0];
                DataGridPP.Rows[position + 1].Selected = true;
            }
        }
    }
}
