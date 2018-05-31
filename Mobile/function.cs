using Android.App;
using Android.Content;
using Android.Util;

namespace Mobile
{
    class function
    {
        public static float convertDpToPixel(float dp, Context context)
        {
            #pragma warning disable CS0618 // ��� ��� ���� �������
            float px = dp * ((float)context.Resources.DisplayMetrics.DensityDpi / (float)DisplayMetrics.DensityDefault);
            #pragma warning restore CS0618 // ��� ��� ���� �������
            return px;
        }

        public static void AlertDialogShow(string zagolovok, string messeg, Context instance)
        {
            var dlg = new AlertDialog.Builder(instance);//��������� ���������� ��� ������������ ���������
            AlertDialog alert = dlg.Create(); //������� ��������� ����
            alert.SetTitle(zagolovok);//��������� ��� ���������
            alert.SetButton("�������", delegate
            {//��������� ��� ����� ��������� �� ������
                alert.Dismiss();//�������� ��� ��� ������� �� ���� ������� ����
            });
            alert.SetMessage(messeg);//����� ���������

            alert.Show();//���������� ���� ������������
        }
    }
}