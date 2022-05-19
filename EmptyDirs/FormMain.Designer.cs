namespace EmptyDirs
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.ButtonSelectPath = new System.Windows.Forms.Button();
            this.PanelTop = new System.Windows.Forms.Panel();
            this.ButtonDisplay = new System.Windows.Forms.Button();
            this.TextBoxRootPath = new System.Windows.Forms.TextBox();
            this.MenuStripMain = new System.Windows.Forms.MenuStrip();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListViewMain = new System.Windows.Forms.ListView();
            this.ColumnHeaderPath = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeaderStatus = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeaderAttributes = new System.Windows.Forms.ColumnHeader();
            this.PanelCenter = new System.Windows.Forms.Panel();
            this.PanelTop.SuspendLayout();
            this.MenuStripMain.SuspendLayout();
            this.PanelCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonSelectPath
            // 
            this.ButtonSelectPath.Location = new System.Drawing.Point(12, 37);
            this.ButtonSelectPath.Name = "ButtonSelectPath";
            this.ButtonSelectPath.Size = new System.Drawing.Size(109, 23);
            this.ButtonSelectPath.TabIndex = 0;
            this.ButtonSelectPath.Text = "최상위 경로 선택";
            this.ButtonSelectPath.UseVisualStyleBackColor = true;
            this.ButtonSelectPath.Click += new System.EventHandler(this.ButtonSelectPath_Click);
            // 
            // PanelTop
            // 
            this.PanelTop.Controls.Add(this.ButtonDisplay);
            this.PanelTop.Controls.Add(this.TextBoxRootPath);
            this.PanelTop.Controls.Add(this.ButtonSelectPath);
            this.PanelTop.Controls.Add(this.MenuStripMain);
            this.PanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTop.Location = new System.Drawing.Point(0, 0);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(784, 99);
            this.PanelTop.TabIndex = 1;
            // 
            // ButtonDisplay
            // 
            this.ButtonDisplay.Location = new System.Drawing.Point(12, 67);
            this.ButtonDisplay.Name = "ButtonDisplay";
            this.ButtonDisplay.Size = new System.Drawing.Size(352, 23);
            this.ButtonDisplay.TabIndex = 2;
            this.ButtonDisplay.Text = "검색 / 갱신";
            this.ButtonDisplay.UseVisualStyleBackColor = true;
            this.ButtonDisplay.Click += new System.EventHandler(this.ButtonDisplay_Click);
            // 
            // TextBoxRootPath
            // 
            this.TextBoxRootPath.Location = new System.Drawing.Point(127, 38);
            this.TextBoxRootPath.Name = "TextBoxRootPath";
            this.TextBoxRootPath.ReadOnly = true;
            this.TextBoxRootPath.Size = new System.Drawing.Size(645, 23);
            this.TextBoxRootPath.TabIndex = 1;
            // 
            // MenuStripMain
            // 
            this.MenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
            this.MenuStripMain.Location = new System.Drawing.Point(0, 0);
            this.MenuStripMain.Name = "MenuStripMain";
            this.MenuStripMain.Size = new System.Drawing.Size(784, 24);
            this.MenuStripMain.TabIndex = 3;
            this.MenuStripMain.Text = "menuStrip1";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.AboutToolStripMenuItem.Text = "&About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // ListViewMain
            // 
            this.ListViewMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListViewMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeaderPath,
            this.ColumnHeaderStatus,
            this.ColumnHeaderAttributes});
            this.ListViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewMain.FullRowSelect = true;
            this.ListViewMain.GridLines = true;
            this.ListViewMain.Location = new System.Drawing.Point(0, 0);
            this.ListViewMain.MultiSelect = false;
            this.ListViewMain.Name = "ListViewMain";
            this.ListViewMain.ShowItemToolTips = true;
            this.ListViewMain.Size = new System.Drawing.Size(784, 532);
            this.ListViewMain.TabIndex = 2;
            this.ListViewMain.UseCompatibleStateImageBehavior = false;
            this.ListViewMain.View = System.Windows.Forms.View.Details;
            this.ListViewMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewMain_MouseDoubleClick);
            this.ListViewMain.Resize += new System.EventHandler(this.ListViewMain_Resize);
            // 
            // ColumnHeaderPath
            // 
            this.ColumnHeaderPath.Text = "경로";
            this.ColumnHeaderPath.Width = 120;
            // 
            // ColumnHeaderStatus
            // 
            this.ColumnHeaderStatus.Text = "상태";
            this.ColumnHeaderStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeaderStatus.Width = 120;
            // 
            // ColumnHeaderAttributes
            // 
            this.ColumnHeaderAttributes.Text = "디렉토리 속성";
            this.ColumnHeaderAttributes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeaderAttributes.Width = 120;
            // 
            // PanelCenter
            // 
            this.PanelCenter.Controls.Add(this.ListViewMain);
            this.PanelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCenter.Location = new System.Drawing.Point(0, 99);
            this.PanelCenter.Name = "PanelCenter";
            this.PanelCenter.Size = new System.Drawing.Size(784, 532);
            this.PanelCenter.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 631);
            this.Controls.Add(this.PanelCenter);
            this.Controls.Add(this.PanelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStripMain;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormMain";
            this.Text = "EmptyDirs";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.PanelTop.ResumeLayout(false);
            this.PanelTop.PerformLayout();
            this.MenuStripMain.ResumeLayout(false);
            this.MenuStripMain.PerformLayout();
            this.PanelCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button ButtonSelectPath;
        private Panel PanelTop;
        private TextBox TextBoxRootPath;
        private Button ButtonDisplay;
        private ListView ListViewMain;
        private ColumnHeader ColumnHeaderPath;
        private ColumnHeader ColumnHeaderStatus;
        private ColumnHeader ColumnHeaderAttributes;
        private Panel PanelCenter;
        private MenuStrip MenuStripMain;
        private ToolStripMenuItem AboutToolStripMenuItem;
    }
}