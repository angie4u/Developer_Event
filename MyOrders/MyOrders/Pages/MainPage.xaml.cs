using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyOrders.Services;
using Xamarin.Forms;
using MyOrders.ViewModels;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MyOrders.Pages
{
    public partial class MainPage : ContentPage
    {
        DateTime today = DateTime.Now;

        public MainPage()
        {
            InitializeComponent();
            Month.Text = today.Month + "월 이벤트";            
        }

        void LastMonthClicked(object sender, EventArgs args)
        {
            today = today.AddMonths(-1);
            Month.Text = today.Month + "월 이벤트";
            Refresh(today);

        }

        void NextMonthClicked(object sender, EventArgs args)
        {
            today = today.AddMonths(1);
            Month.Text = today.Month + "월 이벤트";
            Refresh(today);

        }
       
        async void Refresh(DateTime today)
        {
            //OrderViewModel
            ApiService apiService = new ApiService();
            

            var list = await apiService.GetAllEvent(today);

           

            foreach (var item in list)
            {
                string ImageURL = "img" + item.ImageNumber + ".png";
                item.Title = item.EventTitle;
                item.DeliveryDate = item.EventStartDay;
                item.Description = item.Description;
                item.Image = ImageURL;
            }
            MyList.ItemsSource = list;
           


        }


        async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                if (e.SelectedItem is ViewModels.OrderViewModel)
                {
                    var list = e.SelectedItem as ViewModels.OrderViewModel;
                    var modelList = e.SelectedItem as Models.Event;
                    var eventDetailPage = new EventDetailPage(list.locationX, list.locationY, list.Venue, list.EventStartDay, list.ContentsURL, list.RegistrationURL, list.Audience);
                    eventDetailPage.BindingContext = list;

                    await Navigation.PushAsync(eventDetailPage);

                }
                else
                {
                    var list = e.SelectedItem as Models.Event;
                    var eventDetailPage = new EventDetailPage(list.locationX, list.locationY, list.Venue, list.EventStartDay, list.ContentsURL, list.RegistrationURL, list.Audience);
                    eventDetailPage.BindingContext = list;

                    await Navigation.PushAsync(eventDetailPage);

                }



            }
           

        }
       

    }
}
