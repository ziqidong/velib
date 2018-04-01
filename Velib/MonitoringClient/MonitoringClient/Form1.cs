using MonitoringClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoringClient
{
    public partial class Form1 : Form
    {
        ServiceReference1.Service1Client proxy = new Service1Client();

        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int clientquantity = proxy.ClientQuantity();
            listBox1.Items.Add(clientquantity);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string delay = proxy.GetAverageRequestDelay();
            listBox2.Items.Add(delay);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            int clientrequestquantity = proxy.ClientRequestQuantity();
            listBox3.Items.Add(clientrequestquantity);
        }
    }
}
