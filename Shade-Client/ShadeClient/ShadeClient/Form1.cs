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
            guna2Button3.Visible = false;
            label5.Visible = false;
            guna2ComboBox2.Visible = false;
            guna2Button4.Visible = false;
            label1.Text = "SHADE CLIENT";
        }
        public static string versiyon;

        private void path()
        {
            var path = new MinecraftPath();
            var launcher = new CMLauncher(path);

            foreach (var item in launcher.GetAllVersions())
            {
                guna2ComboBox1.Items.Add(item.Name);
            }
        }
        private void launch()
        {
            var path = new MinecraftPath();
            var launcher = new CMLauncher(path);
            var launchOption = new MLaunchOption
            {
                MaximumRamMb = 1024,
                Session = MSession.GetOfflineSession(guna2TextBox1.Text),
                ServerIp = "play.hypixel.net",
            };
            versiyon = guna2ComboBox1.SelectedItem.ToString();
            var process = launcher.CreateProcess(versiyon, launchOption);
            process.Start();
            Hide();
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
                guna2Button3.Visible = true;
                label1.Text = "LAUNCHER";
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Button1.Text = "Açılıyor";
            guna2Button1.Enabled = false;
            guna2ComboBox1.Enabled = false;

            Thread thread = new Thread(() => launch());
            thread.IsBackground = true;
            thread.Start();
        }


        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            path();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2Button3.Visible = false;
            guna2GroupBox1.Visible = false;
            guna2PictureBox3.Visible = false;
            guna2ComboBox1.Visible = false;
            label3.Visible = false;
            label5.Visible = true;
            guna2ComboBox2.Visible = true;
            guna2Button4.Visible = true;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2Button3.Visible = true;
            guna2GroupBox1.Visible = true;
            guna2PictureBox3.Visible = true;
            guna2ComboBox1.Visible = true;
            label3.Visible = true;
            label5.Visible = false;
            guna2ComboBox2.Visible = false;
            guna2Button4.Visible = false;
        }


    }
}
