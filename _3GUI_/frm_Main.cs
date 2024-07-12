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
        public static string email;
        public static int ResetForm = 1; // load form
        public frm_Main()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
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

        private void MoForm(Form form)
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



        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_Main_Load(sender, e);
        }
        private void frm_Main_Load(object sender, EventArgs e)
        {
            ResetForm = 1;
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoForm(new frm_NguoiDung());
        }

        private void phòngTrọToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoForm(new frm_PhongTro());
        }
    }
}
