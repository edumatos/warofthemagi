namespace Client_CSharp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lobby1 = new Client_CSharp.Lobby();
            this.SuspendLayout();
            // 
            // lobby1
            // 
            this.lobby1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lobby1.Location = new System.Drawing.Point(0, 0);
            this.lobby1.MinimumSize = new System.Drawing.Size(800, 600);
            this.lobby1.Name = "lobby1";
            this.lobby1.Size = new System.Drawing.Size(800, 600);
            this.lobby1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.lobby1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "War of the Magi";
            this.ResumeLayout(false);

        }

        #endregion

        private Lobby lobby1;
    }
}

