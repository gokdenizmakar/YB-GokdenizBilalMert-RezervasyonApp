namespace YB.UI.Forms
{
    partial class Frm_Booking
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
            txtHotelFiltre = new TextBox();
            label1 = new Label();
            grpHotelList = new GroupBox();
            lstHotelList = new ListBox();
            grpMusteri = new GroupBox();
            btnGuestSave = new Button();
            dtpBirthDate = new DateTimePicker();
            txtMusteriSoyad = new TextBox();
            label3 = new Label();
            label8 = new Label();
            rtxtAdress = new RichTextBox();
            txtMusteriEmail = new TextBox();
            mskPhone = new MaskedTextBox();
            mskTC = new MaskedTextBox();
            txtMusteriAd = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            grpBooking = new GroupBox();
            btnBookingSave = new Button();
            lblTotalPrice = new Label();
            dtpCheckOut = new DateTimePicker();
            dtpCheckIn = new DateTimePicker();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            cmbRoomType = new ComboBox();
            label9 = new Label();
            label10 = new Label();
            nmrGuest = new NumericUpDown();
            lstGuest = new ListBox();
            btnGuestUpdate = new Button();
            btnGuestDelete = new Button();
            label14 = new Label();
            btnBookingUpdate = new Button();
            btnBookingDelete = new Button();
            dgwBooking = new DataGridView();
            label15 = new Label();
            comboBox1 = new ComboBox();
            grpHotelList.SuspendLayout();
            grpMusteri.SuspendLayout();
            grpBooking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmrGuest).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgwBooking).BeginInit();
            SuspendLayout();
            // 
            // txtHotelFiltre
            // 
            txtHotelFiltre.Location = new Point(5, 44);
            txtHotelFiltre.Margin = new Padding(2);
            txtHotelFiltre.Name = "txtHotelFiltre";
            txtHotelFiltre.Size = new Size(266, 23);
            txtHotelFiltre.TabIndex = 0;
            txtHotelFiltre.TextChanged += txtHotelFiltre_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 21);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 1;
            label1.Text = "Hotel Filtre:";
            // 
            // grpHotelList
            // 
            grpHotelList.Controls.Add(lstHotelList);
            grpHotelList.Controls.Add(label1);
            grpHotelList.Controls.Add(txtHotelFiltre);
            grpHotelList.Location = new Point(9, 9);
            grpHotelList.Margin = new Padding(2);
            grpHotelList.Name = "grpHotelList";
            grpHotelList.Padding = new Padding(2);
            grpHotelList.Size = new Size(275, 275);
            grpHotelList.TabIndex = 2;
            grpHotelList.TabStop = false;
            grpHotelList.Text = "Hotel";
            // 
            // lstHotelList
            // 
            lstHotelList.FormattingEnabled = true;
            lstHotelList.ItemHeight = 15;
            lstHotelList.Location = new Point(5, 72);
            lstHotelList.Margin = new Padding(2);
            lstHotelList.Name = "lstHotelList";
            lstHotelList.Size = new Size(266, 199);
            lstHotelList.TabIndex = 2;
            lstHotelList.SelectedIndexChanged += lstHotelList_SelectedIndexChanged;
            lstHotelList.DoubleClick += lstHotelList_DoubleClick;
            // 
            // grpMusteri
            // 
            grpMusteri.Controls.Add(btnGuestSave);
            grpMusteri.Controls.Add(dtpBirthDate);
            grpMusteri.Controls.Add(txtMusteriSoyad);
            grpMusteri.Controls.Add(label3);
            grpMusteri.Controls.Add(label8);
            grpMusteri.Controls.Add(rtxtAdress);
            grpMusteri.Controls.Add(txtMusteriEmail);
            grpMusteri.Controls.Add(mskPhone);
            grpMusteri.Controls.Add(mskTC);
            grpMusteri.Controls.Add(txtMusteriAd);
            grpMusteri.Controls.Add(label7);
            grpMusteri.Controls.Add(label6);
            grpMusteri.Controls.Add(label5);
            grpMusteri.Controls.Add(label4);
            grpMusteri.Controls.Add(label2);
            grpMusteri.Location = new Point(669, 9);
            grpMusteri.Margin = new Padding(2);
            grpMusteri.Name = "grpMusteri";
            grpMusteri.Padding = new Padding(2);
            grpMusteri.Size = new Size(375, 275);
            grpMusteri.TabIndex = 3;
            grpMusteri.TabStop = false;
            grpMusteri.Text = "Misafir";
            // 
            // btnGuestSave
            // 
            btnGuestSave.Location = new Point(117, 242);
            btnGuestSave.Margin = new Padding(2);
            btnGuestSave.Name = "btnGuestSave";
            btnGuestSave.Size = new Size(254, 28);
            btnGuestSave.TabIndex = 18;
            btnGuestSave.Text = "Kaydet";
            btnGuestSave.UseVisualStyleBackColor = true;
            btnGuestSave.Click += btnGuestSave_Click;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(117, 214);
            dtpBirthDate.Margin = new Padding(2);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(254, 23);
            dtpBirthDate.TabIndex = 13;
            // 
            // txtMusteriSoyad
            // 
            txtMusteriSoyad.Location = new Point(117, 48);
            txtMusteriSoyad.Margin = new Padding(2);
            txtMusteriSoyad.Name = "txtMusteriSoyad";
            txtMusteriSoyad.Size = new Size(254, 23);
            txtMusteriSoyad.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 50);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 1;
            label3.Text = "Soyad:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(5, 217);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(83, 15);
            label8.TabIndex = 12;
            label8.Text = "Doğum Tarihi:";
            // 
            // rtxtAdress
            // 
            rtxtAdress.Location = new Point(117, 161);
            rtxtAdress.Margin = new Padding(2);
            rtxtAdress.Name = "rtxtAdress";
            rtxtAdress.Size = new Size(254, 45);
            rtxtAdress.TabIndex = 11;
            rtxtAdress.Text = "";
            // 
            // txtMusteriEmail
            // 
            txtMusteriEmail.Location = new Point(117, 131);
            txtMusteriEmail.Margin = new Padding(2);
            txtMusteriEmail.Name = "txtMusteriEmail";
            txtMusteriEmail.Size = new Size(254, 23);
            txtMusteriEmail.TabIndex = 10;
            // 
            // mskPhone
            // 
            mskPhone.Location = new Point(117, 103);
            mskPhone.Margin = new Padding(2);
            mskPhone.Mask = "0 (999) 000-0000";
            mskPhone.Name = "mskPhone";
            mskPhone.Size = new Size(254, 23);
            mskPhone.TabIndex = 9;
            // 
            // mskTC
            // 
            mskTC.Location = new Point(117, 74);
            mskTC.Margin = new Padding(2);
            mskTC.Mask = "00000000000";
            mskTC.Name = "mskTC";
            mskTC.Size = new Size(254, 23);
            mskTC.TabIndex = 8;
            mskTC.ValidatingType = typeof(int);
            // 
            // txtMusteriAd
            // 
            txtMusteriAd.Location = new Point(117, 19);
            txtMusteriAd.Margin = new Padding(2);
            txtMusteriAd.Name = "txtMusteriAd";
            txtMusteriAd.Size = new Size(254, 23);
            txtMusteriAd.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(59, 163);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(40, 15);
            label7.TabIndex = 5;
            label7.Text = "Adres:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(47, 105);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 4;
            label6.Text = "Telefon:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(47, 134);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(50, 15);
            label5.TabIndex = 3;
            label5.Text = "E-posta:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(82, 76);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(24, 15);
            label4.TabIndex = 2;
            label4.Text = "TC:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(80, 21);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(25, 15);
            label2.TabIndex = 0;
            label2.Text = "Ad:";
            // 
            // grpBooking
            // 
            grpBooking.Controls.Add(comboBox1);
            grpBooking.Controls.Add(label15);
            grpBooking.Controls.Add(btnBookingSave);
            grpBooking.Controls.Add(lblTotalPrice);
            grpBooking.Controls.Add(dtpCheckOut);
            grpBooking.Controls.Add(dtpCheckIn);
            grpBooking.Controls.Add(label13);
            grpBooking.Controls.Add(label12);
            grpBooking.Controls.Add(label11);
            grpBooking.Controls.Add(cmbRoomType);
            grpBooking.Controls.Add(label9);
            grpBooking.Controls.Add(label10);
            grpBooking.Controls.Add(nmrGuest);
            grpBooking.Location = new Point(297, 9);
            grpBooking.Margin = new Padding(2);
            grpBooking.Name = "grpBooking";
            grpBooking.Padding = new Padding(2);
            grpBooking.Size = new Size(366, 138);
            grpBooking.TabIndex = 4;
            grpBooking.TabStop = false;
            grpBooking.Text = "Rezervasyon";
            // 
            // btnBookingSave
            // 
            btnBookingSave.Location = new Point(106, 103);
            btnBookingSave.Margin = new Padding(2);
            btnBookingSave.Name = "btnBookingSave";
            btnBookingSave.Size = new Size(230, 24);
            btnBookingSave.TabIndex = 10;
            btnBookingSave.Text = "Rezervasyonu Kaydet";
            btnBookingSave.UseVisualStyleBackColor = true;
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Location = new Point(293, 82);
            lblTotalPrice.Margin = new Padding(2, 0, 2, 0);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(44, 15);
            lblTotalPrice.TabIndex = 9;
            lblTotalPrice.Text = "label14";
            lblTotalPrice.Visible = false;
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.Location = new Point(253, 18);
            dtpCheckOut.Margin = new Padding(2);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(83, 23);
            dtpCheckOut.TabIndex = 8;
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            dtpCheckIn.Location = new Point(93, 18);
            dtpCheckIn.Margin = new Padding(2);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(79, 23);
            dtpCheckIn.TabIndex = 7;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(204, 82);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(81, 15);
            label13.TabIndex = 6;
            label13.Text = "Toplam Ücret:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(184, 24);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(66, 15);
            label12.TabIndex = 5;
            label12.Text = "Çıkış Tarihi:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(20, 22);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(65, 15);
            label11.TabIndex = 4;
            label11.Text = "Giriş Tarihi:";
            label11.Click += label11_Click;
            // 
            // cmbRoomType
            // 
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(254, 45);
            cmbRoomType.Margin = new Padding(2);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(83, 23);
            cmbRoomType.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 47);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(79, 15);
            label9.TabIndex = 0;
            label9.Text = "Misafir Sayısı:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(196, 47);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(55, 15);
            label10.TabIndex = 2;
            label10.Text = "Oda Tipi:";
            // 
            // nmrGuest
            // 
            nmrGuest.Location = new Point(94, 44);
            nmrGuest.Margin = new Padding(2, 1, 2, 1);
            nmrGuest.Name = "nmrGuest";
            nmrGuest.Size = new Size(78, 23);
            nmrGuest.TabIndex = 1;
            nmrGuest.ValueChanged += nmrGuest_ValueChanged;
            // 
            // lstGuest
            // 
            lstGuest.FormattingEnabled = true;
            lstGuest.ItemHeight = 15;
            lstGuest.Location = new Point(296, 151);
            lstGuest.Margin = new Padding(2);
            lstGuest.Name = "lstGuest";
            lstGuest.Size = new Size(367, 64);
            lstGuest.TabIndex = 5;
            // 
            // btnGuestUpdate
            // 
            btnGuestUpdate.Location = new Point(525, 217);
            btnGuestUpdate.Margin = new Padding(2);
            btnGuestUpdate.Name = "btnGuestUpdate";
            btnGuestUpdate.Size = new Size(108, 24);
            btnGuestUpdate.TabIndex = 11;
            btnGuestUpdate.Text = "Misafir Güncelle";
            btnGuestUpdate.UseVisualStyleBackColor = true;
            // 
            // btnGuestDelete
            // 
            btnGuestDelete.Location = new Point(403, 217);
            btnGuestDelete.Margin = new Padding(2);
            btnGuestDelete.Name = "btnGuestDelete";
            btnGuestDelete.Size = new Size(108, 24);
            btnGuestDelete.TabIndex = 12;
            btnGuestDelete.Text = "Misafir Sil";
            btnGuestDelete.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(297, 241);
            label14.Name = "label14";
            label14.Size = new Size(352, 15);
            label14.TabIndex = 13;
            label14.Text = "_____________________________________________________________________";
            // 
            // btnBookingUpdate
            // 
            btnBookingUpdate.Location = new Point(469, 260);
            btnBookingUpdate.Margin = new Padding(2);
            btnBookingUpdate.Name = "btnBookingUpdate";
            btnBookingUpdate.Size = new Size(180, 24);
            btnBookingUpdate.TabIndex = 15;
            btnBookingUpdate.Text = "Rezervasyon Güncelle";
            btnBookingUpdate.UseVisualStyleBackColor = true;
            // 
            // btnBookingDelete
            // 
            btnBookingDelete.Location = new Point(297, 260);
            btnBookingDelete.Margin = new Padding(2);
            btnBookingDelete.Name = "btnBookingDelete";
            btnBookingDelete.Size = new Size(168, 24);
            btnBookingDelete.TabIndex = 14;
            btnBookingDelete.Text = "Rezervasyon Sil";
            btnBookingDelete.UseVisualStyleBackColor = true;
            // 
            // dgwBooking
            // 
            dgwBooking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgwBooking.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwBooking.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwBooking.Location = new Point(14, 289);
            dgwBooking.Name = "dgwBooking";
            dgwBooking.Size = new Size(1026, 243);
            dgwBooking.TabIndex = 16;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(5, 82);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(64, 15);
            label15.TabIndex = 11;
            label15.Text = "Oda Seçin:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(78, 76);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 12;
            // 
            // Frm_Booking
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1053, 539);
            Controls.Add(dgwBooking);
            Controls.Add(btnBookingUpdate);
            Controls.Add(btnBookingDelete);
            Controls.Add(label14);
            Controls.Add(btnGuestDelete);
            Controls.Add(btnGuestUpdate);
            Controls.Add(lstGuest);
            Controls.Add(grpBooking);
            Controls.Add(grpMusteri);
            Controls.Add(grpHotelList);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Name = "Frm_Booking";
            Text = "Frm_Booking";
            Load += Frm_Booking_Load;
            grpHotelList.ResumeLayout(false);
            grpHotelList.PerformLayout();
            grpMusteri.ResumeLayout(false);
            grpMusteri.PerformLayout();
            grpBooking.ResumeLayout(false);
            grpBooking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmrGuest).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgwBooking).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtHotelFiltre;
        private Label label1;
        private GroupBox grpHotelList;
        private ListBox lstHotelList;
        private GroupBox grpMusteri;
        private MaskedTextBox mskTC;
        private TextBox txtMusteriSoyad;
        private TextBox txtMusteriAd;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private DateTimePicker dtpBirthDate;
        private Label label8;
        private RichTextBox rtxtAdress;
        private TextBox txtMusteriEmail;
        private MaskedTextBox mskPhone;
        private Button btnGuestSave;
        private GroupBox grpBooking;
        private NumericUpDown nmrGuest;
        private Label label9;
        private ComboBox cmbRoomType;
        private Label label10;
        private Label lblTotalPrice;
        private DateTimePicker dtpCheckOut;
        private DateTimePicker dtpCheckIn;
        private Label label13;
        private Label label12;
        private Label label11;
        private Button btnBookingSave;
        private ListBox lstGuest;
        private Button btnGuestUpdate;
        private Button btnGuestDelete;
        private Label label14;
        private Button btnBookingUpdate;
        private Button btnBookingDelete;
        private DataGridView dgwBooking;
        private ComboBox comboBox1;
        private Label label15;
    }
}