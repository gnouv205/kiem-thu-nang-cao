using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3GUI_
{
    public partial class frm_Main : Form
    {
        public static string email = "";

        public static int seesion = 1;
        public frm_Main()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void PhanQuyen()
        {
            if (frm_DangNhap.vaitro == "Quản Trị")
            {
                // Nếu là quan ly
                danhMụcToolStripMenuItem.Visible = true;
                quảnLýThốngKêToolStripMenuItem.Visible = true;
            }
            else
            {
                // Nếu là nhân viên thông thường
                danhMụcToolStripMenuItem.Visible = false;
                tàiKhoảnToolStripMenuItem.Visible = true;
                phòngTrọToolStripMenuItem.Visible = true;
                kháchThuêToolStripMenuItem.Visible = false;

                thốngKêHóaĐơnToolStripMenuItem.Visible = false;
                hóaĐơnToolStripMenuItem.Visible = false;
                thốngKêHóaĐơnToolStripMenuItem.Visible = false;

            }
        }

        void GiaTriBanDau()
        {
            if(seesion == 1)
            {
                đăngXuấtToolStripMenuItem1.Visible = false;
                ĐổiMậtKhẩuToolStripMenuItem.Visible = false;
                danhMụcToolStripMenuItem.Visible = false;
                quảnLýThốngKêToolStripMenuItem.Visible = false;
                tàiKhoảnĐăngNhậpToolStripMenuItem.Visible = false;
                đăngNhậpToolStripMenuItem.Visible = true;
            }
            else
            {
                label1.Visible = false;
                tàiKhoảnĐăngNhậpToolStripMenuItem.Visible = true;
                tàiKhoảnĐăngNhậpToolStripMenuItem.Text = "Chao " + email;
                đăngXuấtToolStripMenuItem1.Visible = true;
                ĐổiMậtKhẩuToolStripMenuItem.Visible = true;
                đăngNhậpToolStripMenuItem.Visible = false;
                PhanQuyen();
            }
        }


        #region Hoạt Động của form con

        private bool KiemTraFormCon(Form form)
        {
            foreach (Form frm in MdiChildren)
            {
                if(frm.Name == form.Name)
                {
                    return true;
                }
            }
            return false;
        }

        private void FormDangHoatDong(Form form)
        {
            foreach(Form frm in MdiChildren)
            {
                if(frm.Name == form.Name)
                {
                    form.Activate();
                }
            }
        }

        public void MoForm(Form form)
        {
            DongForm();

            if (!KiemTraFormCon(form))
            {
                form.MdiParent = this;
                form.FormClosed += Form_FormClosed;
                form.Show();
            }
            else
            {
                FormDangHoatDong(form);
            }
        }

        public void DongForm()
        {
            foreach (Form form in this.MdiChildren)
            {
                // Đóng Form con
                form.Close();
            }
        }
        #endregion


        #region Chuc Nang
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_Main_Load(sender, e);
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            GiaTriBanDau();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoForm(new frm_NguoiDung());
        }

        private void phòngTrọToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoForm(new frm_PhongTro());
        }

        private void kháchThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoForm(new frm_KhachThue());
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoForm(new frm_DangNhap());
        }

        private void ĐổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoForm(new frm_DoiMatKhau());
        }
        private void hợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoForm(new frm_HopDong());
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoForm(new frm_HoaDon());
        }

        private void thôngTinSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            MoForm(new frm_GioiThieu());
        }

        private void hướngDẫnSửDụngToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            seesion = 1;
            DongForm();
            frm_Main_Load(sender, e);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hủyHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoForm(new frm_ViPham());
        }
        #endregion

        private void thốngKêHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoForm(new frm_ThongKeHoaDon());
        }
    }
}
