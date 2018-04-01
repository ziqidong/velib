using System;
//using System.ServiceModel.Web;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Host
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class Service1 : IService1, wcf
    {
        System.Web.Caching.Cache objCache = HttpRuntime.Cache;

        System.Web.Caching.Cache monitoring = HttpRuntime.Cache;

        public JArray lastcity;

        public string hehe()
        {
            return "hehe";
        }
        
        //public async Task<string> DoWork(int id)
        public string DoWork(int id)
        {
            //Task<string> a = haha(id);
            //string result = await a;
            if (monitoring["clientquantity"] == null)
            {
                monitoring.Insert("clientquantity", 1);
            }
            else
            {
                monitoring["clientquantity"] = ((int)monitoring["clientquantity"]) + 1;
            }
            Thread.Sleep(2000);
            return string.Format("经过平方后的值为：{0}", id * id);
        }

        public string Getcitys()
        {
            if (monitoring["clientrequestquantity"] == null)
            {
                monitoring.Insert("clientrequestquantity", 1);
            }
            else
            {
                monitoring["clientrequestquantity"] = ((int)monitoring["clientrequestquantity"]) + 1;
            }
            Task<string> a = getcitys();
            return a.Result;
        }

        public string GetOneCity(string id)
        {
            if (monitoring["clientrequestquantity"] == null)
            {
                monitoring.Insert("clientrequestquantity", 1);
            }
            else
            {
                monitoring["clientrequestquantity"] = ((int)monitoring["clientrequestquantity"]) + 1;
            }
            Task<string> a = getonecity(id);
            return a.Result;
        }

        public string GetStation(string id)
        {
            if (monitoring["clientrequestquantity"] == null)
            {
                monitoring.Insert("clientrequestquantity", 1);
            }
            else
            {
                monitoring["clientrequestquantity"] = ((int)monitoring["clientrequestquantity"]) + 1;
            }
            Task<string> a = getstation(id);
            return a.Result;
        }

        public int ClientQuantity()
        {
            if(monitoring["clientquantity"] == null)
            {
                return 0;
            }
            else
            {
                return (int)monitoring["clientquantity"];
            }
        }

        public int ClientRequestQuantity()
        {
            if (monitoring["clientrequestquantity"] == null)
            {
                return 0;
            }
            else
            {
                return (int)monitoring["clientrequestquantity"];
            }
        }

        public void SetRequestDelay(int delay)
        {
            if (monitoring["delay"] == null)
            {
                monitoring.Insert("delay", new delays());
                ((delays)monitoring["delay"]).adddelay(delay);
            }
            else
            {
                ((delays)monitoring["delay"]).adddelay(delay);
            }
        }
        
        public string GetAverageRequestDelay()
        {
            int delay = 0;
            if (monitoring["delay"] == null)
            {
                return "No record.";
            }
            else
            {
                 return "Average delay is " + ((delays)monitoring["delay"]).calculatedelay() + "ms.";
            }
        }

        private async Task<string> getcitys()
        {
            Task<string> op = getcityss();
            string opp = await op;
            return opp;
        }
        private async Task<string> getcityss()
        {
            return await Task.Run<string>(() => {
                string cityss = "";
                WebRequest rq = WebRequest.Create("https://api.jcdecaux.com/vls/v1/contracts/?apiKey=a128869411f54eff41401cba4a717e9d42f9595a");
                rq.ContentType = "text/html;charset=UTF-8";
                rq.Method = "GET";
                WebResponse rp = rq.GetResponse();
                Stream dataStreamcity = rp.GetResponseStream();
                StreamReader citys = new StreamReader(dataStreamcity);
                string cityy = citys.ReadToEnd();
                JArray jaa = (JArray)JsonConvert.DeserializeObject(cityy);
                foreach (JObject jo in jaa)
                {
                    String pp = jo.ToString();
                    String City = (String)jo["name"];
                    cityss += City + "\n";
                }
                return cityss;
            });
        }

        private async Task<string> getonecity(string id)
        {
            Task<string> op = getonecityy(id);
            string opp = await op;
            return opp;
        }
        private async Task<string> getonecityy(string id)
        {
            return await Task.Run<string>(() =>
           {
               string stations = "";
               //foreach (City cy in citylist)
               //{
               //    if (cy.cityname.Equals(id))
               //    {
               //        foreach (JObject jo in cy.city)
               //        {
               //            String pp = jo.ToString();
               //            String name = (String)jo["name"];
               //            stations += name + "\n";
               //        }
               //        lastcity = cy.city;
               //        return stations;
               //    }
               //}
               if(objCache[id] != null)
               {
                   foreach (JObject jo in ((City)objCache[id]).city)
                   {
                       String pp = jo.ToString();
                       String name = (String)jo["name"];
                       stations += name + "\n";
                   }
                   lastcity = ((City)objCache[id]).city;
                   return stations;
               }
               WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + id + "&apiKey=a128869411f54eff41401cba4a717e9d42f9595a");
               request.ContentType = "text/html;charset=UTF-8";
               request.Method = "GET";
                //request.Credentials = CredentialCache.DefaultCredentials;

                WebResponse response = request.GetResponse();

                //Console.WriteLine (((HttpWebResponse)response).StatusDescription);

                Stream dataStream = response.GetResponseStream();

               StreamReader reader = new StreamReader(dataStream);

               string responseFromServer = reader.ReadToEnd();

               JArray ja = (JArray)JsonConvert.DeserializeObject(responseFromServer);

               //citylist.Add(new City(id, ja));
               objCache.Insert(id, new City(id, ja));

               lastcity = ja;

               foreach (JObject jo in ja)
               {
                   String pp = jo.ToString();
                   String name = (String)jo["name"];
                   stations += name + "\n";
               }
               return stations;
           });
        }

        private async Task<string> getstation(string id)
        {
            Task<string> op = getstationn(id);
            string opp = await op;
            return opp;
        }
        private async Task<string> getstationn(string id)
        {
            return await Task.Run<string>(() =>
         {
             string station = "Station not found";
             foreach (JObject jo in lastcity)
             {
                 String add = (String)jo["name"];
                 if (add.Equals(id))
                 {
                     station = "";
                     station += "Number : " + (String)jo["number"] + "\n";
                     station += "Name : " + (String)jo["name"] + "\n";
                     station += "Address : " + (String)jo["address"] + "\n";
                     station += "Lat : " + (String)jo["position"]["lat"] + "\n";
                     station += "Lng : " + (String)jo["position"]["lng"] + "\n";
                     station += "Banking" + (String)jo["banking"] + "\n";
                     station += "Bonus : " + (String)jo["bonus"] + "\n";
                     station += "Status :" + (String)jo["status"] + "\n";
                     station += "Contract_name : " + (String)jo["contract_name"] + "\n";
                     station += "Bike_stands : " + (String)jo["bike_stands"] + "\n";
                     station += "Available_bike_stands : " + (String)jo["available_bike_stands"] + "\n";
                     station += "Available_bikes : " + (String)jo["available_bikes"] + "\n";
                     station += "Last_update : " + (String)jo["last_update"] + "\n";
                 }
             }
             Console.WriteLine(station);
             return station;
         });
        }
        //[WebInvoke(Method = "GET",
        //    ResponseFormat = WebMessageFormat.Json,
        //    UriTemplate = "data/{id}")]
        //public Person GetData(string id)
        //{
        //    return new Person()
        //    {
        //        id = Convert.ToInt32(id),
        //        name = "wocao"
        //    };
        //}
    }

    public class City
    {
        public City(string cityname, JArray city)
        {
            this.city = city;
            this.cityname = cityname;
        }
        public string cityname;
        public JArray city;
    }

    public class delays
    {
        public delays()
        {
            delayy = new List<int>();
        }

        public void adddelay(int delay)
        {
            delayy.Add(delay);
        }

        public int calculatedelay()
        {
            int delay = 0;
            foreach(int d in delayy)
            {
                delay += d;
            }
            return delay / (delayy.Count);
        }

        public List<int> delayy;
    }
}
