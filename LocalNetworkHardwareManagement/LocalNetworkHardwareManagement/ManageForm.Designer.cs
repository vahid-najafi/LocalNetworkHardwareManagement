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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.menuIcon = new System.Windows.Forms.PictureBox();
            this.mainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showSystemInfoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showActivitiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showNodesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitButton = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TitleIcon = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pcNameLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ipLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sowSelectedSystemButton = new System.Windows.Forms.Button();
            this.showThisSystemButton = new System.Windows.Forms.Button();
            this.nodesDataGrid = new System.Windows.Forms.DataGridView();
            this.ipCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuIcon)).BeginInit();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitleIcon)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodesDataGrid)).BeginInit();
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
            this.menuIcon.ContextMenuStrip = this.mainMenu;
            this.menuIcon.Location = new System.Drawing.Point(51, 17);
            this.menuIcon.Name = "menuIcon";
            this.menuIcon.Size = new System.Drawing.Size(28, 26);
            this.menuIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.menuIcon.TabIndex = 7;
            this.menuIcon.TabStop = false;
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
            this.mainMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
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
            this.panel2.Controls.Add(this.sowSelectedSystemButton);
            this.panel2.Controls.Add(this.showThisSystemButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(825, 143);
            this.panel2.TabIndex = 1;
            // 
            // pcNameLabel
            // 
            this.pcNameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.ipLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // sowSelectedSystemButton
            // 
            this.sowSelectedSystemButton.BackColor = System.Drawing.Color.Teal;
            this.sowSelectedSystemButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sowSelectedSystemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sowSelectedSystemButton.Font = new System.Drawing.Font("B Mitra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.sowSelectedSystemButton.ForeColor = System.Drawing.Color.White;
            this.sowSelectedSystemButton.Location = new System.Drawing.Point(51, 19);
            this.sowSelectedSystemButton.Name = "sowSelectedSystemButton";
            this.sowSelectedSystemButton.Size = new System.Drawing.Size(303, 48);
            this.sowSelectedSystemButton.TabIndex = 14;
            this.sowSelectedSystemButton.Text = "نمایش جزئیات سیستم انتخاب شده";
            this.sowSelectedSystemButton.UseVisualStyleBackColor = false;
            this.sowSelectedSystemButton.Click += new System.EventHandler(this.SowSelectedSystemButton_Click);
            // 
            // showThisSystemButton
            // 
            this.showThisSystemButton.BackColor = System.Drawing.Color.Crimson;
            this.showThisSystemButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showThisSystemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showThisSystemButton.Font = new System.Drawing.Font("B Mitra", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.showThisSystemButton.ForeColor = System.Drawing.Color.White;
            this.showThisSystemButton.Location = new System.Drawing.Point(479, 19);
            this.showThisSystemButton.Name = "showThisSystemButton";
            this.showThisSystemButton.Size = new System.Drawing.Size(303, 48);
            this.showThisSystemButton.TabIndex = 11;
            this.showThisSystemButton.Text = "نمایش جزئیات سیستم خود";
            this.showThisSystemButton.UseVisualStyleBackColor = false;
            // 
            // nodesDataGrid
            // 
            this.nodesDataGrid.AllowUserToAddRows = false;
            this.nodesDataGrid.AllowUserToDeleteRows = false;
            this.nodesDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Mitra", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nodesDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.nodesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nodesDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ipCol,
            this.nameCol,
            this.cpuCol});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.nodesDataGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.nodesDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodesDataGrid.Location = new System.Drawing.Point(0, 203);
            this.nodesDataGrid.MultiSelect = false;
            this.nodesDataGrid.Name = "nodesDataGrid";
            this.nodesDataGrid.ReadOnly = true;
            this.nodesDataGrid.RowHeadersWidth = 62;
            this.nodesDataGrid.RowTemplate.Height = 28;
            this.nodesDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.nodesDataGrid.Size = new System.Drawing.Size(825, 490);
            this.nodesDataGrid.TabIndex = 2;
            // 
            // ipCol
            // 
            this.ipCol.HeaderText = "آیپی سیستم";
            this.ipCol.MinimumWidth = 8;
            this.ipCol.Name = "ipCol";
            this.ipCol.ReadOnly = true;
            // 
            // nameCol
            // 
            this.nameCol.HeaderText = "نام سیستم";
            this.nameCol.MinimumWidth = 8;
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            // 
            // cpuCol
            // 
            this.cpuCol.HeaderText = "پردازنده";
            this.cpuCol.MinimumWidth = 8;
            this.cpuCol.Name = "cpuCol";
            this.cpuCol.ReadOnly = true;
            // 
            // ManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(825, 693);
            this.Controls.Add(this.nodesDataGrid);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.TitlePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مدیریت سیستم ها متصل";
            this.Load += new System.EventHandler(this.ManageForm_Load);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuIcon)).EndInit();
            this.mainMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TitleIcon)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nodesDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView nodesDataGrid;
        private System.Windows.Forms.Button showThisSystemButton;
        private System.Windows.Forms.PictureBox TitleIcon;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label ExitButton;
        private System.Windows.Forms.Button sowSelectedSystemButton;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox menuIcon;
        private System.Windows.Forms.Label pcNameLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpuCol;
        private System.Windows.Forms.ContextMenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem showSystemInfoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showActivitiesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showNodesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
    }
}