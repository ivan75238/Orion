using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;
using Android.Webkit;

namespace Mobile
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait, Theme = "@style/Theme.AppCompat.Light.NoActionBar.FullScreen")]
    public class WebViewActivity : Activity
    {
        WebView web_view;
        TextView Label;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.WebViewLayout);
            Label = FindViewById<TextView>(Resource.Id.Label);
            string Url = Intent.GetStringExtra("url");
            Label.Text = "Оплата";
            web_view = FindViewById<WebView>(Resource.Id.webview);
            web_view.Settings.JavaScriptEnabled = true;
            web_view.LoadUrl(Url);
            web_view.SetWebViewClient(new HelloWebViewClient());
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.Back && web_view.CanGoBack())
            {
                web_view.GoBack();
                return true;
            }

            return base.OnKeyDown(keyCode, e);
        }
    }

    public class HelloWebViewClient : WebViewClient
    {
        #pragma warning disable CS0672 // Член переопределяет устаревший член
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        #pragma warning restore CS0672 // Член переопределяет устаревший член
        {
            view.LoadUrl(url);
            return true;
        }
    }
}