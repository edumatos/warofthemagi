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
            this.AuthenticateUser = new Client_CSharp.AuthenticateUser();
            this.Lobby = new Client_CSharp.Lobby();
            this.GameUI = new Client_CSharp.GameUI();
            this.SuspendLayout();
            // 
            // AuthenticateUser
            // 
            this.AuthenticateUser.BackColor = System.Drawing.Color.Black;
            this.AuthenticateUser.Location = new System.Drawing.Point(-455, 429);
            this.AuthenticateUser.MinimumSize = new System.Drawing.Size(800, 600);
            this.AuthenticateUser.Name = "AuthenticateUser";
            this.AuthenticateUser.Size = new System.Drawing.Size(800, 600);
            this.AuthenticateUser.TabIndex = 1;
            // 
            // Lobby
            // 
            this.Lobby.Location = new System.Drawing.Point(521, 429);
            this.Lobby.MinimumSize = new System.Drawing.Size(800, 600);
            this.Lobby.Name = "Lobby";
            this.Lobby.Size = new System.Drawing.Size(800, 600);
            this.Lobby.TabIndex = 0;
            this.Lobby.Visible = false;
            // 
            // GameUI
            // 
            this.GameUI.Location = new System.Drawing.Point(-455, -229);
            this.GameUI.MinimumSize = new System.Drawing.Size(800, 600);
            this.GameUI.Name = "GameUI";
            this.GameUI.Size = new System.Drawing.Size(800, 600);
            this.GameUI.TabIndex = 2;
            this.GameUI.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.GameUI);
            this.Controls.Add(this.AuthenticateUser);
            this.Controls.Add(this.Lobby);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "War of the Magi";
            this.ResumeLayout(false);

        }

        #endregion

        public GameUI GameUI;
        public Lobby Lobby;
        public AuthenticateUser AuthenticateUser;
    }
}

