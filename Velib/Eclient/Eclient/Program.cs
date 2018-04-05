using System;
using System.Text;
using System.ServiceModel;

namespace EventsClient
{
    class Program
    {
        static void Main(string[] args)
        {

            CalcServiceCallbackSink objsink = new CalcServiceCallbackSink();
            InstanceContext iCntxt = new InstanceContext(objsink);

            Eclient.ServiceReference1.CalcServiiiiiiiiiiiceClient objClient = new Eclient.ServiceReference1.CalcServiiiiiiiiiiiceClient(iCntxt);
            objClient.SubscribeSentEvent();
            objClient.SubscribeSendFinishedEvent();

            Console.WriteLine("Input a city:");
            string a = Console.ReadLine();
            objClient.SendInfo(a);

            Console.WriteLine("Press any key to close ...");
            Console.ReadKey();
        }
    }
}
