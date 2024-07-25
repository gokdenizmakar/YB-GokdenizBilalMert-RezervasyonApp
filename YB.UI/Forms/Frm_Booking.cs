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

            FillDataGrid();
        }

        private void FillDataGrid()
        {
            //var bookings = bookingService.GetAllBookingAllDetail();
            //foreach (var item in bookings)
            //{
            //    dynamic booking = item;
            //    Guid bookingid=booking.BookingID;
            //}
            dgwBooking.DataSource = bookingService.GetAllBookingAllDetail();
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
                    grpMusteri.Enabled = false;
                    ClearGuestGroup();
                }
                FillRoomAndRoomType();
                if (cmbRoom.SelectedValue == null)
                {
                    grpMusteri.Enabled = false;
                    ClearGuestGroup();
                }
                if (lstGuest.Items.Count > Convert.ToInt32(nmrGuest.Value))
                {
                    //Eski değeridne kal!
                    nmrGuest.Value = maxindex;
                    grpMusteri.Enabled = false;
                    ClearGuestGroup();
                    throw new Exception("Kayıtlı misafir sayısı, belirtilen misafir sayısından fazla olamaz! Lütfen misafir siliniz!");
                }
                else if (lstGuest.Items.Count == Convert.ToInt32(nmrGuest.Value))
                {
                    maxindex = Convert.ToInt32(nmrGuest.Value);
                    grpMusteri.Enabled = false;
                    ClearGuestGroup();
                }
                else
                {
                    maxindex = Convert.ToInt32(nmrGuest.Value);
                    grpMusteri.Enabled = true;
                }

                if (nmrGuest.Value > lstGuest.Items.Count)
                {
                    maxindex = Convert.ToInt32(nmrGuest.Value);
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
                    var uygunRooms = bookingService.GetRoomByVisible((byte)nmrGuest.Value, DateOnly.FromDateTime(dtpCheckIn.Value), DateOnly.FromDateTime(dtpCheckOut.Value), seciliHotelid).ToList();
                    if (uygunRooms.Count == 0 )
                    {
                        cmbRoom.Text = "";
                        cmbRoomType.Text = "";
                        throw new Exception("Uygun oda bulunamadı!");
                    }
                    cmbRoomType.DisplayMember = "Name";
                    cmbRoomType.ValueMember = "RoomTypeID";
                    cmbRoomType.DataSource = uygunRooms;
                    //cmbRoomType.SelectedIndex = 1;
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
                if (selectedindex != -1)
                {
                    lstGuest.Items[selectedindex] = new Guest
                    {
                        Address = rtxtAdress.Text,
                        DateOfBirth = DateOnly.FromDateTime(dtpBirthDate.Value),
                        Email = txtMusteriEmail.Text,
                        FirstName = txtMusteriAd.Text,
                        LastName = txtMusteriSoyad.Text,
                        Phone = mskPhone.Text,
                        TC = mskTC.Text,
                    };
                    lstGuest.SelectedIndex = -1;
                    selectedindex = -1;
                    grpHotelList.Enabled = true;
                    grpBooking.Enabled = true;
                    btnBookingUpdate.Enabled = true;
                    btnBookingDelete.Enabled = true;
                    btnGuestUpdate.Enabled = true;
                    btnGuestDelete.Enabled = true;
                    updatingGuest = null;
                    if (nmrGuest.Value == lstGuest.Items.Count)
                    {
                        grpMusteri.Enabled = false;
                        ClearGuestGroup();
                    }

                }
                else
                {
                    while (guest.Count <= nowindex)
                    {
                        guest.Add(new Guest());
                    }

                    guest[nowindex] = new Guest
                    {
                        ID = Guid.NewGuid(),
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
                    if (nowindex == maxindex || nmrGuest.Value == lstGuest.Items.Count)
                    {
                        grpMusteri.Enabled = false;
                        ClearGuestGroup();
                    }
                }




            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ClearGuestGroup()
        {
            txtMusteriAd.Text = "";
            txtMusteriSoyad.Text = "";
            txtMusteriEmail.Text = "";
            mskPhone.Text = "";
            mskTC.Text = "";
            rtxtAdress.Text = "";
            dtpBirthDate.Value = DateTime.Now;
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

        private void btnGuestDelete_Click(object sender, EventArgs e)
        {
            if (lstGuest.SelectedIndex != -1)
            {
                lstGuest.Items.Remove(lstGuest.SelectedItem);
                if (nmrGuest.Value > lstGuest.Items.Count)
                {
                    grpMusteri.Enabled = true;
                }
            }
            else MessageBox.Show("Lütfen silinecek misafiri seçiniz!");
        }

        Guest updatingGuest = null;
        int selectedindex = -1;
        private void btnGuestUpdate_Click(object sender, EventArgs e)
        {
            if (lstGuest.SelectedIndex != -1)
            {
                //Güncellemek için verileri group boxa ata
                selectedindex = lstGuest.SelectedIndex;
                grpHotelList.Enabled = false;
                grpBooking.Enabled = false;
                grpMusteri.Enabled = true;
                btnBookingUpdate.Enabled = false;
                btnBookingDelete.Enabled = false;
                btnGuestDelete.Enabled = false;
                btnGuestUpdate.Enabled = false;
                updatingGuest = lstGuest.SelectedItem as Guest;
                txtMusteriAd.Text = updatingGuest.FirstName;
                txtMusteriSoyad.Text = updatingGuest.LastName;
                txtMusteriEmail.Text = updatingGuest.Email;
                mskPhone.Text = updatingGuest.Phone;
                mskTC.Text = updatingGuest.TC;
                rtxtAdress.Text = updatingGuest.Address;
                dtpBirthDate.Value = updatingGuest.DateOfBirth.ToDateTime(new TimeOnly(0, 0));
            }
            else MessageBox.Show("Lütfen güncellenecek misafiri seçiniz!");
        }

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            var room = (Room)cmbRoom.SelectedItem;
            lblTotalPrice.Text = room.PricePerNight * (dtpCheckOut.Value - dtpCheckIn.Value).Days + " TL";
            if (room != null) lblTotalPrice.Visible = true;
        }

        private void btnBookingSave_Click(object sender, EventArgs e)
        {
            try
            {
                var bookingroom = (Room)cmbRoom.SelectedItem;
                Booking booking = new Booking()
                {
                    CheckinDate = DateOnly.FromDateTime(dtpCheckIn.Value),
                    CheckoutDate = DateOnly.FromDateTime(dtpCheckOut.Value),
                    Guests = guest,
                    TotalPrice = bookingroom.PricePerNight * (dtpCheckOut.Value - dtpCheckIn.Value).Days,
                    RoomID = bookingroom.ID,
                };
                bookingService.Add(booking);
                ClearGuestGroup();
                seciliHotelid = default(Guid);
                dtpCheckIn.Value=DateTime.Now;
                dtpCheckOut.Value = DateTime.Now.AddDays(1);
                cmbRoom.Items.Clear();
                cmbRoomType.Items.Clear();
                nmrGuest.Value = 0;
                FillDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBookingDelete_Click(object sender, EventArgs e)
        {
           bookingService.Delete((Guid)dgwBooking.CurrentRow.Cells["BookingID"].Value);
            FillDataGrid();   
        }
    }
}
