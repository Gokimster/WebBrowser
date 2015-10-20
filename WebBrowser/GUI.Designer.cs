namespace WebBrowser
{
    partial class GUI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newTabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.favMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.historyMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.addTabBtn = new System.Windows.Forms.Button();
            this.removeTabBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.favMenu,
            this.historyMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(829, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTabMenuItem,
            this.clearHistory});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(44, 20);
            this.fileMenu.Text = "FILE";
            // 
            // newTabMenuItem
            // 
            this.newTabMenuItem.Name = "newTabMenuItem";
            this.newTabMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.newTabMenuItem.Size = new System.Drawing.Size(209, 22);
            this.newTabMenuItem.Text = "NEW TAB";
            this.newTabMenuItem.Click += new System.EventHandler(this.newTabMenuItem_Click);
            // 
            // clearHistory
            // 
            this.clearHistory.Name = "clearHistory";
            this.clearHistory.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Delete)));
            this.clearHistory.Size = new System.Drawing.Size(250, 22);
            this.clearHistory.Text = "CLEAR HISTORY";
            this.clearHistory.Click += new System.EventHandler(this.clearHistory_Click);
            // 
            // favMenu
            // 
            this.favMenu.Name = "favMenu";
            this.favMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.favMenu.Size = new System.Drawing.Size(93, 20);
            this.favMenu.Text = "FAVOURITES";
            // 
            // historyMenu
            // 
            this.historyMenu.Name = "historyMenu";
            this.historyMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.historyMenu.Size = new System.Drawing.Size(71, 20);
            this.historyMenu.Text = "HISTORY";
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(829, 421);
            this.tabControl1.TabIndex = 6;
            // 
            // addTabBtn
            // 
            this.addTabBtn.Location = new System.Drawing.Point(800, 23);
            this.addTabBtn.Name = "addTabBtn";
            this.addTabBtn.Size = new System.Drawing.Size(25, 24);
            this.addTabBtn.TabIndex = 7;
            this.addTabBtn.Text = "+";
            this.addTabBtn.UseVisualStyleBackColor = true;
            this.addTabBtn.Click += new System.EventHandler(this.addTabBtn_Click);
            // 
            // removeTabBtn
            // 
            this.removeTabBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeTabBtn.ForeColor = System.Drawing.Color.DarkRed;
            this.removeTabBtn.Location = new System.Drawing.Point(769, 23);
            this.removeTabBtn.Name = "removeTabBtn";
            this.removeTabBtn.Size = new System.Drawing.Size(25, 24);
            this.removeTabBtn.TabIndex = 8;
            this.removeTabBtn.Text = "-";
            this.removeTabBtn.UseVisualStyleBackColor = true;
            this.removeTabBtn.Click += new System.EventHandler(this.removeTabBtn_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(829, 450);
            this.Controls.Add(this.removeTabBtn);
            this.Controls.Add(this.addTabBtn);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GUI";
            this.Text = "WebBrowser";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem favMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem newTabMenuItem;
        private System.Windows.Forms.Button addTabBtn;
        private System.Windows.Forms.Button removeTabBtn;
        private System.Windows.Forms.ToolStripMenuItem historyMenu;
        private System.Windows.Forms.ToolStripMenuItem clearHistory;
    }
}

