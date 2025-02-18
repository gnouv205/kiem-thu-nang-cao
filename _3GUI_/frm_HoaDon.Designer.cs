
namespace _3GUI_
{
    partial class frm_HoaDon
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
            this.btnThem = new System.Windows.Forms.Button();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.dgvDSHoaDon = new System.Windows.Forms.DataGridView();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtGiaPhong = new System.Windows.Forms.TextBox();
            this.txtTienNuoc = new System.Windows.Forms.TextBox();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.cbxMaKhach = new System.Windows.Forms.ComboBox();
            this.lblGiaPhong = new System.Windows.Forms.Label();
            this.lblTienNuoc = new System.Windows.Forms.Label();
            this.btnTongTien = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnChayLai = new System.Windows.Forms.Button();
            this.btnHienDanhSach = new System.Windows.Forms.Button();
            this.btnKhoiDong = new System.Windows.Forms.Button();
            this.btnSuaDon = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnXuatHD = new System.Windows.Forms.Button();
            this.lblTienDien = new System.Windows.Forms.Label();
            this.txtTienDien = new System.Windows.Forms.TextBox();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.lblMaKhach = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblNgayKetThuc = new System.Windows.Forms.Label();
            this.lblMaPhong = new System.Windows.Forms.Label();
            this.lblNgayBatDau = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtpNgayXuat = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.radioButtonChua = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonThu = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxDaThu = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHoaDon)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.White;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.Red;
            this.btnThem.Location = new System.Drawing.Point(207, 7);
            this.btnThem.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(190, 48);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm Hóa Đơn";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(190, 30);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtTongTien.Multiline = true;
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(252, 23);
            this.txtTongTien.TabIndex = 17;
            // 
            // dgvDSHoaDon
            // 
            this.dgvDSHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSHoaDon.Location = new System.Drawing.Point(20, 377);
            this.dgvDSHoaDon.Name = "dgvDSHoaDon";
            this.dgvDSHoaDon.ReadOnly = true;
            this.dgvDSHoaDon.RowHeadersWidth = 51;
            this.dgvDSHoaDon.RowTemplate.Height = 24;
            this.dgvDSHoaDon.Size = new System.Drawing.Size(1252, 247);
            this.dgvDSHoaDon.TabIndex = 0;
            this.dgvDSHoaDon.Click += new System.EventHandler(this.dgvDSHoaDon_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.Blue;
            this.lblTongTien.Location = new System.Drawing.Point(12, 30);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(97, 23);
            this.lblTongTien.TabIndex = 16;
            this.lblTongTien.Text = "Tổng tiền:";
            // 
            // txtGiaPhong
            // 
            this.txtGiaPhong.Location = new System.Drawing.Point(608, 86);
            this.txtGiaPhong.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtGiaPhong.Name = "txtGiaPhong";
            this.txtGiaPhong.ReadOnly = true;
            this.txtGiaPhong.Size = new System.Drawing.Size(252, 22);
            this.txtGiaPhong.TabIndex = 15;
            // 
            // txtTienNuoc
            // 
            this.txtTienNuoc.Location = new System.Drawing.Point(608, 53);
            this.txtTienNuoc.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtTienNuoc.Name = "txtTienNuoc";
            this.txtTienNuoc.Size = new System.Drawing.Size(252, 22);
            this.txtTienNuoc.TabIndex = 13;
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(190, 184);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(252, 27);
            this.dtpNgayKetThuc.TabIndex = 10;
            // 
            // cbxMaKhach
            // 
            this.cbxMaKhach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMaKhach.FormattingEnabled = true;
            this.cbxMaKhach.Location = new System.Drawing.Point(190, 59);
            this.cbxMaKhach.Name = "cbxMaKhach";
            this.cbxMaKhach.Size = new System.Drawing.Size(252, 24);
            this.cbxMaKhach.TabIndex = 6;
            this.cbxMaKhach.SelectedIndexChanged += new System.EventHandler(this.cbxMaKhach_SelectedIndexChanged);
            // 
            // lblGiaPhong
            // 
            this.lblGiaPhong.AutoSize = true;
            this.lblGiaPhong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaPhong.ForeColor = System.Drawing.Color.Blue;
            this.lblGiaPhong.Location = new System.Drawing.Point(458, 86);
            this.lblGiaPhong.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblGiaPhong.Name = "lblGiaPhong";
            this.lblGiaPhong.Size = new System.Drawing.Size(110, 23);
            this.lblGiaPhong.TabIndex = 14;
            this.lblGiaPhong.Text = "Giá Phòng: ";
            // 
            // lblTienNuoc
            // 
            this.lblTienNuoc.AutoSize = true;
            this.lblTienNuoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienNuoc.ForeColor = System.Drawing.Color.Blue;
            this.lblTienNuoc.Location = new System.Drawing.Point(458, 51);
            this.lblTienNuoc.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTienNuoc.Name = "lblTienNuoc";
            this.lblTienNuoc.Size = new System.Drawing.Size(106, 23);
            this.lblTienNuoc.TabIndex = 12;
            this.lblTienNuoc.Text = "Tiền Nước:";
            // 
            // btnTongTien
            // 
            this.btnTongTien.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTongTien.ForeColor = System.Drawing.Color.Red;
            this.btnTongTien.Location = new System.Drawing.Point(608, 9);
            this.btnTongTien.Name = "btnTongTien";
            this.btnTongTien.Size = new System.Drawing.Size(252, 48);
            this.btnTongTien.TabIndex = 7;
            this.btnTongTien.Text = "Tổng Tiền";
            this.btnTongTien.UseVisualStyleBackColor = true;
            this.btnTongTien.Click += new System.EventHandler(this.btnTongTien_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.White;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Red;
            this.btnThoat.Location = new System.Drawing.Point(6, 174);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(190, 48);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnChayLai
            // 
            this.btnChayLai.BackColor = System.Drawing.Color.White;
            this.btnChayLai.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChayLai.ForeColor = System.Drawing.Color.Red;
            this.btnChayLai.Location = new System.Drawing.Point(6, 117);
            this.btnChayLai.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnChayLai.Name = "btnChayLai";
            this.btnChayLai.Size = new System.Drawing.Size(190, 48);
            this.btnChayLai.TabIndex = 4;
            this.btnChayLai.Text = "Khởi Động Lại";
            this.btnChayLai.UseVisualStyleBackColor = false;
            this.btnChayLai.Click += new System.EventHandler(this.btnChayLai_Click);
            // 
            // btnHienDanhSach
            // 
            this.btnHienDanhSach.BackColor = System.Drawing.Color.White;
            this.btnHienDanhSach.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHienDanhSach.ForeColor = System.Drawing.Color.Red;
            this.btnHienDanhSach.Location = new System.Drawing.Point(6, 60);
            this.btnHienDanhSach.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnHienDanhSach.Name = "btnHienDanhSach";
            this.btnHienDanhSach.Size = new System.Drawing.Size(190, 48);
            this.btnHienDanhSach.TabIndex = 2;
            this.btnHienDanhSach.Text = "Hiện Danh Sách";
            this.btnHienDanhSach.UseVisualStyleBackColor = false;
            this.btnHienDanhSach.Click += new System.EventHandler(this.btnHienDanhSach_Click);
            // 
            // btnKhoiDong
            // 
            this.btnKhoiDong.BackColor = System.Drawing.Color.White;
            this.btnKhoiDong.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhoiDong.ForeColor = System.Drawing.Color.Red;
            this.btnKhoiDong.Location = new System.Drawing.Point(6, 7);
            this.btnKhoiDong.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnKhoiDong.Name = "btnKhoiDong";
            this.btnKhoiDong.Size = new System.Drawing.Size(190, 48);
            this.btnKhoiDong.TabIndex = 0;
            this.btnKhoiDong.Text = "Khởi Động";
            this.btnKhoiDong.UseVisualStyleBackColor = false;
            this.btnKhoiDong.Click += new System.EventHandler(this.btnKhoiDong_Click);
            // 
            // btnSuaDon
            // 
            this.btnSuaDon.BackColor = System.Drawing.Color.White;
            this.btnSuaDon.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaDon.ForeColor = System.Drawing.Color.Red;
            this.btnSuaDon.Location = new System.Drawing.Point(207, 60);
            this.btnSuaDon.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSuaDon.Name = "btnSuaDon";
            this.btnSuaDon.Size = new System.Drawing.Size(190, 47);
            this.btnSuaDon.TabIndex = 3;
            this.btnSuaDon.Text = "Sửa Hóa Đơn";
            this.btnSuaDon.UseVisualStyleBackColor = false;
            this.btnSuaDon.Click += new System.EventHandler(this.btnSuaDon_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.White;
            this.btnThanhToan.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.Red;
            this.btnThanhToan.Location = new System.Drawing.Point(207, 117);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(190, 48);
            this.btnThanhToan.TabIndex = 5;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnXoaHoaDon_Click);
            // 
            // btnXuatHD
            // 
            this.btnXuatHD.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatHD.ForeColor = System.Drawing.Color.Red;
            this.btnXuatHD.Location = new System.Drawing.Point(6, 237);
            this.btnXuatHD.Name = "btnXuatHD";
            this.btnXuatHD.Size = new System.Drawing.Size(392, 48);
            this.btnXuatHD.TabIndex = 6;
            this.btnXuatHD.Text = "Xuất File";
            this.btnXuatHD.UseVisualStyleBackColor = true;
            this.btnXuatHD.Click += new System.EventHandler(this.btnXuatHD_Click);
            // 
            // lblTienDien
            // 
            this.lblTienDien.AutoSize = true;
            this.lblTienDien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienDien.ForeColor = System.Drawing.Color.Blue;
            this.lblTienDien.Location = new System.Drawing.Point(458, 18);
            this.lblTienDien.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTienDien.Name = "lblTienDien";
            this.lblTienDien.Size = new System.Drawing.Size(99, 23);
            this.lblTienDien.TabIndex = 11;
            this.lblTienDien.Text = "Tiền Điện:";
            // 
            // txtTienDien
            // 
            this.txtTienDien.Location = new System.Drawing.Point(608, 21);
            this.txtTienDien.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtTienDien.Name = "txtTienDien";
            this.txtTienDien.Size = new System.Drawing.Size(252, 22);
            this.txtTienDien.TabIndex = 12;
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(190, 21);
            this.txtMaHD.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(252, 22);
            this.txtMaHD.TabIndex = 2;
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHD.ForeColor = System.Drawing.Color.Blue;
            this.lblMaHD.Location = new System.Drawing.Point(12, 21);
            this.lblMaHD.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(79, 23);
            this.lblMaHD.TabIndex = 1;
            this.lblMaHD.Text = "Mã HĐ:";
            // 
            // lblMaKhach
            // 
            this.lblMaKhach.AutoSize = true;
            this.lblMaKhach.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKhach.ForeColor = System.Drawing.Color.Blue;
            this.lblMaKhach.Location = new System.Drawing.Point(11, 60);
            this.lblMaKhach.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMaKhach.Name = "lblMaKhach";
            this.lblMaKhach.Size = new System.Drawing.Size(103, 23);
            this.lblMaKhach.TabIndex = 3;
            this.lblMaKhach.Text = "Mã Khách:";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.White;
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.Red;
            this.btnTimKiem.Location = new System.Drawing.Point(207, 174);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(190, 47);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Location = new System.Drawing.Point(190, 102);
            this.txtMaPhong.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.ReadOnly = true;
            this.txtMaPhong.Size = new System.Drawing.Size(252, 22);
            this.txtMaPhong.TabIndex = 4;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(608, 189);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(252, 22);
            this.txtTimKiem.TabIndex = 0;
            // 
            // lblNgayKetThuc
            // 
            this.lblNgayKetThuc.AutoSize = true;
            this.lblNgayKetThuc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayKetThuc.ForeColor = System.Drawing.Color.Blue;
            this.lblNgayKetThuc.Location = new System.Drawing.Point(11, 182);
            this.lblNgayKetThuc.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNgayKetThuc.Name = "lblNgayKetThuc";
            this.lblNgayKetThuc.Size = new System.Drawing.Size(145, 23);
            this.lblNgayKetThuc.TabIndex = 9;
            this.lblNgayKetThuc.Text = "Ngày Kết Thúc:";
            // 
            // lblMaPhong
            // 
            this.lblMaPhong.AutoSize = true;
            this.lblMaPhong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPhong.ForeColor = System.Drawing.Color.Blue;
            this.lblMaPhong.Location = new System.Drawing.Point(12, 102);
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
            this.lblNgayBatDau.Location = new System.Drawing.Point(11, 142);
            this.lblNgayBatDau.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.Size = new System.Drawing.Size(135, 23);
            this.lblNgayBatDau.TabIndex = 7;
            this.lblNgayBatDau.Text = "Ngày Bắt Đầu:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.dtpNgayXuat);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.dtpNgayBatDau);
            this.panel3.Controls.Add(this.txtTimKiem);
            this.panel3.Controls.Add(this.radioButtonChua);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.radioButtonThu);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtGiaPhong);
            this.panel3.Controls.Add(this.txtTienNuoc);
            this.panel3.Controls.Add(this.dtpNgayKetThuc);
            this.panel3.Controls.Add(this.cbxMaKhach);
            this.panel3.Controls.Add(this.lblGiaPhong);
            this.panel3.Controls.Add(this.lblTienNuoc);
            this.panel3.Controls.Add(this.lblTienDien);
            this.panel3.Controls.Add(this.txtTienDien);
            this.panel3.Controls.Add(this.txtMaHD);
            this.panel3.Controls.Add(this.lblMaHD);
            this.panel3.Controls.Add(this.txtMaPhong);
            this.panel3.Controls.Add(this.lblMaKhach);
            this.panel3.Controls.Add(this.lblNgayKetThuc);
            this.panel3.Controls.Add(this.lblMaPhong);
            this.panel3.Controls.Add(this.lblNgayBatDau);
            this.panel3.Location = new System.Drawing.Point(3, 55);
            this.panel3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(872, 223);
            this.panel3.TabIndex = 11;
            // 
            // dtpNgayXuat
            // 
            this.dtpNgayXuat.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayXuat.Location = new System.Drawing.Point(608, 150);
            this.dtpNgayXuat.Name = "dtpNgayXuat";
            this.dtpNgayXuat.Size = new System.Drawing.Size(252, 27);
            this.dtpNgayXuat.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(459, 150);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 23);
            this.label4.TabIndex = 23;
            this.label4.Text = "Ngày Xuất HD:";
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayBatDau.Location = new System.Drawing.Point(190, 142);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(252, 27);
            this.dtpNgayBatDau.TabIndex = 22;
            // 
            // radioButtonChua
            // 
            this.radioButtonChua.AutoSize = true;
            this.radioButtonChua.Location = new System.Drawing.Point(761, 117);
            this.radioButtonChua.Name = "radioButtonChua";
            this.radioButtonChua.Size = new System.Drawing.Size(99, 21);
            this.radioButtonChua.TabIndex = 20;
            this.radioButtonChua.TabStop = true;
            this.radioButtonChua.Text = "Chưa Thu";
            this.radioButtonChua.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(458, 188);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 23);
            this.label2.TabIndex = 21;
            this.label2.Text = "Tìm Kiếm";
            // 
            // radioButtonThu
            // 
            this.radioButtonThu.AutoSize = true;
            this.radioButtonThu.Location = new System.Drawing.Point(608, 117);
            this.radioButtonThu.Name = "radioButtonThu";
            this.radioButtonThu.Size = new System.Drawing.Size(82, 21);
            this.radioButtonThu.TabIndex = 19;
            this.radioButtonThu.TabStop = true;
            this.radioButtonThu.Text = "Đã Thu";
            this.radioButtonThu.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(458, 117);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 23);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tình Trạng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(575, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 43);
            this.label1.TabIndex = 18;
            this.label1.Text = "Hóa Đơn";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnKhoiDong);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.btnChayLai);
            this.panel1.Controls.Add(this.btnXuatHD);
            this.panel1.Controls.Add(this.btnHienDanhSach);
            this.panel1.Controls.Add(this.btnThanhToan);
            this.panel1.Controls.Add(this.btnSuaDon);
            this.panel1.Location = new System.Drawing.Point(875, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 289);
            this.panel1.TabIndex = 19;
            // 
            // checkBoxDaThu
            // 
            this.checkBoxDaThu.AutoSize = true;
            this.checkBoxDaThu.Location = new System.Drawing.Point(20, 350);
            this.checkBoxDaThu.Name = "checkBoxDaThu";
            this.checkBoxDaThu.Size = new System.Drawing.Size(151, 21);
            this.checkBoxDaThu.TabIndex = 20;
            this.checkBoxDaThu.Text = "Hóa Đơn Đã Thu";
            this.checkBoxDaThu.UseVisualStyleBackColor = true;
            this.checkBoxDaThu.CheckedChanged += new System.EventHandler(this.checkBoxDaThu_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTongTien);
            this.groupBox1.Controls.Add(this.txtTongTien);
            this.groupBox1.Controls.Add(this.btnTongTien);
            this.groupBox1.Location = new System.Drawing.Point(3, 286);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(871, 58);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tổng Tiền Cần Thanh Toán";
            // 
            // frm_HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1286, 633);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxDaThu);
            this.Controls.Add(this.dgvDSHoaDon);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frm_HoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Hóa Đơn";
            this.Load += new System.EventHandler(this.frm_HoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHoaDon)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.DataGridView dgvDSHoaDon;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtGiaPhong;
        private System.Windows.Forms.TextBox txtTienNuoc;
        private System.Windows.Forms.DateTimePicker dtpNgayKetThuc;
        private System.Windows.Forms.ComboBox cbxMaKhach;
        private System.Windows.Forms.Label lblGiaPhong;
        private System.Windows.Forms.Label lblTienNuoc;
        private System.Windows.Forms.Button btnTongTien;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnChayLai;
        private System.Windows.Forms.Button btnHienDanhSach;
        private System.Windows.Forms.Button btnKhoiDong;
        private System.Windows.Forms.Button btnSuaDon;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnXuatHD;
        private System.Windows.Forms.Label lblTienDien;
        private System.Windows.Forms.TextBox txtTienDien;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.Label lblMaKhach;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblNgayKetThuc;
        private System.Windows.Forms.Label lblMaPhong;
        private System.Windows.Forms.Label lblNgayBatDau;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonChua;
        private System.Windows.Forms.RadioButton radioButtonThu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxDaThu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpNgayBatDau;
        private System.Windows.Forms.DateTimePicker dtpNgayXuat;
        private System.Windows.Forms.Label label4;
    }
}