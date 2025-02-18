
namespace _3GUI_
{
    partial class frm_ThongKeHoaDon
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
            this.dtpNgayXuat = new System.Windows.Forms.DateTimePicker();
            this.btnDaThu = new System.Windows.Forms.Button();
            this.dtgvDSHoaDon = new System.Windows.Forms.DataGridView();
            this.btnXuat = new System.Windows.Forms.Button();
            this.btnChuaThu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDSHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpNgayXuat
            // 
            this.dtpNgayXuat.Location = new System.Drawing.Point(213, 27);
            this.dtpNgayXuat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpNgayXuat.Name = "dtpNgayXuat";
            this.dtpNgayXuat.Size = new System.Drawing.Size(224, 27);
            this.dtpNgayXuat.TabIndex = 0;
            // 
            // btnDaThu
            // 
            this.btnDaThu.AutoSize = true;
            this.btnDaThu.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDaThu.ForeColor = System.Drawing.Color.Red;
            this.btnDaThu.Location = new System.Drawing.Point(686, 13);
            this.btnDaThu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDaThu.Name = "btnDaThu";
            this.btnDaThu.Size = new System.Drawing.Size(224, 57);
            this.btnDaThu.TabIndex = 1;
            this.btnDaThu.Text = "Xem Hóa Đơn Đã Thu";
            this.btnDaThu.UseVisualStyleBackColor = true;
            this.btnDaThu.Click += new System.EventHandler(this.btnDaThu_Click);
            // 
            // dtgvDSHoaDon
            // 
            this.dtgvDSHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvDSHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDSHoaDon.Location = new System.Drawing.Point(12, 81);
            this.dtgvDSHoaDon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgvDSHoaDon.Name = "dtgvDSHoaDon";
            this.dtgvDSHoaDon.RowHeadersWidth = 51;
            this.dtgvDSHoaDon.RowTemplate.Height = 24;
            this.dtgvDSHoaDon.Size = new System.Drawing.Size(1436, 350);
            this.dtgvDSHoaDon.TabIndex = 3;
            // 
            // btnXuat
            // 
            this.btnXuat.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.ForeColor = System.Drawing.Color.Red;
            this.btnXuat.Location = new System.Drawing.Point(1224, 13);
            this.btnXuat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(224, 57);
            this.btnXuat.TabIndex = 4;
            this.btnXuat.Text = "Xuất File ";
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // btnChuaThu
            // 
            this.btnChuaThu.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuaThu.ForeColor = System.Drawing.Color.Red;
            this.btnChuaThu.Location = new System.Drawing.Point(964, 13);
            this.btnChuaThu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChuaThu.Name = "btnChuaThu";
            this.btnChuaThu.Size = new System.Drawing.Size(224, 57);
            this.btnChuaThu.TabIndex = 5;
            this.btnChuaThu.Text = "Xem Hóa Đơn Chưa Thu";
            this.btnChuaThu.UseVisualStyleBackColor = true;
            this.btnChuaThu.Click += new System.EventHandler(this.btnChuaThu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(8, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Chọn Ngày Cần Xem:";
            // 
            // frm_ThongKeHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1472, 448);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnChuaThu);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.dtgvDSHoaDon);
            this.Controls.Add(this.btnDaThu);
            this.Controls.Add(this.dtpNgayXuat);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_ThongKeHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_ThongKeHoaDon";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDSHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpNgayXuat;
        private System.Windows.Forms.Button btnDaThu;
        private System.Windows.Forms.DataGridView dtgvDSHoaDon;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.Button btnChuaThu;
        private System.Windows.Forms.Label label2;
    }
}