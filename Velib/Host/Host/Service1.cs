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

namespace Host
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class Service1 : IService1
    {
        public JArray lastcity;

        public List<City> citylist= new List<City>();

        public string DoWork(int id)
        {
            int iPingfang = id * id;
            return string.Format("经过平方后的值为：{0}", iPingfang);
        }

        public string Getcitys()
        {
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
        }

        public string GetOneCity(string id)
        {
            string stations = "";
            foreach (City cy in citylist)
            {
                if (cy.cityname.Equals(id))
                {
                    foreach (JObject jo in cy.city)
                    {
                        String pp = jo.ToString();
                        String name = (String)jo["name"];
                        stations += name + "\n";
                    }
                    lastcity = cy.city;
                    return stations;
                }
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

            citylist.Add(new City(id, ja));

            lastcity = ja;
            
            foreach (JObject jo in ja)
            {
                String pp = jo.ToString();
                String name = (String)jo["name"];
                stations += name + "\n";
            }
            return stations;
        }

        public string GetStation(string id)
        {
            string station = "";
            foreach (JObject jo in lastcity)
            {
                String add = (String)jo["name"];
                if (add.Equals(id))
                {
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
            return station;
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
}
