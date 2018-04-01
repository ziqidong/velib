using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            ServiceReference1.Service1Client proxy = new Service1Client();

            proxy.DoWorkCompleted += proxy_DoworkCompleted;
            proxy.DoWorkAsync(10);

            ServiceReference1.wcfClient op = new wcfClient();//服务端在一个服务中实现多个终结点，每个终结点对应多个契约，这里利用不同的终结点调用不同的契约，注意在服务端添加多个终结点时其identity属性必须一致
            string a = op.hehe();
            Console.WriteLine(a);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 f = new Form1();

            Application.Run(f);
        }

        private static void proxy_DoworkCompleted(object sender, DoWorkCompletedEventArgs e)
        {
            try
            {
                string a = e.Result;
                Console.WriteLine(a);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
