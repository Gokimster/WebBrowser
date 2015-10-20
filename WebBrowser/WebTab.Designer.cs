using System.ComponentModel;

namespace WebBrowser
{
    partial class WebTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebTab));
            this.address = new System.Windows.Forms.TextBox();
            this.backBtn = new System.Windows.Forms.Button();
            this.fwdBtn = new System.Windows.Forms.Button();
            this.favBtn = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.favNameBox = new System.Windows.Forms.TextBox();
            this.pageContent = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // worker
            // 
            this.worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(58, 0);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(526, 20);
            this.address.TabIndex = 1;
            this.address.Text = "Enter Address";
            this.address.KeyDown += new System.Windows.Forms.KeyEventHandler(this.address_KeyDown);
            this.Controls.Add(this.address);
            // 
            // backBtn
            // 
            this.backBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backBtn.BackgroundImage")));
            this.backBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backBtn.Location = new System.Drawing.Point(0, 0);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(25, 23);
            this.backBtn.TabIndex = 2;
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            this.Controls.Add(this.backBtn);
            // 
            // fwdBtn
            // 
            this.fwdBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("fwdBtn.BackgroundImage")));
            this.fwdBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fwdBtn.Location = new System.Drawing.Point(27, 0);
            this.fwdBtn.Name = "fwdBtn";
            this.fwdBtn.Size = new System.Drawing.Size(25, 23);
            this.fwdBtn.TabIndex = 3;
            this.fwdBtn.UseVisualStyleBackColor = true;
            this.fwdBtn.Click += new System.EventHandler(this.fwdBtn_Click);
            this.Controls.Add(this.fwdBtn);
            // 
            // favBtn
            // 
            this.favBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("favBtn.BackgroundImage")));
            this.favBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.favBtn.Location = new System.Drawing.Point(621, 0);
            this.favBtn.Name = "favBtn";
            this.favBtn.Size = new System.Drawing.Size(25, 23);
            this.favBtn.TabIndex = 4;
            this.favBtn.UseVisualStyleBackColor = true;
            this.favBtn.Click += new System.EventHandler(this.favBtn_Click);
            this.Controls.Add(this.favBtn);
            // 
            // homeBtn
            // 
            this.homeBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("homeBtn.BackgroundImage")));
            this.homeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.homeBtn.Location = new System.Drawing.Point(590, 0);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(25, 23);
            this.homeBtn.TabIndex = 5;
            this.homeBtn.UseVisualStyleBackColor = true;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            this.Controls.Add(this.homeBtn);
            // 
            // favNameBox
            // 
            this.favNameBox.Location = new System.Drawing.Point(652, 0);
            this.favNameBox.Name = "favNameBox";
            this.favNameBox.Size = new System.Drawing.Size(161, 20);
            this.favNameBox.TabIndex = 7;
            this.favNameBox.Text = "Favourite Name";
            this.Controls.Add(this.favNameBox);
            // 
            // pageContent
            // 
            this.pageContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pageContent.Cursor = System.Windows.Forms.Cursors.Default;
            this.pageContent.Location = new System.Drawing.Point(3, 26);
            this.pageContent.Multiline = true;
            this.pageContent.Name = "pageContent";
            this.pageContent.ReadOnly = true;
            this.pageContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pageContent.Size = new System.Drawing.Size(815, 376);
            this.pageContent.TabIndex = 6;
            this.Controls.Add(this.pageContent);
            // 
            // WebTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Name = "WebTab";
            this.Size = new System.Drawing.Size(829, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button fwdBtn;
        private System.Windows.Forms.Button favBtn;
        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.TextBox pageContent;
        private System.Windows.Forms.TextBox favNameBox;
    }
}
