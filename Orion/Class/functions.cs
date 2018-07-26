using GlobalLib;
using MetroFramework.Controls;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.WinForms;

namespace Orion
{
    class functions
    {
        public static string CheckStatus (string status)
        {
            switch (status)
            {
                case "0":
                    status = "Оформлен";
                    break;
                case "1":
                    status = "Забронирован";
                    break;
                case "2":
                    status = "Оплачен полностью";
                    break;
                case "3":
                    status = "Отменен";
                    break;
            }
            return status;
        }
        public static void ClearButtonSvMesta (List<MetroButton> ButtonMas)
        {
            for (int i = 0; i < ButtonMas.Count; i++)
            {
                ButtonMas[i].UseCustomBackColor = false;
                ButtonMas[i].BackColor = Color.White;
                ButtonMas[i].TabStop = false;
            }
        }
        public static void CheckSvMestaOnShema (List<int> mesta, List<MetroButton> ButtonMas, List<int> ListMesta)
        {
            for (int i = 0; i < mesta.Count; i++)
            {
                if (mesta[i] == 1)
                {
                    ButtonMas[i].UseCustomBackColor = true;
                    ButtonMas[i].BackColor = Color.DimGray;
                }
                else
                {
                    if ((i+1) != mesta.Count)
                        ListMesta.Add(i+1);
                    else
                        ListMesta.Add(14);
                }
            }
        }
        public static void CheckSvMestaOnShema(List<int> mesta, List<MetroButton> ButtonMas, MetroComboBox ComboBox)
        {
            for (int i = 0; i < mesta.Count; i++)
            {
                if (mesta[i] == 1)
                {
                    ButtonMas[i].UseCustomBackColor = true;
                    ButtonMas[i].BackColor = Color.DimGray;
                }
                else
                {
                    if ((i + 1) != mesta.Count)
                        ComboBox.Items.Add((i+1).ToString());
                    else
                        ComboBox.Items.Add("14");
                }
            }
        }
        public static void CheckSvMestaOnShema(List<int> mesta, List<MetroButton> ButtonMas)
        {
            for (int i = 0; i < mesta.Count; i++)
            {
                if (mesta[i] == 1)
                {
                    ButtonMas[i].UseCustomBackColor = true;
                    ButtonMas[i].BackColor = Color.DimGray;
                }
            }
        }
        public static void ConvertHtmlToImage(OrderInService order)
        {
            Bitmap m_Bitmap = new Bitmap(720, 1024);
            PointF point = new PointF(0, 0);
            SizeF maxSize = new SizeF(720, 1024);
            Image image = HtmlRender.RenderToImage(
                "<html><head> <meta http-equiv = 'content-type' content = 'text/html; charset=utf-8' />" +
                "</head><body style=\"backgroud-color: #ffffff;\"><h1>Маршрутное такси 'Орион'</h1><h2>Билет</h2>" +
                "<table><tr><td style=\"text-align: center; border: 1px solid black; padding: 0px 15px;\">ФИО</td><td style=\"text-align: center; border: 1px solid black; padding: 0px 15px;\">Дата отправления</td><td style=\"text-align: center; border: 1px solid black; padding: 0px 15px;\">Место</td><td style=\"text-align: center; border: 1px solid black; padding: 0px 15px;\">Маршрут</td><td style=\"text-align: center; border: 1px solid black; padding: 0px 15px;\">Пункт отправления</td><td style=\"text-align: center; border: 1px solid black; padding: 0px 15px;\">Место прибытия</td><td style=\"text-align: center; border: 1px solid black; padding: 0px 15px;\">Тип билета</td></tr>" +
                "<tr><td style=\"text-align: center; border: 1px solid black; padding: 0px 15px;\">" + order.fio + "</td><td style=\"text-align: center; border: 1px solid black; padding: 0px 15px;\">" + order.data.ToShortDateString() + "</td><td style=\"text-align: center; border: 1px solid black; padding: 0px 15px;\">" + order.mesto + "</td><td style=\"text-align: center; border: 1px solid black; padding: 0px 15px;\">" + order.name_marsh + "</td><td style=\"text-align: center; border: 1px solid black; padding: 0px 15px;\">" + order.otkyda + "</td><td style=\"text-align: center; border: 1px solid black; padding: 0px 15px;\">" + order.kyda + "</td><td style=\"text-align: center; border: 1px solid black; padding: 0px 15px;\">" + order.type_bilet + "</td></tr></table>" +
                "<p>Номер заказа: " + order.id + "</p><p>Точное время и место посадки сообщит диспетчер.</p><p>Полная стоимость билета: " + order.cost + "руб.</p><p style=\"text-align: center;font-size: 17pt;\">Счастливого пути!</p></body></html>",
                new Size(950, 600), Color.White);
            image.Save(Application.StartupPath + @"\"+"bilet.png", ImageFormat.Png);
            Process.Start(Application.StartupPath + @"\" + "bilet.png");
        }
    }
}
