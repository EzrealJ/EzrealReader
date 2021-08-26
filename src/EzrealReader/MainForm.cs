using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;
using WebView2 = Microsoft.Web.WebView2.WinForms.WebView2;

namespace EzrealReader
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            this.InitializeComponent();
            this.Resize += new System.EventHandler(this.Form_Resize);

        }

        private void webView2_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {

        }
        private void Form_Resize(object? sender, EventArgs e)
        {
            this.webView2.Size = this.ClientSize - new Size(this.webView2.Location);
            this.btnGo.Left = this.ClientSize.Width - this.btnGo.Width;
            this.textUrl.Width = this.btnGo.Left - this.textUrl.Left;
        }

        private async void BtnGo_ClickAsync(object sender, EventArgs e)
        {
            if (this.webView2 is null)
            {
                return;
            }
            if (this.webView2.CoreWebView2 is null)
            {
                try
                {
                    //download webview2 runtime from https://go.microsoft.com/fwlink/p/?LinkId=2124703
                    CoreWebView2Environment? env =await CoreWebView2Environment.CreateAsync(userDataFolder: @"./WebView2Data");
                    await this.webView2.EnsureCoreWebView2Async();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
            if (this.webView2.CoreWebView2 is null)
            {
                MessageBox.Show("内核加载失败");
                return;
            }
            this.webView2.CoreWebView2.Navigate(this.textUrl.Text);

        }
    }

}
