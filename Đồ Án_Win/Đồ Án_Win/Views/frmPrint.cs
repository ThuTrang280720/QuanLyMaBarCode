using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using Đồ_Án_Win.Models;
using Đồ_Án_Win.Controlls;

namespace Đồ_Án_Win
{
    public partial class Print : Form
    {
        List<SanPham> listSP; 
        
        public Print()
        {
            InitializeComponent();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            // //CHange Picturebox
            pictureBoxin.Image = sp.QrCode;
            pictureBoxin.SizeMode = PictureBoxSizeMode.CenterImage;

            // Open Print Dialog
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += Doc_PrintPage;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
                doc.Print();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //CHange Picturebox
            pictureBoxin.Image = sp.MaVach;
            pictureBoxin.SizeMode = PictureBoxSizeMode.CenterImage;

            // Open Print Dialog
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += Doc_PrintPage;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
                doc.Print();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
