
namespace _3GUI_
{
    partial class frm_ViPham
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
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dgvViPham = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonKhach = new System.Windows.Forms.RadioButton();
            this.radioButtonChu = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonHuy = new System.Windows.Forms.RadioButton();
            this.radioButtonChua = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaKhach = new System.Windows.Forms.TextBox();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.txtMaND = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoiThuong = new System.Windows.Forms.TextBox();
            this.txtBienPhap = new System.Windows.Forms.TextBox();
            this.dtpNgayViPham = new System.Windows.Forms.DateTimePicker();
            this.lblGiaPhong = new System.Windows.Forms.Label();
            this.lblTienNuoc = new System.Windows.Forms.Label();
            this.lblTienDien = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.txtMaViPham = new System.Windows.Forms.TextBox();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.lblMaKhach = new System.Windows.Forms.Label();
            this.lblMaPhong = new System.Windows.Forms.Label();
            this.lblNgayBatDau = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXacNhanHuy = new System.Windows.Forms.Button();
            this.btnLap = new System.Windows.Forms.Button();
            this.btnHienDanhSach = new System.Windows.Forms.Button();
            this.btnXuatFile = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonTimMaK = new System.Windows.Forms.RadioButton();
            this.radioButtonNgayKT = new System.Windows.Forms.RadioButton();
            this.checkBoxDaHuy = new System.Windows.Forms.CheckBox();
            this.dtpNgayHuy = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViPham)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(190, 60);
            this.txtMaHD.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(252, 22);
            this.txtMaHD.TabIndex = 28;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(9, 23);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(364, 22);
            this.txtTimKiem.TabIndex = 27;
            // 
            // dgvViPham
            // 
            this.dgvViPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvViPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViPham.Location = new System.Drawing.Point(15, 382);
            this.dgvViPham.Name = "dgvViPham";
            this.dgvViPham.ReadOnly = true;
            this.dgvViPham.RowHeadersWidth = 51;
            this.dgvViPham.RowTemplate.Height = 24;
            this.dgvViPham.Size = new System.Drawing.Size(1249, 239);
            this.dgvViPham.TabIndex = 27;
            this.dgvViPham.Click += new System.EventHandler(this.dgvViPham_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 23);
            this.label2.TabIndex = 22;
            this.label2.Text = "Mã Hợp Đồng:";
            // 
            // radioButtonKhach
            // 
            this.radioButtonKhach.AutoSize = true;
            this.radioButtonKhach.Location = new System.Drawing.Point(326, 250);
            this.radioButtonKhach.Name = "radioButtonKhach";
            this.radioButtonKhach.Size = new System.Drawing.Size(116, 21);
            this.radioButtonKhach.TabIndex = 20;
            this.radioButtonKhach.TabStop = true;
            this.radioButtonKhach.Text = "Khách Thuê";
            this.radioButtonKhach.UseVisualStyleBackColor = true;
            this.radioButtonKhach.CheckedChanged += new System.EventHandler(this.radioButtonKhach_CheckedChanged);
            // 
            // radioButtonChu
            // 
            this.radioButtonChu.AutoSize = true;
            this.radioButtonChu.Location = new System.Drawing.Point(190, 251);
            this.radioButtonChu.Name = "radioButtonChu";
            this.radioButtonChu.Size = new System.Drawing.Size(99, 21);
            this.radioButtonChu.TabIndex = 19;
            this.radioButtonChu.TabStop = true;
            this.radioButtonChu.Text = "Chủ Thuê";
            this.radioButtonChu.UseVisualStyleBackColor = true;
            this.radioButtonChu.CheckedChanged += new System.EventHandler(this.radioButtonKhach_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtpNgayHuy);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtMaKhach);
            this.panel3.Controls.Add(this.txtMaPhong);
            this.panel3.Controls.Add(this.txtMaND);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtMaHD);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.radioButtonKhach);
            this.panel3.Controls.Add(this.radioButtonChu);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtBoiThuong);
            this.panel3.Controls.Add(this.txtBienPhap);
            this.panel3.Controls.Add(this.dtpNgayViPham);
            this.panel3.Controls.Add(this.lblGiaPhong);
            this.panel3.Controls.Add(this.lblTienNuoc);
            this.panel3.Controls.Add(this.lblTienDien);
            this.panel3.Controls.Add(this.txtNoiDung);
            this.panel3.Controls.Add(this.txtMaViPham);
            this.panel3.Controls.Add(this.lblMaHD);
            this.panel3.Controls.Add(this.lblMaKhach);
            this.panel3.Controls.Add(this.lblMaPhong);
            this.panel3.Controls.Add(this.lblNgayBatDau);
            this.panel3.Location = new System.Drawing.Point(-1, 56);
            this.panel3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(872, 286);
            this.panel3.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButtonHuy);
            this.panel2.Controls.Add(this.radioButtonChua);
            this.panel2.Location = new System.Drawing.Point(593, 228);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(276, 45);
            this.panel2.TabIndex = 36;
            // 
            // radioButtonHuy
            // 
            this.radioButtonHuy.AutoSize = true;
            this.radioButtonHuy.Location = new System.Drawing.Point(205, 22);
            this.radioButtonHuy.Name = "radioButtonHuy";
            this.radioButtonHuy.Size = new System.Drawing.Size(57, 21);
            this.radioButtonHuy.TabIndex = 35;
            this.radioButtonHuy.TabStop = true;
            this.radioButtonHuy.Text = "Hủy";
            this.radioButtonHuy.UseVisualStyleBackColor = true;
            // 
            // radioButtonChua
            // 
            this.radioButtonChua.AutoSize = true;
            this.radioButtonChua.Location = new System.Drawing.Point(10, 21);
            this.radioButtonChua.Name = "radioButtonChua";
            this.radioButtonChua.Size = new System.Drawing.Size(99, 21);
            this.radioButtonChua.TabIndex = 34;
            this.radioButtonChua.TabStop = true;
            this.radioButtonChua.Text = "Chưa Hủy";
            this.radioButtonChua.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(454, 247);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 23);
            this.label4.TabIndex = 33;
            this.label4.Text = "Tình Trạng:";
            // 
            // txtMaKhach
            // 
            this.txtMaKhach.Location = new System.Drawing.Point(190, 156);
            this.txtMaKhach.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMaKhach.Name = "txtMaKhach";
            this.txtMaKhach.ReadOnly = true;
            this.txtMaKhach.Size = new System.Drawing.Size(252, 22);
            this.txtMaKhach.TabIndex = 32;
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Location = new System.Drawing.Point(190, 204);
            this.txtMaPhong.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.ReadOnly = true;
            this.txtMaPhong.Size = new System.Drawing.Size(252, 22);
            this.txtMaPhong.TabIndex = 31;
            // 
            // txtMaND
            // 
            this.txtMaND.Location = new System.Drawing.Point(190, 108);
            this.txtMaND.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMaND.Name = "txtMaND";
            this.txtMaND.ReadOnly = true;
            this.txtMaND.Size = new System.Drawing.Size(252, 22);
            this.txtMaND.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(12, 106);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 23);
            this.label6.TabIndex = 29;
            this.label6.Text = "Mã Người Dùng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(12, 248);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 23);
            this.label3.TabIndex = 18;
            this.label3.Text = "Người Vi Phạm:";
            // 
            // txtBoiThuong
            // 
            this.txtBoiThuong.Location = new System.Drawing.Point(603, 205);
            this.txtBoiThuong.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtBoiThuong.Name = "txtBoiThuong";
            this.txtBoiThuong.ReadOnly = true;
            this.txtBoiThuong.Size = new System.Drawing.Size(252, 22);
            this.txtBoiThuong.TabIndex = 15;
            // 
            // txtBienPhap
            // 
            this.txtBienPhap.Location = new System.Drawing.Point(603, 156);
            this.txtBienPhap.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtBienPhap.Name = "txtBienPhap";
            this.txtBienPhap.ReadOnly = true;
            this.txtBienPhap.Size = new System.Drawing.Size(252, 22);
            this.txtBienPhap.TabIndex = 13;
            // 
            // dtpNgayViPham
            // 
            this.dtpNgayViPham.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayViPham.Location = new System.Drawing.Point(603, 61);
            this.dtpNgayViPham.Name = "dtpNgayViPham";
            this.dtpNgayViPham.Size = new System.Drawing.Size(252, 27);
            this.dtpNgayViPham.TabIndex = 8;
            // 
            // lblGiaPhong
            // 
            this.lblGiaPhong.AutoSize = true;
            this.lblGiaPhong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaPhong.ForeColor = System.Drawing.Color.Blue;
            this.lblGiaPhong.Location = new System.Drawing.Point(455, 203);
            this.lblGiaPhong.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblGiaPhong.Name = "lblGiaPhong";
            this.lblGiaPhong.Size = new System.Drawing.Size(116, 23);
            this.lblGiaPhong.TabIndex = 14;
            this.lblGiaPhong.Text = "Bồi Thường:";
            // 
            // lblTienNuoc
            // 
            this.lblTienNuoc.AutoSize = true;
            this.lblTienNuoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienNuoc.ForeColor = System.Drawing.Color.Blue;
            this.lblTienNuoc.Location = new System.Drawing.Point(454, 154);
            this.lblTienNuoc.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTienNuoc.Name = "lblTienNuoc";
            this.lblTienNuoc.Size = new System.Drawing.Size(102, 23);
            this.lblTienNuoc.TabIndex = 12;
            this.lblTienNuoc.Text = "Biện Pháp:";
            // 
            // lblTienDien
            // 
            this.lblTienDien.AutoSize = true;
            this.lblTienDien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienDien.ForeColor = System.Drawing.Color.Blue;
            this.lblTienDien.Location = new System.Drawing.Point(455, 9);
            this.lblTienDien.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTienDien.Name = "lblTienDien";
            this.lblTienDien.Size = new System.Drawing.Size(95, 23);
            this.lblTienDien.TabIndex = 11;
            this.lblTienDien.Text = "Nội Dung:";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(603, 10);
            this.txtNoiDung.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(252, 24);
            this.txtNoiDung.TabIndex = 12;
            // 
            // txtMaViPham
            // 
            this.txtMaViPham.Location = new System.Drawing.Point(190, 8);
            this.txtMaViPham.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMaViPham.Name = "txtMaViPham";
            this.txtMaViPham.ReadOnly = true;
            this.txtMaViPham.Size = new System.Drawing.Size(252, 22);
            this.txtMaViPham.TabIndex = 2;
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHD.ForeColor = System.Drawing.Color.Blue;
            this.lblMaHD.Location = new System.Drawing.Point(12, 8);
            this.lblMaHD.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(120, 23);
            this.lblMaHD.TabIndex = 1;
            this.lblMaHD.Text = "Mã Vi Phạm:";
            // 
            // lblMaKhach
            // 
            this.lblMaKhach.AutoSize = true;
            this.lblMaKhach.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKhach.ForeColor = System.Drawing.Color.Blue;
            this.lblMaKhach.Location = new System.Drawing.Point(12, 154);
            this.lblMaKhach.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMaKhach.Name = "lblMaKhach";
            this.lblMaKhach.Size = new System.Drawing.Size(103, 23);
            this.lblMaKhach.TabIndex = 3;
            this.lblMaKhach.Text = "Mã Khách:";
            // 
            // lblMaPhong
            // 
            this.lblMaPhong.AutoSize = true;
            this.lblMaPhong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPhong.ForeColor = System.Drawing.Color.Blue;
            this.lblMaPhong.Location = new System.Drawing.Point(12, 205);
            this.lblMaPhong.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMaPhong.Name = "lblMaPhong";
            this.lblMaPhong.Size = new System.Drawing.Size(102, 23);
            this.lblMaPhong.TabIndex = 5;
            this.lblMaPhong.Text = "Mã Phòng:";
            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.AutoSize = true;
            this.lblNgayBatDau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayBatDau.ForeColor = System.Drawing.Color.Blue;
            this.lblNgayBatDau.Location = new System.Drawing.Point(455, 63);
            this.lblNgayBatDau.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.Size = new System.Drawing.Size(136, 23);
            this.lblNgayBatDau.TabIndex = 7;
            this.lblNgayBatDau.Text = "Ngày Vi Phạm:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnXacNhanHuy);
            this.panel1.Controls.Add(this.btnLap);
            this.panel1.Controls.Add(this.btnHienDanhSach);
            this.panel1.Controls.Add(this.btnXuatFile);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Location = new System.Drawing.Point(877, 178);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 164);
            this.panel1.TabIndex = 25;
            // 
            // btnXacNhanHuy
            // 
            this.btnXacNhanHuy.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhanHuy.ForeColor = System.Drawing.Color.Red;
            this.btnXacNhanHuy.Location = new System.Drawing.Point(202, 58);
            this.btnXacNhanHuy.Name = "btnXacNhanHuy";
            this.btnXacNhanHuy.Size = new System.Drawing.Size(185, 48);
            this.btnXacNhanHuy.TabIndex = 10;
            this.btnXacNhanHuy.Text = "Xác Nhận Hủy Hợp Đồng";
            this.btnXacNhanHuy.UseVisualStyleBackColor = true;
            this.btnXacNhanHuy.Click += new System.EventHandler(this.btnXacNhanHuy_Click);
            // 
            // btnLap
            // 
            this.btnLap.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLap.ForeColor = System.Drawing.Color.Red;
            this.btnLap.Location = new System.Drawing.Point(7, 58);
            this.btnLap.Name = "btnLap";
            this.btnLap.Size = new System.Drawing.Size(185, 48);
            this.btnLap.TabIndex = 9;
            this.btnLap.Text = "Lập Bảng Hủy";
            this.btnLap.UseVisualStyleBackColor = true;
            this.btnLap.Click += new System.EventHandler(this.btnLap_Click);
            // 
            // btnHienDanhSach
            // 
            this.btnHienDanhSach.BackColor = System.Drawing.Color.White;
            this.btnHienDanhSach.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHienDanhSach.ForeColor = System.Drawing.Color.Red;
            this.btnHienDanhSach.Location = new System.Drawing.Point(6, 4);
            this.btnHienDanhSach.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnHienDanhSach.Name = "btnHienDanhSach";
            this.btnHienDanhSach.Size = new System.Drawing.Size(186, 48);
            this.btnHienDanhSach.TabIndex = 2;
            this.btnHienDanhSach.Text = "Hiện Danh Sách";
            this.btnHienDanhSach.UseVisualStyleBackColor = false;
            this.btnHienDanhSach.Click += new System.EventHandler(this.btnHienDanhSach_Click);
            // 
            // btnXuatFile
            // 
            this.btnXuatFile.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatFile.ForeColor = System.Drawing.Color.Red;
            this.btnXuatFile.Location = new System.Drawing.Point(7, 112);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Size = new System.Drawing.Size(380, 48);
            this.btnXuatFile.TabIndex = 6;
            this.btnXuatFile.Text = "Xuất File";
            this.btnXuatFile.UseVisualStyleBackColor = true;
            this.btnXuatFile.Click += new System.EventHandler(this.btnXuatFile_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.White;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Red;
            this.btnThoat.Location = new System.Drawing.Point(201, 4);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(186, 48);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.White;
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.Red;
            this.btnTimKiem.Location = new System.Drawing.Point(191, 60);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(185, 48);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(574, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 43);
            this.label1.TabIndex = 24;
            this.label1.Text = "Hủy Hợp Đồng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonTimMaK);
            this.groupBox1.Controls.Add(this.radioButtonNgayKT);
            this.groupBox1.Controls.Add(this.txtTimKiem);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Location = new System.Drawing.Point(884, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 116);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm";
            // 
            // radioButtonTimMaK
            // 
            this.radioButtonTimMaK.AutoSize = true;
            this.radioButtonTimMaK.Location = new System.Drawing.Point(9, 58);
            this.radioButtonTimMaK.Name = "radioButtonTimMaK";
            this.radioButtonTimMaK.Size = new System.Drawing.Size(100, 21);
            this.radioButtonTimMaK.TabIndex = 33;
            this.radioButtonTimMaK.Text = "Mã Khách";
            this.radioButtonTimMaK.UseVisualStyleBackColor = true;
            // 
            // radioButtonNgayKT
            // 
            this.radioButtonNgayKT.AutoSize = true;
            this.radioButtonNgayKT.Location = new System.Drawing.Point(9, 85);
            this.radioButtonNgayKT.Name = "radioButtonNgayKT";
            this.radioButtonNgayKT.Size = new System.Drawing.Size(136, 21);
            this.radioButtonNgayKT.TabIndex = 34;
            this.radioButtonNgayKT.TabStop = true;
            this.radioButtonNgayKT.Text = "Ngày Kết Thúc";
            this.radioButtonNgayKT.UseVisualStyleBackColor = true;
            // 
            // checkBoxDaHuy
            // 
            this.checkBoxDaHuy.AutoSize = true;
            this.checkBoxDaHuy.Location = new System.Drawing.Point(15, 350);
            this.checkBoxDaHuy.Name = "checkBoxDaHuy";
            this.checkBoxDaHuy.Size = new System.Drawing.Size(160, 21);
            this.checkBoxDaHuy.TabIndex = 28;
            this.checkBoxDaHuy.Text = "Hợp Đồng Đã Hủy";
            this.checkBoxDaHuy.UseVisualStyleBackColor = true;
            this.checkBoxDaHuy.CheckedChanged += new System.EventHandler(this.checkBoxDaHuy_CheckedChanged);
            // 
            // dtpNgayHuy
            // 
            this.dtpNgayHuy.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayHuy.Location = new System.Drawing.Point(603, 108);
            this.dtpNgayHuy.Name = "dtpNgayHuy";
            this.dtpNgayHuy.Size = new System.Drawing.Size(252, 27);
            this.dtpNgayHuy.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(455, 110);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 23);
            this.label5.TabIndex = 37;
            this.label5.Text = "Ngày Hủy:";
            // 
            // frm_ViPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 633);
            this.Controls.Add(this.checkBoxDaHuy);
            this.Controls.Add(this.dgvViPham);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frm_ViPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vi Phạm";
            this.Load += new System.EventHandler(this.frm_ViPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViPham)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgvViPham;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonKhach;
        private System.Windows.Forms.RadioButton radioButtonChu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoiThuong;
        private System.Windows.Forms.TextBox txtBienPhap;
        private System.Windows.Forms.Label lblGiaPhong;
        private System.Windows.Forms.Label lblTienNuoc;
        private System.Windows.Forms.Label lblTienDien;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.TextBox txtMaViPham;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.Label lblMaKhach;
        private System.Windows.Forms.Label lblMaPhong;
        private System.Windows.Forms.Label lblNgayBatDau;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXuatFile;
        private System.Windows.Forms.Button btnHienDanhSach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaND;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaKhach;
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.Button btnLap;
        private System.Windows.Forms.DateTimePicker dtpNgayViPham;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonTimMaK;
        private System.Windows.Forms.RadioButton radioButtonNgayKT;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButtonHuy;
        private System.Windows.Forms.RadioButton radioButtonChua;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxDaHuy;
        private System.Windows.Forms.Button btnXacNhanHuy;
        private System.Windows.Forms.DateTimePicker dtpNgayHuy;
        private System.Windows.Forms.Label label5;
    }
}