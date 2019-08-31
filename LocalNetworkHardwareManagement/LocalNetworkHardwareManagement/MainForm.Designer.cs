namespace LocalNetworkHardwareManagement
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
            this.components = new System.ComponentModel.Container();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.menuIcon = new System.Windows.Forms.PictureBox();
            this.mainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showSystemInfoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showActivitiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showNodesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TitleIcon = new System.Windows.Forms.PictureBox();
            this.ExitButton = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ActivitiesText = new System.Windows.Forms.TextBox();
            this.NodesList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.showNodesButton = new System.Windows.Forms.Button();
            this.FullExitButton = new System.Windows.Forms.Button();
            this.btnShowSystemInfo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LocalIPsCombo = new System.Windows.Forms.ComboBox();
            this.ServerStartButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuIcon)).BeginInit();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitleIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TitlePanel.Controls.Add(this.menuIcon);
            this.TitlePanel.Controls.Add(this.TitleIcon);
            this.TitlePanel.Controls.Add(this.ExitButton);
            this.TitlePanel.Controls.Add(this.TitleLabel);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(780, 60);
            this.TitlePanel.TabIndex = 0;
            this.TitlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitlePanel_MouseDown);
            this.TitlePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitlePanel_MouseMove);
            this.TitlePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitlePanel_MouseUp);
            // 
            // menuIcon
            // 
            this.menuIcon.BackgroundImage = global::LocalNetworkHardwareManagement.Properties.Resources.line_menu_white;
            this.menuIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuIcon.ContextMenuStrip = this.mainMenu;
            this.menuIcon.Location = new System.Drawing.Point(51, 17);
            this.menuIcon.Name = "menuIcon";
            this.menuIcon.Size = new System.Drawing.Size(28, 26);
            this.menuIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.menuIcon.TabIndex = 8;
            this.menuIcon.TabStop = false;
            this.menuIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuIcon_MouseDown);
            this.menuIcon.MouseEnter += new System.EventHandler(this.MenuIcon_MouseEnter);
            this.menuIcon.MouseLeave += new System.EventHandler(this.MenuIcon_MouseLeave);
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mainMenu.DropShadowEnabled = false;
            this.mainMenu.Font = new System.Drawing.Font("B Mitra", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showSystemInfoMenuItem,
            this.showActivitiesMenuItem,
            this.showNodesMenuItem,
            this.settingsMenuItem,
            this.aboutMenuItem,
            this.exitMenuItem});
            this.mainMenu.Name = "contextMenuStrip1";
            this.mainMenu.ShowImageMargin = false;
            this.mainMenu.Size = new System.Drawing.Size(249, 220);
            // 
            // showSystemInfoMenuItem
            // 
            this.showSystemInfoMenuItem.ForeColor = System.Drawing.Color.White;
            this.showSystemInfoMenuItem.Name = "showSystemInfoMenuItem";
            this.showSystemInfoMenuItem.Size = new System.Drawing.Size(248, 36);
            this.showSystemInfoMenuItem.Text = "نمایش جزئیات سیستم خود";
            // 
            // showActivitiesMenuItem
            // 
            this.showActivitiesMenuItem.ForeColor = System.Drawing.Color.White;
            this.showActivitiesMenuItem.Name = "showActivitiesMenuItem";
            this.showActivitiesMenuItem.Size = new System.Drawing.Size(248, 36);
            this.showActivitiesMenuItem.Text = "نمایش فعالیت های اخیر برنامه";
            // 
            // showNodesMenuItem
            // 
            this.showNodesMenuItem.ForeColor = System.Drawing.Color.White;
            this.showNodesMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.showNodesMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showNodesMenuItem.ImageTransparentColor = System.Drawing.Color.Yellow;
            this.showNodesMenuItem.Name = "showNodesMenuItem";
            this.showNodesMenuItem.Size = new System.Drawing.Size(248, 36);
            this.showNodesMenuItem.Text = "نمایش جزئیات گره های متصل";
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.settingsMenuItem.Font = new System.Drawing.Font("B Mitra", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.settingsMenuItem.ForeColor = System.Drawing.Color.White;
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(248, 36);
            this.settingsMenuItem.Text = "تنظیمات برنامه";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.aboutMenuItem.ForeColor = System.Drawing.Color.White;
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(248, 36);
            this.aboutMenuItem.Text = "درباره برنامه نویس";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(248, 36);
            this.exitMenuItem.Text = "خروج";
            // 
            // TitleIcon
            // 
            this.TitleIcon.BackgroundImage = global::LocalNetworkHardwareManagement.Properties.Resources.local_network__3_;
            this.TitleIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TitleIcon.Location = new System.Drawing.Point(707, 9);
            this.TitleIcon.Name = "TitleIcon";
            this.TitleIcon.Size = new System.Drawing.Size(61, 42);
            this.TitleIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TitleIcon.TabIndex = 3;
            this.TitleIcon.TabStop = false;
            // 
            // ExitButton
            // 
            this.ExitButton.AutoSize = true;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(14, 15);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(31, 29);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "X";
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("B Mehr", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(445, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(253, 48);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "مدیریت سخت افزاری شبکه";
            this.TitleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseDown);
            this.TitleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseMove);
            this.TitleLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseUp);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("B Mitra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(505, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "فعالیت ها و پیام ها:";
            // 
            // ActivitiesText
            // 
            this.ActivitiesText.Font = new System.Drawing.Font("B Mitra", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ActivitiesText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ActivitiesText.Location = new System.Drawing.Point(291, 117);
            this.ActivitiesText.Multiline = true;
            this.ActivitiesText.Name = "ActivitiesText";
            this.ActivitiesText.ReadOnly = true;
            this.ActivitiesText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ActivitiesText.Size = new System.Drawing.Size(477, 284);
            this.ActivitiesText.TabIndex = 5;
            // 
            // NodesList
            // 
            this.NodesList.FormattingEnabled = true;
            this.NodesList.ItemHeight = 20;
            this.NodesList.Location = new System.Drawing.Point(12, 237);
            this.NodesList.Name = "NodesList";
            this.NodesList.Size = new System.Drawing.Size(262, 164);
            this.NodesList.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("B Mitra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(110, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "گره های متصل:";
            // 
            // showNodesButton
            // 
            this.showNodesButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.showNodesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showNodesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showNodesButton.Font = new System.Drawing.Font("B Mitra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.showNodesButton.ForeColor = System.Drawing.Color.White;
            this.showNodesButton.Location = new System.Drawing.Point(492, 415);
            this.showNodesButton.Name = "showNodesButton";
            this.showNodesButton.Size = new System.Drawing.Size(276, 48);
            this.showNodesButton.TabIndex = 9;
            this.showNodesButton.Text = "نمایش جزئیات گره های متصل";
            this.showNodesButton.UseVisualStyleBackColor = false;
            this.showNodesButton.Click += new System.EventHandler(this.showNodesButton_Click);
            // 
            // FullExitButton
            // 
            this.FullExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FullExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FullExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FullExitButton.Font = new System.Drawing.Font("B Mitra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FullExitButton.ForeColor = System.Drawing.Color.White;
            this.FullExitButton.Location = new System.Drawing.Point(12, 415);
            this.FullExitButton.Name = "FullExitButton";
            this.FullExitButton.Size = new System.Drawing.Size(105, 48);
            this.FullExitButton.TabIndex = 10;
            this.FullExitButton.Text = "خروج";
            this.FullExitButton.UseVisualStyleBackColor = false;
            this.FullExitButton.Click += new System.EventHandler(this.FullExitButton_Click);
            // 
            // btnShowSystemInfo
            // 
            this.btnShowSystemInfo.BackColor = System.Drawing.Color.SlateGray;
            this.btnShowSystemInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowSystemInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowSystemInfo.Font = new System.Drawing.Font("B Mitra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnShowSystemInfo.ForeColor = System.Drawing.Color.White;
            this.btnShowSystemInfo.Location = new System.Drawing.Point(167, 415);
            this.btnShowSystemInfo.Name = "btnShowSystemInfo";
            this.btnShowSystemInfo.Size = new System.Drawing.Size(276, 48);
            this.btnShowSystemInfo.TabIndex = 11;
            this.btnShowSystemInfo.Text = "نمایش اطلاعات سیستم";
            this.btnShowSystemInfo.UseVisualStyleBackColor = false;
            this.btnShowSystemInfo.Click += new System.EventHandler(this.BtnShowSystemInfo_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("B Mitra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(14, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 30);
            this.label3.TabIndex = 13;
            this.label3.Text = "آیپی خود را انتخاب کنید:";
            // 
            // LocalIPsCombo
            // 
            this.LocalIPsCombo.FormattingEnabled = true;
            this.LocalIPsCombo.Location = new System.Drawing.Point(14, 117);
            this.LocalIPsCombo.Name = "LocalIPsCombo";
            this.LocalIPsCombo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LocalIPsCombo.Size = new System.Drawing.Size(260, 28);
            this.LocalIPsCombo.TabIndex = 14;
            // 
            // ServerStartButton
            // 
            this.ServerStartButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.ServerStartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ServerStartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ServerStartButton.Font = new System.Drawing.Font("B Mitra", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ServerStartButton.ForeColor = System.Drawing.Color.White;
            this.ServerStartButton.Location = new System.Drawing.Point(14, 151);
            this.ServerStartButton.Name = "ServerStartButton";
            this.ServerStartButton.Size = new System.Drawing.Size(260, 40);
            this.ServerStartButton.TabIndex = 15;
            this.ServerStartButton.Text = "استارت سرور";
            this.ServerStartButton.UseVisualStyleBackColor = false;
            this.ServerStartButton.Click += new System.EventHandler(this.ServerStartButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.SeaShell;
            this.ClearButton.BackgroundImage = global::LocalNetworkHardwareManagement.Properties.Resources.eraser__1_;
            this.ClearButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClearButton.Location = new System.Drawing.Point(291, 84);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(30, 27);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(780, 480);
            this.Controls.Add(this.ServerStartButton);
            this.Controls.Add(this.LocalIPsCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnShowSystemInfo);
            this.Controls.Add(this.FullExitButton);
            this.Controls.Add(this.showNodesButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NodesList);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ActivitiesText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TitlePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Network Hardware Management";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuIcon)).EndInit();
            this.mainMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TitleIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.PictureBox TitleIcon;
        private System.Windows.Forms.Label ExitButton;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ActivitiesText;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.ListBox NodesList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button showNodesButton;
        private System.Windows.Forms.Button FullExitButton;
        private System.Windows.Forms.Button btnShowSystemInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox LocalIPsCombo;
        private System.Windows.Forms.Button ServerStartButton;
        private System.Windows.Forms.PictureBox menuIcon;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showNodesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showActivitiesMenuItem;
        private System.Windows.Forms.ContextMenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem showSystemInfoMenuItem;
    }
}