using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace browser
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }

        private void History_Load(object sender, EventArgs e)
        {
            for(int i=0;i<=Form1.history.Count-1;i++)
                listBox1.Items.Add(Form1.history[i]);
        }

        private void button2_Click(object sender, EventArgs e)
        {     
            Form1.history.Clear();
            listBox1.Items.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                Form1.history.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            else
                MessageBox.Show("Please Select item");
               
        }



        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                Form1 f = new Form1();
                f.webBrowser1.Navigate(listBox1.SelectedItem.ToString());
                f.webBrowser1.Navigate(listBox1.SelectedItem.ToString());
                f.UrlcompoBox.Text = listBox1.SelectedItem.ToString();
                f.tabPage1.Text = f.webBrowser1.DocumentTitle;
                f.Show();
                this.Close();
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
