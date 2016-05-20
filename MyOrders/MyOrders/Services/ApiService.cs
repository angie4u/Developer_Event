using MyOrders.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyOrders.Services
{
    public class ApiService
    {
        

        public async Task<List<Order>> GetAllOrders()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "http://ninjatips.azurewebsites.net/tables/Orders";
                client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
                var result = await client.GetAsync(url);

                string data = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<Order>>(data);
                }
                else
                    return new List<Order>();
            }
        }

        //public async Task<Order> CreateOrder(Order newOrder)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        string url = "http://ninjatips.azurewebsites.net/tables/Orders";
        //        client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");

        //        string content = JsonConvert.SerializeObject(newOrder);
        //        StringContent body = new StringContent(content, Encoding.UTF8, "application/json");
        //        var result = await client.PostAsync(url, body);

        //        string data = await result.Content.ReadAsStringAsync();

        //        if (result.IsSuccessStatusCode)
        //        {
        //            return JsonConvert.DeserializeObject<Order>(data);
        //        }
        //        else
        //            return null;
        //    }
        //}

       
        
        public async Task<List<Event>> GetAllEvent(DateTime today)
        {
            //DateTime today = DateTime.Now;
            
            List<Event> eventList = new List<Event>();
            HttpClient Client = new HttpClient();
            int datediff = 0;
            string param = today.ToString("yyyy-MM-dd");
            Uri myUri = new Uri("http://sevenstars.azurewebsites.net/EventModels/getThisMonthEvent/" + param);

            HttpResponseMessage response = await Client.GetAsync(myUri);
            string jsonString = await response.Content.ReadAsStringAsync();


            //JObject obj = JObject.Parse(jsonString);
            JArray array = JArray.Parse(jsonString);

            int eventCount = array.Count;


            for (int i = 0; i < eventCount; i++)
            {
                Event e = new Event();

                e.ID = array[i].Value<int>("ID");
                e.EventTitle = array[i].Value<string>("EventTitle");
                e.EventStartDay = array[i].Value<DateTime>("EventStartDay");
                e.EventEndDay = array[i].Value<DateTime>("EventEndDay");
                e.Venue = array[i].Value<string>("Venue");
                e.locationX = array[i].Value<double>("locationX");
                e.locationY = array[i].Value<double>("locationY");
                e.Audience = array[i].Value<string>("Audience");
                e.Description = array[i].Value<string>("Description");
                e.Agenda = array[i].Value<string>("Agenda");
                e.Speaker = array[i].Value<string>("Speaker");
                e.RegistrationURL = array[i].Value<string>("RegistrationURL");
                e.ContentsURL = array[i].Value<string>("ContentsURL");
                e.ImageNumber = array[i].Value<int>("ImageNumber");
                e.ImageURL = array[i].Value<string>("ImageURL");

                DateTime currentDate = DateTime.Today;
                datediff = (int)(currentDate - e.EventStartDay).TotalDays;
                e.EventDday = "D" + String.Format("{0:+#;#}", datediff.ToString());

                eventList.Add(e);

            }

            return eventList;

        } 

       
    }
}
