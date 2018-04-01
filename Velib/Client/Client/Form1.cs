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

        int starttime = 0;

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
            starttime = getmilliseconds();
            proxy.GetcitysCompleted += proxy_Getcitys;
            proxy.GetcitysAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(lbshow.Items.Count == 0)
            {
                MessageBox.Show("Please get citys first", "error", MessageBoxButtons.OK);
            }
            else if(textBox2.Text == "")
            {
                MessageBox.Show("Must enter a city name", "error", MessageBoxButtons.OK);
            }
            else
            {
                starttime = getmilliseconds();
                proxy.GetStationCompleted += proxy_GetStation;
                proxy.GetStationAsync(textBox2.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lbshow.Items.Count == 0)
            {
                MessageBox.Show("Please get citys first", "error", MessageBoxButtons.OK);
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Must enter a city name", "error", MessageBoxButtons.OK);
            }
            else
            {
                Boolean y = false;
                foreach (string c in lbshow.Items)
                {
                    if (textBox1.Text == c)
                    {
                        starttime = getmilliseconds();
                        proxy.GetOneCityCompleted += proxy_GetOneCity;
                        proxy.GetOneCityAsync(textBox1.Text);
                        y = true;
                        break;
                    }
                }
                if (y == false) MessageBox.Show("City not found.", "error", MessageBoxButtons.OK);

            }
        }

        private void proxy_Getcitys(object sender, GetcitysCompletedEventArgs e)
        {
            lbshow.Items.Clear();
            string[] cc = Regex.Split(e.Result, "\n", RegexOptions.IgnoreCase);
            for (int i = 0; i < cc.Length; i++)
            {
                lbshow.Items.Add(cc[i]);
            }
            proxy.SetRequestDelay(getmilliseconds() - starttime);
        }

        private void proxy_GetStation(object sender, GetStationCompletedEventArgs e)
        {
            listBox2.Items.Clear();
            string[] ss = Regex.Split(e.Result, "\n", RegexOptions.IgnoreCase);
            for (int i = 0; i < ss.Length; i++)
            {
                listBox2.Items.Add(ss[i]);
            }
            proxy.SetRequestDelay(getmilliseconds() - starttime);
        }

        private void proxy_GetOneCity(object sender, GetOneCityCompletedEventArgs e)
        {
            listBox1.Items.Clear();
            string[] ss = Regex.Split(e.Result, "\n", RegexOptions.IgnoreCase);
            for (int i = 0; i < ss.Length; i++)
            {
                listBox1.Items.Add(ss[i]);
            }
            proxy.SetRequestDelay(getmilliseconds() - starttime);
        }

        public int getmilliseconds()
        {
            long currentTicks = DateTime.Now.Ticks;
            DateTime dtFrom = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long currentMillis = (currentTicks - dtFrom.Ticks) / 10000;
            return (int)currentMillis;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
