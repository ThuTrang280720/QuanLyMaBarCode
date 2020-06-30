using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Đồ_Án_Win.Models;

namespace Đồ_Án_Win
{
    public partial class frmMainGUI : Form
    {
        //frmInformation fromThongTin;
        Print fromin;
        Suon fromInformation;
        List<SanPham> listSP;
        public frmMainGUI()
        {
            InitializeComponent();
            listSP = new List<SanPham>();
        }

        private void frmMainGUI_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                return;
            }
            this.ActiveMdiChild.WindowState = FormWindowState.Maximized;
            if (this.ActiveMdiChild.Tag == null)
            {
                TabPage tp = new TabPage(this.ActiveMdiChild.Text);
                tp.Tag = this.ActiveMdiChild;
                tp.Parent = this.tabMain;
                this.tabMain.SelectedTab = tp;
                this.ActiveMdiChild.Tag = tp;
                this.ActiveMdiChild.FormClosed += ActiveMdiChild_FormClosed;
            }
        }

        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
        }

        private void mExit_Click(object sender, EventArgs e)
        {
            DialogResult tb;
           tb= MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           if(tb== DialogResult.Yes)
            {
                Application.Exit();
            }
          
        }

        private void choToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mPrintf_Click(object sender, EventArgs e)
        {
            if (this.fromin is null || this.fromin.IsDisposed)
            {
                this.fromin = new Print();
                this.fromin.MdiParent = this;
                this.fromin.Show();
            }
            else
            {
                this.fromin.Select();
            }
        }
        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabMain.SelectedTab != null && this.tabMain.SelectedTab.Tag != null)
                (this.tabMain.SelectedTab.Tag as Form).Select();
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mFunction_Click(object sender, EventArgs e)
        {
            if (this.fromInformation is null || this.fromInformation.IsDisposed)
            {
                this.fromInformation = new Suon(ref listSP);
                this.fromInformation.MdiParent = this;
                fromInformation.MaximizeBox = false;
                this.fromInformation.Show();
            }
            else
            {
                this.fromInformation.Select();
            }
        }
    }
}
