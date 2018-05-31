using GlobalLib;
using MetroFramework.Forms;

namespace Orion
{
    public partial class ClientInfoForm : MetroForm
    {
        int ClientID;
        Client client;
        public ClientInfoForm(int _ClientID)
        {
            InitializeComponent();
            ClientID = _ClientID;
            client = Clients.GetClient(ClientID);
            LabelName.Text = client.fio;
            if (client.date.ToString("yyyy-MM-dd") != "1900-01-01")
                LabelDate.Text = client.date.ToString("dd.MM.yyyy");
            else
                LabelDate.Text = "информация отсутствует";
            if (client.email == "")
                LabelEmail.Text = "информация отсутствует";
            else
                LabelEmail.Text = client.email;
            LabelCountTrip.Text = client.count.ToString();
            LabelCost.Text = client.cost.ToString();
            LabelPhone.Text = client.phone;
            if (client.avatar != "")
                PictureBoxAva.Load("https://orion38.info/image/avatar/" + client.avatar);
        }

        private void ButtonEdit_Click(object sender, System.EventArgs e)
        {
            var SetClientForm = new EditClientDopInfoForm(client);
            SetClientForm.ShowDialog();
            client = Clients.GetClient(ClientID);
            LabelName.Text = client.fio;
            if (client.date.ToString("yyyy-MM-dd") != "1900-01-01")
                LabelDate.Text = client.date.ToString("dd.MM.yyyy");
            else
                LabelDate.Text = "информация отсутствует";
            if (client.email == "")
                LabelEmail.Text = "информация отсутствует";
            else
                LabelEmail.Text = client.email;
            if (client.avatar != "")
            {
                //Сделать загрузку аватари и её демонстрация
            }
            LabelCountTrip.Text = client.count.ToString();
            LabelCost.Text = client.cost.ToString();
            LabelPhone.Text = client.phone;
        }

        private void ButtonHistoryTrips_Click(object sender, System.EventArgs e)
        {
            var HistoryForm = new ClientHistoryForm(client.id);
            HistoryForm.ShowDialog();
        }
    }
}
