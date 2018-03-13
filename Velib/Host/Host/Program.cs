using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Host.Service1)))
            {
                host.Open();
                Console.WriteLine("服务已经启动......");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}

/*
                WebRequest rq = WebRequest.Create("https://api.jcdecaux.com/vls/v1/contracts/?apiKey=a128869411f54eff41401cba4a717e9d42f9595a");
                rq.ContentType = "text/html;charset=UTF-8";
                rq.Method = "GET";
                WebResponse rp = rq.GetResponse();
                Stream dataStreamcity = rp.GetResponseStream();
                StreamReader citys = new StreamReader(dataStreamcity);
                string cityy = citys.ReadToEnd();
                JArray jaa = (JArray)JsonConvert.DeserializeObject(cityy);
                Console.WriteLine("List of cities :");
                foreach (JObject jo in jaa)
                {
                    String pp = jo.ToString();
                    String City = (String)jo["name"];
                    Console.WriteLine(City);
                }


                Console.WriteLine("Input a city:");
                String city = Console.ReadLine();

                // Create a request for the URL. 
                WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + city + "&apiKey=a128869411f54eff41401cba4a717e9d42f9595a");
                request.ContentType = "text/html;charset=UTF-8";
                request.Method = "GET";
                //request.Credentials = CredentialCache.DefaultCredentials;

                WebResponse response = request.GetResponse();

                //Console.WriteLine (((HttpWebResponse)response).StatusDescription);

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();

                JArray ja = (JArray)JsonConvert.DeserializeObject(responseFromServer);

                Console.WriteLine("List of stations : ");
                foreach (JObject jo in ja)
                {
                    String pp = jo.ToString();
                    String name = (String)jo["name"];
                    Console.WriteLine(name);
                    //                if (ad.Equals(add))
                    //                {
                    //                    Console.WriteLine(pp);
                    //                }

                    //                JsonParser jp = (JsonParser)JsonConvert.DeserializeObject(pp);
                    //                Console.WriteLine(jp.address);
                }
                Console.WriteLine("Input a station : ");
                String station = Console.ReadLine();
                foreach (JObject jo in ja)
                {
                    String add = (String)jo["name"];
                    if (add.Equals(station))
                    {
                        Console.WriteLine("Number : " + (String)jo["number"]);
                        Console.WriteLine("Name : " + (String)jo["name"]);
                        Console.WriteLine("Address : " + (String)jo["address"]);
                        Console.WriteLine("Lat : " + (String)jo["position"]["lat"]);
                        Console.WriteLine("Lng : " + (String)jo["position"]["lng"]);
                        Console.WriteLine("Banking" + (String)jo["banking"]);
                        Console.WriteLine("Bonus : " + (String)jo["bonus"]);
                        Console.WriteLine("Status :" + (String)jo["status"]);
                        Console.WriteLine("Contract_name : " + (String)jo["contract_name"]);
                        Console.WriteLine("Bike_stands : " + (String)jo["bike_stands"]);
                        Console.WriteLine("Available_bike_stands : " + (String)jo["available_bike_stands"]);
                        Console.WriteLine("Available_bikes : " + (String)jo["available_bikes"]);
                        Console.WriteLine("Last_update : " + (String)jo["last_update"]);
                    }
                }

                reader.Close();
                response.Close();
                */
