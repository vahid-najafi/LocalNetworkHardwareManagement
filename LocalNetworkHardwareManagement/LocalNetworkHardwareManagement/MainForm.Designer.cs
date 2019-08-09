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
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.TitleIcon = new System.Windows.Forms.PictureBox();
            this.ExitButton = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ActivitiesText = new System.Windows.Forms.TextBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.NodesList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.FullExitButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitleIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.DimGray;
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
            // TitleIcon
            // 
            this.TitleIcon.Image = global::LocalNetworkHardwareManagement.Properties.Resources.LocalNetwork;
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
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Mitra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(625, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "فعالیت ها و پیام ها:";
            // 
            // ActivitiesText
            // 
            this.ActivitiesText.Location = new System.Drawing.Point(195, 117);
            this.ActivitiesText.Multiline = true;
            this.ActivitiesText.Name = "ActivitiesText";
            this.ActivitiesText.ReadOnly = true;
            this.ActivitiesText.Size = new System.Drawing.Size(573, 284);
            this.ActivitiesText.TabIndex = 5;
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.SeaShell;
            this.ClearButton.BackgroundImage = global::LocalNetworkHardwareManagement.Properties.Resources.eraser__1_;
            this.ClearButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClearButton.Location = new System.Drawing.Point(195, 74);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(40, 40);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // NodesList
            // 
            this.NodesList.FormattingEnabled = true;
            this.NodesList.ItemHeight = 20;
            this.NodesList.Location = new System.Drawing.Point(12, 117);
            this.NodesList.Name = "NodesList";
            this.NodesList.Size = new System.Drawing.Size(163, 284);
            this.NodesList.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Mitra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(62, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "گره های متصل:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("B Mitra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(505, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(263, 48);
            this.button1.TabIndex = 9;
            this.button1.Text = "نمایش جزئیات گره های متصل";
            this.button1.UseVisualStyleBackColor = false;
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
            this.FullExitButton.Size = new System.Drawing.Size(92, 48);
            this.FullExitButton.TabIndex = 10;
            this.FullExitButton.Text = "خروج";
            this.FullExitButton.UseVisualStyleBackColor = false;
            this.FullExitButton.Click += new System.EventHandler(this.FullExitButton_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Olive;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("B Mitra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(110, 415);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(175, 48);
            this.button3.TabIndex = 11;
            this.button3.Text = "تنظیمات برنامه";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Green;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("B Mitra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(291, 415);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(208, 48);
            this.button4.TabIndex = 12;
            this.button4.Text = "درباره برنامه نویس";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(780, 480);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.FullExitButton);
            this.Controls.Add(this.button1);
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
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button FullExitButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}