using GalaSoft.MvvmLight.Command;
using MyOrders.Pages;
using MyOrders.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyOrders.ViewModels
{
    public class MainViewModel
    {
        NavigationService navigationService;
        ApiService apiService;

        public MainViewModel()
        {
            navigationService = new NavigationService();
            apiService = new ApiService();

            Orders = new ObservableCollection<OrderViewModel>();

            LoadMenu();
           
            

        }

        #region Properties

        public OrderViewModel NewOrder { get; private set; }

        public ObservableCollection<OrderViewModel> Orders { get; set; }
        
        public ObservableCollection<EventViewModel> Events { get; set; }

        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        #endregion

        #region Commands
        public ICommand GoToCommand
        {
            get { return new RelayCommand<string>(GoTo); }
        }

        private void GoTo(string pageName)
        {
            switch (pageName)
            {
                case "NewOrderPage":
                    NewOrder = new OrderViewModel();
                    break;
                default:
                    break;
            }
            navigationService.Navigate(pageName);
        }

        public ICommand StartCommand
        {
            get { return new RelayCommand(Start); }
        }


        private async void Start()
        {
            DateTime today = DateTime.Now;
            var list = await apiService.GetAllEvent(today);
            //Orders.Clear();

            foreach (var item in list)
            {
                string imageURL = "img" + item.ImageNumber + ".png";

                Orders.Add(new OrderViewModel()
                {
                    Title = item.EventTitle,
                    DeliveryDate = item.EventStartDay,
                    Description = item.Description,
                    Image = imageURL,

                    //Event Model 때문에 추가하는 항
                    ID = item.ID,
                    EventTitle = item.EventTitle,
                    EventStartDay = item.EventStartDay,
                    EventEndDay = item.EventEndDay,
                    Venue = item.Venue,
                    locationX = item.locationX,
                    locationY = item.locationY,
                    Audience = item.Audience,
                    Agenda = item.Agenda,
                    Speaker = item.Speaker,
                    RegistrationURL = item.RegistrationURL,
                    ContentsURL = item.ContentsURL,
                    ImageNumber = item.ImageNumber,
                    EventDday = item.EventDday,
                    lstColor = item.lstColor,
                    txtColor = item.txtColor

                });
            }

            

            navigationService.SetMainPage("MasterPage");
        }

       



        #endregion

        #region Methods
        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_home",
                Title = "Home",
                PageName = "MainPage"
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_console",
                Title = "Microsoft Developer",
                PageName = "Microsoft Developer"
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_itpro",
                Title = "TechNet Korea",
                PageName = "TechNet Korea"
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_orders",
                Title = "MSDN",
                PageName = "MSDN"
            });
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_msdnnews",
                Title = "MSDN Newsletter",
                PageName = "MSDN Newsletter"
            });
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_technews",
                Title = "TechNet Newsletter",
                PageName = "TechNet Newsletter"
            });
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_eva",
                Title = "Technical Evangelist Blog",
                PageName = "Technical Evangelist Blog"
            });
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_conf",
                Title = "Conference",
                PageName = "Conference"
            });
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_ch9",
                Title = "Channel 9",
                PageName = "Channel 9"
            });




        }

      
        #endregion

        

    }
}
