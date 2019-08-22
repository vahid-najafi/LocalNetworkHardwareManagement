namespace LocalNetworkHardwareManagement
{
    partial class ManageForm
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
            this.menuIcon = new System.Windows.Forms.PictureBox();
            this.ExitButton = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TitleIcon = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pcNameLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ipLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleIcon)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TitlePanel.Controls.Add(this.menuIcon);
            this.TitlePanel.Controls.Add(this.ExitButton);
            this.TitlePanel.Controls.Add(this.TitleLabel);
            this.TitlePanel.Controls.Add(this.TitleIcon);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(825, 60);
            this.TitlePanel.TabIndex = 0;
            this.TitlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitlePanel_MouseDown);
            this.TitlePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitlePanel_MouseMove);
            this.TitlePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitlePanel_MouseUp);
            // 
            // menuIcon
            // 
            this.menuIcon.BackgroundImage = global::LocalNetworkHardwareManagement.Properties.Resources.line_menu_white;
            this.menuIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuIcon.Location = new System.Drawing.Point(51, 17);
            this.menuIcon.Name = "menuIcon";
            this.menuIcon.Size = new System.Drawing.Size(28, 26);
            this.menuIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.menuIcon.TabIndex = 7;
            this.menuIcon.TabStop = false;
            // 
            // ExitButton
            // 
            this.ExitButton.AutoSize = true;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(14, 15);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(31, 29);
            this.ExitButton.TabIndex = 6;
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
            this.TitleLabel.Location = new System.Drawing.Point(441, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(305, 48);
            this.TitleLabel.TabIndex = 5;
            this.TitleLabel.Text = "مدیریت سیستم های متصل شده";
            this.TitleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseDown);
            this.TitleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseMove);
            this.TitleLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseUp);
            // 
            // TitleIcon
            // 
            this.TitleIcon.BackgroundImage = global::LocalNetworkHardwareManagement.Properties.Resources.local_network__3_;
            this.TitleIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TitleIcon.Location = new System.Drawing.Point(752, 9);
            this.TitleIcon.Name = "TitleIcon";
            this.TitleIcon.Size = new System.Drawing.Size(61, 42);
            this.TitleIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TitleIcon.TabIndex = 4;
            this.TitleIcon.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.pcNameLabel);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.ipLabel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(825, 143);
            this.panel2.TabIndex = 1;
            // 
            // pcNameLabel
            // 
            this.pcNameLabel.Font = new System.Drawing.Font("B Mitra", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.pcNameLabel.ForeColor = System.Drawing.Color.Maroon;
            this.pcNameLabel.Location = new System.Drawing.Point(51, 101);
            this.pcNameLabel.Name = "pcNameLabel";
            this.pcNameLabel.Size = new System.Drawing.Size(303, 36);
            this.pcNameLabel.TabIndex = 20;
            this.pcNameLabel.Text = "Vahid-Pc";
            this.pcNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("B Mitra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(51, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(303, 31);
            this.label5.TabIndex = 19;
            this.label5.Text = "نام سیستم:";
            // 
            // ipLabel
            // 
            this.ipLabel.Font = new System.Drawing.Font("B Mitra", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ipLabel.ForeColor = System.Drawing.Color.Teal;
            this.ipLabel.Location = new System.Drawing.Point(479, 104);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(298, 36);
            this.ipLabel.TabIndex = 16;
            this.ipLabel.Text = "192.168.1.1";
            this.ipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("B Mitra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(479, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 31);
            this.label1.TabIndex = 15;
            this.label1.Text = "آیپی سیستم:";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Teal;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("B Mitra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(51, 19);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(303, 48);
            this.button5.TabIndex = 14;
            this.button5.Text = "نمایش جزئیات سیستم انتخاب شده";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Crimson;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("B Mitra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(479, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(303, 48);
            this.button2.TabIndex = 11;
            this.button2.Text = "نمایش جزئیات سیستم خود";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 203);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(825, 490);
            this.dataGridView1.TabIndex = 2;
            // 
            // ManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(825, 693);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.TitlePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مدیریت سیستم ها متصل";
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleIcon)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox TitleIcon;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label ExitButton;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox menuIcon;
        private System.Windows.Forms.Label pcNameLabel;
        private System.Windows.Forms.Label label5;
    }
}