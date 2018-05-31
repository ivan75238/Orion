using Android.App;
using Android.Content;
using Android.Util;

namespace Mobile
{
    class function
    {
        public static float convertDpToPixel(float dp, Context context)
        {
            #pragma warning disable CS0618 // Тип или член устарел
            float px = dp * ((float)context.Resources.DisplayMetrics.DensityDpi / (float)DisplayMetrics.DensityDefault);
            #pragma warning restore CS0618 // Тип или член устарел
            return px;
        }

        public static void AlertDialogShow(string zagolovok, string messeg, Context instance)
        {
            var dlg = new AlertDialog.Builder(instance);//указываем переменную для всплывающего сообщения
            AlertDialog alert = dlg.Create(); //создаем далоговое окно
            alert.SetTitle(zagolovok);//указываем его заголовок
            alert.SetButton("Закрыть", delegate
            {//указываем что будет написанно на кнопке
                alert.Dismiss();//указывем что при нажатии ОК надо закрыть окно
            });
            alert.SetMessage(messeg);//текст сообщения

            alert.Show();//показываем окно пользователю
        }
    }
}