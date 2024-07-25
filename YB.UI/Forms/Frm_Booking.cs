using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YB.Business.Abstractions;
using YB.Business.DependicyInjection.AutoFac;
using YB.Entities.Models;

namespace YB.UI.Forms
{
    public partial class Frm_Booking : Form
    {
        private readonly IGuestService guestService;
        private readonly IBookingService bookingService;
        private readonly IHotelService hotelService;
        private readonly IRoomService roomService;
        private readonly IRoomTypeService roomTypeService;

        public Frm_Booking()
        {
            InitializeComponent();

            //Dependicy Injection atamaları:
            hotelService = InstanceFactory.GetInstance<IHotelService>();
            guestService = InstanceFactory.GetInstance<IGuestService>();
            bookingService = InstanceFactory.GetInstance<IBookingService>();
            roomService = InstanceFactory.GetInstance<IRoomService>();
            roomTypeService = InstanceFactory.GetInstance<IRoomTypeService>();
        }

        private void Frm_Booking_Load(object sender, EventArgs e)
        {
            //Oda tipi validasyonu için gerekli.
            cmbRoomType.DataSource = null;

            //tarih seçim ayarları
            dtpCheckOut.MinDate = dtpCheckIn.Value;
            dtpCheckIn.MinDate = DateTime.Now;

            //kişi seçim ayarları
            nmrGuest.Minimum = 0;
            nmrGuest.Maximum = 4;
            grpMusteri.Enabled = false;

            //Hotel listesini doldur
            FillHotelList();

        }

        //Hotel Listesini Doldur.
        private void FillHotelList()
        {
            try
            {
                lstHotelList.DataSource = null;
                lstHotelList.DataSource = hotelService.GetAll().ToList();
                lstHotelList.DisplayMember = "Name";
                lstHotelList.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //işlem gören misafirler:
        List<Guest> guest = new List<Guest>();
        int maxindex = 0;
        int nowindex = 0;

        //Secilen hotelin idsi:
        Guid seciliHotelid = default(Guid);


        private void nmrGuest_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                if (nmrGuest.Value > 0 && seciliHotelid == default(Guid))
                {
                    MessageBox.Show("Lütfen hotel seçiniz!");
                    nmrGuest.Value = 0;
                }
                if (lstGuest.Items.Count> Convert.ToInt32(nmrGuest.Value))
                {
                    //Eski değeridne kal!
                    nmrGuest.Value = maxindex;
                    throw new Exception("Kayıtlı misafir sayısı, belirtilen misafir sayısından fazla olamaz! Lütfen misafir siliniz!");
                }
                else
                {
                maxindex = Convert.ToInt32(nmrGuest.Value);
                }
                //eğer index düşürülecekse listbox guest kontrol ettirim misafir sildirt yoksa düşürtme.

                FillRoomAndRoomType();
                if (cmbRoom.SelectedIndex != -1)
                {
                    grpMusteri.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        void FillRoomAndRoomType()
        {
            try
            {
                if (nmrGuest.Value > 0 && seciliHotelid != default(Guid))
                {
                    var uygunRooms = bookingService.GetRoomByVisible((byte)nmrGuest.Value, DateOnly.FromDateTime(dtpCheckIn.Value), DateOnly.FromDateTime(dtpCheckOut.Value), seciliHotelid);

                    cmbRoomType.DisplayMember = "Name";
                    cmbRoomType.ValueMember = "RoomTypeID";
                    cmbRoomType.DataSource = uygunRooms;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnGuestSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstGuest.Items.Count < maxindex)
                {
                    while (guest.Count <= nowindex)
                    {
                        guest.Add(new Guest());
                    }
                    guest[nowindex] = new Guest
                    {
                        Address = rtxtAdress.Text,
                        DateOfBirth = DateOnly.FromDateTime(dtpBirthDate.Value),
                        Email = txtMusteriEmail.Text,
                        FirstName = txtMusteriAd.Text,
                        LastName = txtMusteriSoyad.Text,
                        Phone = mskPhone.Text,
                        TC = mskTC.Text,
                    };
                    lstGuest.ValueMember = "ID";
                    lstGuest.DisplayMember = "FullName";
                    lstGuest.Items.Add(guest[nowindex]);
                    nowindex++;
                    if (nowindex==maxindex || nmrGuest.Value==lstGuest.Items.Count)
                    {
                        grpMusteri.Enabled = false;
                    }
                }
                else
                {
                    btnGuestSave.Enabled = false;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtHotelFiltre_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtHotelFiltre.Text.ToLower();

            if (!string.IsNullOrEmpty(searchText) && searchText.Length >= 3)
            {
                var pList = hotelService.GetAll().Where(p => p.Name.ToLower().Contains(searchText));

                lstHotelList.ValueMember = "Id";
                lstHotelList.DisplayMember = "ProductName";
                lstHotelList.DataSource = pList.ToList();
            }
            else if (searchText.Length == 0)
            {
                FillHotelList();
            }
        }

        private void lstHotelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillRoomAndRoomType();
        }
        private void lstHotelList_DoubleClick(object sender, EventArgs e)
        {
            seciliHotelid = (Guid)lstHotelList.SelectedValue;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var uygunodalar = roomService.GetAll().Where(x => x.RoomTypeID == (Guid)cmbRoomType.SelectedValue && x.HotelID == seciliHotelid).ToList();
                cmbRoom.DataSource = uygunodalar;
                cmbRoom.DisplayMember = "RoomNumber";
                cmbRoom.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            dtpCheckOut.MinDate = dtpCheckIn.Value.AddDays(1);
        }
    }
}
