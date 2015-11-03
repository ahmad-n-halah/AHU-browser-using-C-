using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Xml;
using System.Net;
using System.Globalization;
using System.Collections;
using System.IO;
using System.IO.Ports;



namespace browser
{

    public partial class Form1 : Form
    {
        public static int totalBytes = 0;
        public static List<string> history = new List<string>();
        public static List<string> favorites= new List<string>();

        public static Form1 f=new Form1();
        
       
        public Form1()
        {
            InitializeComponent();
        }

        private void newTapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.Controls.Add(new BrowserTab());
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tabControl1.Controls.Add(new BrowserTab());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            f.Close();//For performance

            BackButton.Enabled = false;
            ForwardButton.Enabled = false;

            for (int i = 0; i <= history.Count - 1; i++)
                UrlcompoBox.Items.Add(history[i]);

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            ForwardButton.Enabled = true;
            webBrowser1.Stop();
            webBrowser1.GoBack();
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
                webBrowser1.Stop();
                webBrowser1.GoForward();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();

         
        }
        
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
            
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.google.com/search?seuceid=ie7&q=" + googleText.Text);
        }

        
        

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintPreviewDialog();
        }

        private void hTMLCompilerV1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide(); 
        }

       

        private void printPreviewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintPreviewDialog();
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }

        private void progressBAR_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
             
            totalBytes += 10;
            if (totalBytes > 90)
                totalBytes -= 10;

            progressBAR.Value = totalBytes;

        }

        public static Image favicon(String u, string file)
        {
            Uri url = new Uri(u);
            String iconurl = "http://" + url.Host + "/favicon.ico";

            WebRequest request = WebRequest.Create(iconurl);
            try
            {
                WebResponse response = request.GetResponse();

                Stream s = response.GetResponseStream();
                return Image.FromStream(s);
            }
            catch 
            {
                return Image.FromFile(file);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            int totalCount = 100 - progressBAR.Value;
            progressBAR.Value += totalCount;
            progressBAR.Visible = false;
            Done.Text = "Done";
            Done.Visible = true;
            UrlcompoBox.Text = webBrowser1.Url.ToString();

            webBrowser1.ScriptErrorsSuppressed = true;

            toolStripButton6.Image = favicon(webBrowser1.Url.ToString(), "net.png");
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History history = new History();
            history.ShowDialog();


        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 nw = new Form1();
            nw.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Favorites fav = new Favorites();
            fav.textBox1.Text=UrlcompoBox.Text;
            fav.Show();

        }

        private void bookmarksToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Favorites fav = new Favorites();
            fav.ShowDialog();
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;


            progressBAR.Visible = true;
            Done.Visible = false;
            totalBytes = 0;
            progressBAR.Value = 0;

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Text Files(*.txt)|*.txt|Html file(*.html)|*.html|Htm file(*.htm)|*.htm|AllFiles|*.*";
            if (o.ShowDialog() == DialogResult.OK)
                 UrlcompoBox.Text = o.FileName;

            webBrowser1.Navigate(UrlcompoBox.Text);

        }

        private void UrlcompoBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {

                    BackButton.Enabled = true ;
                    webBrowser1.Navigate(UrlcompoBox.Text);
                    history.Add(UrlcompoBox.Text);
                }
                catch
                {
                    MessageBox.Show("wrong");
                }
            }
        }

       

        private void UrlcompoBox_Click(object sender, EventArgs e)
        {
            if(UrlcompoBox.SelectedIndex >= 0)
            webBrowser1.Navigate(UrlcompoBox.SelectedItem.ToString());

        }

        private void UrlcompoBox_DropDown(object sender, EventArgs e)
        {

        }

        private void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                try
                {
                }
                catch
                {
                    MessageBox.Show("wrong");
                }
            }
        }

       

       

       

        private void toolStripButton1_Click_2(object sender, EventArgs e)
        {
            BackButton.Enabled = true;
            webBrowser1.Navigate(UrlcompoBox.Text);



        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            tabControl1.Controls.Add(new BrowserTab());

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.TabCount != 1)
            {
                this.tabControl1.TabPages.RemoveAt(this.tabControl1.SelectedIndex);
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
      

        }

      

     
       


        

    }
