using GalaSoft.MvvmLight.Command;
using MyOrders.Models;
using MyOrders.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyOrders.ViewModels
{
    public class OrderViewModel
    {
        ApiService apiService;
        DialogService dialogService;

        public OrderViewModel()
        {
            apiService = new ApiService();
            dialogService = new DialogService();
            DeliveryDate = DateTime.Today;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryInformation { get; set; }
        public string Client { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime MinimumDate { get; private set; }

        public int ID { get; set; }
        public string EventTitle { get; set; }
        public DateTime EventStartDay { get; set; }
        public DateTime EventEndDay { get; set; }
        public string Venue { get; set; }
        public double locationX { get; set; }
        public double locationY { get; set; }
        public string Audience { get; set; }
        //public string Description { get; set; }
        public string Agenda { get; set; }
        public string Speaker { get; set; }
        public string RegistrationURL { get; set; }
        public string ContentsURL { get; set; }
        public int ImageNumber { get; set; }
        public string ImageURL { get; set; }

        public string EventDday { get; set; }
        public string lstColor { get; set; }
        public string txtColor { get; set; }



        public ICommand SaveCommand
        {
            get { return new RelayCommand(Save); }
        }


        private async void Save()
        {
            try
            {
                await apiService.CreateOrder(new Order()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = this.Title,
                    Client = this.Client,
                    DeliveryDate = this.DeliveryDate,
                    DeliveryInformation = this.DeliveryInformation,
                    Description = this.Description,                                        
                    IsDelivered = false                                    
                    ,
                    
            });

                await dialogService.ShowMessage("El pedido ha sido creado.", "Información");
            }
            catch 
	        {
                await dialogService.ShowMessage("Ha ocuarrido un error inesperado.", "Error");
            }
        }
    }
}
