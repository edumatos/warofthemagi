namespace Client_CSharp
{
    partial class Lobby
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GameList = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.sendMessage = new System.Windows.Forms.Button();
            this.userList = new System.Windows.Forms.ListBox();
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.logOut = new System.Windows.Forms.Button();
            this.createGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GameList
            // 
            this.GameList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.GameList.FormattingEnabled = true;
            this.GameList.Location = new System.Drawing.Point(3, 3);
            this.GameList.Name = "GameList";
            this.GameList.ScrollAlwaysVisible = true;
            this.GameList.Size = new System.Drawing.Size(200, 563);
            this.GameList.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(210, 576);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(539, 20);
            this.textBox1.TabIndex = 1;
            // 
            // sendMessage
            // 
            this.sendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendMessage.AutoSize = true;
            this.sendMessage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sendMessage.Location = new System.Drawing.Point(755, 574);
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(42, 23);
            this.sendMessage.TabIndex = 2;
            this.sendMessage.Text = "Send";
            this.sendMessage.UseVisualStyleBackColor = true;
            // 
            // userList
            // 
            this.userList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.userList.FormattingEnabled = true;
            this.userList.Location = new System.Drawing.Point(677, 3);
            this.userList.Name = "userList";
            this.userList.ScrollAlwaysVisible = true;
            this.userList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.userList.Size = new System.Drawing.Size(120, 563);
            this.userList.TabIndex = 4;
            // 
            // chatBox
            // 
            this.chatBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chatBox.Enabled = false;
            this.chatBox.Location = new System.Drawing.Point(210, 4);
            this.chatBox.Name = "chatBox";
            this.chatBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.chatBox.Size = new System.Drawing.Size(461, 566);
            this.chatBox.TabIndex = 5;
            this.chatBox.Text = "";
            // 
            // logOut
            // 
            this.logOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logOut.AutoSize = true;
            this.logOut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.logOut.Location = new System.Drawing.Point(4, 574);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(58, 23);
            this.logOut.TabIndex = 6;
            this.logOut.Text = "Sign Out";
            this.logOut.UseVisualStyleBackColor = true;
            // 
            // createGame
            // 
            this.createGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createGame.AutoSize = true;
            this.createGame.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.createGame.Location = new System.Drawing.Point(124, 574);
            this.createGame.Name = "createGame";
            this.createGame.Size = new System.Drawing.Size(79, 23);
            this.createGame.TabIndex = 7;
            this.createGame.Text = "Create Game";
            this.createGame.UseVisualStyleBackColor = true;
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.createGame);
            this.Controls.Add(this.logOut);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.userList);
            this.Controls.Add(this.sendMessage);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.GameList);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Lobby";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button sendMessage;
        private System.Windows.Forms.ListBox userList;
        private System.Windows.Forms.RichTextBox chatBox;
        private System.Windows.Forms.Button logOut;
        public System.Windows.Forms.ListBox GameList;
        private System.Windows.Forms.Button createGame;
    }
}
