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
namespace browser
{
    
         public class BrowserTab:TabPage
        {
            WebBrowser web = new WebBrowser();
  
            StatusStrip Top = new StatusStrip();
            ToolStripStatusLabel AddressText = new ToolStripStatusLabel();
            ToolStripComboBox urlcombpBox = new ToolStripComboBox();
            ToolStripButton Back = new ToolStripButton();
            ToolStripButton Forward = new ToolStripButton();
            ToolStripButton webPic = new ToolStripButton();
            ToolStripButton Stop = new ToolStripButton();
            ToolStripButton Refresh = new ToolStripButton();
            ToolStripTextBox googleBox = new ToolStripTextBox();
            ToolStripButton google = new ToolStripButton();
            ToolStripButton Fav = new ToolStripButton();
            ToolStripButton Go = new ToolStripButton();

            ToolStripSeparator A = new ToolStripSeparator();
            ToolStripSeparator B = new ToolStripSeparator();
            ToolStripSeparator C = new ToolStripSeparator();
            ToolStripSeparator D = new ToolStripSeparator();
             

            ToolStripSplitButton DropDown = new ToolStripSplitButton();
            ToolStripMenuItem print = new ToolStripMenuItem();
            ToolStripMenuItem printpreview = new ToolStripMenuItem();
            

            StatusStrip Bottom = new StatusStrip();
            ToolStripStatusLabel Done = new ToolStripStatusLabel();
            ToolStripProgressBar ProgressBar = new ToolStripProgressBar();

            public BrowserTab()
            {
               
                web.SetBounds(0, 20, 962, 496);
            
                //
                DropDown.Image = Image.FromFile(@"print.png");
                Back.Image = Image.FromFile(@"Back.png");
                Back.Enabled = false;
                Forward.Image = Image.FromFile(@"Forward.png");
                Go.Image = Image.FromFile(@"Go.png");
                Stop.Image = Image.FromFile(@"Stop.png");
                Refresh.Image = Image.FromFile(@"Refresh.png");
                google.Image = Image.FromFile(@"google.png");

                webPic.Image = Image.FromFile(@"net.png");
              
                Fav.Image = Image.FromFile(@"bookmark_add-256.png");
                web.Dock = DockStyle.Fill;
               // web.Anchor = AnchorStyles.Left | AnchorStyles.Top;



                
                Top.Dock = DockStyle.Top;
                Top.Anchor =AnchorStyles.Top;
                Bottom.Dock = DockStyle.Bottom;

                AddressText.Text = "Back :";
                googleBox.Text="Search....";
                Back.Text = "Back";
                printpreview.Text = "Print preview";
                print.Text = "Print";

                web.ScriptErrorsSuppressed = false;
                
                Back.Enabled = false;
                Forward.Enabled = false;

                urlcombpBox.Size= new System.Drawing.Size(500, 20);

                Top.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.C,Back,Forward, B,webPic, urlcombpBox,Go, Stop, Refresh, A, googleBox, google, DropDown,Fav });
                Bottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.Done,ProgressBar });
                
                DropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.print,printpreview});

                urlcombpBox.Text = "http://";

                Done.Visible = false;
                Form1.totalBytes = 0;
                ProgressBar.Value = 0;

                web.Url = new Uri("http://www.Google.com");

                printpreview.Click += delegate
                {

                    web.ShowPrintPreviewDialog();
                };




                Go.Click += delegate
                {
                    Back.Enabled = true;
                    web.Navigate(urlcombpBox.Text);
                    Form1.history.Add(urlcombpBox.Text);

                };

               Fav.Click += delegate
                {
                    Favorites fav = new Favorites();
                    fav.textBox1.Text = urlcombpBox.Text;
                    fav.Show();
                };

                print.Click += delegate
                {
                    web.ShowPrintDialog();
                };


                Forward.Click += delegate
                {

                    web.GoForward();
                    /* Back.Enabled = true;
                     Done.Visible = false;
                     ProgressBar.Visible = true;
                     Form1.totalBytes = 0;
                     ProgressBar.Value = 0;
                     web.Url=new Uri(urlcombpBox.Text);*/
                }; 

               
                Back.Click += delegate
                {
                    Forward.Enabled = true;
                    web.Stop();

                    this.Text = web.DocumentTitle; ;

                   // this.Controls.Clear();
                    web.GoBack();
                    Done.Visible = false;
                    ProgressBar.Visible = true;
                    Form1.totalBytes = 0;
                    ProgressBar.Value = 0;


                };


             
                web.ProgressChanged += delegate
                {
                    web.ScriptErrorsSuppressed = true;

                    Form1.totalBytes+=10;

                    this.Text=web.DocumentTitle;

                    if (Form1.totalBytes > 90)
                        Form1.totalBytes -= 10;
                    ProgressBar.Value = Form1.totalBytes;

                };


                Refresh.Click += delegate
                { 
                    web.Refresh();

                };

                Stop.Click += delegate
                {
                    web.Stop();
                    ProgressBar.Visible = false;
                };

                google.Click += delegate
                {

                    web.Navigate("http://www.google.com/search?seuceid=ie7&q="+googleBox.Text);

                };
                web.DocumentCompleted += delegate
                {
                    int totalCount = 100 - ProgressBar.Value;
                    ProgressBar.Value += totalCount;
                    ProgressBar.Visible = false;
                    Done.Text = "Done";
                    Done.Visible = true;
                    urlcombpBox.Text=web.Url.ToString();

                    web.ScriptErrorsSuppressed = true;

                    webPic.Image = Form1.favicon(web.Url.ToString(), "net.png");

                };

                web.Navigating += delegate
                {
                    web.ScriptErrorsSuppressed = true;

                    Done.Visible = false;
                    ProgressBar.Visible = true;
                    Form1.totalBytes = 0;
                    ProgressBar.Value = 0;

                };
             

                this.Controls.Add(web);
                this.Controls.Add(Bottom);
                this.Controls.Add(Top);
                this.Controls.Add(web);


            }
    }
}
