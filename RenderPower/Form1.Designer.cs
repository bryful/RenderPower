namespace RenderPower
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watchStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watchStopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.BtnSelectWatchFolder = new System.Windows.Forms.Button();
            this.TbWatchFolder = new System.Windows.Forms.TextBox();
            this.BtnWatchStart = new System.Windows.Forms.Button();
            this.BtnWatchStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CbIsStartup = new System.Windows.Forms.CheckBox();
            this.BtnStopOrder = new System.Windows.Forms.Button();
            this.LbList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(725, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // SelectToolStripMenuItem
            // 
            this.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem";
            this.SelectToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.SelectToolStripMenuItem.Text = "Select Watch Folder";
            this.SelectToolStripMenuItem.Click += new System.EventHandler(this.SelectToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.watchStartToolStripMenuItem,
            this.watchStopToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // watchStartToolStripMenuItem
            // 
            this.watchStartToolStripMenuItem.Name = "watchStartToolStripMenuItem";
            this.watchStartToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.watchStartToolStripMenuItem.Text = "Watch Start";
            // 
            // watchStopToolStripMenuItem
            // 
            this.watchStopToolStripMenuItem.Name = "watchStopToolStripMenuItem";
            this.watchStopToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.watchStopToolStripMenuItem.Text = "Watch Stop";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.aboutToolStripMenuItem.Text = "バージョン情報の表示";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 556);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(725, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(293, 197);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(420, 340);
            this.listBox1.TabIndex = 2;
            // 
            // BtnSelectWatchFolder
            // 
            this.BtnSelectWatchFolder.Location = new System.Drawing.Point(23, 37);
            this.BtnSelectWatchFolder.Name = "BtnSelectWatchFolder";
            this.BtnSelectWatchFolder.Size = new System.Drawing.Size(139, 23);
            this.BtnSelectWatchFolder.TabIndex = 3;
            this.BtnSelectWatchFolder.Text = "select WatchFolder";
            this.BtnSelectWatchFolder.UseVisualStyleBackColor = true;
            this.BtnSelectWatchFolder.Click += new System.EventHandler(this.BtnSelectWatchFolder_Click);
            // 
            // TbWatchFolder
            // 
            this.TbWatchFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbWatchFolder.Location = new System.Drawing.Point(23, 66);
            this.TbWatchFolder.Name = "TbWatchFolder";
            this.TbWatchFolder.Size = new System.Drawing.Size(694, 19);
            this.TbWatchFolder.TabIndex = 4;
            // 
            // BtnWatchStart
            // 
            this.BtnWatchStart.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnWatchStart.Location = new System.Drawing.Point(34, 91);
            this.BtnWatchStart.Name = "BtnWatchStart";
            this.BtnWatchStart.Size = new System.Drawing.Size(121, 37);
            this.BtnWatchStart.TabIndex = 5;
            this.BtnWatchStart.Text = "Watch Start";
            this.BtnWatchStart.UseVisualStyleBackColor = true;
            // 
            // BtnWatchStop
            // 
            this.BtnWatchStop.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnWatchStop.Location = new System.Drawing.Point(161, 91);
            this.BtnWatchStop.Name = "BtnWatchStop";
            this.BtnWatchStop.Size = new System.Drawing.Size(206, 37);
            this.BtnWatchStop.TabIndex = 6;
            this.BtnWatchStop.Text = "Stop Watch  and Render ";
            this.BtnWatchStop.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(300, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Progress";
            // 
            // CbIsStartup
            // 
            this.CbIsStartup.AutoSize = true;
            this.CbIsStartup.Location = new System.Drawing.Point(34, 134);
            this.CbIsStartup.Name = "CbIsStartup";
            this.CbIsStartup.Size = new System.Drawing.Size(187, 16);
            this.CbIsStartup.TabIndex = 9;
            this.CbIsStartup.Text = "Go to Watching mode at startup";
            this.CbIsStartup.UseVisualStyleBackColor = true;
            // 
            // BtnStopOrder
            // 
            this.BtnStopOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnStopOrder.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnStopOrder.Location = new System.Drawing.Point(177, 508);
            this.BtnStopOrder.Name = "BtnStopOrder";
            this.BtnStopOrder.Size = new System.Drawing.Size(110, 25);
            this.BtnStopOrder.TabIndex = 11;
            this.BtnStopOrder.Text = "Stop Order";
            this.BtnStopOrder.UseVisualStyleBackColor = true;
            // 
            // LbList
            // 
            this.LbList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LbList.FormattingEnabled = true;
            this.LbList.ItemHeight = 12;
            this.LbList.Location = new System.Drawing.Point(23, 198);
            this.LbList.Name = "LbList";
            this.LbList.Size = new System.Drawing.Size(264, 304);
            this.LbList.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "Render Info Files";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(177, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 25);
            this.button1.TabIndex = 14;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 578);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LbList);
            this.Controls.Add(this.BtnStopOrder);
            this.Controls.Add(this.CbIsStartup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnWatchStop);
            this.Controls.Add(this.BtnWatchStart);
            this.Controls.Add(this.TbWatchFolder);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.BtnSelectWatchFolder);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "RenderPower";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button BtnSelectWatchFolder;
        private System.Windows.Forms.TextBox TbWatchFolder;
        private System.Windows.Forms.Button BtnWatchStart;
        private System.Windows.Forms.Button BtnWatchStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CbIsStartup;
        private System.Windows.Forms.Button BtnStopOrder;
        private System.Windows.Forms.ToolStripMenuItem watchStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem watchStopToolStripMenuItem;
        private System.Windows.Forms.ListBox LbList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}

