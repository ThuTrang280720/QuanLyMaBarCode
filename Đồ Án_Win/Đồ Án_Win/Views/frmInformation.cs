using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib;
using QRCoder;
using Đồ_Án_Win.Models;
using Đồ_Án_Win.Controlls;
using System.Drawing.Imaging;

//https://laptrinh360.com/su-dung-ma-barcode-va-qrcode-trong-csharp/

namespace Đồ_Án_Win
{
    public partial class Suon : Form
    {
        private int ID;
        BarcodeLib.Barcode code128;
        Print formin;

        List<SanPham> listSP;
        DateTimePicker dtp;
        bool failusername;
        public int rowIndex;
        public Suon(ref List<SanPham> sanphams)
        {
            InitializeComponent();
            
            BindingSource source = new BindingSource();
            source.DataSource = SPController.getListSP();
           
            DisPlayInformation();
        }
        void DisPlayInformation()
        {
            listInformation.Items.Clear();

            List<SanPham> sanPhams = SPController.getListSP();
            foreach(SanPham sanPham in sanPhams)
            {
                ListViewItem item = new ListViewItem(sanPham.ID.ToString());
                item.SubItems.Add(sanPham.MaSanPham);
                item.SubItems.Add(sanPham.TenSanPham);
                item.SubItems.Add(sanPham.GiaSanPham);
                item.SubItems.Add(sanPham.NgayIn.ToString());
                
                listInformation.Items.Add(item);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtmasp.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.txtmasp, "Nhập mã sản phẩm");
                return;
            }
            else if (SPController.getSanPham( this.txtmasp.Text) != null)
            {
                this.errorProvider1.SetError(this.txtmasp, "Mã Sản Phẩm Đã Tồn Tại");
                return;
            }
            else if (this.txttensp.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.txttensp, "Nhập tên Sản Phẩm");
                return;
            }
            else if (this.txtgiasp.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.txtgiasp, "Nhập giá sản phẩm");
                return;
            }
            else if (Convert.ToDateTime(dtpngayin.Value.ToString()) <= Convert.ToDateTime(DateTime.Today.ToString()))
            {
                this.errorProvider1.SetError(this.dtpngayin, "Ngày in phải nhỏ hơn hoặc bằng ngày hiện tại");
                return;
            }
            else
            {
                SanPham sanpham = new SanPham();
                sanpham.MaSanPham = this.txtmasp.Text.Trim();
                sanpham.TenSanPham = this.txttensp.Text.Trim();
                sanpham.GiaSanPham = this.txtgiasp.Text.Trim();
                sanpham.NgayIn = this.dtpngayin.Value;


                ListViewItem information = new ListViewItem(this.ID.ToString());
                information.SubItems.Add(new ListViewItem.ListViewSubItem(information, txtmasp.Text));
                information.SubItems.Add(new ListViewItem.ListViewSubItem(information, txttensp.Text));
                information.SubItems.Add(new ListViewItem.ListViewSubItem(information, txtgiasp.Text));
                information.SubItems.Add(new ListViewItem.ListViewSubItem(information, dtpngayin.Value.ToString()));

                this.listInformation.Items.Add(information);

                Bitmap bm = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
                this.pictureBox1.DrawToBitmap(bm, this.pictureBox1.ClientRectangle);
                this.pictureBox1.CreateGraphics().Clear(Color.White);

               
                bm = new Bitmap(this.pictureBox1.Width + 2, this.pictureBox1.Height + 2);

                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                //In ma 3D
                QRCoder.QRCodeGenerator qr = new QRCoder.QRCodeGenerator();
                var data = qr.CreateQrCode(txttensp.Text, QRCoder.QRCodeGenerator.ECCLevel.H);
                var code = new QRCoder.QRCode(data);
                pictureBox1.Image = code.GetGraphic(5);

                MemoryStream stream = new MemoryStream();
                code.GetGraphic(5).Save(stream, ImageFormat.Jpeg);
                sanpham.ImgQCode = stream.ToArray();

                //In ma 2D
                string barcode = txttensp.Text;
                try
                {
                    Zen.Barcode.Code128BarcodeDraw br = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                    pictureBox2.Image = br.Draw(barcode, 40);

                    MemoryStream stream1 = new MemoryStream();
                    br.Draw(barcode, 40).Save(stream1, ImageFormat.Jpeg);
                    sanpham.Img1D = stream1.ToArray();
                }
                catch (Exception ex)
                {

                }

                if (SPController.AddSanPham(sanpham) == false)
                {
                    MessageBox.Show("Lỗi thêm user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txttensp.Text = string.Empty;
                txtmasp.Text = string.Empty;
                txtgiasp.Text = string.Empty;
                dtpngayin.Value = DateTime.Now;
                this.errorProvider1.Clear();

                DisPlayInformation();
            }
            
        }

        int clickId;
        int NextSP;

        private void listInformation_Click(object sender, EventArgs e)
        {
            int iD = Convert.ToInt32(listInformation.SelectedItems[0].SubItems[0].Text);

            SanPham sanpham = SPController.GetSPByID(iD);
            this.txtmasp.Text = this.listInformation.SelectedItems[0].SubItems[1].Text.Trim();
            this.txttensp.Text = this.listInformation.SelectedItems[0].SubItems[2].Text.Trim();
            this.txtmasp.Text = this.listInformation.SelectedItems[0].SubItems[3].Text.Trim();
            this.dtpngayin.Value = DateTime.Parse(this.listInformation.SelectedItems[0].SubItems[4].Text.Trim());

            if (sanpham != null)
            {
                MemoryStream picMaQR = new MemoryStream(sanpham.ImgQCode.ToArray());
                MemoryStream picMaVach = new MemoryStream(sanpham.Img1D.ToArray());


                pictureBox1.Image = Image.FromStream(picMaQR);
                pictureBox2.Image = Image.FromStream(picMaVach);

                sp.QrCode = Image.FromStream(picMaQR);
                sp.MaVach = Image.FromStream(picMaVach);

                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;

            }
        }

        private void Suon_Load(object sender, EventArgs e)
        {
            ID = 1;
            this.helpProvider1.SetShowHelp(this.txttensp, true);
            this.helpProvider1.SetHelpString(this.txttensp, "Nhap ten san pham");
            this.helpProvider1.SetShowHelp(this.txtmasp, true);
            this.helpProvider1.SetHelpString(this.txtmasp, "Nhap ma san pham");
            this.helpProvider1.SetShowHelp(this.txtgiasp, true);
            this.helpProvider1.SetHelpString(this.txtgiasp, "Nhap ten san pham");
            this.helpProvider1.SetShowHelp(this.dtpngayin, true);
            this.helpProvider1.SetHelpString(this.dtpngayin, "Nhap ngay in san pham");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < listInformation.Items.Count; i++)
                {
                    if (listInformation.Items[i].Selected)
                        listInformation.Items[i].Remove();
                }
                SanPham sanpham = SPController.getSanPham(this.ID.ToString());
                SPController.DeleteSanPham(Convert.ToInt32(sanpham.ID));
            }
            catch
            {
                txtmasp.Clear();
                txttensp.Clear();
                txtgiasp.Clear();
                this.errorProvider1.Clear();
                listInformation.Items.Clear();
                return;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Print formin = new Print();
            formin.ShowDialog();
            //this.Close();
        }

        private void listInformation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void txtmasp_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
