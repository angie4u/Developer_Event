using MyOrders.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyOrders.Services
{
    public class NavigationService
    {
        public async void Navigate(string pageName)
        {
            App.Master.IsPresented = false;
            switch (pageName)
            {
                case "NewOrderPage":
                    await Navigate(new NewOrderPage());
                    break;
                case "AlarmsPage":
                    await Navigate(new AlarmsPage());
                    break;
                case "ClientsPage":
                    await Navigate(new WebViewPage("http://www.naver.com/",pageName));
                    break;
                case "SettingsPage":
                    await Navigate(new SettingsPage());
                    break;
                case "MainPage":
                    await App.Navigator.PopToRootAsync();
                    break;
                case "Microsoft Developer":
                    await Navigate(new WebViewPage("https://www.facebook.com/MicrosoftDeveloper.Korea", pageName));
                    break;
                case "TechNet Korea":
                    await Navigate(new WebViewPage("https://www.facebook.com/TechNetKorea", pageName));
                    break;
                case "MSDN":
                    await Navigate(new WebViewPage("https://msdn.microsoft.com", pageName));
                    break;
                case "MSDN Newsletter":
                    await Navigate(new WebViewPage("https://msdn.microsoft.com/ko-kr/aa940986", pageName));
                    break;
                case "TechNet Newsletter":
                    await Navigate(new WebViewPage("https://www.microsoft.com/korea/technet/flash/archive/default.mspx", pageName));
                    break;
                case "Technical Evangelist Blog":
                    await Navigate(new WebViewPage("https://blogs.msdn.microsoft.com/eva/", pageName));
                    break;
                case "Conference":
                    await Navigate(new WebViewPage("https://channel9.msdn.com/Events/Build/Build-Tour-Seoul-2015", pageName));
                    break;
                case "Channel 9":
                    await Navigate(new WebViewPage("https://channel9.msdn.com/", pageName));
                    break;
                default:
                    break;
            }
        }

        private static async Task Navigate<T>(T page) where T : Page
        {
            NavigationPage.SetHasBackButton(page, false);
            NavigationPage.SetBackButtonTitle(page, "Atrás"); //iOS

            await App.Navigator.PushAsync(page);
        }

        internal void SetMainPage(string pageName)
        {
            switch (pageName)
            {
                case "MasterPage":
                    App.Current.MainPage = new MasterPage();
                    break;
                default:
                    break;
            }
        }
    }
}
