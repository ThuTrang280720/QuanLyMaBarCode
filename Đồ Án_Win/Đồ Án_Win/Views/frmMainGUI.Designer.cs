namespace Đồ_Án_Win
{
    partial class frmMainGUI
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.mFunction = new System.Windows.Forms.ToolStripMenuItem();
            this.mExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mFunction,
            this.mExit});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip2.Size = new System.Drawing.Size(632, 24);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip2_ItemClicked);
            // 
            // mFunction
            // 
            this.mFunction.Name = "mFunction";
            this.mFunction.Size = new System.Drawing.Size(112, 20);
            this.mFunction.Text = "&Quản lý thông tin";
            this.mFunction.Click += new System.EventHandler(this.mFunction_Click);
            // 
            // mExit
            // 
            this.mExit.Name = "mExit";
            this.mExit.Size = new System.Drawing.Size(49, 20);
            this.mExit.Text = "&Thoát";
            this.mExit.Click += new System.EventHandler(this.mExit_Click);
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabMain.Location = new System.Drawing.Point(0, 24);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(632, 30);
            this.tabMain.TabIndex = 4;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // frmMainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Đồ_Án_Win.Properties.Resources.qr_codes_creative;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.menuStrip2);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "frmMainGUI";
            this.Text = "Quản Lý In Mã Barcode";
            this.MdiChildActivate += new System.EventHandler(this.frmMainGUI_MdiChildActivate);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem mFunction;
        private System.Windows.Forms.ToolStripMenuItem mExit;
        private System.Windows.Forms.TabControl tabMain;
    }
}



