using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;



namespace browser
{
    public partial class Form2 : Form
    {
        public Form1 f = new Form1();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {   
            webBrowser1.DocumentText = "<html><head><title>AHU software</title></head><body>Welcome To AHU IT Software<br /> Enjoy</body></html>";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Text Files(*.txt)|*.txt|Html file(*.html)|*.html|AllFiles|*.*";
            if (o.ShowDialog() == DialogResult.OK)
                richTextBox1.Text = o.FileName;

            webBrowser2.Navigate(richTextBox1.Text);
            webBrowser2.Navigate(richTextBox1.Text);

            richTextBox1.Text = webBrowser2.DocumentText;
            



        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tab.Text = webBrowser1.DocumentTitle;
                
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = richTextBox1.Text;

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            String source = ("viewsource.txt");

            StreamWriter writer = File.CreateText(source);

            writer.Write(webBrowser1.DocumentText);

            writer.Close();

            Process.Start("notepad.exe", source);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            f.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

       

       
    }
}
