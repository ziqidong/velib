using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.ServiceModel;
using Client.ServiceReference1;//引用命名空间
using System.ServiceModel.Web;
using System.Text.RegularExpressions; 

namespace Client
{
    public partial class Form1 : Form
    {
        ServiceReference1.Service1Client proxy = new Service1Client();

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void lbshow_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string citys = proxy.Getcitys();
            string[] cc = Regex.Split(citys, "\n", RegexOptions.IgnoreCase);
            for (int i = 0; i < cc.Length; i++)
            {
                lbshow.Items.Add(cc[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string stations = proxy.GetStation(textBox2.Text);
            string[] ss = Regex.Split(stations, "\n", RegexOptions.IgnoreCase);
            for (int i = 0; i < ss.Length; i++)
            {
                listBox2.Items.Add(ss[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string stations = proxy.GetOneCity(textBox1.Text);
            string[] ss = Regex.Split(stations, "\n", RegexOptions.IgnoreCase);
            for (int i = 0; i < ss.Length; i++)
            {
                listBox1.Items.Add(ss[i]);
            }
        }
    }
}
