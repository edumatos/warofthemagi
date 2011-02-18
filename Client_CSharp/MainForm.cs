using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client_CSharp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            int borderWidth = SystemInformation.FrameBorderSize.Width * 2;
            int borderHeight = borderWidth + SystemInformation.CaptionHeight;
            MinimumSize = new Size(800 + borderWidth, 600 + borderHeight);
        }
    }
}
