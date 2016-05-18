using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyOrders.Pages
{
    public partial class WebViewPage : ContentPage
    {
        public WebViewPage(string url, string name)
        {
            InitializeComponent();
            Browser.Source = url;
            Title = name;
            //WebView.SourceProperty = url;
        }
    }
}
