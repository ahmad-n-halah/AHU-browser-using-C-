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
    public partial class Favorites : Form
    {
        public Favorites()
        {
            InitializeComponent();
        }

        private void Favorites_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= Form1.favorites.Count - 1; i++)
                listBox1.Items.Add(Form1.favorites[i]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.favorites.Clear();
            listBox1.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (listBox1.SelectedIndex >= 0)
            {
                Form1.favorites.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            else
                MessageBox.Show("Please Select item");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                listBox1.Items.Add(textBox1.Text);
                Form1.favorites.Add(textBox1.Text);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                try
                {
                    Form1 f = new Form1();
                    f.webBrowser1.Url = new Uri(listBox1.SelectedItem.ToString());
                    f.UrlcompoBox.Text = listBox1.SelectedItem.ToString();
                    f.Show();
                    this.Close();
                }
                catch
                {   
                    MessageBox.Show("please Enter valid URL. sure URL has http://");
                }
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {   
            this.Close();
           
        }

       
        }
    }
