namespace Client_CSharp
{
    partial class GameUI
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
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.buildings = new System.Windows.Forms.TabPage();
            this.spells = new System.Windows.Forms.TabPage();
            this.GameDisplay = new Client_CSharp.GameDisplay();
            this.magesGroup = new System.Windows.Forms.GroupBox();
            this.magesFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.tabMenu.SuspendLayout();
            this.magesGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMenu
            // 
            this.tabMenu.Controls.Add(this.buildings);
            this.tabMenu.Controls.Add(this.spells);
            this.tabMenu.Location = new System.Drawing.Point(547, 347);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(250, 250);
            this.tabMenu.TabIndex = 0;
            // 
            // buildings
            // 
            this.buildings.Location = new System.Drawing.Point(4, 22);
            this.buildings.Name = "buildings";
            this.buildings.Padding = new System.Windows.Forms.Padding(3);
            this.buildings.Size = new System.Drawing.Size(242, 224);
            this.buildings.TabIndex = 0;
            this.buildings.Text = "Buildings";
            this.buildings.UseVisualStyleBackColor = true;
            // 
            // spells
            // 
            this.spells.Location = new System.Drawing.Point(4, 22);
            this.spells.Name = "spells";
            this.spells.Padding = new System.Windows.Forms.Padding(3);
            this.spells.Size = new System.Drawing.Size(242, 224);
            this.spells.TabIndex = 1;
            this.spells.Text = "Spells";
            this.spells.UseVisualStyleBackColor = true;
            // 
            // GameDisplay
            // 
            this.GameDisplay.Location = new System.Drawing.Point(0, 0);
            this.GameDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.GameDisplay.MinimumSize = new System.Drawing.Size(544, 600);
            this.GameDisplay.Name = "GameDisplay";
            this.GameDisplay.Size = new System.Drawing.Size(544, 600);
            this.GameDisplay.TabIndex = 1;
            // 
            // magesGroup
            // 
            this.magesGroup.Controls.Add(this.magesFlowLayout);
            this.magesGroup.Location = new System.Drawing.Point(547, 141);
            this.magesGroup.Name = "magesGroup";
            this.magesGroup.Size = new System.Drawing.Size(250, 200);
            this.magesGroup.TabIndex = 2;
            this.magesGroup.TabStop = false;
            this.magesGroup.Text = "Mages";
            // 
            // magesFlowLayout
            // 
            this.magesFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.magesFlowLayout.Location = new System.Drawing.Point(3, 16);
            this.magesFlowLayout.Name = "magesFlowLayout";
            this.magesFlowLayout.Size = new System.Drawing.Size(244, 181);
            this.magesFlowLayout.TabIndex = 0;
            // 
            // GameUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.magesGroup);
            this.Controls.Add(this.GameDisplay);
            this.Controls.Add(this.tabMenu);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "GameUI";
            this.Size = new System.Drawing.Size(800, 600);
            this.tabMenu.ResumeLayout(false);
            this.magesGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.TabPage buildings;
        private System.Windows.Forms.TabPage spells;
        public GameDisplay GameDisplay;
        private System.Windows.Forms.GroupBox magesGroup;
        private System.Windows.Forms.FlowLayoutPanel magesFlowLayout;
    }
}
