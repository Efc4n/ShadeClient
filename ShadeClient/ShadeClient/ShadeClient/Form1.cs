using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using CmlLib.Core;
using CmlLib.Core.Auth;

namespace ShadeClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            label3.Visible = false;
            guna2Button1.Visible = false;
            label4.Visible = false;
            guna2ComboBox1.Visible = false;
            guna2PictureBox3.Visible = false;
            guna2GroupBox1.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(guna2TextBox1.Text))
            {
                MessageBox.Show("Kullanıcı Adı Boş Bırakılamaz!");
            }
            else
            {
                guna2TextBox1.Visible = false;
                guna2Button2.Visible = false;
                label3.Text = guna2TextBox1.Text;
                label3.Visible = true;
                guna2Button1.Visible = true;
                label4.Visible = true;
                guna2ComboBox1.Visible = true;
                guna2PictureBox3.Visible = true;
                guna2GroupBox1.Visible = true;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Button1.Text = "Açılıyor";
            guna2Button1.Enabled = false;
            guna2ComboBox1.Enabled = false;

            Thread thread = new Thread(() => shadeoyunac());
            thread.IsBackground = true;
            thread.Start();
        }
        async private void shadeoyunac()
        {
            var path = new MinecraftPath();
            var launcher = new CMLauncher(path);

            var ayar = new MLaunchOption
            {
                MaximumRamMb = 1024,
                Session = MSession.GetOfflineSession(label3.Text),
            };
            var process = await launcher.CreateProcessAsync(guna2ComboBox1.Text,ayar);
            process.Start();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
