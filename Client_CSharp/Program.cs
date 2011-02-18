using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace Client_CSharp
{
    static class Program
    {

        static MainForm MainForm { get; set; }

        static long Timestamp { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(MainForm);
            MainForm = new MainForm();

            SlimDX.Windows.MessagePump.Run(MainForm, Update);
        }

        static void Update()
        {
            if (!MainForm.ShowGame) return;

            long lastTimestamp = Timestamp;
            Timestamp = Stopwatch.GetTimestamp();
            float deltaTime = Convert.ToSingle(Timestamp - lastTimestamp) / Stopwatch.Frequency;
            if (deltaTime > .1f) deltaTime = .1f;

            //TODO: update and render game.
        }
    }
}
