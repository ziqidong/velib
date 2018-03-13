using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Client.ServiceReference1;//引用命名空间
using System.ServiceModel.Web;

using System.Windows.Forms;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 f= new Form1();
            
            Application.Run(f);
        }
    }
}
