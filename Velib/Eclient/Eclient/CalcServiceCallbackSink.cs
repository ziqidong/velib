using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsClient
{
    class CalcServiceCallbackSink : Eclient.ServiceReference1.ICalcServiiiiiiiiiiiceCallback
    {
        public void Sent(string name)
        {
            Console.WriteLine(name);
        }

        public void SentFinished()
        {
            Console.WriteLine("Information received");
        }
    }
}

