using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MyOrders.Pages
{
    public partial class EventDetailPage : ContentPage
    {
        DateTime today = DateTime.Now;
        string ContentsURL;
        string RegistrationURL;
        DateTime eventDay;

        
        public EventDetailPage(double x, double y,string name, DateTime eventDay, string ContentsURL, string RegistrationURL, string Audience)
        {
            InitializeComponent();
            string location = name;
            this.eventDay = eventDay;
            this.ContentsURL = ContentsURL;
            this.RegistrationURL = RegistrationURL;
            
            MyMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(x, y), Distance.FromMiles(0.3)));

            var position = new Position(x, y);
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = location
            };
            MyMap.Pins.Add(pin);

            if (String.IsNullOrEmpty(Audience))
            {
                targetAudience.IsVisible = false;
            }

            whichDate.Text = eventDay.ToString("dddd", new CultureInfo("ko-KR"));
                

            if (today > eventDay)
            {
                if (!String.IsNullOrEmpty(ContentsURL))
                {
                    MyButton.Text = "다시보기";
                    Navigation.PushAsync(new WebViewPage(ContentsURL, "다시보기"));
                }
                else
                {
                    MyButton.IsVisible = false;
                }
            }
            else 
            {
                if (String.IsNullOrEmpty(RegistrationURL))
                {
                    MyButton.IsVisible = false;
                }
                else
                {
                    MyButton.Text = "등록하기";
                    Navigation.PushAsync(new WebViewPage(RegistrationURL, "등록하기"));
                }
                
            }

    
            
        }

        void ButtonClicked(object sender, EventArgs args)
        {
            if(DateTime.Now > eventDay)
            {
                //행사날짜가 지난경우 -> 다시보기 페이지로 이동
                Navigation.PushAsync(new WebViewPage(ContentsURL,"다시보기"));
            }
            //행사가 지나지 않았으므로 -> 등록하기 페이지로 이동
            else
            {
                Navigation.PushAsync(new WebViewPage(RegistrationURL, "등록하기"));
            }
            
        }

    }
}
