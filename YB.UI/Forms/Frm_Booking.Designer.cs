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
            cmbRoom = new ComboBox();
            label15 = new Label();
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
            grpHotelList.SuspendLayout();
            grpMusteri.SuspendLayout();
            grpBooking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmrGuest).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgwBooking).BeginInit();
            SuspendLayout();
            // 
            // txtHotelFiltre
            // 
            txtHotelFiltre.Location = new Point(6, 44);
            txtHotelFiltre.Margin = new Padding(1);
            txtHotelFiltre.Name = "txtHotelFiltre";
            txtHotelFiltre.Size = new Size(266, 27);
            txtHotelFiltre.TabIndex = 0;
            txtHotelFiltre.TextChanged += txtHotelFiltre_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 21);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 1;
            label1.Text = "Hotel Filtre:";
            // 
            // grpHotelList
            // 
            grpHotelList.Controls.Add(lstHotelList);
            grpHotelList.Controls.Add(label1);
            grpHotelList.Controls.Add(txtHotelFiltre);
            grpHotelList.Location = new Point(9, 8);
            grpHotelList.Margin = new Padding(1);
            grpHotelList.Name = "grpHotelList";
            grpHotelList.Padding = new Padding(1);
            grpHotelList.Size = new Size(276, 275);
            grpHotelList.TabIndex = 2;
            grpHotelList.TabStop = false;
            grpHotelList.Text = "Hotel";
            // 
            // lstHotelList
            // 
            lstHotelList.FormattingEnabled = true;
            lstHotelList.Location = new Point(6, 72);
            lstHotelList.Margin = new Padding(1);
            lstHotelList.Name = "lstHotelList";
            lstHotelList.Size = new Size(266, 184);
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
            grpMusteri.Location = new Point(743, 8);
            grpMusteri.Margin = new Padding(1);
            grpMusteri.Name = "grpMusteri";
            grpMusteri.Padding = new Padding(1);
            grpMusteri.Size = new Size(376, 275);
            grpMusteri.TabIndex = 3;
            grpMusteri.TabStop = false;
            grpMusteri.Text = "Misafir";
            // 
            // btnGuestSave
            // 
            btnGuestSave.Location = new Point(117, 241);
            btnGuestSave.Margin = new Padding(1);
            btnGuestSave.Name = "btnGuestSave";
            btnGuestSave.Size = new Size(253, 28);
            btnGuestSave.TabIndex = 18;
            btnGuestSave.Text = "Kaydet";
            btnGuestSave.UseVisualStyleBackColor = true;
            btnGuestSave.Click += btnGuestSave_Click;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(117, 214);
            dtpBirthDate.Margin = new Padding(1);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(255, 27);
            dtpBirthDate.TabIndex = 13;
            // 
            // txtMusteriSoyad
            // 
            txtMusteriSoyad.Location = new Point(117, 48);
            txtMusteriSoyad.Margin = new Padding(1);
            txtMusteriSoyad.Name = "txtMusteriSoyad";
            txtMusteriSoyad.Size = new Size(255, 27);
            txtMusteriSoyad.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(56, 49);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 1;
            label3.Text = "Soyad:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 217);
            label8.Margin = new Padding(1, 0, 1, 0);
            label8.Name = "label8";
            label8.Size = new Size(106, 20);
            label8.TabIndex = 12;
            label8.Text = "Doğum Tarihi:";
            // 
            // rtxtAdress
            // 
            rtxtAdress.Location = new Point(117, 161);
            rtxtAdress.Margin = new Padding(1);
            rtxtAdress.Name = "rtxtAdress";
            rtxtAdress.Size = new Size(255, 45);
            rtxtAdress.TabIndex = 11;
            rtxtAdress.Text = "";
            // 
            // txtMusteriEmail
            // 
            txtMusteriEmail.Location = new Point(117, 132);
            txtMusteriEmail.Margin = new Padding(1);
            txtMusteriEmail.Name = "txtMusteriEmail";
            txtMusteriEmail.Size = new Size(255, 27);
            txtMusteriEmail.TabIndex = 10;
            // 
            // mskPhone
            // 
            mskPhone.Location = new Point(117, 103);
            mskPhone.Margin = new Padding(1);
            mskPhone.Mask = "0 (999) 000-0000";
            mskPhone.Name = "mskPhone";
            mskPhone.Size = new Size(255, 27);
            mskPhone.TabIndex = 9;
            // 
            // mskTC
            // 
            mskTC.Location = new Point(117, 74);
            mskTC.Margin = new Padding(1);
            mskTC.Mask = "00000000000";
            mskTC.Name = "mskTC";
            mskTC.Size = new Size(255, 27);
            mskTC.TabIndex = 8;
            mskTC.ValidatingType = typeof(int);
            // 
            // txtMusteriAd
            // 
            txtMusteriAd.Location = new Point(117, 19);
            txtMusteriAd.Margin = new Padding(1);
            txtMusteriAd.Name = "txtMusteriAd";
            txtMusteriAd.Size = new Size(255, 27);
            txtMusteriAd.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(60, 163);
            label7.Margin = new Padding(1, 0, 1, 0);
            label7.Name = "label7";
            label7.Size = new Size(52, 20);
            label7.TabIndex = 5;
            label7.Text = "Adres:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(46, 105);
            label6.Margin = new Padding(1, 0, 1, 0);
            label6.Name = "label6";
            label6.Size = new Size(63, 20);
            label6.TabIndex = 4;
            label6.Text = "Telefon:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(46, 134);
            label5.Margin = new Padding(1, 0, 1, 0);
            label5.Name = "label5";
            label5.Size = new Size(64, 20);
            label5.TabIndex = 3;
            label5.Text = "E-posta:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(82, 76);
            label4.Margin = new Padding(1, 0, 1, 0);
            label4.Name = "label4";
            label4.Size = new Size(29, 20);
            label4.TabIndex = 2;
            label4.Text = "TC:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(80, 21);
            label2.Margin = new Padding(1, 0, 1, 0);
            label2.Name = "label2";
            label2.Size = new Size(32, 20);
            label2.TabIndex = 0;
            label2.Text = "Ad:";
            // 
            // grpBooking
            // 
            grpBooking.Controls.Add(cmbRoom);
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
            grpBooking.Location = new Point(297, 8);
            grpBooking.Margin = new Padding(1);
            grpBooking.Name = "grpBooking";
            grpBooking.Padding = new Padding(1);
            grpBooking.Size = new Size(367, 138);
            grpBooking.TabIndex = 4;
            grpBooking.TabStop = false;
            grpBooking.Text = "Rezervasyon";
            // 
            // cmbRoom
            // 
            cmbRoom.FormattingEnabled = true;
            cmbRoom.Location = new Point(79, 76);
            cmbRoom.Margin = new Padding(2, 3, 2, 3);
            cmbRoom.Name = "cmbRoom";
            cmbRoom.Size = new Size(121, 28);
            cmbRoom.TabIndex = 12;
            cmbRoom.SelectedIndexChanged += cmbRoom_SelectedIndexChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(6, 81);
            label15.Margin = new Padding(1, 0, 1, 0);
            label15.Name = "label15";
            label15.Size = new Size(81, 20);
            label15.TabIndex = 11;
            label15.Text = "Oda Seçin:";
            // 
            // btnBookingSave
            // 
            btnBookingSave.Location = new Point(107, 103);
            btnBookingSave.Margin = new Padding(1);
            btnBookingSave.Name = "btnBookingSave";
            btnBookingSave.Size = new Size(231, 24);
            btnBookingSave.TabIndex = 10;
            btnBookingSave.Text = "Rezervasyonu Kaydet";
            btnBookingSave.UseVisualStyleBackColor = true;
            btnBookingSave.Click += btnBookingSave_Click;
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Location = new Point(308, 84);
            lblTotalPrice.Margin = new Padding(1, 0, 1, 0);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(57, 20);
            lblTotalPrice.TabIndex = 9;
            lblTotalPrice.Text = "label14";
            lblTotalPrice.Visible = false;
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.Location = new Point(253, 18);
            dtpCheckOut.Margin = new Padding(1);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(84, 27);
            dtpCheckOut.TabIndex = 8;
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            dtpCheckIn.Location = new Point(92, 18);
            dtpCheckIn.Margin = new Padding(1);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(78, 27);
            dtpCheckIn.TabIndex = 7;
            dtpCheckIn.ValueChanged += dtpCheckIn_ValueChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(205, 81);
            label13.Margin = new Padding(1, 0, 1, 0);
            label13.Name = "label13";
            label13.Size = new Size(104, 20);
            label13.TabIndex = 6;
            label13.Text = "Toplam Ücret:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(183, 24);
            label12.Margin = new Padding(1, 0, 1, 0);
            label12.Name = "label12";
            label12.Size = new Size(86, 20);
            label12.TabIndex = 5;
            label12.Text = "Çıkış Tarihi:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(19, 22);
            label11.Margin = new Padding(1, 0, 1, 0);
            label11.Name = "label11";
            label11.Size = new Size(85, 20);
            label11.TabIndex = 4;
            label11.Text = "Giriş Tarihi:";
            label11.Click += label11_Click;
            // 
            // cmbRoomType
            // 
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(253, 45);
            cmbRoomType.Margin = new Padding(1);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(84, 28);
            cmbRoomType.TabIndex = 3;
            cmbRoomType.SelectedIndexChanged += cmbRoomType_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(7, 47);
            label9.Margin = new Padding(1, 0, 1, 0);
            label9.Name = "label9";
            label9.Size = new Size(102, 20);
            label9.TabIndex = 0;
            label9.Text = "Misafir Sayısı:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(197, 47);
            label10.Margin = new Padding(1, 0, 1, 0);
            label10.Name = "label10";
            label10.Size = new Size(70, 20);
            label10.TabIndex = 2;
            label10.Text = "Oda Tipi:";
            // 
            // nmrGuest
            // 
            nmrGuest.Location = new Point(116, 45);
            nmrGuest.Margin = new Padding(1);
            nmrGuest.Name = "nmrGuest";
            nmrGuest.Size = new Size(79, 27);
            nmrGuest.TabIndex = 1;
            nmrGuest.ValueChanged += nmrGuest_ValueChanged;
            // 
            // lstGuest
            // 
            lstGuest.FormattingEnabled = true;
            lstGuest.Location = new Point(296, 152);
            lstGuest.Margin = new Padding(1);
            lstGuest.Name = "lstGuest";
            lstGuest.Size = new Size(366, 64);
            lstGuest.TabIndex = 5;
            // 
            // btnGuestUpdate
            // 
            btnGuestUpdate.Location = new Point(522, 218);
            btnGuestUpdate.Margin = new Padding(1);
            btnGuestUpdate.Name = "btnGuestUpdate";
            btnGuestUpdate.Size = new Size(140, 24);
            btnGuestUpdate.TabIndex = 11;
            btnGuestUpdate.Text = "Misafir Güncelle";
            btnGuestUpdate.UseVisualStyleBackColor = true;
            btnGuestUpdate.Click += btnGuestUpdate_Click;
            // 
            // btnGuestDelete
            // 
            btnGuestDelete.Location = new Point(384, 218);
            btnGuestDelete.Margin = new Padding(1);
            btnGuestDelete.Name = "btnGuestDelete";
            btnGuestDelete.Size = new Size(136, 24);
            btnGuestDelete.TabIndex = 12;
            btnGuestDelete.Text = "Misafir Sil";
            btnGuestDelete.UseVisualStyleBackColor = true;
            btnGuestDelete.Click += btnGuestDelete_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(297, 241);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(423, 20);
            label14.TabIndex = 13;
            label14.Text = "_____________________________________________________________________";
            // 
            // btnBookingUpdate
            // 
            btnBookingUpdate.Location = new Point(469, 260);
            btnBookingUpdate.Margin = new Padding(1);
            btnBookingUpdate.Name = "btnBookingUpdate";
            btnBookingUpdate.Size = new Size(180, 24);
            btnBookingUpdate.TabIndex = 15;
            btnBookingUpdate.Text = "Rezervasyon Güncelle";
            btnBookingUpdate.UseVisualStyleBackColor = true;
            btnBookingUpdate.Click += btnBookingUpdate_Click;
            // 
            // btnBookingDelete
            // 
            btnBookingDelete.Location = new Point(297, 260);
            btnBookingDelete.Margin = new Padding(1);
            btnBookingDelete.Name = "btnBookingDelete";
            btnBookingDelete.Size = new Size(169, 24);
            btnBookingDelete.TabIndex = 14;
            btnBookingDelete.Text = "Rezervasyon Sil";
            btnBookingDelete.UseVisualStyleBackColor = true;
            btnBookingDelete.Click += btnBookingDelete_Click;
            // 
            // dgwBooking
            // 
            dgwBooking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgwBooking.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwBooking.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwBooking.Location = new Point(15, 288);
            dgwBooking.Margin = new Padding(2, 3, 2, 3);
            dgwBooking.Name = "dgwBooking";
            dgwBooking.RowHeadersWidth = 51;
            dgwBooking.Size = new Size(1026, 243);
            dgwBooking.TabIndex = 16;
            // 
            // Frm_Booking
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1162, 549);
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
            Margin = new Padding(2, 3, 2, 3);
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
        private ComboBox cmbRoom;
        private Label label15;
    }
}