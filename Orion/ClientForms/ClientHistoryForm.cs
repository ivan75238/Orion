using GlobalLib;
using MetroFramework.Forms;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Orion
{
    public partial class ClientHistoryForm : MetroForm
    {
        List<OrderInService> orders;
        public ClientHistoryForm(int clientID)
        {
            InitializeComponent();
            orders = Orders.GetClientHistory(clientID);
            DataGridOrders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DataGridOrders.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            for (int i = 0; i < orders.Count; i++)
            {
                string status = functions.CheckStatus(orders[i].status);
                DataGridOrders.Rows.Add(orders[i].data.ToShortDateString(), orders[i].type_bilet, orders[i].name_marsh, orders[i].otkyda, orders[i].kyda, orders[i].mesto, orders[i].voditel, orders[i].gos_nomer, orders[i].cost, status);
            }
        }

        private void DataGridOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            functions.ConvertHtmlToImage(orders[e.RowIndex]);
        }
    }
}
