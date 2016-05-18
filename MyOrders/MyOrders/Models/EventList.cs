using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrders.Models
{
    public class Event
    {
        //public int ID { get; set; }
        //public string EventTitle { get; set; }
        //public DateTime EventStartDay { get; set; }
        //public DateTime EventEndDay { get; set; }
        //public string Venue { get; set; }
        //public double locationX { get; set; }
        //public double locationY { get; set; }
        //public string Audience { get; set; }
        //public string Description { get; set; }
        //public string Agenda { get; set; }
        //public string Speaker { get; set; }
        //public string RegistrationURL { get; set; }
        //public string ContentsURL { get; set; }
        //public int ImageNumber { get; set; }
        //public string ImageURL { get; set; }

        //public string EventDday { get; set; }
        //public string lstColor { get; set; }
        //public string txtColor { get; set; }
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

    }
}
