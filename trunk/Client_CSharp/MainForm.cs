using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SlimDX.Direct3D9;

namespace Client_CSharp
{
    public partial class MainForm : Form
    {

        public bool ShowGame { get; set; }

        Device Device { get; set; }


        public MainForm()
        {
            InitializeComponent();

            int borderWidth = SystemInformation.FrameBorderSize.Width * 2;
            int borderHeight = borderWidth + SystemInformation.CaptionHeight;
            MinimumSize = new Size(800 + borderWidth, 600 + borderHeight);

            AuthenticateUser.Dock = DockStyle.Fill;
            Lobby.Dock = DockStyle.Fill;
            GameUI.Dock = DockStyle.Fill;

            ShowGame = false;
        }

        public void Update(float _delta)
        {
            //TODO: update game
        }
    }
}
